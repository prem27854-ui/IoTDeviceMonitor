using System;
using System.Linq;
using System.Collections.Generic;
using Models;
using Utils;

namespace Services
{
    public class DeviceManager
    {
        private readonly StorageService _storage;
        private List<Device> _devices;

        public DeviceManager(StorageService storage)
        {
            _storage = storage;
            _devices = _storage.LoadDevices();
        }

        public bool AddDevice(Device device)
        {
            if (_devices.Any(d => d.Id == device.Id || d.IpAddress == device.IpAddress))
                return false;

            _devices.Add(device);
            _storage.SaveDevices(_devices);
            Logger.Log($"Device Added: {device.Id} - {device.Name}");
            return true;
        }

        public bool UpdateStatus(string id, string newStatus)
        {
            var device = _devices.FirstOrDefault(d => d.Id == id);
            if (device == null)
                return false;

            device.Status = newStatus;
            device.LastUpdated = DateTime.Now;
            _storage.SaveDevices(_devices);
            Logger.Log($"Status Updated: {id} → {newStatus}");
            return true;
        }

        public void ViewDevices()
        {
            Console.WriteLine("\n== All Devices ==");
            if (!_devices.Any())
            {
                Console.WriteLine("No devices found.");
                return;
            }
            foreach (var d in _devices)
                Console.WriteLine($"{d.Id} | {d.Name} | {d.IpAddress} | {d.Status} | Updated: {d.LastUpdated}");
        }

        public void LinearSearch(string keyword)
        {
            var results = new List<Device>();
            foreach (var d in _devices)
            {
                if (d.Id.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                    d.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                    d.IpAddress.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                    results.Add(d);
            }
            Console.WriteLine("\n== Search Results ==");
            if (!results.Any())
            {
                Console.WriteLine("No matches found.");
                return;
            }
            foreach (var d in results)
                Console.WriteLine($"{d.Id} | {d.Name} | {d.IpAddress} | {d.Status}");
        }

        public void BubbleSort(string field)
        {
            int n = _devices.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    bool swap = false;
                    switch (field.ToLower())
                    {
                        case "name":
                            if (string.Compare(_devices[j].Name, _devices[j + 1].Name) > 0) swap = true;
                            break;
                        case "ip":
                            if (string.Compare(_devices[j].IpAddress, _devices[j + 1].IpAddress) > 0) swap = true;
                            break;
                        case "status":
                            if (string.Compare(_devices[j].Status, _devices[j + 1].Status) > 0) swap = true;
                            break;
                        default:
                            Console.WriteLine("Invalid sort option.");
                            return;
                    }
                    if (swap)
                    {
                        var temp = _devices[j];
                        _devices[j] = _devices[j + 1];
                        _devices[j + 1] = temp;
                    }
                }
            }
            _storage.SaveDevices(_devices);
            Console.WriteLine("Devices sorted.");
        }

        public void FilterByStatus(string status)
        {
            var filtered = _devices.Where(d => d.Status.Equals(status, StringComparison.OrdinalIgnoreCase)).ToList();
            Console.WriteLine($"\n== Devices with Status: {status} ==");
            if (!filtered.Any())
            {
                Console.WriteLine("No devices found.");
                return;
            }
            foreach (var d in filtered)
                Console.WriteLine($"{d.Id} | {d.Name} | {d.IpAddress} | {d.Status}");
        }

        public void ExportAdvancedReport()
        {
            // ReportService.ExportAdvanced(_devices);
            Console.WriteLine("Advanced report saved as report.txt");
        }
    }
}


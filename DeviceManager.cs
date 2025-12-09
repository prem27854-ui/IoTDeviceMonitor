using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;

public class DeviceManager
{
    private List<Device> devices = new List<Device>();
    private string dataFile = "devices.json";

    public DeviceManager()
    {
        LoadData();
    }

    public void AddDevice(Device device)
    {
        if (devices.Any(d => d.Id == device.Id || d.IpAddress == device.IpAddress))
        {
            Console.WriteLine("Duplicate device detected. Not added.");
            return;
        }

        devices.Add(device);
        SaveData();
        Logger.Log($"Device added: {device.Id}, {device.Name}");
    }

    public void UpdateStatus(string id, string newStatus)
    {
        var device = devices.FirstOrDefault(d => d.Id == id);
        if (device == null)
        {
            Console.WriteLine("Device not found.");
            return;
        }

        device.Status = newStatus;
        SaveData();
        Logger.Log($"Status updated for {id}: {newStatus}");
    }

    public void ViewDevices()
    {
        foreach (var d in devices)
        {
            Console.WriteLine($"{d.Id} | {d.Name} | {d.IpAddress} | {d.Status}");
        }
    }

    public void Search(string keyword)
    {
        var results = devices.Where(d =>
            d.Id.Contains(keyword) ||
            d.Name.Contains(keyword) ||
            d.IpAddress.Contains(keyword)
        );

        foreach (var d in results)
        {
            Console.WriteLine($"{d.Id} | {d.Name} | {d.IpAddress} | {d.Status}");
        }
    }

    public void SortBy(string field)
    {
        if (field == "name")
            devices = devices.OrderBy(d => d.Name).ToList();
        else if (field == "ip")
            devices = devices.OrderBy(d => d.IpAddress).ToList();
        else if (field == "status")
            devices = devices.OrderBy(d => d.Status).ToList();

        ViewDevices();
    }

    public void ExportReport()
    {
        string report =
            $"Total Devices: {devices.Count}\n" +
            $"Online: {devices.Count(d => d.Status == "online")}\n" +
            $"Offline: {devices.Count(d => d.Status == "offline")}\n" +
            $"Maintenance: {devices.Count(d => d.Status == "maintenance")}\n\n";

        foreach (var d in devices)
        {
            report += $"{d.Id} | {d.Name} | {d.IpAddress} | {d.Status}\n";
        }

        File.WriteAllText("report.txt", report);
        Logger.Log("Report exported.");
        Console.WriteLine("Report saved to report.txt");
    }

    private void SaveData()
    {
        File.WriteAllText(dataFile, JsonSerializer.Serialize(devices));
    }

    private void LoadData()
    {
        if (File.Exists(dataFile))
        {
            string json = File.ReadAllText(dataFile);
            devices = JsonSerializer.Deserialize<List<Device>>(json);
        }
    }
}
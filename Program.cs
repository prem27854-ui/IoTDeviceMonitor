using System;
using Models;
using Services;

class Program
{
    static void Main()
    {
        var storage = new StorageService("devices.json");
        var manager = new DeviceManager(storage);

        while (true)
        {
            Console.WriteLine("\n== IoT Device Monitor ==");
            Console.WriteLine("1. Add Device");
            Console.WriteLine("2. Update Status");
            Console.WriteLine("3. View Devices");
            Console.WriteLine("4. Search Devices");
            Console.WriteLine("5. Sort Devices");
            Console.WriteLine("6. Filter by Status");
            Console.WriteLine("7. Export Report");
            Console.WriteLine("0. Exit");
            Console.Write("Choose: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("ID: ");
                    string id = Console.ReadLine() ?? "";
                    Console.Write("Name: ");
                    string name = Console.ReadLine() ?? "";
                    Console.Write("IP Address: ");
                    string ip = Console.ReadLine() ?? "";

                    bool added = manager.AddDevice(new Device
                    {
                        Id = id,
                        Name = name,
                        IpAddress = ip,
                        Status = "offline",
                        LastUpdated = DateTime.Now
                    });

                    Console.WriteLine(added ? "Device added." : "Device already exists!");
                    break;

                case "2":
                    Console.Write("Device ID: ");
                    string id2 = Console.ReadLine() ?? "";
                    Console.Write("New Status (online/offline/maintenance): ");
                    string status = Console.ReadLine() ?? "";

                    bool updated = manager.UpdateStatus(id2, status);
                    Console.WriteLine(updated ? "Status updated." : "Device not found.");
                    break;

                case "3":
                    manager.ViewDevices();
                    break;

                case "4":
                    Console.Write("Search keyword: ");
                    string keyword = Console.ReadLine() ?? "";
                    manager.LinearSearch(keyword);
                    break;

                case "5":
                    Console.Write("Sort by (name/ip/status): ");
                    manager.BubbleSort(Console.ReadLine() ?? "");
                    break;

                case "6":
                    Console.Write("Filter by status (online/offline/maintenance): ");
                    manager.FilterByStatus(Console.ReadLine() ?? "");
                    break;

                case "7":
                    manager.ExportAdvancedReport();
                    break;

                case "0":
                    return;
            }
        }
    }
}


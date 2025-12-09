using System;

class Program
{
    static void Main()
    {
        DeviceManager manager = new DeviceManager();

        while (true)
        {
            Console.WriteLine("\n== IoT Device Monitor ==");
            Console.WriteLine("1. Add Device");
            Console.WriteLine("2. Update Status");
            Console.WriteLine("3. View Devices");
            Console.WriteLine("4. Search");
            Console.WriteLine("5. Sort");
            Console.WriteLine("6. Export Report");
            Console.WriteLine("0. Exit");
            Console.Write("Choose: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("ID: ");
                    string id = Console.ReadLine();
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("IP Address: ");
                    string ip = Console.ReadLine();

                    manager.AddDevice(new Device
                    {
                        Id = id,
                        Name = name,
                        IpAddress = ip,
                        Status = "offline"
                    });
                    break;

                case "2":
                    Console.Write("Device ID: ");
                    string id2 = Console.ReadLine();
                    Console.Write("New Status (online/offline/maintenance): ");
                    string status = Console.ReadLine();

                    manager.UpdateStatus(id2, status);
                    break;

                case "3":
                    manager.ViewDevices();
                    break;

                case "4":
                    Console.Write("Search keyword: ");
                    manager.Search(Console.ReadLine());
                    break;

                case "5":
                    Console.Write("Sort by (name/ip/status): ");
                    manager.SortBy(Console.ReadLine());
                    break;

                case "6":
                    manager.ExportReport();
                    break;

                case "0":
                    return;
            }
        }
    }
}

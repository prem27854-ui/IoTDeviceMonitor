# IoT Device Monitor Application

This project is a **C# console-based IoT Device Monitor system**. The application is designed to simulate how IoT devices can be managed, monitored, and reported in a simple way. It follows **Object-Oriented Programming (OOP)** concepts and is built based on **Scenario 3** from the assignment.

The main goal of this project is to show understanding of C# programming, OOP structure, data handling, and basic algorithms without using external databases or complex frameworks.

---

## Features

* Add new IoT devices with details like ID, name, type, and status
* Update device status (Active / Inactive)
* Remove devices from the system
* Search devices using linear search algorithm
* Display all registered devices
* Generate basic and advanced reports
* Menu-driven console interface for easy use

---

## Technologies Used

* Language: C#
* Platform: .NET Console Application
* Programming Style: Object-Oriented Programming (OOP)

---

## Project Structure

```
IoT/
│
├── Models/
│   └── Device.cs
│
├── Services/
│   ├── DeviceManager.cs
│   └── ReportService.cs
│
├── Utils/
│   └── InputHelper.cs
│
├── Program.cs
├── IoTDeviceMonitor.csproj
└── README.md
```

---

## How to Run the Application

1. Open terminal and go to the root folder:

   ```bash
   cd IoT
   ```

2. Build the project:

   ```bash
   dotnet build
   ```

3. Run the application:

   ```bash
   dotnet run
   ```

---

## Design Approach

The application is divided into multiple classes to make the code easy to read and manage.

* **Device** class stores all device-related data
* **DeviceManager** handles adding, updating, deleting, and searching devices
* **ReportService** is responsible for generating reports
* **Program.cs** controls the menu and user interaction

Linear search is used when finding devices because the data is stored in a simple list and the logic is easy to understand.

---

## Limitations

* Data is stored only in memory
* No database or file storage used
* Console-based interface only
* No unit testing included in final version

---

## Future Improvements

* Add file or database storage
* Add sorting algorithms
* Improve reporting features
* Add user login system
* Convert to GUI or web application

---

## Conclusion

This IoT Device Monitor application successfully demonstrates basic IoT device management using C#. It shows proper use of OOP principles, clean project structure, and simple algorithms. The project meets the assignment requirements for Scenario 3 and provides a solid base for future improvement.

---

**Author:** prem
**Assignment:** 1

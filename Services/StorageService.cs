using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Models;

namespace Services
{
    public class StorageService
    {
        private readonly string _filePath;

        public StorageService(string filePath)
        {
            _filePath = filePath;

            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "[]");
            }
        }

        public List<Device> LoadDevices()
        {
            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Device>>(json) ?? new List<Device>();
        }

        public void SaveDevices(List<Device> devices)
        {
            var json = JsonSerializer.Serialize(devices);
            File.WriteAllText(_filePath, json);
        }
    }
}


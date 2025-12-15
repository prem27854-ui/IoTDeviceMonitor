using System.IO;
using System.Linq;
using Models;

namespace Services
{
    public static class ReportService
    {
        public static void ExportReport(List<Device> devices)
        {
            var lines = devices.Select(d => $"{d.Id},{d.Name},{d.IpAddress},{d.Status}");
            var content = string.Join("\n", lines);
            File.WriteAllText("report.txt", content);
        }
    }
}


using System.IO;
using System.Text.Json;

namespace WpfCounterApp.Services
{
    public class JsonCounterStorage
    {
        private const string FilePath = "counter.json";

        public int Load()
        {
            if (!File.Exists(FilePath)) return 0;

            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<int>(json);
        }

        public void Save(int value)
        {
            var json = JsonSerializer.Serialize(value);
            File.WriteAllText(FilePath, json);
        }
    }
}
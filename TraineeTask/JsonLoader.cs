using Newtonsoft.Json;

namespace TraineeTask
{
    public static class JsonLoader
    {
        public static List<T> LoadFromJson<T>(string filePath)
        {
            try
            {
                var json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<T>>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data: {ex.Message}");
                return new List<T>();
            }
        }
    }
}
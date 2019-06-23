using Windows.Storage;
using Newtonsoft.Json;

namespace CafeHit.Shared.Helpers
{
    public static class PersistenceHelper
    {
        public static T Deserialize<T>() where T : class
        {
            if (!ApplicationData.Current.LocalSettings.Values.TryGetValue(typeof(T).Name, out object vmJson))
            {
                return null;
            }

            try
            {
                return JsonConvert.DeserializeObject<T>(vmJson.ToString());
            }
            catch (JsonException)
            {
                Clear<T>();
                return null;
            }
        }

        public static void Serialize<T>(T vm) where T : class
        {
            ApplicationData.Current.LocalSettings.Values[typeof(T).Name] = JsonConvert.SerializeObject(vm);
        }

        public static void Clear<T>() where T : class
        {
            ApplicationData.Current.LocalSettings.Values[typeof(T).Name] = null;
        }
    }
}

 

namespace AutoBroswer.ViewModels
{
    public class ViewModelBase : ObservableObject
    {
        private string ConfigName = "appconfig.json";
        public AppConfig ReadLocalConfig()
        {     
            if (!File.Exists(ConfigName))
            {
                var appconfig = new AppConfig();
                File.WriteAllText(ConfigName, JsonSerializer.Serialize(appconfig));
                return appconfig;
            }
            var conf = File.ReadAllText(ConfigName);
            var config = JsonSerializer.Deserialize<AppConfig>(conf) ?? new AppConfig();

            return config;

        }
    }
}

namespace AutoBroswer.Models
{
    public class AppConfig
    {
        public bool IsShowBroswer { get; set; } 
        public bool IsUseLocalBroswer { get; set; }
        public string BroswerPath { get; set; }
        public string Language { get; set; }

        public bool IsRunFirstStart { get; set; }
        public int WaitSeconds { get; set; } = 0;

    }
}

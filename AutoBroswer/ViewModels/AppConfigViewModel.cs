
using System.Threading;

namespace AutoBroswer.ViewModels
{
    public partial class AppConfigViewModel : ViewModelBase
    {
        private string ConfigName = "appconfig.json";
        public AppConfigViewModel()
        {
            ReadConfig();
        }

        #region 绑定字段
        [ObservableProperty]
        private bool isShowBroswer;
        [ObservableProperty]
        private string broswerPath;
        [ObservableProperty]
        private string language;
        [ObservableProperty]
        private bool isUseLocalBroswer;
        [ObservableProperty]
        private bool isRunFirstStart;
        [ObservableProperty]
        private int waitSeconds;
        #endregion

        public AppConfig Config { get; set; }
        [ObservableProperty]
        private bool isDownloading;
        [RelayCommand]
        public async Task DownloadBroswerAsync()
        {
            IsDownloading = true;
            var NewBrowserFetcher = new BrowserFetcher();
            await NewBrowserFetcher.DownloadAsync();
            IsDownloading = false;
        }


        #region 处理本地文件
        [RelayCommand]
        public void OpenFileDialog()
        {
            WeakReferenceMessenger.Default.Send(new OpenFileDialogMessage
            {
                Sender = new WeakReference(this)
            });
        }

        /// <summary>
        /// 有改动时调用
        /// </summary>
        public void WriteConfig()
        {
            Config = new AppConfig()
            {
                BroswerPath = BroswerPath,
                Language = Language,
                IsShowBroswer = IsShowBroswer,
                IsUseLocalBroswer = IsUseLocalBroswer,
                IsRunFirstStart = IsRunFirstStart,
                WaitSeconds = WaitSeconds
            };
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
            File.WriteAllText(ConfigName, JsonSerializer.Serialize(Config, options));

        }
        private void ReadConfig()
        {
            Config = ReadLocalConfig();
            BroswerPath = Config.BroswerPath;
            Language = Config.Language;
            IsShowBroswer = Config.IsShowBroswer;
            IsUseLocalBroswer = Config.IsUseLocalBroswer;
            IsRunFirstStart = Config.IsRunFirstStart;
            WaitSeconds = Config.WaitSeconds;
        }
        #endregion



    }
}

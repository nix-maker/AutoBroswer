


namespace AutoBroswer.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {


        }
        public AppConfig Config { get; set; }

        [RelayCommand]
        public void OpenConfig()
        {
            WeakReferenceMessenger.Default.Send(new OpenAppConfigMessage
            {
                Sender = new WeakReference(this)
            });
        }


        public void SaveTask(TaskConfig taskConfig)
        {
            // 启动任务
        }

    }


}
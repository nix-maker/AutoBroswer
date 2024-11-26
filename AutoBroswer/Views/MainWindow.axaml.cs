namespace AutoBroswer.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            WeakReferenceMessenger.Default.Register<OpenAppConfigMessage>(this, (p, m) =>
            {
                var configWindow = new AppConfigWindow();
                configWindow.DataContext = new AppConfigViewModel();
                configWindow.ShowDialog(this);
            });

            WeakReferenceMessenger.Default.Register<CloseAppConfigMessage>(this, (p, m) =>
            {
                var vm = this.DataContext as MainWindowViewModel;
                vm.Config = (AppConfig)m.Data;
            });
        }
    }
}
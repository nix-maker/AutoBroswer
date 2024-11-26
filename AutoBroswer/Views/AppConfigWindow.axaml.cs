
namespace AutoBroswer;

public partial class AppConfigWindow : Window
{
    public AppConfigWindow()
    {
        InitializeComponent();
        this.Closed += AppConfigWindow_Closed;
        WeakReferenceMessenger.Default.Register<OpenFileDialogMessage>(this, async (p, m) =>
        {
            var storage = this.StorageProvider;
            var fileType = new FilePickerFileType("") { Patterns = new[] { "*.exe", } };
            var result = await storage.OpenFilePickerAsync(new Avalonia.Platform.Storage.FilePickerOpenOptions
            {
                AllowMultiple = false,
                FileTypeFilter = [fileType],
                Title = "Ñ¡Ôñä¯ÀÀÆ÷"
            });
            if (result.Count == 1)
            {
                var vm = this.DataContext as AppConfigViewModel;
                vm.BroswerPath = result.FirstOrDefault().Path.AbsolutePath.ToString();
            }

        });
    }

    private void AppConfigWindow_Closed(object? sender, EventArgs e)
    {
        var vm = this.DataContext as AppConfigViewModel;
        vm.WriteConfig();
        WeakReferenceMessenger.Default.Send(new CloseAppConfigMessage
        {
            Sender = new WeakReference(this),
            Data = vm.Config
        });
        this.Close();

    }
}
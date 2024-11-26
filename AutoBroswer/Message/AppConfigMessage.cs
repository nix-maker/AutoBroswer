 namespace AutoBroswer.Message
{
    public class OpenAppConfigMessage 
    {
        public WeakReference? Sender { set; get; }
    }
    public class CloseAppConfigMessage
    {
        public WeakReference? Sender { set; get; }

        public object Data { get; set; }
    }

    public class OpenFileDialogMessage
    {
        public WeakReference? Sender { set; get; }
    }
}

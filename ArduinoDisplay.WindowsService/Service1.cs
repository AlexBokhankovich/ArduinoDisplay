namespace ArduinoDisplay.WindowsService
{
    using System.ServiceProcess;

    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            this.InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
        }

        protected override void OnStop()
        {
        }
    }
}
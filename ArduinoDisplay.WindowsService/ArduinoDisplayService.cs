namespace ArduinoDisplay.WindowsService
{
    using System.ServiceProcess;

    using ArduinoDisplay.Core;

    public partial class ArduinoDisplayService : ServiceBase
    {
        private Bootstraper bs;

        public ArduinoDisplayService()
        {
            this.InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            this.bs = new Bootstraper();
            this.bs.Start();
        }

        protected override void OnStop()
        {
        }
    }
}

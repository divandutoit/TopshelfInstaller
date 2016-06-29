using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace TopshelfTesting
{
    [RunInstaller(true)]
    public class ProjectInstaller : Installer
    {
        private ServiceInstaller _serviceInstaller;

        private ServiceProcessInstaller _serviceProcessInstaller;

        public ProjectInstaller()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            this._serviceInstaller = new ServiceInstaller();
            _serviceProcessInstaller = new ServiceProcessInstaller();

            this._serviceProcessInstaller.Account = ServiceAccount.User;

            this._serviceInstaller.DisplayName = "TopshelfInstaller";
            this._serviceInstaller.ServiceName = "TopshelfInstaller";

            this.Installers.AddRange(new Installer[] { this._serviceProcessInstaller, this._serviceInstaller });
        }
    }
}

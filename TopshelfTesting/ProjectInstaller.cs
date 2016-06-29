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
    /// <summary>
    /// 
    /// Added this installer Class thats handles the Installe via WI installer.
    /// 
    /// </summary>

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

            ///
            ///the Display name and Service name should be the same names
            ///as the display and service name of the service in topshelf.
            ///

            this._serviceInstaller.DisplayName = "TopshelfInstaller"; 
            this._serviceInstaller.ServiceName = "TopshelfInstaller";

            this.Installers.AddRange(new Installer[] { this._serviceProcessInstaller, this._serviceInstaller });
        }
    }
}

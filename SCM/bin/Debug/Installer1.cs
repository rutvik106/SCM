using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Configuration;
using System.IO;
using System.ServiceProcess;
using Microsoft.Win32;



namespace SCM
{
    [RunInstaller(true)]
    
    public partial class Installer1 : Installer
    {

        

        public Installer1()
        {
            InitializeComponent();
        }
        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);
            
            //string targetDirectory = Context.Parameters["targetdir"];
            string param1 = Context.Parameters["Param1"];
            string id = Context.Parameters["mail_id"];
            string pwd=Context.Parameters["mail_pwd"];
            //Form2.pass = master_pass;
            //string exePath = Path.Combine(targetDirectory, "SCM.exe.config");
            //string exePath = string.Format("{0}SCM.exe", targetDirectory);
            string exeFilePath = this.Context.Parameters["assemblypath"];
            //string exePath = System.IO.Path.Combine(Environment.CurrentDirectory, "SCM.exe");
            // + "SCM.exe.config");
            Configuration config = ConfigurationManager.OpenExeConfiguration(exeFilePath);
            config.AppSettings.Settings["Param1"].Value = param1;
            config.AppSettings.Settings["mailid"].Value = id;
            config.AppSettings.Settings["mailpwd"].Value = pwd;
            config.AppSettings.Settings["location"].Value = exeFilePath;
            config.Save();


            /*ServiceInstaller si = new ServiceInstaller();
            ServiceProcessInstaller spi = new ServiceProcessInstaller();
            si.ServiceName = "SCMService";
            si.DisplayName = "scm";
            this.Installers.Add(si);
            spi.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            spi.Username = null;
            spi.Password = null;
            this.Installers.Add(spi);*/
            
            
        }
        protected override void OnBeforeUninstall(IDictionary savedState)
        {
            base.OnBeforeUninstall(savedState);

            try
            {
                string exeFilePath = this.Context.Parameters["assemblypath"];
                Configuration config = ConfigurationManager.OpenExeConfiguration(exeFilePath);
                SCM.Properties.Settings.Default.remember_me = false;
                SCM.Properties.Settings.Default.allowgen = false;
                SCM.Properties.Settings.Default.chk2 = false;
                SCM.Properties.Settings.Default.Save();
                config.AppSettings.Settings.Clear();
                config.Save();
                

                RegistryKey main = Registry.CurrentUser;
                RegistryKey software = main.OpenSubKey("SOFTWARE", true);
                RegistryKey rememberme = software.CreateSubKey("idpwd");
                rememberme.DeleteValue("id");
                rememberme.DeleteValue("pwd");
            }
            catch (Exception)
            {
                
            }
        }

        
        
    }
}

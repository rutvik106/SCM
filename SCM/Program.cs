using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ServiceProcess;
using System.Reflection;
using System.Threading;


namespace SCM
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Assembly asm = Assembly.GetExecutingAssembly();
            string guid = asm.GetType().GUID.ToString();

            using (Mutex mut = new Mutex(false, "Global\\" + guid))
            {
                if (!mut.WaitOne(0, false))
                {
                    
                    //MessageBox.Show("Application allready running!");
                    return;
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }

        }
    }
}

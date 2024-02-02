using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.Timers;
using System.Configuration;



namespace WindowsService1
{
    public partial class SCM : ServiceBase
    {       

        //public ServiceController service = new ServiceController("SCM Service");

        //private Timer timer = null;

        public Timer timer = null;

        //public Timer timer2 = null;

        //public Timer timer3 = null;

        //public string exeFilePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\SCM.exe";     //"C:\\Program Files\\106 Developers\\SCM System\\SCM.exe";



        //Configuration config1 = ConfigurationManager.OpenExeConfiguration(exeFilePath);

        public SCM()
        {
            
            InitializeComponent();

            //this.ServiceName="SCM";
           
            //timer = new Timer(10000);

            //timer2 = new Timer(20000);

            //timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);

            //timer2.Elapsed += new ElapsedEventHandler(timer2_Elapsed);

        }

        public void chk_db()
        {
            

            string connection_1;

            connection_1 = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\SCM_Database\\scm_main.mdf;Integrated Security=True;User Instance=True;Initial Catalog=scm_main;Trusted_Connection=Yes;Connect Timeout=3000";

            SqlConnection sql_con = new SqlConnection(connection_1);

            string exe_File_Path;

            exe_File_Path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\SCM.exe";

            try
            {

                string minval = "";

                Configuration app_config = ConfigurationManager.OpenExeConfiguration(exe_File_Path);                

                //minval = config.AppSettings.Settings["min_val"].Value;

                minval = app_config.AppSettings.Settings["min_val"].Value;

                string str = "";


                SqlCommand sql_cmd = new SqlCommand("SELECT item_name FROM inventory WHERE qty<='" + minval + "';", sql_con);

                sql_con.Open();


                SqlDataReader sql_rdr = sql_cmd.ExecuteReader();

                while (sql_rdr.Read() != false)
                {

                    str += sql_rdr.GetValue(0).ToString() + ", ";

                }

                app_config.AppSettings.Settings["low_item"].Value = str;

                //con.Close();

                app_config.Save();

                sql_con.Close();
                

                //timer.Stop();

                //service.Pause();

                timer = new Timer(20000);

                timer.Start();

            }
            catch (Exception ex)
            {
                
                EventLog.WriteEntry(this.ServiceName, "error:rutvik " + ex.ToString() + "conn=" + sql_con.ToString() + "path=" + exe_File_Path.ToString(), System.Diagnostics.EventLogEntryType.Warning);

                sql_con.Close();

            }


        }

        

        protected override void OnStart(string[] args)
        {
            // TODO: Add code here to start your service.
            timer = new Timer(10000);
            timer.Start();
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
        }

        public void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            timer.Stop();
            chk_db();
        }

        /*protected override void OnPause()
        {
            try
            {
                timer.Stop();

                
            }
            catch
            {

            }
            timer2 = new Timer(20000);
            timer2.Start();
            timer2.Elapsed += new ElapsedEventHandler(timer2_Elapsed);
        }
        
        void timer2_Elapsed(object sender, ElapsedEventArgs e)
        {
            service.Continue();
        }

        protected override void OnContinue()
        {
            timer2.Stop();
            timer3 = new Timer(10000);
            timer3.Start();
            timer3.Elapsed += new ElapsedEventHandler(timer3_Elapsed);
        }

        void timer3_Elapsed(object sender, ElapsedEventArgs e)
        {
            chk_db();
        }*/     

        
        protected override void OnStop()
        {
            
        }

    }

}

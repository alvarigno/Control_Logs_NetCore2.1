using System;

namespace Control_Logs_NetCore2._1
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> recibeip = new Lst<String>();
            string filename = "test";

            List<string> uno = new Lst<String>();
            string dos = uno.add("hola);

            createlog(uno,"hola", "trstv1")
        {
            Console.WriteLine("Hello World!");
        }


        /*Obtiene los datos del proceso de TBK para procesar la creación de log*/
        protected void createlog(List<string> recibeip, string tx_step, string filename)
        {

            string m_exePath = string.Empty;

            if (tx_step == "ipconsulta")
            {
                m_exePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory) + "\\logsrequest";
            }


            try
            {
                using (StreamWriter w = File.AppendText(m_exePath + "\\" + filename + "_log.txt"))
                {
                    Log(recibeip, w, tx_step);
                }
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("Error: " + ex.Message);
            }

        }

        /*Crear los log según corresponda, de acuerdo al stepname*/
        protected void Log(List<string> logMessage, TextWriter txtWriter, string stepname)
        {
            try
            {
                txtWriter.Write("\r\nLog Entry : ");
                txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                txtWriter.WriteLine("  :{0}", stepname);
                txtWriter.WriteLine("  :Request");
                txtWriter.WriteLine("-------------------------------");
                while(var data in logMessage){}
                    txtWriter.WriteLine("  :{0}", data);
                }
                txtWriter.WriteLine("-------------------------------");



            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("Error: " + ex.Message);
            }
        }

    }
}

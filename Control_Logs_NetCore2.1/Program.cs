using System;
using System.Collections.Generic;
using System.IO;

namespace Control_Logs_NetCore2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<string> data = new List<string>();

            string tx_step = Console.ReadLine();
            Console.WriteLine("Dato ingresado es: "+ tx_step);


            if (tx_step == "error-data") {

                data.Add("modelo");
                data.Add("marca");
                data.Add("version");
                data.Add("tipo techo");

                createlog(data, tx_step, "987654321_.xml", "12000089", "2019", "2556");

            }

            if (tx_step == "error-xml")
            {

                data.Add("Mensaje de error en XML");
                createlog(data, tx_step, "123456.xml", "987654321", "1546", "2556");

            }


           

            Console.WriteLine("Para salir presione cualquier tecla.");
            Console.ReadKey();


        }


        /*Obtiene los datos del proceso de TBK para procesar la creación de log*/
        protected static void createlog(List<string> contenido, string tx_step, string filename, string idorigen, string sucursal, string idsucursalxkey)
        {

            string m_exePath = string.Empty;
            m_exePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory) + "\\logsrequest\\"+idsucursalxkey;

            if (!Directory.Exists(m_exePath))
            {
                DirectoryInfo di = Directory.CreateDirectory(m_exePath);
            }


            try { 


                    using (StreamWriter w = File.AppendText(m_exePath + "\\" + filename + "_"+ tx_step +".txt"))
                    {
                        Log(contenido, w, tx_step, idorigen, sucursal);
                    }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        /*Crear los log según corresponda, de acuerdo al stepname*/
        protected static void Log(List<string> logMessage, TextWriter txtWriter, string stepname, string idorigen, string sucursal)
        {
            try
            {
                txtWriter.Write("\r\nLog Entry : ");
                txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                txtWriter.WriteLine("{0}","Datos Procesados ");
                txtWriter.WriteLine("  {0}", "idorigen: "+idorigen);
                txtWriter.WriteLine("  {0}", "Sucursal: " + sucursal);
                txtWriter.WriteLine("{0}", stepname);
                txtWriter.WriteLine("-------------------------------");
                foreach (var text in logMessage) {

                    txtWriter.WriteLine("  {0}","Error: "+ text);

                }

                txtWriter.WriteLine("-------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BotOMat.Domain
{
    public static class Json
    {

        public static string ReadJson(string path)
        {
            try
            {
                using (StreamReader file = new StreamReader(path))
                {
                    var json = file.ReadToEnd();
                    file.Close();
                    return json;
                } 
          
            }
            catch
            {
                MessageBox.Show("Error","File not found");
            }

       

            return null;
        }
    }
}

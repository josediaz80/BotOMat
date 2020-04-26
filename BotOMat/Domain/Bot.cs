using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotOMat
{
    class Bot
    {
        public int Place { get; set; }
        public string Name { get; set; }

        public string Type { get; set; }
        
        public int CountTask { get; set; }

        public List<Task> ListTask { get; set; }


        public Bot(string name, string typeRobot ,List<Task> list)
        {
           
            Name = name;
            Type = typeRobot;
            ListTask = list;
            CountTask = 0;
        }


      

    }
}

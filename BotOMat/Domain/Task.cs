using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotOMat
{
    public class Task
    {
        public string Description { get; set; }

        public int Time { get; set; }

        public Task(string description,int eta)
        {
           Description = description;
           Time = eta;            
        }

        public override string ToString() => $"{Description.ToUpper()} ({Time.ToString()})";


    }
}

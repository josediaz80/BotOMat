using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotOMat.Domain
{
    class TypeRobot
    {

        public string Type{ get; set; }

        public TypeRobot(string type)
        {
            Type = type;
        
        }


        public override string ToString() => Type;
       
    }
}

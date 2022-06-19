using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TwitchBot.Commands
{
    public class Command
    {
        public string CommandName { get; set; }
        public Command(string name)
        {
            CommandName = name;         
        }
        public virtual void CallFunction(string name, string param)
        {
           
        }
        public virtual string GetMessage(string name, string param)
        {
            return "";
        }
    } 

    public class Lurk : Command
    {
        public Lurk(string name) : base(name)
        {

        }

        public override string GetMessage(string name, string param)
        {
            return $"{name} está lurkando!!";
        }


    }
    public class Brb : Command
    {
        public Brb(string name) : base(name) 
        {      
        }

        public override string GetMessage(string name, string param)
        {
            if (string.IsNullOrEmpty(param))
            {
                return $"{name} disse que ja volta!";
            }
            else
            {
                return $"{name} disse que ja volta pois está {param}!";
            }
                
            
        }
    }


    public static class CommandList
    {
        public static List<Command> commands = new List<Command>();          

        public static void AddNewCommand(string name)
        {
            var command = new Command(name);

            commands.Add(command);
          
        }
    }

}

using System.Reflection;
using TwitchBot.Commands;
namespace TwitchBot
{
    class Program
    {
        static void Main(string[] args)
        {

            var lurk = new Lurk("lurk");
            CommandList.commands.Add(lurk);

            var brb = new Brb("brb");
            CommandList.commands.Add(brb);

            Bot bot = new Bot();
            bot.Connect(true);
            Console.ReadLine();
        }       

    }


}
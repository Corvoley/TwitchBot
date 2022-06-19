using TwitchBot.Commands;
using TwitchBot.Resources;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;

namespace TwitchBot
{
    internal class Bot
    {

        ConnectionCredentials credentials = new ConnectionCredentials(TwitchInfo.ChannelName, TwitchInfo.BotToken);
        TwitchClient client;
        internal void Connect(bool isLogging)
        {
            client = new TwitchClient();
            client.Initialize(credentials, TwitchInfo.ChannelName);

            if (isLogging)
            {
                client.OnLog += Client_OnLog;
            }
            client.Connect();

            client.OnError += Client_OnError;
            client.OnMessageReceived += Client_OnMessageReceived;
            client.OnChatCommandReceived += Client_OnChatCommandReceived;            


        }

        private void Client_OnChatCommandReceived(object? sender, OnChatCommandReceivedArgs e)
        {
            foreach (var item in CommandList.commands)
            {
                if (item.CommandName == e.Command.CommandText.ToLower())
                {
                    var name = e.Command.ChatMessage.Username;
                    var arg = e.Command.ArgumentsAsString;
                    item.CallFunction(name, arg);                   
                    client.SendMessage(TwitchInfo.ChannelName, item.GetMessage(name, arg));                 
                    

                }
            }
        }

        private void Client_OnMessageReceived(object? sender, OnMessageReceivedArgs e)
        {
            
        }

        private void Client_OnError(object? sender, TwitchLib.Communication.Events.OnErrorEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Client_OnLog(object? sender, OnLogArgs e)
        {
            Console.WriteLine(e.Data);
        }

        internal void Disconnect()
        {
            client.Disconnect();
        }
    }
}
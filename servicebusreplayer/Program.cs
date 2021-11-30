using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Hosting;
using servicebusreplayer.Models;
using servicebusreplayer.Services;

namespace servicebusreplayer
{
    class Program
    {
        static List<QueueAlias> queueAliases = new List<QueueAlias>();
        static QueueClientFactory _queueClientFactory;
        static async Task Main(string[] args)
        {

            //DEBUG: print cli args
            // foreach (var cliArg in args)
            // {
            //     Console.WriteLine(cliArg);
            // }

            using IHost host = CreateHostBuilder(args).Build();

            //DI services and stuff
            _queueClientFactory = new QueueClientFactory();

            //TODO: parse input and do stuff...
            var command = args[1];
            var parsedAlias = args[2];

            //TODO: load aliases from file... to seed alias list

            //this is not final version, this helps get the MVP working...
            switch (command)
            {
                //peek mesagges on dlq
                case "list":
                {
                    //var queueAlias = queueAliases.First(qa => qa.AliasName == parsedAlias);
                    //TODO: this factor will create a connected queue client, by alias
                    var queueClient = _queueClientFactory.Create(parsedAlias);
                    
                    var dlqMessages = await queueClient.PeekDlqMessages();
                    break;
                }

                //resubmit messages from dlq
                case "resubmit":
                {
                    var queueClient = _queueClientFactory.Create(parsedAlias);
                    await queueClient.FixAndResubmitDlqMessages();

                    break;
                }
                
                //register an alias
                case "register":
                {
                    var connectionString = args[3];
                    var queueAlias = new QueueAlias { AliasName = parsedAlias, ConnectionString = connectionString };
                    queueAliases.Add(queueAlias);
                    Console.WriteLine($"Registered alias: {queueAlias.AliasName} for {queueAlias.ConnectionString}");
                    break;
                }
                
                default:
                    Console.WriteLine("Help docs...");
                    break;
            }

            await host.RunAsync();
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args);
    }


}

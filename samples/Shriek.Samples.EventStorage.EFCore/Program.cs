﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shriek.Commands;
using Shriek.EventStorage.EFCore;
using Shriek.Samples.Commands;
using System;

namespace Shriek.Sample.EventStorage.EFCore
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var services = new ServiceCollection();
            var connectionStringBuilder = new Microsoft.Data.Sqlite.SqliteConnectionStringBuilder { DataSource = "shriek.event.db" };
            var connectionString = connectionStringBuilder.ToString();

            services.AddShriek(option => option.UseEFCoreEventStorage(options => options.UseSqlite(connectionString)));

            var container = services.BuildServiceProvider();

            var bus = container.GetService<ICommandBus>();

            var id = Guid.NewGuid();

            bus.Send(new CreateTodoCommand(id)
            {
                Name = "get up",
                Desception = "good day",
                FinishTime = DateTime.Now.AddDays(1)
            });

            Console.WriteLine($"{nameof(CreateTodoCommand)} sended!");

            bus.Send(new ChangeTodoCommand(id)
            {
                Name = "eat breakfast",
                Desception = "yummy!",
                FinishTime = DateTime.Now.AddDays(1)
            });

            Console.WriteLine($"{nameof(ChangeTodoCommand)} sended!");

            bus.Send(new ChangeTodoCommand(id)
            {
                Name = "go to work",
                Desception = "fighting!",
                FinishTime = DateTime.Now.AddDays(1)
            });
            Console.WriteLine($"{nameof(ChangeTodoCommand)} sended!");

            bus.Send(new ChangeTodoCommand(id)
            {
                Name = "call boss",
                Desception = "haha!",
                FinishTime = DateTime.Now.AddDays(1)
            });
            Console.WriteLine($"{nameof(ChangeTodoCommand)} sended!");

            bus.Send(new ChangeTodoCommand(id)
            {
                Name = "coding",
                Desception = "great!",
                FinishTime = DateTime.Now.AddDays(1)
            });
            Console.WriteLine($"{nameof(ChangeTodoCommand)} sended!");

            bus.Send(new ChangeTodoCommand(id)
            {
                Name = "drive car",
                Desception = "be careful!",
                FinishTime = DateTime.Now.AddDays(-1)
            });
            Console.WriteLine($"{nameof(ChangeTodoCommand)} sended!");

            Console.ReadKey();
        }
    }
}
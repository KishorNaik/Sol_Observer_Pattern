using Sol_Demo.Business.Notifier;
using Sol_Demo.Business.Observer;
using Sol_Demo.Cores;
using Sol_Demo.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sol_Demo
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // List of Investors
            List<IObserver> observersInvestors = new List<IObserver>();
            observersInvestors.Add(new InvestorA());
            observersInvestors.Add(new InvestorB());

            // Stock Price Changed
            ISamsungStockTrigger samsungStockTrigger = new SamsungStockTrigger(new SamsungStockNotifier(), observersInvestors);
            await samsungStockTrigger.ChangePriceAsync(new StockPriceModel() { Price = 12.50 });

            // It will notify to all investores when Stock Price Changed.

            // Stock Price Changed
            samsungStockTrigger = new SamsungStockTrigger(new SamsungStockNotifier(), observersInvestors);
            await samsungStockTrigger.ChangePriceAsync(new StockPriceModel() { Price = 15.50 });
        }
    }
}
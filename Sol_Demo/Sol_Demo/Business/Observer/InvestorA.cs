using Sol_Demo.Cores;
using Sol_Demo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sol_Demo.Business.Observer
{
    public class InvestorA : IObserver
    {
        Task IObserver.GetUpdatePrice(StockPriceModel stockPriceModel)
        {
            Console.WriteLine($"Investor A :{stockPriceModel.Price}");
            return Task.CompletedTask;
        }
    }
}
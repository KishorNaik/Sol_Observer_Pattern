using Sol_Demo.Cores;
using Sol_Demo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sol_Demo.Business.Notifier
{
    public interface ISamsungStockNotifier : INotify
    {
        Task NotifyAsync(StockPriceModel stockPriceModel);
    }

    public sealed class SamsungStockNotifier : ISamsungStockNotifier
    {
        public event EventHandler<Action<List<IObserver>>> OnNotify;

        Task ISamsungStockNotifier.NotifyAsync(StockPriceModel stockPriceModel)
        {
            return Task.Run(() =>
            {
                OnNotify?.Invoke(this, (listObserver) =>
                {
                    listObserver.ForEach((observer) => observer.GetUpdatePrice(stockPriceModel));
                });
            });
        }
    }
}
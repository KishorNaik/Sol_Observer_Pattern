using Sol_Demo.Cores;
using Sol_Demo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sol_Demo.Business.Notifier
{
    public interface ISamsungStockTrigger
    {
        Task ChangePriceAsync(StockPriceModel stockPriceModel);
    }

    public sealed class SamsungStockTrigger : ISamsungStockTrigger
    {
        private readonly ISamsungStockNotifier samsungStockNotifier = null;
        private readonly List<IObserver> listInvestors = null;

        public SamsungStockTrigger(ISamsungStockNotifier samsungStockNotifier, List<IObserver> listInvestors)
        {
            this.samsungStockNotifier = samsungStockNotifier;
            this.listInvestors = listInvestors;
        }

        async Task ISamsungStockTrigger.ChangePriceAsync(StockPriceModel stockPriceModel)
        {
            //this.samsungStockNotifier.OnNotify += SamsungStockNotifier_OnNotify;

            EventHandler<Action<List<IObserver>>> @event = (sender, notifyToInvestors) => notifyToInvestors.Invoke(this.listInvestors);

            // Subscribe event
            this.samsungStockNotifier.OnNotify += @event;

            await this.samsungStockNotifier.NotifyAsync(stockPriceModel);

            // UnSubscribe event
            this.samsungStockNotifier.OnNotify -= @event;
        }

        //private void SamsungStockNotifier_OnNotify(object sender, Action<List<IObserver>> notifyToInvestors)
        //{
        //    // Notify to All Investors
        //    notifyToInvestors.Invoke(this.listInvestors);
        //}
    }
}
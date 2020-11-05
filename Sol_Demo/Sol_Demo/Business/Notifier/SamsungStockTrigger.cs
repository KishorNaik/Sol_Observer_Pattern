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
            try
            {
                this.samsungStockNotifier.OnNotify += SamsungStockNotifier_OnNotify;
                await this.samsungStockNotifier.NotifyAsync(stockPriceModel);
            }
            finally
            {
                this.samsungStockNotifier.OnNotify -= SamsungStockNotifier_OnNotify;
            }
        }

        private void SamsungStockNotifier_OnNotify(object sender, Action<List<IObserver>> e)
        {
            // Notify to All Investors
            e.Invoke(this.listInvestors);
        }
    }
}
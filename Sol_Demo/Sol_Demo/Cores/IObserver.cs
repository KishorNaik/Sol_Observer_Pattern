﻿using Sol_Demo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sol_Demo.Cores
{
    public interface IObserver
    {
        Task GetUpdatePrice(StockPriceModel stockPriceModel);
    }
}
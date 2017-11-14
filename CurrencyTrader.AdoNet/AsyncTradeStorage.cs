using CurrencyTrader.AdoNet;
using CurrencyTrader.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibilityPrinciple.AdoNet
{
    public class AsyncTradeStorage : ITradeStorage
    {
        private readonly ILogger logger;
        private ITradeStorage SyncTradeStorage;

        public AsyncTradeStorage(ILogger logger)
        {
            this.logger = logger;
            SyncTradeStorage = new AdoNetTradeStorage(logger);
        }

        public void Persist(IEnumerable<TradeRecord> trades)
        {
            logger.LogInfo("Starting async storage");
            Task.Run(() =>
                SyncTradeStorage.Persist(trades)
            );
        }
    }
}

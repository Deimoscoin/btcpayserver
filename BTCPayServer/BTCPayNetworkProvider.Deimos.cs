using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BTCPayServer.Services.Rates;
using NBitcoin;
using NBXplorer;

namespace BTCPayServer
{
    public partial class BTCPayNetworkProvider
    {
        public void InitDeimos()
        {
            var nbxplorerNetwork = NBXplorerNetworkProvider.GetFromCryptoCode("DEI");
            Add(new BTCPayNetwork()
            {
                CryptoCode = nbxplorerNetwork.CryptoCode,
                DisplayName = "Deimos",
                BlockExplorerLink = NetworkType == NetworkType.Mainnet ? "https://deimos.network/tx/{0}" : "https://deimos.network/tx/{0}",
                NBitcoinNetwork = nbxplorerNetwork.NBitcoinNetwork,
                NBXplorerNetwork = nbxplorerNetwork,
                UriScheme = "deimos",
                DefaultRateRules = new[] 
                {
                                "DEI_X = DEI_BTC * BTC_X",
                                "DEI_BTC = zaif(DEI_BTC)"
                },
                CryptoImagePath = "imlegacy/deimos.png",
                LightningImagePath = "imlegacy/deimos-lightning.png",
                DefaultSettings = BTCPayDefaultSettings.GetDefaultSettings(NetworkType),
                CoinType = NetworkType == NetworkType.Mainnet ? new KeyPath("1'") : new KeyPath("1'")
            });
        }
    }
}

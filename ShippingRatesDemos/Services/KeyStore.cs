using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingRatesDemos.Services
{
    public static class KeyStore
    {
        private const string ApiKeyName = "ShippoApiKey";

        public static Task SaveAsync(string key) =>
            SecureStorage.SetAsync(ApiKeyName, key);

        public static Task<string?> GetAsync() =>
            SecureStorage.GetAsync(ApiKeyName);
    }
}

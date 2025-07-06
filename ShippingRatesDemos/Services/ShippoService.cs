using Shippo;
using Shippo.Models.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingRatesDemos.Services
{
    public class ShippoService : IShippoService
    {
        private readonly ShippoSDK _sdk;

        public ShippoService(string apiKey)
        {
            _sdk = new ShippoSDK(
                apiKeyHeader: apiKey,
                shippoApiVersion: "201802-08");
        }

        public Task<Address> CreateAddressAsync(AddressCreateRequest req) =>
            _sdk.Addresses.CreateAsync(req);
    }
}

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
                shippoApiVersion: "2018-02-08");
        }

        public Task<Address> CreateAddressAsync(AddressCreateRequest req) =>
            _sdk.Addresses.CreateAsync(req);

        public async Task<Shipment> CreateShipmentAsync(ShipmentCreateRequest req)
        {
            return await _sdk.Shipments.CreateAsync(req);          // Rates are inside the response
        }

        public Task<IReadOnlyList<Rate>> GetRatesAsync(string shipmentId)
        {
            throw new NotImplementedException();
        }

        public async Task<AddressPaginatedList> ListAddressesAsync(int max = 20)
        {
            AddressPaginatedList page = await _sdk.Addresses.ListAsync(results: max);

            return page;
        }
    }
}

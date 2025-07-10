using Shippo.Models.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingRatesDemos.Services
{
    public interface IShippoService
    {
        Task<Address> CreateAddressAsync(AddressCreateRequest req);
        Task<Shipment> CreateShipmentAsync(ShipmentCreateRequest req);
        Task<IReadOnlyList<Rate>> GetRatesAsync(string shipmentId);
        Task<AddressPaginatedList> ListAddressesAsync(int limit = 20);

    }
}

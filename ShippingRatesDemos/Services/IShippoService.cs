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
        // other calls(GetRatesAsync, BuyLabelAsync, etc.)
    }
}

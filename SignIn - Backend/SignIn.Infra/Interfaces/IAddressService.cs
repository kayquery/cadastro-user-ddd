using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignIn.Domain.Entities;

namespace SignIn.Infra.Interfaces
{
    public interface IAddressService
    {
        Task<Address> GetAddress(string zipcode);
    }
}
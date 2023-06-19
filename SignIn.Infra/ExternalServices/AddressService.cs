using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Amazon.Runtime.Internal;
using MongoDB.Driver;
using SignIn.Domain.Entities;
using SignIn.Infra.Interfaces;
using System.Net;
using SignIn.Domain.Models;

namespace SignIn.Infra.ExternalServices
{
    public class AddressService : IAddressService
    {
        private HttpClient _httpClient;

        public AddressService(ViaCEPSettings settings)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(settings.BaseUrl);
        }

        public async Task<Address> GetAddress(string zipCode)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync(zipCode+"/json");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<Address>(await httpResponseMessage.Content.ReadAsStringAsync());
            }
            
            if (httpResponseMessage.StatusCode == HttpStatusCode.InternalServerError)   
                throw new Exception("Error ao conetar com servidor externo");

            return null;
        }
    }
}
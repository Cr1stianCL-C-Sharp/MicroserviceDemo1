using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using VirtualMind.Core.Entities;
using VirtualMind.Infrastructure.IExtServices;

namespace VirtualMind.Infrastructure.ExtServices
{
    public class CurrencyAdapterService : ICurrencyAdapterService
    {


        private static readonly HttpClient _httpClient = new HttpClient();

        public CurrencyAdapterService()
        { }


        public async Task<CurrencyEntity> GetUpdatedUSDCurrency(string url)
        {
            try
            {   /*La cotización del dólar se obtendrá del siguiente servicio externo:http://www.bancoprovincia.com.ar/Principal/Dolar.*/

                CurrencyEntity currency = new CurrencyEntity();
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                var response = await _httpClient.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    await using var responseStream = await response.Content.ReadAsStreamAsync();
                    var list = await JsonSerializer.DeserializeAsync<List<string>>(responseStream);
                    //getting info from array
                    currency.Informal = Convert.ToDecimal(list[0]);
                    currency.Observed = Convert.ToDecimal(list[1]);
                    currency.Information = list[2];
                }
                return currency;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}

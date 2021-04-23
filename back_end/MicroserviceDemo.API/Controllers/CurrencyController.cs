using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualMind.API.Config;
using VirtualMind.Application.IServices;
using VirtualMind.Core.Enums;


namespace VirtualMind.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {


        public ICurrencyService CurrencyService { get; set; }

        private readonly List<EndpointsConfig> _endpointsConfigs;

        public CurrencyController(ICurrencyService currencyService, List<EndpointsConfig> endpointsConfigs)
        {
            Log.Information("CurrencyController Called");
            CurrencyService = currencyService;
            _endpointsConfigs = endpointsConfigs;

        }


        [HttpGet]
        public async Task<IActionResult> GetCurrency(Currency currency)
        {
            try
            {
                Log.Information("CurrencyController:::GetCurrency:::{currency}", currency);
                if (!ModelState.IsValid)
                {
                    Log.Warning("CurrencyController Empty Currency");
                    return BadRequest("Currency is Empty");
                }

                var uri = _endpointsConfigs.Find(x => x.Name == "USDCurrency_Endpoint");
                var result = await CurrencyService.ObtainCurrencyQuote(uri.Endpoint, currency);

                Log.Information("Success {@output}", result);
                return Ok(new { status = "success", data = result });
            }
            catch (Exception e)
            {
                Log.Error("CurrencyController Error::: {@exception}", e);
                return StatusCode(500);
            }


        }

    }
}

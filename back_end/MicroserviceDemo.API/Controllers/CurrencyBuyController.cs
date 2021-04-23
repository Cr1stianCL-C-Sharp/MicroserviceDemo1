using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Threading.Tasks;
using VirtualMind.Application.Dtos;
using VirtualMind.Application.IServices;


namespace VirtualMind.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyBuyController : ControllerBase
    {


        public ICurrencyBuyService BuyService { get; set; }


        public CurrencyBuyController(ICurrencyBuyService buyService)
        {
            BuyService = buyService;
        }

        /*         
           un servicio que realice una compra de una moneda. Dados un id de usuario, monto a comprar
           en pesos argentinos e identificador de moneda, el endpoint realizará una transacción que
           almacenará en la base de datos dicha compra registrando el usuario y los montos
           comprados en la unidad de la moneda (dólar o real)        
         
         */


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CurrencyBuyDto currencyDto)
        {

            try
            {
                Log.Information("Post Called");
                //if (!ModelState.IsValid)
                //{
                //    Log.Warning("CurrencyController Empty Currency");
                //    return BadRequest("Currency is Empty");
                //}
                var result = await BuyService.CurrencyBuyTransaction(currencyDto);
                Log.Information("Post Result: {@result}", result);

                return Ok(new { status = "success", Data = result });
            }
            catch (Exception e)
            {
                Log.Error("CurrencyController Error::: {@exception}", e);
                return StatusCode(500);
            }


        }
    }
}

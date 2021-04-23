using AutoMapper;
using FluentAssertions;
using Moq;
using System.Threading.Tasks;
using VirtualMind.Application.Dtos;
using VirtualMind.Application.Services;
using VirtualMind.Infrastructure.IRepository;
using Xunit;

namespace VirtualMind.Test.Services.Currency
{
    public class CurrencyServiceTest
    {


        [Fact]
        public async Task ObtainCurrencyAsyncQuoteOK()
        {
            //expected response
            var eResponse = new CurrencyDto()
            {
                Informal = 99500,
                Observed = 105500,
                Information = "string info"
            };

            var mockCurrencyRepository = new Mock<ICurrencyRepository>();
            var mockMapper = new Mock<IMapper>();

            var service = new CurrencyService(mockCurrencyRepository.Object, mockMapper.Object);


            var reponseService = await service.ObtainCurrencyQuote(It.IsAny<string>(), It.IsAny<Core.Enums.Currency>());


            var information = reponseService.Information;
            information.Should().StartWith("Hi").And.EndWith("!");


            //assertions
            Assert.True(reponseService.Informal < 200000);
            Assert.True(reponseService.Informal > 0);
            Assert.True(reponseService.Observed < 200000);
            Assert.True(reponseService.Informal > 0);
            Assert.NotEmpty(reponseService.Information);



        }

    }
}

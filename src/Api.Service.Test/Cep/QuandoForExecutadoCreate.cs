using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Cep;
using Api.Domain.Interfaces.Services.Municipio;
using Api.Service.Test.Municipio;
using Moq;
using Xunit;

namespace Api.Service.Test.Cep
{
    public class QuandoForExecutadoCreate : CepTestes
    {
        private ICepService _service;
        private Mock<ICepService> _serviceMock;

        [Fact(DisplayName = "É Possivel executar o Método Create.")]
        public async Task E_Possivel_Executar_Metodo_Create()
        {
            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.Post(cepDtoCreate)).ReturnsAsync(cepDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(cepDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(CepOriginal, result.Cep);
            Assert.Equal(LogradouroOriginal, result.Logradouro);
            Assert.Equal(NumeroOriginal, result.Numero);

        }
    }
}

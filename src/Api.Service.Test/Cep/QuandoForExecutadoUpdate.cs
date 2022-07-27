using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Cep;
using Api.Service.Test.Municipio;
using Moq;
using Xunit;

namespace Api.Service.Test.Cep
{
    public class QuandoForExecutadoUpdate : CepTestes
    {
        private ICepService _service;
        private Mock<ICepService> _serviceMock;

        [Fact(DisplayName = "É Possivel executar o Método Update.")]
        public async Task E_Possivel_Executar_Metodo_Update()
        {
            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.Put(cepDtoUpdate)).ReturnsAsync(cepDtoUpdateResult);
            _service = _serviceMock.Object;

            var resultUpdate = await _service.Put(cepDtoUpdate);
            Assert.NotNull(resultUpdate);
            Assert.Equal(CepAlterado, resultUpdate.Cep);
            Assert.Equal(LogradouroAlterado, resultUpdate.Logradouro);
            Assert.Equal(NumeroAlterado, resultUpdate.Numero);

        }
    }
}

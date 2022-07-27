using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Municipio;
using Moq;
using Xunit;

namespace Api.Service.Test.Municipio
{
    public class QuandoForExecutadoGetCompleteById : MunicipioTestes
    {
        private IMunicipioService _service;
        private Mock<IMunicipioService> _serviceMock;

        [Fact(DisplayName = "É Possivel Executar o Método GET Complete By Id.")]
        public async Task E_Possivel_Executar_Metodo_Get_Complete_by_Id()
        {
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m => m.GetCompleteById(IdMunicipio)).ReturnsAsync(municipioDtoCompleto);
            _service = _serviceMock.Object;

            var result = await _service.GetCompleteById(IdMunicipio);
            Assert.NotNull(result);
            Assert.True(result.Id == IdMunicipio);
            Assert.Equal(NomeMunicipio, result.Nome);
            Assert.Equal(CodigoIBGEMunicipio, result.CodIBGE);
            Assert.NotNull(result.Uf);
        }
    }
}

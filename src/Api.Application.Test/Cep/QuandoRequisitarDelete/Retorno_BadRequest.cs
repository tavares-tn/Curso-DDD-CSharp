using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Interfaces.Services.Cep;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Cep.QuandoRequisitarDelete
{
    public class Retorno_BadRequest
    {
        private CepsController _controller;

        [Fact(DisplayName = "É possível Realizar o Deleted.")]
        public async Task E_Possivel_Invocar_a_Controller_Delete()
        {
            var serviceMock = new Mock<ICepService>();
            serviceMock.Setup(m => m.Delete(It.IsAny<Guid>()))
                       .ReturnsAsync(true);

            _controller = new CepsController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato Inválido");

            var result = await _controller.Delete(Guid.NewGuid());
            Assert.True(result is BadRequestObjectResult);
        }
    }
}

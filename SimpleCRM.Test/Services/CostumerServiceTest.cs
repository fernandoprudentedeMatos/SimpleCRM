using SimpleCRM.Models;
using SimpleCRM.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SimpleCRM.Test.Services
{
    public class CostumerServiceTest
    {
        //ATENCAO Eder, PODIA TER USAR RhinoMock, mas queria mostrar o conhecimento de abstracao :)
        //FIz apenas um metodo que precisa de utilizar o Stub, fazendo sentido a abstração
        [Fact]
        public void QuandoExcluiClienteInexistente()
        {
            var repositoryStub = new CostumerRepositoryStub();
            var service = new CostumerService(repositoryStub);
            var mensagemEsperada = "Cliente inexistente para exclusão.";
            string idExistente = "01";

            var exception = Assert.Throws<InvalidServiceRequestException>(() => service.Remove(idExistente));
            Assert.Equal(mensagemEsperada, exception.Message);

        }
    }
}

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
        //ATENCAO Eder, PODIA TER USADO RhinoMock, mas queria mostrar o conhecimento de abstracao :)
        //SEGUINDO TDD, os testes com "caminho feliz" deveriam ser prioridade, seguindo os que seguem caminhos alternativos .. mas apenas exemplos abaixo
        //FIz apenas um metodo que precisa de utilizar o Stub, fazendo sentido a abstração
        [Fact]
        public void ExcecaoQuandoExcluiClienteInexistente()
        {
            var repositoryStub = new CostumerRepositoryStub();
            var service = new CostumerService(repositoryStub);            
            string idExistente = "01";

            var mensagemEsperada = "Cliente inexistente para exclusão.";

            var exception = Assert.Throws<InvalidServiceRequestException>(() => service.Remove(idExistente));
            Assert.Equal(mensagemEsperada, exception.Message);

        }

        [Fact]
        public void ExcecaoQuandoInsiroClienteNulo()
        {
            var repositoryStub = new CostumerRepositoryStub();
            var service = new CostumerService(repositoryStub);
            CostumerModel costumer = null;

            var mensagemEsperada = "Cliente deve ser informado.";

            var exception = Assert.Throws<InvalidServiceRequestException>(() => service.Insert(costumer));
            Assert.Equal(mensagemEsperada, exception.Message);

        }

        [Fact]
        public void ExcecaoQuandoInsiroClienteSemNome()
        {
            var repositoryStub = new CostumerRepositoryStub();
            var service = new CostumerService(repositoryStub);
            CostumerModel costumer = new CostumerModel {  Email = "fsdf@fdf.com", Endereco = "ddsf dsf dsf ds fsdfsdf sdfdsff sdfd"};

            var mensagemEsperada = "Nome de cliente deve ser informado";

            var exception = Assert.Throws<InvalidServiceRequestException>(() => service.Insert(costumer));
            Assert.Equal(mensagemEsperada, exception.Message);

        }

        //-- OUTROS E OUTROS TESTES ... .. .. ..
    }
}

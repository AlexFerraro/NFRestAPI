using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NFRestAPI.Controllers;
using NFRestAPI.Domain.Interfaces;
using NFRestAPI.Infrastructure.EntityTypes;
using NUnit.Framework;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace NFRestAPI_Test
{
    public class TNotaFiscalController
    {
        [Test]
        public async Task TestGetNotaFiscalsByEmissionDateAsync() 
        {
            var defaultNota = new NotaFiscal {
                Codnota = 5
                , Codvenda = 81357684
                , Destinatarioremetente = "Kamilly Alícia dos Santos"
                , Dtemissao = DateTime.Parse("12-12-2020")
                , Dtsaidaentrada = DateTime.Parse("01-15-2021")
                , Numerorecibo = null
                , Numnota = null
                , Transfrete = null
                , Valortotalnota = null 
                , Valortotalprodutos = null
                , Notafiscalitens = null
            };
            var repo = new Mock<INotaFiscalRepository>();
            var dataEmissao = DateTime.Parse("12-12-2020");

            var notaFiscais = new Collection<NotaFiscal>();
            notaFiscais.Add(defaultNota);

            repo.Setup(s => s.GetNotaFiscalByEmissionDateAsync(dataEmissao)).ReturnsAsync(notaFiscais);

            var loggerMock = Mock.Of<ILoggerFactory>();

            var nfc = new NotaFiscalController(loggerMock);

            var response = await nfc.GetNotaFiscalsByEmissionDate(repo.Object, dataEmissao);

            repo.Verify(v => v.GetNotaFiscalByEmissionDateAsync(dataEmissao), Times.Once);

            var okObjectResult = response as OkObjectResult;

            Assert.AreEqual(okObjectResult.StatusCode, 200);
        }
    }
}

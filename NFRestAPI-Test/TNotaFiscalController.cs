using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NFRestAPI.Controllers;
using NFRestAPI.Domain.Interfaces;
using NFRestAPI.Infrastructure.EntityTypes;
using NUnit.Framework;
using System;
using System.Collections.ObjectModel;

namespace NFRestAPI_Test
{
    public class TNotaFiscalController
    {
        [Test]
        public async System.Threading.Tasks.Task GetNotaFiscalsByEmissionDateAsync() 
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

            repo.Verify();

            var loggerMock = new Mock<ILoggerFactory>();

            loggerMock.Verify();

            var nfc = new NotaFiscalController(loggerMock.Object);

            var response = await nfc.GetNotaFiscalsByEmissionDate(repo.Object, dataEmissao);
            
            var okObjectResult = response as OkObjectResult;

            Assert.NotNull(okObjectResult);
        }

    }
}

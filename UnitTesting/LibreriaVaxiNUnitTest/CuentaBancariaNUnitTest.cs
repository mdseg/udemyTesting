using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaVaxi
{
    [TestFixture]
    public class CuentaBancariaNUnitTest
    {
        private CuentaBancaria cuenta;
        [SetUp]
        public void SetUp()
        {
        }
        [Test]
        public void Deposito_InputMonto100LoggerFake_ReturnTrue()
        {
            CuentaBancaria cuentaBancaria = new CuentaBancaria(new LoggerFake());
            var resultado = cuentaBancaria.Deposito(100);

            Assert.IsTrue(resultado);
            Assert.That(cuentaBancaria.GetBalance, Is.EqualTo(100));
        }

        [Test]
        public void Deposito_InputMonto100Mocking_ReturnTrue()
        {
            var mocking = new Mock<LoggerGeneral>();
            CuentaBancaria cuentaBancaria = new CuentaBancaria(mocking.Object);
            var resultado = cuentaBancaria.Deposito(100);

            Assert.IsTrue(resultado);
            Assert.That(cuentaBancaria.GetBalance, Is.EqualTo(100));
        }
        [Test]
        public void Retiro_Retiro100ConBalance200_ReturnTrue()
        {
            var loggerMock = new Mock<LoggerGeneral>();
            loggerMock.Setup( u => u.LogDatabase(It.IsAny<string>())).Returns(true);
            loggerMock.Setup(u => u.LogBalanceDespuesRetiro(It.IsAny<int>())).Returns(true);    
            CuentaBancaria cuentaBancaria = new CuentaBancaria(loggerMock.Object);
            cuentaBancaria.Deposito(200);

            var resultado = cuentaBancaria.Retiro(100);

            Assert.IsTrue(resultado);
        
        }

            
    }
}

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaVaxi
{
    [TestFixture]
    public class ClienteNUnitTest
    {
        private Cliente cliente;
        [SetUp]
        public void Setup()
        {
            cliente = new Cliente();
        }

        [Test]
        public void CrearNombreCompleto_InputNombreApellido_ReturnNombreCompleto()
        {
            // arrange

            //act
            cliente.CrearNombreCompleto("Vaxi", "Drez");

            // asert

            Assert.Multiple(() =>
            {
                Assert.That(cliente.ClienteNombre, Is.EqualTo("Vaxi Drez"));
                Assert.AreEqual(cliente.ClienteNombre, "Vaxi Drez");
                Assert.That(cliente.ClienteNombre, Does.Contain("Drez"));
                Assert.That(cliente.ClienteNombre, Does.Contain("Drez").IgnoreCase);
                Assert.That(cliente.ClienteNombre, Does.StartWith("Vaxi"));
                Assert.That(cliente.ClienteNombre, Does.EndWith("Drez"));
            });


        }

        [Test]
        public void ClientNombre_NoValues_ReturnNull()
        {
            Assert.IsNull(cliente.ClienteNombre);
        }

        [Test]
        public void DescuentoEvaluacion_DefaultCliente_ReturnDescuentoIntervalo()
        {
            int descuento = cliente.Descuento;
            Assert.That(descuento, Is.InRange(5, 24));
        }

        [Test]
        public void CrearNombreCompleto_InputNombre_ReturnsNotNull()
        {
            cliente.CrearNombreCompleto("Vaxi", "");

            Assert.IsNotNull(cliente.ClienteNombre);
            Assert.IsFalse(string.IsNullOrEmpty(cliente.ClienteNombre));
        }

        [Test]
        public void ClientNombre_InputNombreEnBlanco_ThrowException()
        {
            var exceptionDetalle = Assert.Throws<ArgumentException>(
                () => cliente.CrearNombreCompleto("", "Drez"));

            Assert.AreEqual("El nombre está en blanco", exceptionDetalle.Message);
            Assert.That(() => cliente.CrearNombreCompleto("", "Drez"),
                Throws.ArgumentException.With.Message.EqualTo("El nombre está en blanco"));

            Assert.Throws<ArgumentException>(
                () => cliente.CrearNombreCompleto("", "Drez"));
            Assert.That(() => cliente.CrearNombreCompleto("", "Drez"),
              Throws.ArgumentException);



        }
        [Test]
        public void GetClienteDetalle_CrearClienteConMenos500TotalOrder_ReturnsClienteBasico()
        {
            cliente.OrderTotal = 150;
            var resultado = cliente.GetClienteDetalle();
            Assert.That(resultado, Is.TypeOf<ClienteBasico>());
        }

        [Test]
        public void GetClienteDetalle_CrearClienteConMas500TotalOrder_ReturnsClienteBasico()
        {
            cliente.OrderTotal = 600;
            var resultado = cliente.GetClienteDetalle();
            Assert.That(resultado, Is.TypeOf<ClientePremium>());
        }
    }
}

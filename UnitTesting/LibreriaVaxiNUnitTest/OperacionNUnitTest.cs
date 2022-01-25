using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaVaxi
{
    [TestFixture]
    public class OperacionNUnitTest
    {
        [Test]
        public void SumarNumeros_InputDosNumeros_GetValorCorrecto()
        {
            //Arrange
            Operacion op = new Operacion();
            int numero1Test = 50;
            int numero2Test = 69;

            //Act
            int resultado = op.SumarNumeros(numero1Test, numero2Test);

            //Asert

            Assert.AreEqual(resultado, 119);
        }

        [Test]
        [TestCase(3, ExpectedResult = false)]
        [TestCase(5, ExpectedResult = false)]
        [TestCase(7, ExpectedResult = false)]
        public bool IsValorPar_InputNumeroImpar_ReturnFalse(int numeroImpar)
        {
            Operacion op = new Operacion();
      

            return op.IsValorPar(numeroImpar);


        }

        [Test]
        [TestCase(4)]
        [TestCase(6)]
        [TestCase(20)]
        public void IsValorPar_InputNumeroPar_ReturnTrue(int numeroPar)
        {
            Operacion op = new Operacion();


            bool isPar = op.IsValorPar(numeroPar);

            Assert.IsTrue(isPar);
            Assert.That(isPar, Is.EqualTo(true));
        }

        [Test]
        [TestCase(2.2,1.2)]
        [TestCase(2.23, 1.24)]
        public void SumarDecimal_InputDosNumeros_GetValorCorrecto(double decimal1Test, double decimal2Test)
        {
            //Arrange
            Operacion op = new Operacion();

            //Act
            double resultado = op.SumarDecimal(decimal1Test, decimal2Test);

            //Asert

            // 3.3  3.5

            Assert.AreEqual(3.4,resultado, 0.1);
        }

        [Test]
        public void GetListaNumerosImpares_InputMinimoMaximoIntervalos_ReturnsListaImpares()
        {
            //Arrange
            Operacion op = new Operacion();
            List<int> numerosImparesEsperados = new() { 5,7,9};

            List<int> resultados = op.GetListaNumerosImpares(5, 10);

            Assert.That(resultados, Is.EquivalentTo(numerosImparesEsperados));
            Assert.AreEqual(resultados,numerosImparesEsperados);
            Assert.That(resultados, Does.Contain(5));
            Assert.Contains(5, resultados);
            Assert.That(resultados, Is.Not.Empty);
            Assert.That(resultados.Count, Is.EqualTo(3));
            Assert.That(resultados, Has.No.Member(100));
            Assert.That(resultados, Is.Ordered.Ascending);
            Assert.That(resultados, Is.Unique);


        }

    }
}

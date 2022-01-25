using LibreriaVaxi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaVaxiMSTest
{
    [TestClass]
    public class OperacionMSTest
    {
        [TestMethod]
        public void SumarNumeros_InputDosNumeros_GetValorCorrecto()
        {
            //Arrange
            Operacion op = new Operacion();
            int numero1Test = 50;
            int numero2Test = 69;

            //Act
            int resultado = op.SumarNumeros(numero1Test,numero2Test);

            //Asert

            Assert.AreEqual(resultado, 119);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VerificaAposentadoriaEngine.Helpers;

namespace VerificaAposentadoriaTest.Helpers
{
    [TestClass]
    public class DataHoraHelperTest
    {
        [TestMethod]
        public void TestInstance()
        {
            new DataHoraHelper();
            Equals(true);
        }

        [TestMethod]
        public void TestDiferencaEmAnos()
        {
            double valor = DataHoraHelper.DiferencaEmAnos(new DateTime(DateTime.Now.Year-30, DateTime.Now.Month, DateTime.Now.Day));

            Assert.AreEqual(30, valor);
        }

    }
}

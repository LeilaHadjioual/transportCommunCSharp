using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestTransportsCommuns;

namespace MyLibrary.Tests
{
    [TestClass()]
    public class DataDetailsTransportTests
    {
        [TestMethod()]
        public void DataDetailsTransportTest()
        {
            FakeConnexion fakeConnect = new FakeConnexion();
            fakeConnect.jsonResult = Json1.jsonDetailsLine;
            DataDetailsTransport testDataDetails = new DataDetailsTransport(fakeConnect);
            DetailsTransports test1 = testDataDetails.GetDetailsLine("SEM:13");
            Assert.AreEqual(test1.shortName, "13");
            Assert.AreEqual(test1.color, "00BC9E");
            Assert.AreEqual(test1.mode, "BUS");
            Assert.IsTrue(test1.longName.Contains("Lycée"));
        }
    }
}
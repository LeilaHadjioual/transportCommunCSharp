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
    public class UnduplicateTests
    {
        [TestMethod()]
        public void UnduplicateTest()
        {
           
        }

        [TestMethod()]
        public void RemoveDuplicateTest()
        {
            String latitude = "45.185476";
            String longitude = "5.727772";
            int distance = 400;

            FakeConnexion testFakeConnect = new FakeConnexion();
            testFakeConnect.jsonResult = Json1.jsonStation;
            Unduplicate testConnect = new Unduplicate(testFakeConnect);
            Dictionary<string, List<string>> result = testConnect.RemoveDuplicate(latitude, longitude, distance);
            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(result.ContainsKey("GRENOBLE, CASERNE DE BONNE"));
            Assert.AreEqual(result["GRENOBLE, CASERNE DE BONNE"].Count, 3);
            Assert.IsTrue(result["GRENOBLE, CASERNE DE BONNE"][0].Equals("SEM:13"));
            Assert.IsTrue(result["GRENOBLE, CASERNE DE BONNE"][1] == ("SEM:16"));
            Assert.AreEqual(result["GRENOBLE, CASERNE DE BONNE"][2],"SEM:C4");
        }
    }
}
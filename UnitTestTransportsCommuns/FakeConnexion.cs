using MyLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestTransportsCommuns
{
    public class FakeConnexion : IConnexion
    {
        public String jsonResult { get; set; }

        public String ConnectApi(string url)
        {
            return jsonResult;
        }
    }
}

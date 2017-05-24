using System.Diagnostics;
using Homologador.Fe.Auth;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Homologador.Fe.Tests.Auth
{
    [TestClass()]
    public class SunatApiTests
    {
        private readonly SunatApi _auth;

        public SunatApiTests()
        {
            _auth = new SunatApi("20551520634", "", "");
        }

        /// <summary>
        /// Logins the test.
        /// </summary>
        [TestInitialize]
        public void LoginTest()
        {
            _auth.Login();
            
        }

        [TestMethod()]
        public void GetSolicitudesTest()
        {
            var task = _auth.GetSolicitudes();
            task.Wait();
            var result = task.Result;
            Trace.WriteLine(result);
            Assert.IsNotNull(result);
        }
        [TestMethod()]
        public void GetPruebasTest()
        {
            var task = _auth.GetPruebas("3050825980023");
            task.Wait();
            var result = task.Result;
            Trace.WriteLine(result);
            Assert.IsNotNull(result);
        }
    }
}
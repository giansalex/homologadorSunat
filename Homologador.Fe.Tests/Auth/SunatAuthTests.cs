using System.Diagnostics;
using Homologador.Fe.Auth;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Homologador.Fe.Tests.Auth
{
    [TestClass()]
    public class SunatAuthTests
    {
        private readonly SunatAuth _auth;

        public SunatAuthTests()
        {
            _auth = new SunatAuth("20551520634", "MODDATOS", "moddatos");
        }
        /// <summary>
        /// Logins the test.
        /// </summary>
        [TestMethod]
        public void LoginTest()
        {
            var task = _auth.Login();
            task.Wait();

            Assert.IsTrue(task.Result);
        }

        [TestMethod()]
        public void GetSolicitudesTest()
        {
            LoginTest();

            var task = _auth.GetSolicitudes();
            task.Wait();
            var result = task.Result;
            Trace.WriteLine(result);
            Assert.IsNotNull(result);
        }
    }
}
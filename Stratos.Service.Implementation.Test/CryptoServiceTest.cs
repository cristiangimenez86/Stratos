using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stratos.Service.Implementation.Test
{
    [TestClass]
    public class CryptoServiceTest
    {
        private CryptoService _cryptoService;

        [TestInitialize]
        public void TestInitialize()
        {
            _cryptoService = new CryptoService();
        }

        [TestMethod]
        public void DeleteAndSaveMethodsWhenDeleteServerShouldBeCalledOnce()
        {
            const string expected = "Password";
            var actual = _cryptoService.Decrypt("Gu2OQ4TpqPYNi/4VwtY3Cw==");

            actual.ShouldBeEquivalentTo(expected);
        }

        [TestMethod]
        public void DeleteAndSaveMethodsWhenDeleteServerShouldBeCalledOnce2()
        {
            const string expected = "Gu2OQ4TpqPYNi/4VwtY3Cw==";
            var actual = _cryptoService.Encrypt("Password");

            actual.ShouldBeEquivalentTo(expected);
        }
    }
}

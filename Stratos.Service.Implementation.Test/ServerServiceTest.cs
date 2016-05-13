using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Stratos.DataAccess.Repositories;
using Stratos.DomainModel;
using Stratos.Service.Contract;
using Stratos.Service.Contract.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace Stratos.Service.Implementation.Test
{
    [TestClass]
    public class ServerServiceTest
    {
        private List<Server> _mockedServers;
        private ServerService _serverService;
        private Mock<IRepository<Server>> _serverRepo;
        private Mock<IRepository<Client>> _clientRepo;
        private Mock<ICryptoService> _cryptoService;

        [TestInitialize]
        public void TestInitialize()
        {
            var client1 = new Client
            {
                Id = 1,
                Name = "Name1",
                Company = "Company1",
                Email = "Email1",
                Phone = "Phone1"
            };

            var client2 = new Client
            {
                Id = 2,
                Name = "Name2",
                Company = "Company2",
                Email = "Email2",
                Phone = "Phone2"
            };

            _mockedServers = new List<Server>
            {
                new Server
                {
                    Id = 1,
                    URL = "URL1",
                    Username = "Username1",
                    Password = "HashedPassword1",
                    Client = client1,
                },
                new Server
                {
                    Id = 2,
                    URL = "URL2",
                    Username = "Username2",
                    Password = "HashedPassword2",
                    Client = client1
                },
                new Server
                {
                    Id = 3,
                    URL = "URL3",
                    Username = "Username3",
                    Password = "HashedPassword3",
                    Client = client2
                },
            };

            _serverRepo = new Mock<IRepository<Server>>();
            _clientRepo = new Mock<IRepository<Client>>();
            _cryptoService = new Mock<ICryptoService>();
            _serverRepo.Setup(r => r.Query()).Returns(_mockedServers.AsQueryable());
            _cryptoService.Setup(c => c.Decrypt("HashedPassword2")).Returns("Password2");
            _cryptoService.Setup(c => c.Encrypt("Password2")).Returns("HashedPassword2");
            _serverRepo.Setup(r => r.Save());
            _serverService = new ServerService(_serverRepo.Object, _clientRepo.Object, _cryptoService.Object);
        }

        [TestMethod]
        public void GetServersShouldReturnTwoServersDtosFromServerRepository()
        {
            var actual = _serverService.GetServers(1);

            actual.Should().BeOfType<List<ServerDTO>>().And.HaveCount(2);
        }

        [TestMethod]
        public void GetServerShouldReturnOnlyOneServerDtoFromTheServerRepositoryWhoMatchWithTheServerId()
        {
            var expected = new ServerDTO
            {
                URL = "URL2",
                Username = "Username2",
                Id = 2,
                Password = "Password2",
                ClientId = 1
            };

            var actual = _serverService.GetServer(2);
            actual.ShouldBeEquivalentTo(expected);
        }

        [TestMethod]
        public void AddAndSaveMethodsShouldBeCalledOnce()
        {
            var serverDto = new ServerDTO
            {
                URL = "URL5",
                Username = "Username5",
                Id = 5,
                Password = "Password5",
            };

            _serverService.InsertServer(serverDto);

            _serverRepo.Verify(c => c.Add(It.IsAny<Server>()), Times.Once());
            _serverRepo.Verify(c => c.Save(), Times.Once());
        }

        [TestMethod]
        public void SaveMethodWhenUpdateServerShouldBeCalledOnce()
        {
            var serverDto = new ServerDTO
            {
                URL = "URL2",
                Username = "Username2",
                Id = 2,
                Password = "Password2",
            };

            _serverService.UpdateServer(serverDto);
            _serverRepo.Verify(c => c.Save(), Times.Once());
        }

        [TestMethod]
        public void DeleteAndSaveMethodsWhenDeleteServerShouldBeCalledOnce()
        {
            _serverService.DeleteServer(2);

            _serverRepo.Verify(c => c.Delete(It.IsAny<Server>()), Times.Once());
            _serverRepo.Verify(c => c.Save(), Times.Once());
        }
    }
}

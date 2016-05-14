using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Stratos.DataAccess.Repositories;
using Stratos.DomainModel;
using Stratos.Service.Contract.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace Stratos.Service.Implementation.Test
{
    [TestClass]
    public class ClientServiceTest
    {
        private List<Client> _mockedclients;
        private ClientService _service;
        private Mock<IRepository<Client>> _repo;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockedclients = new List<Client>
            {
                new Client
                {
                    Id = 1,
                    Name = "Name1",
                    Email = "Email1",
                    Phone = "Phone1",
                    Servers = new List<Server>
                    {
                        new Server
                        {
                            Id = 1,
                            URL = "URL1",
                            Username = "Username1",
                            Password = "Password1"
                        },
                        new Server
                        {
                            Id = 2,
                            URL = "URL2",
                            Username = "Username2",
                            Password = "Password2"
                        }
                    }
                },
                new Client
                {
                    Id = 2,
                    Name = "Name2",
                    Email = "Email2",
                    Phone = "Phone2",
                    Servers = new List<Server>
                    {
                        new Server
                        {
                            Id = 3,
                            URL = "URL3",
                            Username = "Username3",
                            Password = "Password3"
                        },
                    }
                }
            };

            _repo = new Mock<IRepository<Client>>();
            _repo.Setup(r => r.Query()).Returns(_mockedclients.AsQueryable());
            _repo.Setup(r => r.Save());
            _service = new ClientService(_repo.Object);
        }

        [TestMethod]
        public void GetClientsShouldReturnTwoClientsDtosFromClientRepository()
        {
            var actual = _service.GetClients();

            actual.Should().BeOfType<List<ClientDTO>>().And.HaveCount(2);

        }

        [TestMethod]
        public void SearchClientsShouldReturnClientsDtosFromTheClientRepositoryWhoMatchWithTheCriteria()
        {
            var expected = new List<ClientDTO>
            {
                new ClientDTO
                {
                    Email = "Email2",
                    Id = 2,
                    Name = "Name2",
                    Phone = "Phone2"
                }
            };

            var actual = _service.SearchClients("Name2");

            actual.ShouldBeEquivalentTo(expected);
        }

        [TestMethod]
        public void GetClientShouldReturnOnlyOneClientDtoFromTheClientRepositoryWhoMatchWithTheClientId()
        {
            var expected = new ClientDTO
                {
                    Email = "Email2",
                    Id = 2,
                    Name = "Name2",
                    Phone = "Phone2"
                };

            var actual = _service.GetClient(2);
            actual.ShouldBeEquivalentTo(expected);
        }

        [TestMethod]
        public void AddAndSaveMethodsShouldBeCalledOnce()
        {
            var clientDto = new ClientDTO
            {
                Email = "Email5",
                Id = 5,
                Name = "Name5",
                Phone = "Phone5"
            };

            _service.InsertClient(clientDto);

            _repo.Verify(c => c.Add(It.IsAny<Client>()), Times.Once());
            _repo.Verify(c => c.Save(), Times.Once());
        }

        [TestMethod]
        public void UpdateAndSaveMethodWhenUpdateClientShouldBeCalledOnce()
        {
            var clientDto = new ClientDTO
            {
                Email = "ModifiedEmail2",
                Id = 2,
                Name = "ModifiedName2",
                Phone = "ModifiedPhone2"
            };

            _service.UpdateClient(clientDto);
            _repo.Verify(c => c.Update(It.IsAny<Client>()), Times.Once());
            _repo.Verify(c => c.Save(), Times.Once());
        }

        [TestMethod]
        public void DeleteAndSaveMethodsWhenDeleteClientShouldBeCalledOnce()
        {
            _service.DeleteClient(2);

            _repo.Verify(c => c.Delete(It.IsAny<Client>()), Times.Once());
            _repo.Verify(c => c.Save(), Times.Once());
        }
    }
}


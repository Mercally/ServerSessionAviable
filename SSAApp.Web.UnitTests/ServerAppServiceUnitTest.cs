using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SSAApp.Web.Domain.Core;
using SSAApp.Web.Domain.Entities;
using SSAApp.Web.Domain.Interfaces.Repositories;
using SSAApp.Web.Domain.Interfaces.Services;
using SSAApp.Web.Services.Interfaces;
using SSAApp.Web.Services.Services;
using SSAApp.Web.UnitTests.Mocks;

namespace SSAApp.Web.UnitTests
{
    [TestClass]
    public class ServerAppServiceUnitTest
    {
        IServerAppService serverAppService;

        public ServerAppServiceUnitTest()
        {
            IServerRepository serverRepository = new IServerRepositoryMock().Setup();
            IServerService serverService = new ServerService(serverRepository);
            serverAppService = new ServerAppService(serverService);
        }

        [TestMethod]
        public void Add()
        {
            var server = new ServerModel()
            {
                Description = "",
                DNS = "",
                IdServer = 1,
                IPv4 = "",
                Project = "",
                Provider = "",
                Tags = ""
            };

            var result = serverAppService.Add(server);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetAll()
        {
            var result = serverAppService.GetAll();

            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void GetById()
        {
            var result = serverAppService.GetById(1);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Delete()
        {
            var result = serverAppService.Delete(1);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Modify()
        {
            var server = new ServerModel();

            var result = serverAppService.Modify(server);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Dispose()
        {
            serverAppService.Dispose();
            Assert.IsTrue(true);
        }
    }
}

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
    public class ServerStatusAppServiceUnitTest
    {
        IServerStatusAppService serverStatusAppService;

        public ServerStatusAppServiceUnitTest()
        {
            IServerStatusRepository serverRepository = new IServerStatusRepositoryMock().Setup();
            IServerStatusService serverService = new ServerStatusService(serverRepository);
            serverStatusAppService = new ServerStatusAppService(serverService);
        }

        [TestMethod]
        public void Add()
        {
            var serverStatus = new ServerStatusModel()
            {
                EndSessionTimestamp = null,
                IdServer = 1,
                IdServerStatus = 2,
                IsSessionActive = false,
                StartSessionTimestamp = DateTime.Now,
                UserInSession = ""
            };

            var result = serverStatusAppService.Add(serverStatus);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetAll()
        {
            var result = serverStatusAppService.GetAll();

            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void GetById()
        {
            var result = serverStatusAppService.GetById(1);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Delete()
        {
            var result = serverStatusAppService.Delete(1);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Modify()
        {
            var serverStatus = new ServerStatusModel();

            var result = serverStatusAppService.Modify(serverStatus);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Dispose()
        {
            serverStatusAppService.Dispose();
            Assert.IsTrue(true);
        }
    }
}

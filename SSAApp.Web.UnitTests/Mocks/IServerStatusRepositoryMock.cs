using Moq;
using SSAApp.Web.Domain.Entities;
using SSAApp.Web.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSAApp.Web.UnitTests.Mocks
{
    public class IServerStatusRepositoryMock
    {
        public IServerStatusRepository Setup()
        {
            var serverStatusRepository = new Mock<IServerStatusRepository>();

            serverStatusRepository.Setup(x => x.Add(It.IsAny<ServerStatusModel>())).Returns(new ServerStatusModel());
            serverStatusRepository.Setup(x => x.GetAll()).Returns(new List<ServerStatusModel>());
            serverStatusRepository.Setup(x => x.Delete(It.IsAny<int>())).Returns(new ServerStatusModel());
            serverStatusRepository.Setup(x => x.Modify(It.IsAny<ServerStatusModel>())).Returns(new ServerStatusModel());
            serverStatusRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(new ServerStatusModel());
            serverStatusRepository.Setup(x => x.Dispose()).Callback(() => { });

            return serverStatusRepository.Object;
        }
    }
}

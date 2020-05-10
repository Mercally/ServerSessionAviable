using Moq;
using SSAApp.Web.Domain.Entities;
using SSAApp.Web.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSAApp.Web.UnitTests.Mocks
{
    public class IServerRepositoryMock
    {
        public IServerRepository Setup()
        {
            var serverRepository = new Mock<IServerRepository>();

            serverRepository.Setup(x => x.Add(It.IsAny<ServerModel>())).Returns(new ServerModel());
            serverRepository.Setup(x => x.GetAll()).Returns(new List<ServerModel>());
            serverRepository.Setup(x => x.Delete(It.IsAny<int>())).Returns(new ServerModel());
            serverRepository.Setup(x => x.Modify(It.IsAny<ServerModel>())).Returns(new ServerModel());
            serverRepository.Setup(x => x.GetById(It.IsAny<int>())).Returns(new ServerModel());
            serverRepository.Setup(x => x.Dispose()).Callback(() => { });

            return serverRepository.Object;
        }
    }
}

using SSAApp.Web.Domain.Entities;
using SSAApp.Web.Domain.Interfaces.Repositories;
using SSAApp.Web.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSAApp.Web.Domain.Core
{
    public class ServerService : BaseService<ServerModel>, IServerService
    {
        private readonly IServerRepository serverRepository;

        public ServerService(IServerRepository serverRepository) : base(serverRepository)
        {
            this.serverRepository = serverRepository;
        }
    }
}

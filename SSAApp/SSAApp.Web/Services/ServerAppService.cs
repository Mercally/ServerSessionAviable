using SSAApp.Web.Domain.Entities;
using SSAApp.Web.Domain.Interfaces.Services;
using SSAApp.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSAApp.Web.Services
{
    public class ServerAppService : BaseAppService<Server>, IServerAppService
    {
        private readonly IServerService serverService;

        public ServerAppService(IServerService serverService) : base(serverService)
        {
            this.serverService = serverService;
        }
    }
}

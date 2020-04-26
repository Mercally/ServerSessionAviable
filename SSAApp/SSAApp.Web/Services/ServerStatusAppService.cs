using SSAApp.Web.Domain.Entities;
using SSAApp.Web.Domain.Interfaces.Services;
using SSAApp.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSAApp.Web.Services
{
    public class ServerStatusAppService : BaseAppService<ServerStatus>, IServerStatusAppService
    {
        private readonly IServerStatusService serverStatusService;

        public ServerStatusAppService(IServerStatusService serverStatusService) : base(serverStatusService)
        {
            this.serverStatusService = serverStatusService;
        }
    }
}

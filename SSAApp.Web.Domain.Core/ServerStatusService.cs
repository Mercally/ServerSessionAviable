using SSAApp.Web.Domain.Entities;
using SSAApp.Web.Domain.Interfaces.Repositories;
using SSAApp.Web.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSAApp.Web.Domain.Core
{
    public class ServerStatusService : BaseService<ServerStatus>, IServerStatusService
    {
        private readonly IServerStatusRepository serverStatusRepository;

        public ServerStatusService(IServerStatusRepository serverStatusRepository) : base(serverStatusRepository)
        {
            this.serverStatusRepository = serverStatusRepository;
        }
    }
}

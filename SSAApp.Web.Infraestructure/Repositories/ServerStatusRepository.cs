using SSAApp.Web.Domain.Entities;
using SSAApp.Web.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSAApp.Web.Infraestructure.Repositories
{
    public class ServerStatusRepository : BaseRepository<ServerStatusModel>, IServerStatusRepository
    {
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SSAApp.Web.Domain.Entities
{
    public class ServerStatusModel
    {
        public long IdServerStatus { get; set; }
        public int IdServer { get; set; }
        public bool IsSessionActive { get; set; }
        public string UserInSession { get; set; }
        public DateTime StartSessionTimestamp { get; set; }
        public DateTime? EndSessionTimestamp { get; set; }
    }
}

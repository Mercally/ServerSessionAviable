using System;
using System.Collections.Generic;

namespace SSAApp.Web.Domain.Entities
{
    public class ServerModel
    {
        public int IdServer { get; set; }
        public string DNS { get; set; }
        public string IPv4 { get; set; }
        public string Provider { get; set; }
        public string Project { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
    }
}

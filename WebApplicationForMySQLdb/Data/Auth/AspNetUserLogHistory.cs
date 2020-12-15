using System;
using System.Collections.Generic;

namespace WebApplicationForMySQLdb.Data.Auth
{
    public partial class AspNetUserLogHistory
    {
        public string IdAspNetUserLogHistory { get; set; }
        public string UserId { get; set; }
        public string Action { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? Time { get; set; }

        public AspNetUsers User { get; set; }
    }
}

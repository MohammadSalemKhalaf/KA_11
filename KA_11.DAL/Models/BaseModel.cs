using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace KA_11.DAL.Models
{
    public enum Status
    {
        Active = 1,
        Inactive = 0
    }
    public class BaseModel
    {
        public int id { get; set; }
        public DateTime createdAt { get; set; }
        public Status status { get; set; } = Status.Active;
    }
}


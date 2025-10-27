using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KA_11.DAL.DTO.Requests
{
    public class ResetPassword
    {
        public string code { get; set; }
        public string newPassword { get; set; } 
        public string Email { get; set; } 
        
    }
}

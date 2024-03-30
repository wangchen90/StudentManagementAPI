using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BAL.Models
{
    public class UserLoginModel
    {
        public string user_name { get; set; }

       
        public string password { get; set; }
      
        public bool is_active { get; set; }

        
        public DateTime created_on { get; set; }
 
        public DateTime updated_on { get; set; }
    }


}

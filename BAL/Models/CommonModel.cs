using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Models
{
    public class CommonModel
    {
        public class DepartmentModel
        {
            public int? department_id { get; set; }
            public string department_name { get; set; }
        }

        public class SemesterModel
        {
            public int semester_id { get; set; }
            
            public string semester_name { get; set; }
        }
    }
}

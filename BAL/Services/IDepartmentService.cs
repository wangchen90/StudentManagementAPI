using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BAL.Models.CommonModel;

namespace BAL.Services
{
    public interface IDepartmentService
    {
        Task<bool> AddDepartment(DepartmentModel department);
        Task<DataTable> GetAllDepartment();
        Task<bool> DeleteDepartment(int id);
        Task<bool> UpdateDepartment(DepartmentModel department);
    }
}

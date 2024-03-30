using Common.Configuration;
using System.Data;
using static BAL.Models.CommonModel;

namespace BAL.Services
{
    public class DepartmentService :  AppDbContext, IDepartmentService
    {
        public async Task<bool> AddDepartment(DepartmentModel department)
        {
            try
            {
                OpenContext();
                _sqlCommand.Add_Parameter_WithValue("prm_department_id", department.department_id);
                _sqlCommand.Add_Parameter_WithValue("prm_department_name", department.department_name);

                var result = await _sqlCommand.Execute_Query("addDepartment", CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseContext();
            }
        }

        public async Task<bool> DeleteDepartment(int id)
        {
            try
            {
                OpenContext();
                _sqlCommand.Add_Parameter_WithValue("prm_department_id", id);
                bool result= await _sqlCommand.Execute_Query("deleteDepartment", CommandType.StoredProcedure);
                return result;
            }

            catch(Exception ex)
            {
                throw ex;
            }
            
            finally
            {
CloseContext();
            }
        }

        public async Task<DataTable> GetAllDepartment()
        {
            try
            {
                OpenContext();
                DataTable result = await _sqlCommand.Select_Table("getAllDepartment", CommandType.StoredProcedure);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                CloseContext();
            }
        }

        public async Task<bool> UpdateDepartment(DepartmentModel department)
        {
            try
            {
OpenContext();
                _sqlCommand.Add_Parameter_WithValue("prm_department_id", department.department_id);
                _sqlCommand.Add_Parameter_WithValue("prm_department_name", department.department_name);

               var result = await _sqlCommand.Execute_Query("updateDepartment", CommandType.StoredProcedure);
                return result;
            }
            catch( Exception ex)
            {
                throw ex;
            }
            finally
            {
CloseContext() ;
            }
        }
    }
}

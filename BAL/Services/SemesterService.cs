using BAL.Models;
using Common.Configuration;
using System.Data;
using static BAL.Models.CommonModel;

namespace BAL.Services
{
    public class SemesterService : AppDbContext, ISemesterService
    {
        public  async Task<bool> AddSemester(SemesterModel semester)
        {
            try
            {
                OpenContext();
                _sqlCommand.Add_Parameter_WithValue("prm_semester_id", semester.semester_id);
                _sqlCommand.Add_Parameter_WithValue("prm_semester_name",semester.semester_name);

                 var result = await _sqlCommand.Execute_Query("addSemester", CommandType.StoredProcedure);
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

        public async Task<bool> DeleteSemester(int id)
        {
            try
            {
OpenContext();
                _sqlCommand.Add_Parameter_WithValue("prm_semester_id", id);

                var result = await _sqlCommand.Execute_Query("deleteSemester", CommandType.StoredProcedure);
                return result;
            }
            catch( Exception ex)
            {
                throw ex;
            }
            
            finally
            {
CloseContext ();
            }
        }

        public async Task<bool> EditSemester(SemesterModel semester)
        {
            try
            {
OpenContext();
                _sqlCommand.Add_Parameter_WithValue("prm_semester_id", semester.semester_id);
                _sqlCommand.Add_Parameter_WithValue("prm_semester_name", semester.semester_name);

               var result = await _sqlCommand.Execute_Query("editSemester", CommandType.StoredProcedure);
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

        public  async Task<DataTable> GetAllSemester()
        {
            try
            {
                OpenContext();
               DataTable result = await _sqlCommand.Select_Table("getAllSemester", CommandType.StoredProcedure);
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
    }


}




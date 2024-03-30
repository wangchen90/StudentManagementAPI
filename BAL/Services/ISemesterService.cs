using System.Data;
using static BAL.Models.CommonModel;

namespace BAL.Services
{
    public interface ISemesterService
    {
        Task<DataTable> GetAllSemester();
        Task<bool> EditSemester(SemesterModel semester);

        Task<bool> AddSemester(SemesterModel semester);

        Task<bool> DeleteSemester(int id);
    }
}

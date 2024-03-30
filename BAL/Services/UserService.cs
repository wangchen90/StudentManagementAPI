using BAL.Models;
using Common.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
    public class UserService : AppDbContext, IUserService
    {
        public async Task<bool> UserLoginInfo(UserLoginModel login)
        {
            try
            {
                OpenContext();
                _sqlCommand.Add_Parameter_WithValue("@user_name", login.user_name);
                _sqlCommand.Add_Parameter_WithValue("@password", login.password);

                var result = await _sqlCommand.Select_Table("SELECT user_name, password FROM user_login WHERE user_name = @user_name AND password = sha(@password);", CommandType.Text);

                if (result.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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

        public async Task<bool> UserRegistration(UserLoginModel login)
        {
            try
            {
                OpenContext();
                _sqlCommand.Add_Parameter_WithValue("prm_username", login.user_name);
                _sqlCommand.Add_Parameter_WithValue("prm_password", login.password);
                _sqlCommand.Add_Parameter_WithValue("prm_is_active", login.is_active);
                _sqlCommand.Add_Parameter_WithValue("prm_updated_on", login.updated_on);

                bool result = await _sqlCommand.Execute_Query("userRegistration", System.Data.CommandType.StoredProcedure);
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


    }
}

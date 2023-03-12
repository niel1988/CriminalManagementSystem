using CriminalManagementSystem.Models;
using System.Data.SqlClient;
using System.Data;
using CriminalManagementSystem.DAL;

namespace CriminalManagementSystem.BusinessLayer
{
    public class UserBL
    {

        public int CreateUser(UserModel userModel)
        {
            int status = 0;
            try
            {
                UserDAL userDAL = new UserDAL();
                status = userDAL.CreateUser(userModel);
            }
            catch (Exception ex)
            {
                status = -2;
            }
            return status;
        }
        public int UpdateUser(UserModel userModel)
        {
            int status = 0;
            try
            {
                UserDAL userDAL = new UserDAL();
                status = userDAL.UpdateUser(userModel);
            }
            catch (Exception ex)
            {
                status = -2;
            }
            return status;
        }
        public int DeleteUser(int Id)
        {
            int status = 0;
            try
            {
                UserDAL userDAL = new UserDAL();
                status = userDAL.DeleteUser(Id);
            }
            catch (Exception ex)
            {
                status = -2;
            }
            return status;
        }
        public UserModel GetUserById(int Id)
        {
            UserModel userModel = null;
            int status = 0;
            try
            {
                UserDAL userDAL = new UserDAL();
                status = userDAL.GetUserById(Id,out userModel);
            }
            catch (Exception ex)
            {
                status = -2;
            }
            return userModel;
        }
        public List<UserModel> GetAllUser()
        {
            int status = 0;
            List<UserModel> listUserModel = null;
            try
            {
                UserDAL userDAL = new UserDAL();
                status = userDAL.GetAllUser(out listUserModel);
            }
            catch (Exception ex)
            {
                status = -2;
            }
            return listUserModel;
        }
    }
}

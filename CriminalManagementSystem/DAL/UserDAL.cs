using System.Data.SqlClient;
using System.Data;
using CriminalManagementSystem.Models;

namespace CriminalManagementSystem.DAL
{
    public class UserDAL
    {
        private string conStr = "";
        public UserDAL()
        {
            conStr = "";
        }
        public int CreateUser(UserModel userModel)
        {
            int status = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(conStr))
                {
                    //Create the Command Object
                   
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "";
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Set Input Parameter
                   
                    //Another approach to add Input Parameter
                    cmd.Parameters.AddWithValue("@UserName", userModel.UserName);
                    cmd.Parameters.AddWithValue("@Email", userModel.Email);
                    cmd.Parameters.AddWithValue("@Password", userModel.Password);
                    cmd.Parameters.AddWithValue("@Designation", userModel.Designation);
                    cmd.Parameters.AddWithValue("@Mobile", userModel.Mobile);
                    cmd.Parameters.AddWithValue("@IsAdmin", userModel.IsAdmin);

                    //Set Output Parameter
                    SqlParameter outParameter = new SqlParameter
                    {
                        ParameterName = "@Status", //Parameter name defined in stored procedure
                        SqlDbType = SqlDbType.Int, //Data Type of Parameter
                        Direction = ParameterDirection.Output //Specify the parameter as ouput
                        //No need to specify the value property
                    };
                    //Add the parameter to the Parameters collection property of SqlCommand object
                    cmd.Parameters.Add(outParameter);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    status = Convert.ToInt16(cmd.Parameters["@Status"].Value);
                }
            }
            catch(Exception ex)
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
                using (SqlConnection connection = new SqlConnection(conStr))
                {
                    //Create the Command Object

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "";
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Set Input Parameter

                    //Another approach to add Input Parameter
                    cmd.Parameters.AddWithValue("@Id", userModel.IsAdmin);
                    cmd.Parameters.AddWithValue("@UserName", userModel.UserName);
                    cmd.Parameters.AddWithValue("@Email", userModel.Email);
                    cmd.Parameters.AddWithValue("@Password", userModel.Password);
                    cmd.Parameters.AddWithValue("@Designation", userModel.Designation);
                    cmd.Parameters.AddWithValue("@Mobile", userModel.Mobile);
                    cmd.Parameters.AddWithValue("@IsAdmin", userModel.IsAdmin);

                    //Set Output Parameter
                    SqlParameter outParameter = new SqlParameter
                    {
                        ParameterName = "@Status", //Parameter name defined in stored procedure
                        SqlDbType = SqlDbType.Int, //Data Type of Parameter
                        Direction = ParameterDirection.Output //Specify the parameter as ouput
                        //No need to specify the value property
                    };
                    //Add the parameter to the Parameters collection property of SqlCommand object
                    cmd.Parameters.Add(outParameter);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    status = Convert.ToInt16(cmd.Parameters["@Status"].Value);
                }
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
                using (SqlConnection connection = new SqlConnection(conStr))
                {
                    //Create the Command Object

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "";
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Set Input Parameter

                    //Another approach to add Input Parameter
                    cmd.Parameters.AddWithValue("@Id", Id);
                    

                    //Set Output Parameter
                    SqlParameter outParameter = new SqlParameter
                    {
                        ParameterName = "@Status", //Parameter name defined in stored procedure
                        SqlDbType = SqlDbType.Int, //Data Type of Parameter
                        Direction = ParameterDirection.Output //Specify the parameter as ouput
                        //No need to specify the value property
                    };
                    //Add the parameter to the Parameters collection property of SqlCommand object
                    cmd.Parameters.Add(outParameter);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    status = Convert.ToInt16(cmd.Parameters["@Status"].Value);
                }
            }
            catch (Exception ex)
            {
                status = -2;
            }
            return status;
        }
        public int GetUserById(int Id,out UserModel userModel)
        {
            userModel = null;
            int status = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(conStr))
                {
                    //Create the SqlCommand object
                    SqlCommand cmd = new SqlCommand()
                    {
                        CommandText = "spGetUserById", //Specify the Stored procedure name
                        Connection = connection, //Specify the connection object where the stored procedure is going to execute
                        CommandType = CommandType.StoredProcedure //Specify the command type as Stored Procedure
                    };
                    //Create an instance of SqlParameter
                    SqlParameter param1 = new SqlParameter
                    {
                        ParameterName = "@Id", //Parameter name defined in stored procedure
                        SqlDbType = SqlDbType.Int, //Data Type of Parameter
                        Value = Id, //Value passes to the paramtere
                        Direction = ParameterDirection.Input //Specify the parameter as input
                    };
                    //Add the parameter to the Parameters property of SqlCommand object
                    cmd.Parameters.Add(param1);
                    //Open the Connection
                    connection.Open();
                    //Execute the command i.e. Executing the Stored Procedure using ExecuteReader method
                    //SqlDataReader requires an active and open connection
                    SqlDataReader sdr = cmd.ExecuteReader();

                    status = Convert.ToInt16(cmd.Parameters["@Status"].Value);

                    if(status == 0)
                    {
                        while (sdr.Read())
                        {
                            userModel = new UserModel();
                            //Accessing the data using the string key as index
                            userModel.Id = Convert.ToInt16(sdr["Id"]);
                            userModel.Email = Convert.ToString(sdr["Email"]);
                            userModel.UserName = Convert.ToString(sdr["UserName"]);
                            userModel.Designation = Convert.ToString(sdr["UserName"]);
                            userModel.Mobile = Convert.ToString(sdr["Mobile"]);
                            userModel.IsAdmin = Convert.ToBoolean(sdr["IsAdmin"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                status = -2;
            }
            return status;
        }
        public int GetAllUser(out List<UserModel> listUserModel)
        {
            int status = 0;
            listUserModel = null;
            try
            {
                //Creating the connection object using the ConnectionString
                using (SqlConnection connection = new SqlConnection(conStr))
                {
                    //Creating DataSet Object
                    DataSet ds = new DataSet();
                    //Creating SQL Command Object 
                    SqlCommand sqlCmd = new SqlCommand
                    {
                        CommandText = "spGetAllUser", //Specifying the Stored Procedure Name
                        CommandType = CommandType.StoredProcedure, //We are going to Execute the command is a Stored Procedure
                        Connection = connection //Specifying the connection object whhere the Stored Procedure is going to be execute
                    };
                  
                    //Create SqlDataAdapter object
                    SqlDataAdapter da = new SqlDataAdapter
                    {
                        //Specify the Select Command as the command object we created
                        SelectCommand = sqlCmd
                    };
                    //Call the Fill Method to fill the dataset
                    da.Fill(ds);

                    listUserModel = new List<UserModel>();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        UserModel userModel = new UserModel();
                        //Accessing the data using the string key as index
                        userModel.Id = Convert.ToInt16(row["Id"]);
                        userModel.Email = Convert.ToString(row["Email"]);
                        userModel.UserName = Convert.ToString(row["UserName"]);
                        userModel.Designation = Convert.ToString(row["UserName"]);
                        userModel.Mobile = Convert.ToString(row["Mobile"]);
                        userModel.IsAdmin = Convert.ToBoolean(row["IsAdmin"]);
                        listUserModel.Add(userModel);
                        userModel = null;
                    }
                    if(listUserModel.Count>0 || listUserModel != null)
                    {
                        status = 0;
                    }
                    else
                    {
                        status = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                status = -2;
            }
            return status;
        }
    }
}

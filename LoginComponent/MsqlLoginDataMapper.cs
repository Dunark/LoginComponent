using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginComponent
{
    public class MsqlLoginDataMapper:ILoginDataMapper
    {
        private string _connectString;
        SqlConnection conn;

        public MsqlLoginDataMapper(string connectString)
        {
            this._connectString = connectString;
        }

        private void Connect()
        {
            conn = new SqlConnection(_connectString);
            conn.Open();
        }
        private void Disconnect()
        {
            conn.Close();
            conn.Dispose();
        }

        public void Create(User u)
        {
            try
            {
                Connect();
                string testTableExist = "SELECT Username FROM Userdata WHERE id='1'";
                SqlCommand cmd = new SqlCommand(testTableExist, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                string createTable = "CREATE TABLE Userdata(Username varchar(150), HashedPassword varchar(255))";
                SqlCommand cmd2 = new SqlCommand(createTable, conn);
            }
            finally
            {
                Disconnect();
            }

            try
            {
                Connect();
                string CreateUser = "INSERT INTO Userdata (Username, HashedPassword) VALUES (@Username, @HashedPassword)";
                SqlCommand cmd = new SqlCommand(CreateUser, conn);
                cmd.Parameters.AddWithValue("Username", u._email);
                cmd.Parameters.AddWithValue("HashedPassword", u._hashedPassword);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                
            }
            finally
            {
                Disconnect();
            }
        }
        public void Delete(User u)
        {
            try
            {
                Connect();
                string username = u._email;
                string hashedPassword = u._hashedPassword;
                string DeleteUser = "DELETE FROM Userdata WHERE Username=@username AND HashedPassword=@hashedPassword";
                SqlCommand cmd = new SqlCommand(DeleteUser, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
            finally
            {
                Disconnect();
            }
        }
        public void Login(User u)
        {
            try
            {
                Connect();
                string username = u._email;
                string hashedPassword = u._hashedPassword;
                string LoginUser = "SELECT FROM Userdata WHERE Username=@username AND HashedPassword=@hashedPassword";
                SqlCommand cmd = new SqlCommand(LoginUser, conn);
                cmd.ExecuteNonQuery();

                SqlDataReader rdr = cmd.ExecuteReader();

                if ((string)rdr["Username"] != username || (string)rdr["HashedPassword"] != hashedPassword)
                {
                    throw new Exception("This user does not exist in the userbase");
                }
                else
                {
                    User.LoggedInUser = u;
                }

            }
            catch (Exception)
            {

            }
            finally
            {
                Disconnect();
            }
        }
    }
}

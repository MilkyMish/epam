using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entities;

namespace User_And_Awards_DAL
{
   public class DataSqlDAO:IData
    {
        private readonly string connectionString;
        public DataSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddUser(Users user)
        {
            //Users user = new Users() { Id = 3, Name = "Namew", Surname = "Lasr", Birthday = new DateTime(1997, 1, 1) };
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                command.CommandText = "InsertUser";
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;


                command.Parameters.AddWithValue("@name", SqlDbType.NVarChar);    // строки SqlDbType.NVarChar
                command.Parameters.AddWithValue("@surname", SqlDbType.NVarChar);
                command.Parameters.AddWithValue("@birthdate", SqlDbType.DateTime2);

                command.Prepare();

                command.Parameters[0].Value = user.Name;
                command.Parameters[1].Value = user.Surname;
                command.Parameters[2].Value = user.Birthday;
                // command.Parameters.Add("@retValue", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;
                connection.Open();
                //var result = command.ExecuteScalar().ToString() == null ? default(int) : int.Parse(command.ExecuteScalar().ToString()); ;
                /*var result=*/
                 command.ExecuteNonQuery();


                //AddUserRewards(connection, user);

                connection.Close();
            }
            #region old
            /*using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                command.CommandText = "InsertUser";
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;

                //command.Prepare();

                command.Parameters.AddWithValue("@name", user.Name);    // строки SqlDbType.NVarChar
                command.Parameters.AddWithValue("@surname", user.Surname);
                command.Parameters.AddWithValue("@birthdate", user.Birthday);

                connection.Open();

                var result = command.ExecuteScalar();
                var userId = (int)result;
                user.Id = userId;

                AddUserRewards(connection, user);

                connection.Close();
            }

            */
            #endregion old
        }

        /* public void test()
         {
             Users user = new Users() { Id = 3, Name = "Namew", Surname = "Lasr", Birthday = new DateTime(1997, 1, 1) };
             using (var connection = new SqlConnection(connectionString))
             using (var command = new SqlCommand())
             {
                 command.CommandText = "InsertUser";
                 command.CommandType = CommandType.StoredProcedure;
                 command.Connection = connection;


                 command.Parameters.AddWithValue("@name", SqlDbType.NVarChar);    // строки SqlDbType.NVarChar
                 command.Parameters.AddWithValue("@surname", SqlDbType.NVarChar);
                 command.Parameters.AddWithValue("@birthdate", SqlDbType.DateTime2);

                 command.Prepare();

                 command.Parameters[0].Value = user.Name;
                 command.Parameters[1].Value = user.Surname;
                 command.Parameters[2].Value = user.Birthday;

                 connection.Open();

                 var result = command.ExecuteScalar();
                 var userId = (int)result;
                 user.Id = userId;

                 //AddUserRewards(connection, user);

                 connection.Close();
             }

         }*/

        private void AddUserRewards(SqlConnection connection, Users user)
        {
            DataTable tempRewardsTable = new DataTable();
            tempRewardsTable.Columns.Add("RewardId", typeof(int));
            foreach (var r in user.Awards)
            {
                tempRewardsTable.Rows.Add(r.Id);
            }

            using (var command = new SqlCommand())
            {
                command.CommandText = "InsertUserRewards";
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;


                command.Parameters.AddWithValue("@userId", user.Id);
                var rewardsTablePArameter = command.Parameters.AddWithValue("@rewardIds", tempRewardsTable);
                rewardsTablePArameter.SqlDbType = SqlDbType.Structured;

                command.ExecuteNonQuery();
            }
        }


        public void AddAward(Awards award)
        {
            //Awa user = new Users() { Id = 3, Name = "Namew", Surname = "Lasr", Birthday = new DateTime(1997, 1, 1) };
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                command.CommandText = "AddAward";
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;


                command.Parameters.AddWithValue("@name", SqlDbType.NVarChar);    // строки SqlDbType.NVarChar
                command.Parameters.AddWithValue("@description", SqlDbType.NVarChar);
                //command.Parameters.AddWithValue("@birthdate", SqlDbType.DateTime2);

                command.Prepare();

                command.Parameters[0].Value = award.Title;
                command.Parameters[1].Value = award.Description;
                // command.Parameters[2].Value = user.Birthday;

                connection.Open();
                //var result = command.ExecuteScalar().ToString() == null ? default(int) : int.Parse(command.ExecuteScalar().ToString()); ;
                  var result = command.ExecuteScalar();
                // string prev_status = string.Format("SELECT cast(STATUS as float) prev_status FROM {0}_Table WHERE ASDU={1} AND IOA={2}",type_id, station, ioa);
                var Id = (int)result;
                award.Id = Id;

                //AddUserRewards(connection, user);

                connection.Close();
            }
        }

        public void EditUser(int id, Users user)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                command.CommandText = "UpdateUser";
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;

                command.Parameters.AddWithValue("@userId", SqlDbType.Int);
                command.Parameters.AddWithValue("@name", SqlDbType.NVarChar);    // строки SqlDbType.NVarChar
                command.Parameters.AddWithValue("@surname", SqlDbType.NVarChar);
                command.Parameters.AddWithValue("@birthday", SqlDbType.DateTime2);

                command.Prepare();

                command.Parameters[0].Value = user.Id;
                command.Parameters[1].Value = user.Name;
                command.Parameters[2].Value = user.Surname;
                command.Parameters[3].Value = user.Birthday;
                // command.Parameters.Add("@retValue", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;
                connection.Open();
                //var result = command.ExecuteScalar().ToString() == null ? default(int) : int.Parse(command.ExecuteScalar().ToString()); ;
                /*var result=*/
                command.ExecuteNonQuery();

                //AddUserRewards(connection, user);

                connection.Close();
            }
        }

        public IEnumerable<Users> GetUserList()
        {
            var users = new List<Users>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                command.CommandText = "GetUsers";
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;

                connection.Open();

                var reader = command.ExecuteReader();
                if ( reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var user = new Users();
                        user.Id = reader.GetInt32(0);
                        user.Name = reader.GetString(1);
                        user.Surname = reader.GetString(2);
                        user.Birthday = reader.GetDateTime(3);
                        users.Add(user);
                    }
                }

                connection.Close();
            }
            FillUserRewards(users);
            return users;
        }

        public IEnumerable<Awards> GetAwardList()
        {
            var awards = new List<Awards>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                command.CommandText = "GetAwards";
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;

                connection.Open();

                var reader = command.ExecuteReader(); 
                if (reader.HasRows)  
                {
                    while (reader.Read())
                    {
                        var award = new Awards();
                        award.Id = reader.GetInt32(0);
                        award.Title = reader.GetString(1);
                        award.Description = reader.GetString(2);
                       
                        awards.Add(award);
                    }
                }

                connection.Close();
            }

            return awards;
        }

        private void FillUserRewards(List<Users> users)
        {
            foreach (var user in users)
            {
                user.Awards = new List<Awards>();
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand())
                {
                    command.CommandText = "GetUsersAwards";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@userId", user.Id);

                    connection.Open();

                    var reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        List<Awards> awards = new List<Awards>(GetAwardList());
                        while (reader.Read())
                        {
                            var reward = new Awards();
                            reward.Id = reader.GetInt32(0);
                            foreach (var item in awards)
                            {
                                if (item.Id==reward.Id)
                                {
                                    reward.Title = item.Title;
                                    reward.Description = item.Description;
                                    user.Awards.Add(reward);
                                }
                            }
                            
                        }
                    }

                    connection.Close();
                }
            }
        }

        public void RemoveAward(int selectedId)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                command.CommandText = "DeleteAward";
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;

                command.Parameters.AddWithValue("@awardId", SqlDbType.Int);
              

                command.Prepare();

                command.Parameters[0].Value = selectedId;
                
                
                connection.Open();
               
                command.ExecuteNonQuery();

                connection.Close();
                
            }
        }
    }
}

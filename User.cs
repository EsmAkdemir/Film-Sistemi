using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace FilmKütüphanesiYönetimSistemi
{
    public class FilmClickedEventArgs : EventArgs
    {
        public FilmData ClickedFilmData { get; }

        public FilmClickedEventArgs(FilmData clickedFilmData)
        {
            ClickedFilmData = clickedFilmData;
        }
    }
    public class UserData
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }
        public long TC { get; set; }
        public bool Cinsiyet { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string AdSoyad { get; set; }

        public UserData(string userName, string password, UserType userType, long tc, bool cinsiyet, DateTime dogumTarihi, string adSoyad, int userId)
        {

            UserName = userName;
            Password = password;
            UserType = userType;
            TC = tc;
            Cinsiyet = cinsiyet;
            DogumTarihi = dogumTarihi;
            AdSoyad = adSoyad;
            UserId = userId;

        }

    }

    public enum UserType
    {
        Admin = 1,
        Premium = 2,
        Standard = 3
    }

    public class UserManager
    {
        private static UserManager instance;

        private UserManager() { }

        public static UserManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserManager();
                }
                return instance;
            }
        }

        public List<UserData> Users { get; set; } = new List<UserData>();

        public void DeleteUser(int userId)
        {
            UserData userToDelete = Users.FirstOrDefault(u => u.UserId == userId);

            if (userToDelete != null)
            {
                DeleteUserFromDatabase(userId);

                Users.Remove(userToDelete);
            }
            else
            {
                MessageBox.Show("User not found.");
            }
        }

        private void DeleteUserFromDatabase(int userId)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; Database=FilmDizi; UserId=postgres; Password=1234"))
            {
                conn.Open();

                NpgsqlCommand command = new NpgsqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.Text;
                command.CommandText = "DELETE FROM users WHERE \"userId\" = @userId";

                command.Parameters.AddWithValue("@userId", userId);

                int rowsAffected = command.ExecuteNonQuery();

                conn.Close();
            }
        }
    }

    public class Kullanıcı : UserData
    {
        public int Aylık_Ücret { get; set; }

        public Kullanıcı(string userName, string password, UserType userType, long tc, bool cinsiyet, DateTime dogumTarihi, string adSoyad, int userId)
            : base(userName, password, userType, tc, cinsiyet, dogumTarihi, adSoyad, userId)
        {
            UserManager.Instance.Users.Add(this);
        }
    }

    public class Standart_Kullanıcı : Kullanıcı
    {
        public Standart_Kullanıcı(string userName, string password, UserType userType, long tc, bool cinsiyet, DateTime dogumTarihi, string adSoyad, int userId)
            : base(userName, password, userType, tc, cinsiyet, dogumTarihi, adSoyad, userId)
        {
            Aylık_Ücret = 100;
        }
    }

    public class Premium_Kullanıcı : Kullanıcı
    {
        public Premium_Kullanıcı(string userName, string password, UserType userType, long tc, bool cinsiyet, DateTime dogumTarihi, string adSoyad, int userId)
            : base(userName, password, userType, tc, cinsiyet, dogumTarihi, adSoyad, userId)
        {
            Aylık_Ücret = (Aylık_Ücret * 25 / 100) + Aylık_Ücret;
        }
    }

    public class Yönetici : Kullanıcı
    {
        public Yönetici(string userName, string password, UserType userType, long tc, bool cinsiyet, DateTime dogumTarihi, string adSoyad, int userId)
            : base(userName, password, userType, tc, cinsiyet, dogumTarihi, adSoyad, userId)
        {
        }
    }

    public class DatabaseManager
    {
        private NpgsqlConnection conn;
        public event EventHandler FilmAdded;

        public DatabaseManager()
        {
            conn = new NpgsqlConnection("Server=localhost; Port=5432; Database=FilmDizi; UserId=postgres; Password=1234");
        }
        public List<UserData> GetUsersFromDatabase()
        {
            List<UserData> users = new List<UserData>();

            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM \"users\"", conn);
            NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                UserData user = new UserData(
                    reader["username"].ToString(),
                    reader["password"].ToString(),
                    (UserType)Convert.ToInt32(reader["userType"]),
                    Convert.ToInt64(reader["tc"]),
                    Convert.ToBoolean(reader["cinsiyet"]),
                    Convert.ToDateTime(reader["dogumtarihi"]),
                    reader["adsoyad"].ToString(),
                    Convert.ToInt32(reader["userId"])
                );
                users.Add(user);
            }

            conn.Close();

            return users;
        }

        public void SaveUserToDatabase(UserData user)
        {
            conn.Open();

            NpgsqlCommand countCommand = new NpgsqlCommand("SELECT COUNT(*) FROM \"users\"", conn);
            int currentUserCount = Convert.ToInt32(countCommand.ExecuteScalar());

            int newUserId = currentUserCount + 1;

            NpgsqlCommand insertCommand = new NpgsqlCommand();
            insertCommand.Connection = conn;
            insertCommand.CommandType = CommandType.Text;
            insertCommand.CommandText = "INSERT INTO \"users\" (username, password, \"userType\", tc, cinsiyet, dogumtarihi, adsoyad, \"userId\") VALUES (@username, @password, @userType, @tc, @cinsiyet, @dogumtarihi, @adsoyad, @userId)";

           
            insertCommand.Parameters.AddWithValue("@username", user.UserName);
            insertCommand.Parameters.AddWithValue("@password", user.Password);
            insertCommand.Parameters.AddWithValue("@userType", Convert.ToInt32(user.UserType));
            insertCommand.Parameters.AddWithValue("@tc", Convert.ToInt64(user.TC));
            insertCommand.Parameters.AddWithValue("@cinsiyet", Convert.ToBoolean(user.Cinsiyet));
            insertCommand.Parameters.AddWithValue("@dogumtarihi", user.DogumTarihi);
            insertCommand.Parameters.AddWithValue("@adsoyad", user.AdSoyad);
            insertCommand.Parameters.AddWithValue("@userId", newUserId);

        
            int rowsAffected = insertCommand.ExecuteNonQuery();

            conn.Close();

          
            if (rowsAffected > 0)
            {
                
                user.UserId = newUserId;
            }
        }
        public void SaveFilmToDatabase(FilmData film, string table)
        {
            conn.Open();


            NpgsqlCommand insertCommand = new NpgsqlCommand();
            insertCommand.Connection = conn;
            insertCommand.CommandType = CommandType.Text;
            insertCommand.CommandText = $"INSERT INTO {table} (filmid, filmname, director, imagepath, posterpath, description, ortpuan, yorum) VALUES (@filmid, @filmname, @director, @imagepath, @posterpath, @description, @ortpuan, @yorum)";

          
            insertCommand.Parameters.AddWithValue("@filmid", film.FilmId);
            insertCommand.Parameters.AddWithValue("@filmname", film.FilmName);
            insertCommand.Parameters.AddWithValue("@director", film.Director);
            insertCommand.Parameters.AddWithValue("@imagepath", film.ImagePath);
            insertCommand.Parameters.AddWithValue("@posterpath", film.PosterPath);
            insertCommand.Parameters.AddWithValue("@description", film.Description);
            insertCommand.Parameters.AddWithValue("@ortpuan", film.OrtPuan);
            insertCommand.Parameters.AddWithValue("@yorum", film.Yorum);

            int rowsAffected = insertCommand.ExecuteNonQuery();

            conn.Close();
            OnFilmAdded(EventArgs.Empty);
        }
        protected virtual void OnFilmAdded(EventArgs e)
        {
            FilmAdded?.Invoke(this, e);
        }
        public void DeleteAllRowsFromTable(string tableName)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; Database=FilmDizi; UserId=postgres; Password=1234"))
            {
                conn.Open();

                using (NpgsqlCommand command = new NpgsqlCommand($"DELETE FROM {tableName}", conn))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        public List<FilmData> GetFilmsFromDatabase(string table)
        {
            List<FilmData> films = new List<FilmData>();

          
            string sqlQuery = $"SELECT filmid, filmname, director, imagepath, posterpath, description, ortpuan, yorum FROM {table}";

           
            films = ExecuteYourQueryToGetFilms(sqlQuery);

            return films;
        }
        public List<FilmData> ExecuteYourQueryToGetFilms(string sqlQuery)
        {
         
            List<FilmData> films = new List<FilmData>();

            using (NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; Database=FilmDizi; UserId=postgres; Password=1234"))
            {
                conn.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand(sqlQuery, conn))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FilmData film = new FilmData
                            {
                                FilmId = reader.GetInt32(reader.GetOrdinal("filmid")),
                                FilmName = reader.GetString(reader.GetOrdinal("filmname")),
                                Director = reader.GetString(reader.GetOrdinal("director")),
                                ImagePath = reader.GetString(reader.GetOrdinal("imagepath")),
                                PosterPath = reader.GetString(reader.GetOrdinal("posterpath")),
                                Description = reader.GetString(reader.GetOrdinal("description")),
                                OrtPuan = reader.GetDouble(reader.GetOrdinal("ortpuan")),
                                Yorum = reader.GetInt32(reader.GetOrdinal("yorum"))
                              
                            };

                            films.Add(film);
                        }
                    }
                }
            }

            return films;
        }
        public void ResetDatabase(string database)
        {
            conn.Open();

         
            NpgsqlCommand deleteCommand = new NpgsqlCommand($"DELETE FROM {database}", conn);

          
            deleteCommand.ExecuteNonQuery();

            conn.Close();
        }
        public void UpdateFilmInDatabase(FilmData film)
        {
            conn.Open();

          
            NpgsqlCommand updateCommand = new NpgsqlCommand();
            updateCommand.Connection = conn;
            updateCommand.CommandType = CommandType.Text;
            updateCommand.CommandText = "UPDATE Films SET filmname = @filmname, director = @director, imagepath = @imagepath, posterpath = @posterpath, description = @description WHERE filmid = @filmid";

        
            updateCommand.Parameters.AddWithValue("@filmid", film.FilmId);
            updateCommand.Parameters.AddWithValue("@filmname", film.FilmName);
            updateCommand.Parameters.AddWithValue("@director", film.Director);
            updateCommand.Parameters.AddWithValue("@imagepath", film.ImagePath);
            updateCommand.Parameters.AddWithValue("@posterpath", film.PosterPath);
            updateCommand.Parameters.AddWithValue("@description", film.Description);

           
            int rowsAffected = updateCommand.ExecuteNonQuery();

            conn.Close();
        }
        public void DeleteFilmDataFromDatabase(FilmData film)
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; Database=FilmDizi; UserId=postgres; Password=1234"))
                {
                    conn.Open();

                   
                    NpgsqlCommand deleteCommand = new NpgsqlCommand();
                    deleteCommand.Connection = conn;
                    deleteCommand.CommandType = CommandType.Text;
                    deleteCommand.CommandText = "DELETE FROM list WHERE filmname = @filmname";

                   
                    deleteCommand.Parameters.AddWithValue("@filmname", film.FilmName);

              
                    int rowsAffected = deleteCommand.ExecuteNonQuery();

                    conn.Close();

                   
                    if (rowsAffected > 0)
                    {
                        
                    }
                    else
                    {
                        MessageBox.Show("No rows matched the deletion criteria.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting film data: {ex.Message}");
            }
        }

        public void DeleteTable(FilmData film, string table)
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; Database=FilmDizi; UserId=postgres; Password=1234"))
                {
                    conn.Open();

               
                    NpgsqlCommand deleteCommand = new NpgsqlCommand();
                    deleteCommand.Connection = conn;
                    deleteCommand.CommandType = CommandType.Text;
                    deleteCommand.CommandText = $"DELETE FROM {table} WHERE filmname = @filmname";

           
                    deleteCommand.Parameters.AddWithValue("@filmname", film.FilmName);

                    
                    int rowsAffected = deleteCommand.ExecuteNonQuery();

                    conn.Close();

                   
                    if (rowsAffected > 0)
                    {

                    }
                    else
                    {
                        MessageBox.Show("No rows matched the deletion criteria.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting film data: {ex.Message}");
            }
        }

    }
}


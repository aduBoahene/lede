using ledeModels.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace ledeHelpers
{
    public class DBHelper
    {
        private static string _Ycon = ConfigurationManager.AppSettings["WRITE_CON_STR"];
        public static DBHelper Instance = new DBHelper();
        public static readonly object instance;


        public User Login(Object a,string returnUrl)
        {
            using (var con = new NpgsqlConnection(_Ycon))
            {
                var results = new User();

                var cmd = new NpgsqlCommand("\"login\"", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                con.Open(); var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return new User
                    {
                        UserId = reader.GetFieldValue<int>(0),
                        username = reader.GetFieldValue<string>(1),
                        password = reader.GetFieldValue<string>(2),
                        LastLogon = reader.GetFieldValue<DateTime>(3),
                        HouseId = reader.GetFieldValue<int>(4)
                    };
                }
                con.Close(); con.Dispose();
                return results;

            }
        }


        public int PostMovie(PostMovie movie)
        {
            using (var con = new NpgsqlConnection(_Ycon))
            {
                int result;

                movie.Title = movie.Title;
                movie.GenreId = movie.GenreId;
                movie.Synopsis = movie.Synopsis;
                movie.PosterUrl = movie.PosterUrl;
                movie.TrailerUrl = movie.TrailerUrl;
                movie.Amount = movie.Amount;
                movie.HouseId = movie.HouseId;
                movie.ReleaseDate = movie.ReleaseDate;
                movie.CreatedBy = movie.CreatedBy;
                movie.CreationDate = movie.CreationDate;
                movie.UserId = movie.UserId;

                var cmd = new NpgsqlCommand("\"submitmovie\"", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new NpgsqlParameter("reqTitle", NpgsqlTypes.NpgsqlDbType.Varchar));
                cmd.Parameters[0].Value = movie.Title;

                cmd.Parameters.Add(new NpgsqlParameter("reqGenreId", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters[1].Value = movie.GenreId;

                cmd.Parameters.Add(new NpgsqlParameter("reqSynopsis", NpgsqlTypes.NpgsqlDbType.Varchar));
                cmd.Parameters[2].Value = movie.Synopsis;

                cmd.Parameters.Add(new NpgsqlParameter("reqPosterUrl", NpgsqlTypes.NpgsqlDbType.Varchar));
                cmd.Parameters[3].Value = movie.PosterUrl;

                cmd.Parameters.Add(new NpgsqlParameter("reqTrailerUrl", NpgsqlTypes.NpgsqlDbType.Varchar));
                cmd.Parameters[4].Value = movie.TrailerUrl;

                cmd.Parameters.Add(new NpgsqlParameter("reqAmount", NpgsqlTypes.NpgsqlDbType.Varchar));
                cmd.Parameters[5].Value = movie.Amount;

                cmd.Parameters.Add(new NpgsqlParameter("reqHouseId", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters[6].Value = movie.HouseId;

                cmd.Parameters.Add(new NpgsqlParameter("reqReleaseDate", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters[7].Value = movie.ReleaseDate;

                cmd.Parameters.Add(new NpgsqlParameter("reqCreatedBy", NpgsqlTypes.NpgsqlDbType.Varchar));
                cmd.Parameters[8].Value = movie.CreatedBy;

                cmd.Parameters.Add(new NpgsqlParameter("reqCreationDate", NpgsqlTypes.NpgsqlDbType.Date));
                cmd.Parameters[9].Value = movie.CreationDate;

                cmd.Parameters.Add(new NpgsqlParameter("reqUserId", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters[10].Value = movie.UserId;


                con.Open();

                result = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                con.Dispose();
                return result;
            }
        }


        public List<ShowMoment> GetMovieTime(int movieId)
        {
            using (var con = new NpgsqlConnection(_Ycon))
            {
                var results = new List<ShowMoment>();

                var cmd = new NpgsqlCommand("\"getshowtimesformovie\"", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new NpgsqlParameter("reqMovieId", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters[0].Value = movieId;

                con.Open(); var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    results.Add(new ShowMoment
                    {
                        ShowMomentId = reader.GetFieldValue<int>(0),
                        Day = reader.GetFieldValue<string>(1),
                        Time = reader.GetFieldValue<string>(2)
                    });
                }
                con.Close(); con.Dispose();
                return results;

            }
        }

        public List<Promotion> GetAllPromotions(int houseId)
        {
            using (var con = new NpgsqlConnection(_Ycon))
            {
                var results = new List<Promotion>();

                var cmd = new NpgsqlCommand("\"getallpromotions\"", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new NpgsqlParameter("reqHouseId", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters[0].Value = houseId;

                con.Open(); var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    results.Add(new Promotion
                    {
                        PromotionId = reader.GetFieldValue<int>(0),
                        Name = reader.GetFieldValue<string>(1),
                        HouseId = reader.GetFieldValue<int>(2),
                        StartDate = reader.GetFieldValue<DateTime>(3),
                        EndDate = reader.GetFieldValue<DateTime>(4),
                        Description = reader.GetFieldValue<string>(5),

                    });
                }
                con.Close(); con.Dispose();
                return results;

            }
        }
        public List<Payment> GetPaymentByHouse(int HouseId)
        {
            using (var con = new NpgsqlConnection(_Ycon))
            {
                var results = new List<Payment>();

                var cmd = new NpgsqlCommand("\"getpaymentbyhouse\"", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new NpgsqlParameter("reqHouseId", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters[0].Value = HouseId;

                con.Open(); var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    results.Add(new Payment
                    {
                        PaymentId = reader.GetFieldValue<int>(0),
                        Name = reader.GetFieldValue<string>(1)
                    });
                }
                con.Close(); con.Dispose();
                return results;

            }
        }

        public List<Movie> GetAllMovie(int houseId)
        {
            using (var con = new NpgsqlConnection(_Ycon))
            {
                var results = new List<Movie>();

                var cmd = new NpgsqlCommand("\"getallmovies\"", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new NpgsqlParameter("reqHouseId", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters[0].Value = houseId;

                con.Open(); var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    results.Add(new Movie
                    {
                        MovieId = reader.GetFieldValue<int>(0),
                        HouseId = reader.GetFieldValue<int>(1),
                        Title = reader.GetFieldValue<string>(2),
                        GenreName = reader.GetFieldValue<string>(3),
                        Synopsis = reader.GetFieldValue<string>(4),
                        PosterUrl = reader.GetFieldValue<string>(5),
                        TrailerUrl = reader.GetFieldValue<string>(6),
                        Amount = reader.GetFieldValue<string>(7),
                        HouseName = reader.GetFieldValue<string>(8),
                        ReleaseDate = reader.GetFieldValue<DateTime>(9)
                    });
                }
                con.Close(); con.Dispose();
                return results;

            }
        }

        public List<House> GetHouseDetail(int houseId)
        {
            using (var con = new NpgsqlConnection(_Ycon))
            {
                var results = new List<House>();

                var cmd = new NpgsqlCommand("\"gethouse\"", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new NpgsqlParameter("reqHouseId", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters[0].Value = houseId;

                con.Open(); var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    results.Add(new House
                    {
                        HouseId = reader.GetFieldValue<int>(0),
                        HouseName = reader.GetFieldValue<string>(1),
                        LocationName = reader.GetFieldValue<string>(2),
                        logoFilePath = reader.GetFieldValue<string>(3)
                    });
                }
                con.Close(); con.Dispose();
                return results;

            }
        }


        public List<House> GetAllHouses()
        {
            using (var con = new NpgsqlConnection(_Ycon))
            {
                var results = new List<House>();

                var cmd = new NpgsqlCommand("\"getallhouses\"", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //cmd.Parameters.Add(new NpgsqlParameter("reqHouseId", NpgsqlTypes.NpgsqlDbType.Integer));
                //cmd.Parameters[0].Value = houseId;

                con.Open(); var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    results.Add(new House
                    {
                        HouseId = reader.GetFieldValue<int>(0),
                        HouseName = reader.GetFieldValue<string>(1),
                        LocationName = reader.GetFieldValue<string>(2)
                    });
                }
                con.Close(); con.Dispose();
                return results;

            }
        }


        public List<Booking> GetAllBooking(int houseId)
        {
            using (var con = new NpgsqlConnection(_Ycon))
            {
                var results = new List<Booking>();

                var cmd = new NpgsqlCommand("\"getbookingforhouse\"", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new NpgsqlParameter("reqHouseId", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters[0].Value = houseId;

                con.Open(); var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    results.Add(new Booking
                    {
                        BookingId = reader.GetFieldValue<int>(0),
                        Title = reader.GetFieldValue<string>(1),
                        FullName = reader.GetFieldValue<string>(2),
                        BookingDate = reader.GetFieldValue<DateTime>(3),
                        HouseId = reader.GetFieldValue<int>(4),
                        PaymentName = reader.GetFieldValue<string>(5),
                        Amount = reader.GetFieldValue<string>(6),
                        HouseName = reader.GetFieldValue<string>(7),
                        Day = reader.GetFieldValue<string>(8),
                        Time = reader.GetFieldValue<string>(9),
                        BookingNumber = reader.GetFieldValue<string>(10)

                    });
                }
                con.Close(); con.Dispose();
                return results;

            }
        }


        public List<Customer> GetAllCustomers(int houseId)
        {
            using (var con = new NpgsqlConnection(_Ycon))
            {
                var results = new List<Customer>();

                var cmd = new NpgsqlCommand("\"getcustomers\"", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new NpgsqlParameter("reqHouseId", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters[0].Value = houseId;

                con.Open(); var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    results.Add(new Customer
                    {
                        CustomerId = reader.GetFieldValue<int>(0),
                        FullName = reader.GetFieldValue<string>(1),
                        Phone = reader.GetFieldValue<string>(2),
                        Address = reader.GetFieldValue<string>(3),
                        Email = reader.GetFieldValue<string>(4),
                        HouseId = reader.GetFieldValue<int>(5)
                    });
                }
                con.Close(); con.Dispose();
                return results;

            }
        }

        public List<House> GetAllHouses(int houseId)
        {
            using (var con = new NpgsqlConnection(_Ycon))
            {
                var results = new List<House>();

                var cmd = new NpgsqlCommand("\"gethouse\"", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new NpgsqlParameter("reqHouseId", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters[0].Value = houseId;

                con.Open(); var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    results.Add(new House
                    {
                        HouseId = reader.GetFieldValue<int>(0),
                        HouseName = reader.GetFieldValue<string>(1),
                        LocationName = reader.GetFieldValue<string>(2),
                        logoFilePath = reader.GetFieldValue<string>(3)
                    });
                }
                con.Close(); con.Dispose();
                return results;

            }
        }

        public List<Movie> GetMovieById(int HouseId,int MovieId)
        {


            var results = new List<Movie>();
            var con = new NpgsqlConnection(_Ycon);
            var cmd = new NpgsqlCommand("\"getmoviebyid\"", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(new NpgsqlParameter("reqHouseId", NpgsqlTypes.NpgsqlDbType.Integer));
            cmd.Parameters[0].Value = HouseId;

            cmd.Parameters.Add(new NpgsqlParameter("reqMovieId", NpgsqlTypes.NpgsqlDbType.Integer));
            cmd.Parameters[1].Value = MovieId;

            con.Open(); var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                results.Add(new Movie
                {

                    MovieId = reader.GetFieldValue<int>(0),
                    Title = reader.GetFieldValue<string>(1),
                    GenreName = reader.GetFieldValue<string>(2),
                    Synopsis = reader.GetFieldValue<string>(3),
                    PosterUrl = reader.GetFieldValue<string>(4),
                    TrailerUrl = reader.GetFieldValue<string>(5),
                    Amount = reader.GetFieldValue<string>(6),
                    ReleaseDate = reader.GetFieldValue<DateTime>(7)
                });
            }
            con.Close(); con.Dispose();
            return results;
        }

        //post booking
        public int PostBooking(PostBooking booking)
        {
            using (var con = new NpgsqlConnection(_Ycon))
            {
                int result;

                var cmd = new NpgsqlCommand("\"submitbooking\"", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new NpgsqlParameter("reqMovieId", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters[0].Value = booking.MovieId;

                cmd.Parameters.Add(new NpgsqlParameter("reqBookDate", NpgsqlTypes.NpgsqlDbType.Timestamp));
                //cmd.Parameters[1].Value = booking.BookingDate;
                cmd.Parameters[1].Value = DateTime.Now;

                cmd.Parameters.Add(new NpgsqlParameter("reqPaymentMethodId", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters[2].Value = booking.PaymentMethodId;

                cmd.Parameters.Add(new NpgsqlParameter("reqHouseId", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters[3].Value = booking.HouseId;

                cmd.Parameters.Add(new NpgsqlParameter("reqAmount", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters[4].Value =booking.Amount;

                cmd.Parameters.Add(new NpgsqlParameter("reqShowMomentId", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters[5].Value = booking.ShowMomentId;

                cmd.Parameters.Add(new NpgsqlParameter("reqCustomerId", NpgsqlTypes.NpgsqlDbType.Integer));
                cmd.Parameters[6].Value = booking.CustomerId;


                cmd.Parameters.Add(new NpgsqlParameter("reqBookingNum", NpgsqlTypes.NpgsqlDbType.Varchar));
                //cmd.Parameters[7].Value = booking.BookingNumber;
                cmd.Parameters[7].Value = randomStringToAdd();

                con.Open();

                result = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                con.Dispose();
                return result;
            }
        }


        private string randomStringToAdd()
        {
            Random rnd = new Random();
            string s;
            string preFix = "BOO";
            s = preFix + rnd.Next(10000); ;
            return s;
        }

    }
}

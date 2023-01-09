using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace gggg
{
    internal class Program
    {
       public static string constring = "Server=(localdb)\\mssqllocaldb; Database=adonetdb; Trusted_Connection=True";

        static async Task Main(string[] args)
        {
            
            Console.WriteLine("Ismni kiriting:");
            string name=Console.ReadLine();



            //Console.WriteLine("Yoshni kiriting:");
            //int age=Int32.Parse(Console.ReadLine());    


           // await AddUserAsync(name, age);
           await GetAgeRange(name);

            Console.WriteLine();


            //await GetUsersAsync();

            static async Task GetAgeRange(string name)
            {
                string sqlExpression = "sp_GetAgeRange";

                using(SqlConnection connection=new SqlConnection(constring))
                {
                    await connection.OpenAsync();

                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                        command.CommandType = CommandType.StoredProcedure;


                    SqlParameter nameParameter = new SqlParameter()
                    {
                        ParameterName = "@name",
                        Value = name
                    };

                    command.Parameters.Add(nameParameter);


                    SqlParameter minAgeParameter = new SqlParameter()
                    {
                        ParameterName = "@minAge",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output

                    };
                    command.Parameters.Add(minAgeParameter);


                    SqlParameter maxAgeParameter = new SqlParameter()
                    {
                        ParameterName = "@maxAge",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(maxAgeParameter);

                    await command.ExecuteNonQueryAsync();

                    object minAge = command.Parameters["@minAge"].Value;
                    object maxAge = command.Parameters["@maxAge"].Value;


                    Console.WriteLine("Max age="+maxAge);
                    Console.WriteLine("Min age="+minAge);





                }



            }

           static async Task AddUserAsync(string name, int age)
            {

                string sqlExpression = "sp_InsertUser";

                using(SqlConnection connection =new SqlConnection(constring))
                {
                    await connection.OpenAsync();


                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;


                    SqlParameter nameParameter = new SqlParameter()
                    {
                        ParameterName="@name",
                        Value=name,
                    };
                    command.Parameters.Add(nameParameter);

                    SqlParameter ageParameter = new SqlParameter()
                    {
                        ParameterName = "@age",
                        Value = age
                    };
                    command.Parameters.Add(ageParameter);

                    var id =await command.ExecuteNonQueryAsync();

                    Console.WriteLine("Joylashgan element id="+id);




                }

            }


            static async Task GetUsersAsync()
            {
                string sqlExpression = "sp_GetUsers";


                using (SqlConnection connection =new SqlConnection(constring))
                {
                    await connection.OpenAsync();

                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;


                    using(SqlDataReader reader=await command.ExecuteReaderAsync())
                    {
                        if(reader.HasRows)
                        {

                            object idColumn = reader.GetName(0);
                            object ageColumn=reader.GetName(1); 
                            object nameColumn=reader.GetName(2);

                            Console.WriteLine($"{idColumn}\t {ageColumn}\t{nameColumn}");


                            while(await reader.ReadAsync())
                            {
                                int id=reader.GetInt32(0);
                                int age=reader.GetInt32(1);
                                string name=reader.GetString(2);

                                Console.WriteLine($"{id}\t {age}\t {name}");
                            }

                        }


                    }


                }



            }




            //using(SqlConnection con = new SqlConnection(constring))
            //{
            //string proc1 = @"CREATE PROCEDURE [dbo].[sp_InsertUser]
            //         @name nvarchar(50),
            //         @age int
            //            AS 
            //                INSERT INTO Users  (Name, Age)
            //                Values(@name, @age)
            //                SELECT SCOPE_IDENTITY()
            //            GO";
            //string proc2 = @"CREATE PROCEDURE [dbo].[sp_GetUsers]
            //            AS
            //                 SELECT * FROM Users
            //            GO";


            //    await con.OpenAsync();
            //    SqlCommand command=new SqlCommand(proc1, con);
            //    await command.ExecuteNonQueryAsync();

            //    command.CommandText=proc2;
            //    await command.ExecuteNonQueryAsync();   


            //}




            //using (SqlConnection connection = new SqlConnection(constring))
            //{

            //    int age = 299;
            //    string name = "Shoh";

            //    string sqlExpression = "INSERT INTO Users (Name, Age) Values(@name, @age); Set @id=SCOPE_IDENTITY()";

            //    await connection.OpenAsync();


            //    SqlCommand command = new SqlCommand(sqlExpression, connection);

            //    SqlParameter nameParameter = new SqlParameter("@name", name);
            //    command.Parameters.Add(nameParameter);

            //    SqlParameter ageParameter = new SqlParameter("@age", age);
            //    command.Parameters.Add(ageParameter);

            //    SqlParameter idParam = new SqlParameter()
            //    {
            //        ParameterName = "@id",
            //        SqlDbType = SqlDbType.Int,
            //        Direction = ParameterDirection.Output
            //    };

            //    command.Parameters.Add(idParam);    
            //    await command.ExecuteNonQueryAsync();

            //    Console.WriteLine(idParam.Value);


            //}



            //string sqlexpression = "INSERT INTO Users(Name, Age) Values(@name, @age)";

            //using (SqlConnection connection=new SqlConnection(constring))
            //{
            //    await connection.OpenAsync();


            //    SqlCommand command=new SqlCommand(sqlexpression, connection);

            //    SqlParameter nameParameter = new SqlParameter("@name", name);
            //    command.Parameters.Add(nameParameter);

            //    SqlParameter ageParameter = new SqlParameter("@age", age);
            //    command.Parameters.Add(ageParameter);


            //    int number = await command.ExecuteNonQueryAsync();
            //    Console.WriteLine(number);


            //    command.CommandText = "SELECT * FROM Users";

            //    using (SqlDataReader reader=await command.ExecuteReaderAsync())
            //    {

            //        if(reader.HasRows)
            //        {

            //            object idColumn = reader.GetName(0);
            //            object ageColumn=reader.GetName(1);
            //            object nameColumn = reader.GetName(2);

            //            Console.WriteLine($"{idColumn}\t {ageColumn}\t {nameColumn}");


            //            while(await reader.ReadAsync())
            //            {
            //                int id = reader.GetInt32(0);
            //                int ageRow=reader.GetInt32(1);
            //                string nameRow=reader.GetString(2);


            //                Console.WriteLine($"{id}\t {ageRow}\t{nameRow}");
            //            }

            //        }

            //    }


            //}


            //using (SqlConnection connection = new SqlConnection(constring))
            //{

            //    await connection.OpenAsync();

            //    SqlCommand command = new SqlCommand();
            //    command.CommandType = CommandType.Text;
            //    command.CommandText = "SELECT COUNT(*) FROM Users";
            //    command.Connection = connection;

            //    object count = await command.ExecuteScalarAsync();
            //    Console.WriteLine("Soni=" + count);

            //    command.CommandText = "Select Min(Age) FROM Users";
            //    object minAge = await command.ExecuteScalarAsync();
            //    Console.WriteLine("MIN AGE=" + minAge);

            //    command.CommandText = "SELECT MAX(Age) FROM Users";

            //    object maxAge = await command.ExecuteScalarAsync();
            //    Console.WriteLine("Max Age" + maxAge);
            //}


            //using (SqlConnection connection=new SqlConnection(constring))
            // {
            //     await connection.OpenAsync();

            //     SqlCommand command = new SqlCommand();
            //     command.CommandText = "Select * from Users";
            //     command.CommandType = CommandType.Text; 
            //     command.Connection = connection;

            //     using(SqlDataReader reader = await command.ExecuteReaderAsync())
            //     {

            //         if(reader.HasRows)
            //         {
            //             object column1 = reader.GetName(0);
            //             object column2 = reader.GetName(1);
            //             object column3 = reader.GetName(2);


            //             Console.WriteLine($"{column1}\t {column2}\t {column3}");



            //             while(await reader.ReadAsync())
            //             {
            //                 int id=reader.GetInt32(0);
            //                 int age2 = reader.GetInt32(1);
            //                 string name2=reader.GetString(2);

            //                 Console.WriteLine($"{id}\t{age2}\t {name2}");
            //             }

            //         }


            //     }


            // }


        }



    }
}

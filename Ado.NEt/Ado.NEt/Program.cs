using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Ado.NEt
{
    internal static class Program
    {
         static async void Main(string[] args)
        {
            await AdoNEt();

            Console.WriteLine("Project shot down");
        } 
       public static async Task AdoNEt()
        {
            string constring = "Server=(localdb)\\mssqllocaldb; Database=master; Trusted_Connection=True";


            SqlConnection sqlconnection = new SqlConnection(constring);


            try
            {
                await sqlconnection.OpenAsync();
                Console.WriteLine("Bazaga ulandi");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                if (sqlconnection.State == ConnectionState.Open)
                {
                    await sqlconnection.CloseAsync();
                    Console.WriteLine("Bazadan uzildi");
                }
            }
        }
    }
}

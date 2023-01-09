using System.Data.SqlClient;

string conString = "Server=(localdb)\\mssqllocaldb; Database=StudentDB; Trusted_Connection=True;";
using(SqlConnection con =new SqlConnection(conString))
{
   
   

    SqlCommand cmd=new SqlCommand();
    cmd.Connection = con;
    cmd.CommandText = "SELECT * FROM student";
    cmd.CommandType=System.Data.CommandType.StoredProcedure;


    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

    con.Open();

    SqlDataReader reader = cmd.ExecuteReader();
    while(reader.Read())
    {
        Console.WriteLine(reader["Name"]+",   "+ reader["Email"]+",  "+ reader["Mobile"]);
    }

}
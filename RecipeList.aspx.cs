using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RecipeList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection dbConn = new SqlConnection();

        //1.1 set the connection string to a specific database
        dbConn.ConnectionString = ConfigurationManager.ConnectionStrings["MealsProject"].ConnectionString;

        //2. create a command to tell the db what to do
        SqlCommand command = new SqlCommand();

        //2.1 set the name of the stored proc to be sent with the command
        command.CommandText = "SELECT Meat, Fruit, Vegetable, Grain, Instruction FROM Recipe";
        //stored proc not a text query
        command.CommandType = System.Data.CommandType.Text;
        //associate the command with a connection
        command.Connection = dbConn;

        //3. open the connection
        dbConn.Open();
        //create the reader
        SqlDataReader reader = command.ExecuteReader();

        //supply the grid view with data
        GridView1.DataSource = reader;
        //bind said data
        GridView1.DataBind();

        command.Dispose();
        dbConn.Close();
        dbConn.Dispose();
    }
}
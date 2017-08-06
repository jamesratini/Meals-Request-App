using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Web;
using System.Web.UI;
using MealsRequest;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.AspNet.Identity.EntityFramework;

public partial class Account_Login : Page
{
        protected void Page_Load(object sender, EventArgs e)
        {
      
        }

    protected void registerButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("Register.aspx");
    }

    protected void LogIn(object sender, EventArgs e)
    {
        string username = UserName.Text;
        string password = Password.Text;

        //empty out the textboxes after we get the data from them
       
        UserName.Text = "";
        Password.Text = "";

        //1. create a connection to the database
        SqlConnection dbConn = new SqlConnection();

        //1.1 set the connection string to a specific database
        dbConn.ConnectionString = ConfigurationManager.ConnectionStrings["MealsProject"].ConnectionString;

        //2. create a command to tell the db what to do
        SqlCommand command = new SqlCommand();

        //2.1 set the text of the query to be sent with the command
        command.CommandText = "SELECT * FROM Users WHERE Users.username = @username AND Users.password = @password";
        //this will be a plain text query not a stored proc
        command.CommandType = System.Data.CommandType.Text;
        //associate the command with a connection
        command.Connection = dbConn;

        //2.2 fill in the parameters from the query 
        SqlParameter userNameParam = new SqlParameter();
        //the text that is being replaced in the query
        userNameParam.ParameterName = "@username";
        //the value to replace it with
        userNameParam.Value = username;
        //the type and size of the data
        userNameParam.SqlDbType = System.Data.SqlDbType.NVarChar;
        userNameParam.Size = 50;

        //2.2 fill in the parameters from the query 
        SqlParameter passwordParam = new SqlParameter();
        //the text that is being replaced in the query
        passwordParam.ParameterName = "@password";
        //the value to replace it with
        passwordParam.Value = password;
        //the type and size of the data
        passwordParam.SqlDbType = System.Data.SqlDbType.NVarChar;
        passwordParam.Size = 50;

        command.Parameters.Add(userNameParam);
        command.Parameters.Add(passwordParam);

        //3. open the connection to allow the command to go through it
        dbConn.Open();

        //4. execute the query (there are no results in an insert, use the non-query version)
        SqlDataReader reader = command.ExecuteReader();

       /* var manager = new UserManager();
        ApplicationUser sessionUser = null;*/
        //if there are rows, succesful login
        if (reader.HasRows)
        {
            Session["loggedIn"] = true;
            Session["username"] = username;
           // sessionUser.UserName = username;
        }
        else
        {
            Session["loggedIn"] = false;
        }

        //5. clean up all the resources
        command.Dispose();
        dbConn.Close();
        dbConn.Dispose();

        if ((bool)Session["loggedIn"] == true)
        {
            
            Response.Redirect("~/Default.aspx");
        }
        else
        {
            FailureText.Text = "Invalid Login";
        }


    }
}
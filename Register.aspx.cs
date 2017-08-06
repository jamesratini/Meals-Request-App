using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.UI;
using MealsRequest;
using System.Data.SqlClient;
using System.Configuration;

public partial class Account_Register : Page
{
    protected void CreateUser_Click(object sender, EventArgs e)
    {
        //get the new user name and password from the text boxes
        string email = Email.Text;
        string username = UserName.Text;
        string password = Password.Text;

        //empty out the textboxes after we get the data from them
        Email.Text = "";
        UserName.Text = "";
        Password.Text = "";

        //1. create a connection to the database
        SqlConnection dbConn = new SqlConnection();

        //1.1 set the connection string to a specific database
        dbConn.ConnectionString = ConfigurationManager.ConnectionStrings["MealsProject"].ConnectionString;

        //2. create a command to tell the db what to do
        SqlCommand command = new SqlCommand();

        //2.1 set the text of the query to be sent with the command
        command.CommandText = "INSERT INTO Users(username, password, email) VALUES (@username, @password, @email)";
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

        SqlParameter emailParam = new SqlParameter();
        emailParam.ParameterName = "@email";
        emailParam.Value = email;
        emailParam.SqlDbType = System.Data.SqlDbType.NVarChar;
        emailParam.Size = 50;

        SqlParameter passwordParam = new SqlParameter();
        //the text that is being replaced in the query
        passwordParam.ParameterName = "@password";
        //the value to replace it with
        passwordParam.Value = password;
        //the type and size of the data
        passwordParam.SqlDbType = System.Data.SqlDbType.NVarChar;
        passwordParam.Size = 50;

        //add the parameters to the command
        command.Parameters.Add(emailParam);
        command.Parameters.Add(userNameParam);
        command.Parameters.Add(passwordParam);

        //3. open the connection to allow the command to go through it
        dbConn.Open();

        //4. execute the query (there are no results in an insert, use the non-query version)
        command.ExecuteNonQuery();

        //5. clean up all the resources
        command.Dispose();
        dbConn.Close();
        dbConn.Dispose();
    }

    protected void loginButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Account/Login.aspx");
    }
}
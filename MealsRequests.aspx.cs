using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MealsRequests : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

       /* if((bool)Session["loggedIn"] != true)
        {
            Response.Redirect("~/Account/Login.aspx");
        }*/
        createRequestPost.Visible = false;
        //1. create a connection to the database
        SqlConnection dbConn = new SqlConnection();

        //1.1 set the connection string to a specific database
        dbConn.ConnectionString = ConfigurationManager.ConnectionStrings["MealsProject"].ConnectionString;

        //2. create a command to tell the db what to do
        SqlCommand command = new SqlCommand();

        //2.1 set the name of the stored proc to be sent with the command
        command.CommandText = "SELECT RequestPost.RequestId, username, Pickup, ContactNumber FROM Users, RequestPost WHERE RequestPost.UserId = Users.UserId ";
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



    protected void requestPostButton_Click(object sender, EventArgs e)
    {
        //change id=createRequestForm to visible
        createRequestPost.Visible = true;
        requestPostButton.Visible = false;
    }

    protected void submitRequest_Click(object sender, EventArgs e)
    {
        //insert the requestpost into database
        string diet = requestCreateDietText.Text;
        string desc = requestCreateDescText.Text;
        string contact = requestCreateContactText.Text;
        string pickup = requestCreatePickupButtons.SelectedValue;

        bool pickupConfirm = true;

        if(pickup == "1")
        {
            pickupConfirm = true;
        }
        else
        {
            pickupConfirm = false;
        }

        //1. create a connection to the database
        SqlConnection dbConn = new SqlConnection();

        //1.1 set the connection string to a specific database
        dbConn.ConnectionString = ConfigurationManager.ConnectionStrings["MealsProject"].ConnectionString;

        //2. create a command to tell the db what to do
        SqlCommand command = new SqlCommand();

        //2.1 set the text of the query to be sent with the command
        command.CommandText = "INSERT INTO RequestPost (DietRestrictions, Pickup, Description, ContactNumber, UserId) VALUES (@diet, @pickup, @desc, @contact, (SELECT Users.UserId FROM Users WHERE Users.username = @sessionUser))";
        //this will be a plain text query not a stored proc
        command.CommandType = System.Data.CommandType.Text;
        //associate the command with a connection
        command.Connection = dbConn;

        //2.2 fill in the parameters from the query 
        SqlParameter dietParam = new SqlParameter();
        //the text that is being replaced in the query
        dietParam.ParameterName = "@diet";
        //the value to replace it with
        dietParam.Value = diet;
        //the type and size of the data
        dietParam.SqlDbType = System.Data.SqlDbType.NVarChar;
        dietParam.Size = 50;

        //2.2 fill in the parameters from the query 
        SqlParameter pickupParam = new SqlParameter();
        //the text that is being replaced in the query
        pickupParam.ParameterName = "@pickup";
        //the value to replace it with
        pickupParam.Value = pickupConfirm;
        //the type and size of the data
        pickupParam.SqlDbType = System.Data.SqlDbType.Bit;
        pickupParam.Size = 11;

        SqlParameter descParam = new SqlParameter();
        //the text that is being replaced in the query
        descParam.ParameterName = "@desc";
        //the value to replace it with
        descParam.Value = desc;
        //the type and size of the data
        descParam.SqlDbType = System.Data.SqlDbType.NVarChar;
        descParam.Size = 99999;

        SqlParameter contactParam = new SqlParameter();
        //the text that is being replaced in the query
        contactParam.ParameterName = "@contact";
        //the value to replace it with
        contactParam.Value = contact;
        //the type and size of the data
        contactParam.SqlDbType = System.Data.SqlDbType.NVarChar;
        contactParam.Size = 50;

        SqlParameter userParam = new SqlParameter();
        //the text that is being replaced in the query
        userParam.ParameterName = "@sessionUser";
        //the value to replace it with
        userParam.Value = Session["username"];
        //the type and size of the data
        userParam.SqlDbType = System.Data.SqlDbType.NVarChar;
        userParam.Size = 50;


        command.Parameters.Add(contactParam);
        command.Parameters.Add(descParam);
        command.Parameters.Add(pickupParam);
        command.Parameters.Add(dietParam);
        command.Parameters.Add(userParam);

        //3. open the connection to allow the command to go through it
        dbConn.Open();

        //4. execute the query (there are no results in an insert, use the non-query version)
        command.ExecuteNonQuery();

        //5. clean up all the resources
        command.Dispose();
        dbConn.Close();
        dbConn.Dispose();

    }

    protected void requestCreateDescText_TextChanged(object sender, EventArgs e)
    {

    }
}
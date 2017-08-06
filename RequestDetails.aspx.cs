using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RequestDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            detailsContactNumber.Text = detailsContactNumber.Text;
            detailsDiet.Text = detailsDiet.Text;
            detailsDescription.Text = detailsDescription.Text;
            detailsPickup.SelectedIndex = detailsPickup.SelectedIndex;

            detailsCommitButton.Visible = false;
            detailsUpdateButton.Visible = false;
            detailsDeletePostButton.Visible = false;

            string urlId = Request.QueryString["ID"];
            if (urlId != null)
            {
                int id = Int32.Parse(urlId);
                //query database for request post with requestId = urlId and also get user info with requestPost.userId = Users.userId

                //1. create a connection to the database
                SqlConnection dbConn = new SqlConnection();

                //1.1 set the connection string to a specific database
                dbConn.ConnectionString = ConfigurationManager.ConnectionStrings["MealsProject"].ConnectionString;

                //2. create a command to tell the db what to do
                SqlCommand command = new SqlCommand();

                //2.1 set the name of the stored proc to be sent with the command
                command.CommandText = "SELECT username, email, Pickup, ContactNumber, Description, DietRestrictions FROM Users, RequestPost WHERE RequestPost.RequestId = @urlId AND RequestPost.UserId = Users.UserId";
                //stored proc not a text query
                command.CommandType = System.Data.CommandType.Text;
                //associate the command with a connection
                command.Connection = dbConn;

                SqlParameter idParam = new SqlParameter();
                //the text that is being replaced in the query
                idParam.ParameterName = "@urlId";
                //the value to replace it with
                idParam.Value = id;
                //the type and size of the data
                idParam.SqlDbType = System.Data.SqlDbType.Int;
                idParam.Size = 3;

                command.Parameters.Add(idParam);
                //3. open the connection
                dbConn.Open();
                //create the reader
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    //get string from COLUMN 0 from returned row
                    detailsUsername.Text = reader.GetString(0);
                    detailsEmail.Text = reader.GetString(1);

                    string selectedRadioValue = reader.GetBoolean(2).ToString();
                    detailsPickup.Items.FindByText(selectedRadioValue).Selected = true;
                    detailsPickup.Items.FindByText(selectedRadioValue).Enabled = true;
                    if (!reader.IsDBNull(3))
                    {
                        detailsContactNumber.Text = reader.GetString(3);
                    }
                    if (!reader.IsDBNull(4))
                    {
                        detailsDescription.Text = reader.GetString(4);
                    }

                    if (!reader.IsDBNull(5))
                    {
                        detailsDiet.Text = reader.GetString(5);
                    }


                }

                command.Dispose();
                dbConn.Close();
                dbConn.Dispose();

            }

            if ((string)Session["username"] == detailsUsername.Text)
            {
                detailsUpdateButton.Visible = true;
            }
        }
    }

    protected void detailsUpdateButton_Click(object sender, EventArgs e)
    {
        //set each item to enabled so user can change if they want.
        detailsContactNumber.ReadOnly = false;
        detailsDescription.ReadOnly = false;
        detailsDiet.ReadOnly = false;
        foreach ( ListItem radButton in detailsPickup.Items)
        {
            radButton.Enabled = true;
        }

        //show the commit and delete post buttons
        detailsCommitButton.Visible = true;
        detailsDeletePostButton.Visible = true;
    }

    protected void detailsCommitButton_Click(object sender, EventArgs e)
    {
        string diet = detailsDiet.Text;
        string desc = detailsDescription.Text;
        string contact = detailsContactNumber.Text;
        string pickup = detailsPickup.SelectedValue;

        bool pickupConfirm = true;

        if (pickup == "1")
        {
            pickupConfirm = true;
        }
        else
        {
            pickupConfirm = false;
        }
        //get requestPost Id
        string urlId = Request.QueryString["ID"];

        int id = Int32.Parse(urlId);
        //query database for request post with requestId = urlId and also get user info with requestPost.userId = Users.userId

        //1. create a connection to the database
        SqlConnection dbConn = new SqlConnection();

        //1.1 set the connection string to a specific database
        dbConn.ConnectionString = ConfigurationManager.ConnectionStrings["MealsProject"].ConnectionString;

        //2. create a command to tell the db what to do
        SqlCommand command = new SqlCommand();

        //2.1 set the name of the stored proc to be sent with the command
        command.CommandText = "UPDATE RequestPost SET RequestPost.DietRestrictions = @diet, RequestPost.Pickup = @pickup, RequestPost.Description = @desc, RequestPost.ContactNumber = @contact WHERE RequestPost.RequestId = @urlId";
        //stored proc not a text query
        command.CommandType = System.Data.CommandType.Text;
        //associate the command with a connection
        command.Connection = dbConn;

        SqlParameter dietParam = new SqlParameter();
        //the text that is being replaced in the query
        dietParam.ParameterName = "@diet";
        //the value to replace it with
        dietParam.Value = diet;
        //the type and size of the data
        dietParam.SqlDbType = System.Data.SqlDbType.Text;
        dietParam.Size = 500;

        SqlParameter pickupParam = new SqlParameter();
        //the text that is being replaced in the query
        pickupParam.ParameterName = "@pickup";
        //the value to replace it with
        pickupParam.Value = pickupConfirm;
        //the type and size of the data
        pickupParam.SqlDbType = System.Data.SqlDbType.Bit;
        pickupParam.Size = 1;

        SqlParameter descParam = new SqlParameter();
        //the text that is being replaced in the query
        descParam.ParameterName = "@desc";
        //the value to replace it with
        descParam.Value = desc;
        //the type and size of the data
        descParam.SqlDbType = System.Data.SqlDbType.Text;
        descParam.Size = 500;

        SqlParameter contactParam = new SqlParameter();
        //the text that is being replaced in the query
        contactParam.ParameterName = "@contact";
        //the value to replace it with
        contactParam.Value = contact;
        //the type and size of the data
        contactParam.SqlDbType = System.Data.SqlDbType.Text;
        contactParam.Size = 10;

        SqlParameter idParam = new SqlParameter();
        //the text that is being replaced in the query
        idParam.ParameterName = "@urlId";
        //the value to replace it with
        idParam.Value = id;
        //the type and size of the data
        idParam.SqlDbType = System.Data.SqlDbType.Int;
        idParam.Size = 3;

        command.Parameters.Add(contactParam);
        command.Parameters.Add(descParam);
        command.Parameters.Add(pickupParam);
        command.Parameters.Add(dietParam);
        command.Parameters.Add(idParam);

        dbConn.Open();

        //4. execute the query (there are no results in an insert, use the non-query version)
        command.ExecuteNonQuery();

        //5. clean up all the resources
        command.Dispose();
        dbConn.Close();
        dbConn.Dispose();
    }
}
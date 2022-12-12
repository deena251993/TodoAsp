using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtUsername.Focus();
    }

    protected void ImageButtonLogin_Click(object sender, ImageClickEventArgs e)
    {
        ToDoDAL dal = new ToDoDAL();
        DataSet ds = new DataSet();
        ds=dal.Authenticate(txtUsername.Text, txtPassword.Text);
        if (ds.Tables[0].Rows.Count>0)
        {
            FormsAuthentication.SetAuthCookie(txtUsername.Text, true);
            Session["uname"] = txtUsername.Text;
            Session["uid"] = ds.Tables[0].Rows[0]["UserId"].ToString();
            Session["role"]= ds.Tables[0].Rows[0]["Role"].ToString();
            Response.Redirect("Default.aspx");
        }
        else
            lblErrorMessage.Text = "Invalid Credentials: Please try again";

    }
}

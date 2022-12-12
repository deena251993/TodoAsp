using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Buffer = true;
        Response.ExpiresAbsolute = DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0));
        Response.Expires = 0;
        Response.CacheControl = "no-cache";
        if (HttpContext.Current.Request.Url.AbsolutePath.ToString().ToLower().Contains("login.aspx"))
            trLoginName.Visible = false;
        else
            trLoginName.Visible = true;
     
    }

}

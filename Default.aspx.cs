using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Web.Security;
using System.IO;
using System.Data;

public partial class _Default : System.Web.UI.Page
{

    ToDoBLL bll = new ToDoBLL();
   
    string uid = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("Login.aspx");
        }
        
        lblMessage.Text = "";
        
        if (!IsPostBack)
        {
            gvToDo.DataBind();
        }
        
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ToDoObject rec = new ToDoObject();
        rec.Title = txtTitle.Text;
        rec.DueDate = DateTime.ParseExact(txtDueDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        rec.IsDone = chkDone.Checked;
        rec.AddUserId = Convert.ToInt32(uid);

        int status = bll.add(rec);

        if (status > 0)
        {
            lblMessage.Text = "تمت الإضافة";
            txtTitle.Text = "";
            txtDueDate.Text = "";
            
            gvToDo.DataBind();

        }
        else if (status == 0)
            lblMessage.Text = "حدث خطأ";
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid)
            return;
        ToDoObject rec = new ToDoObject();
        rec.Id = Convert.ToInt32(hdnId.Value);
        rec.Title = txtTitle.Text;
        rec.DueDate = DateTime.ParseExact(txtDueDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        rec.IsDone = chkDone.Checked;
        int status = bll.edit(rec);
        if (status > 0)
        {
            lblMessage.Text = "تمت الإضافة";
            gvToDo.DataBind();

        }
        else if (status == 0)
            lblMessage.Text = "خطأ في الإضافة";
    }

   
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    protected void gvToDo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            
            int rowindex = Convert.ToInt32(e.CommandArgument);
            int id = Convert.ToInt32(gvToDo.DataKeys[rowindex].Value);
            ToDoObject rec = bll.getSingle(id);
            txtTitle.Text = rec.Title;
            if (rec.DueDate.ToString(@"dd\/MM\/yyyy").Contains("0001") || rec.DueDate.ToString(@"dd\/MM\/yyyy").Contains("1901"))
                txtDueDate.Text = "";
            else
                txtDueDate.Text = rec.DueDate.ToString(@"dd\/MM\/yyyy");
            chkDone.Checked=rec.IsDone;

            btnAdd.Visible = false;
            hdnId.Value = id.ToString();
        }
        if (e.CommandName == "Delete")
        {
            int rowindex = Convert.ToInt32(e.CommandArgument);
            int id = Convert.ToInt32(gvToDo.DataKeys[rowindex].Value);

            int status = bll.delete(id);
            Response.Redirect("Default.aspx");
        }

    }

    protected void gvToDo_DataBound(object sender, EventArgs e)
    {
        
    }

    public string getDate(object dt)
    {
        string str = "";
        if (!string.IsNullOrEmpty(dt.ToString()))
        {
            str = Convert.ToDateTime(dt).ToString(@"dd\/MM\/yyyy");

            if (str.Contains("0001") || str.Contains("1901"))
                return "";
            else
                return str;
        }
        else
            return "";

    }
    
}

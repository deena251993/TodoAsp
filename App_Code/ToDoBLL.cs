using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

public class ToDoBLL
{
    ToDoDAL dal = new ToDoDAL();
    public List<ToDoObject> getGVData(int maximumRows, int startRowIndex, int LoginUserid)
    {
        return dal.getGVData(maximumRows, startRowIndex ,LoginUserid);
    }
    public int getDataCount(int maximumRows, int startRowIndex, int LoginUserid)
    {
        return dal.getDataCount();
    }
    public ToDoObject getSingle(int Id)
    {
        return dal.getSingle(Id);
    }
    
    public int add(ToDoObject rec)
    {
        return dal.add(rec);
    }
    public int edit(ToDoObject rec)
    {
        return dal.edit(rec);
    }

    public int delete(int receiptId)
    {
        return dal.delete(receiptId);
    }
    
	public ToDoBLL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}

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


public class ToDoObject
{

    private int _Id;
    public int Id
    {
        get { return _Id; }
        set { _Id = value; }
    }

    private string _Title;
    public string Title
	{
        get { return _Title; }
        set { _Title = value; }
	}

    private DateTime _DueDate;
    public DateTime DueDate
    {
        get { return _DueDate; }
        set { _DueDate = value; }
    }

    private bool _IsDone;
    public bool IsDone
    {
        get { return _IsDone; }
        set { _IsDone = value; }
    }
    
    private int _AddUserId;
    public int AddUserId
    {
        get { return _AddUserId; }
        set { _AddUserId = value; }
    }
    
   
 
    public ToDoObject(int Id, string Title, DateTime DueDate, bool IsDone, int AddUserId)
    {
        _Id = Id;
        _Title = Title;
        _DueDate = DueDate;
        _IsDone = IsDone;
        _AddUserId = AddUserId;
       
    }

	public ToDoObject()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}

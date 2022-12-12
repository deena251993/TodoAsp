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
using System.Data.Odbc;
using System.Data.SqlClient;
using System.ComponentModel;


public class ToDoDAL
{
    static int _count = -1;

    public List<ToDoObject> getGVData(int maximumRows, int startRowIndex, int LoginUserid)
    {
        List<ToDoObject> todos = new List<ToDoObject>();
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        string sSql = "";
        string commandText = @"
                -- create a temp table for paging
                CREATE TABLE #PageIndexForTable
                (
                    IndexId int IDENTITY (0, 1) NOT NULL,
                    [Id] int    
                )

                -- insert into our temp table
                INSERT INTO #PageIndexForTable 
                (
                    [Id]	
                )
                SELECT distinct Id FROM ToDos R INNER JOIN Users U ON R.AddUserId=U.UserId ";
        bool condition = false;
        
        if (LoginUserid != 0)
        {
            if (condition == false)
                sSql += " where ";
            else
                sSql += " And ";
            condition = true;
            sSql += " R.LoginUserid = " + LoginUserid;
        }
       
        commandText += @"
                SET @totalRecords = @@ROWCOUNT
               
               SELECT R.* From  ToDos R  
  INNER JOIN Users U ON R.AddUserId=U.UserId
  INNER JOIN #PageIndexForTable p 
               ON R.[Id] = p.[Id] AND p.IndexId >= @startRowIndex AND p.IndexId < (@startRowIndex + @maximumRows) order by p.IndexId";

        SqlCommand command = new SqlCommand(commandText, conn);

        command.Parameters.Add(new SqlParameter("@startRowIndex", startRowIndex));
        command.Parameters.Add(new SqlParameter("@maximumRows", maximumRows));
        command.Parameters.Add(new SqlParameter("@totalRecords", SqlDbType.Int));
        command.Parameters["@totalRecords"].Direction = ParameterDirection.Output;

        conn.Open();

        SqlDataReader dr = command.ExecuteReader();

        sSql = "";
        while (dr.Read())
        {
            ToDoObject Receipt = new ToDoObject();
            Receipt.Id = Convert.ToInt32(dr["Id"]);
            Receipt.Title = dr["Title"].ToString();
            Receipt.DueDate = Convert.ToDateTime(dr["DueDate"].ToString());
            Receipt.IsDone = Convert.ToBoolean(dr["IsDone"]);
            Receipt.AddUserId = Convert.ToInt32(dr["AddUserId"]);
           
            todos.Add(Receipt);

        }
        dr.Close();
        conn.Close();
        _count = (int)command.Parameters["@totalRecords"].Value;
        return todos;
    }

    public int getDataCount()
    {
        return _count;
    }

    public ToDoObject getSingle(int Id)
    {
        ToDoObject todo = new ToDoObject();

        string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        using (SqlConnection dbConnection = new SqlConnection(connectionString))
        using (SqlCommand dbCommand = new SqlCommand())
        {
            dbCommand.CommandText = "select R.* from ToDos R INNER JOIN Users U ON R.AddUserId=U.UserId where R.Id=" + Id;

            dbCommand.Connection = dbConnection;
            dbConnection.Open();

            SqlDataReader dr = dbCommand.ExecuteReader();

            if (dr.Read())
            {
                
            todo.Id = Convert.ToInt32(dr["Id"]);
            todo.Title = dr["Title"].ToString();
            todo.DueDate = Convert.ToDateTime(dr["DueDate"].ToString());
            todo.IsDone = Convert.ToBoolean(dr["IsDone"]);
            todo.AddUserId = Convert.ToInt32(dr["AddUserId"]);
          
            }
            dr.Close();
            dbConnection.Close();
        }
        return todo;
    }

    

    public DataSet getUsers()
    {
      
        string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        DataSet ds = new DataSet();

        using (SqlConnection dbConnection = new SqlConnection(connectionString))
        using (SqlCommand dbCommand = new SqlCommand())
        {
            dbCommand.CommandText = "select * from Users where Status=1 order by Username";

            dbCommand.Connection = dbConnection;
            dbConnection.Open();

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = dbCommand;

            da.Fill(ds);
            dbConnection.Close();
        }
        return ds;
    }

    public int add(ToDoObject rec)
    {

        string StrConn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        using (SqlConnection MyConn = new SqlConnection(StrConn))

        using (SqlCommand MyCmd = new SqlCommand())
        {
            MyCmd.CommandType = CommandType.StoredProcedure;
            MyCmd.CommandText = "addToDo";

            MyCmd.Parameters.Add("@Id", SqlDbType.BigInt).Direction = ParameterDirection.Output;

            MyCmd.Parameters.AddWithValue("@Title", rec.Title);
            MyCmd.Parameters.AddWithValue("@DueDate", rec.DueDate);
            MyCmd.Parameters.AddWithValue("@IsDone", rec.IsDone);
            MyCmd.Parameters.AddWithValue("@AddUserId", rec.AddUserId);
            
            MyCmd.Connection = MyConn;
            MyConn.Open();
            MyCmd.ExecuteScalar();
            return int.Parse(MyCmd.Parameters["@Id"].Value.ToString());

        }

    }

    public int edit(ToDoObject rec)
    {

        string StrConn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        using (SqlConnection MyConn = new SqlConnection(StrConn))

        using (SqlCommand MyCmd = new SqlCommand())
        {
            MyCmd.CommandType = CommandType.StoredProcedure;
            MyCmd.CommandText = "updateToDo";

            MyCmd.Parameters.Add("@result", SqlDbType.BigInt).Direction = ParameterDirection.Output;

            MyCmd.Parameters.AddWithValue("@Id", rec.Id);
            MyCmd.Parameters.AddWithValue("@Title", rec.Title);
            MyCmd.Parameters.AddWithValue("@DueDate", rec.DueDate);
            MyCmd.Parameters.AddWithValue("@IsDone", rec.IsDone);
          
            MyCmd.Connection = MyConn;
            MyConn.Open();

            MyCmd.ExecuteNonQuery();

            return Int32.Parse(MyCmd.Parameters["@result"].Value.ToString());

        }

    }

    public int delete(int Id)
    {
        int result = 0;
        string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        try
        {
            using (SqlConnection dbConnection = new SqlConnection(connectionString))
            using (SqlCommand dbCommand = new SqlCommand())
            {
                dbCommand.CommandText = "Delete from ToDos where Id=" + Id;
                dbCommand.Connection = dbConnection;
                dbConnection.Open();
                result = dbCommand.ExecuteNonQuery();
                dbConnection.Close();
                result = 1;
            }
        }
        catch (Exception ex)
        {
            result = 0;
        }
        return result;
    }


    public DataSet Authenticate(string UID, string PWD)
    {
        DataSet ds = new DataSet();
        string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        using (SqlConnection dbConnection = new SqlConnection(connectionString))
        using (SqlCommand dbCommand = new SqlCommand())
        {
            dbCommand.CommandText = "select * from Users where Username='" + UID + "' and Password='" + PWD + "' and Status=1";
            dbCommand.Connection = dbConnection;
            dbConnection.Open();

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = dbCommand;

            da.Fill(ds);
            dbConnection.Close();
        }
        return ds;
    }

	public ToDoDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}

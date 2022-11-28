using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace Assignment6.DAL
{
    public class DesignationDAL
    { 
    public SqlConnection con = new SqlConnection();
    public SqlCommand cmd = new SqlCommand();

    public DesignationDAL()
    {
        string conn = ConfigurationManager.ConnectionStrings["rose"].ConnectionString;
        con = new SqlConnection(conn);
        cmd.Connection = con;
    }

    public SqlConnection Getcon()
    {
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        return con;
    }
        public DataTable Designation_list()
        {

            string qry = "select  * from Department";
            SqlCommand cmd = new SqlCommand(qry, Getcon());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            return ds;
        }
        public  int Designation_insert(BAL.DesignationBAL obj)
        {
            string s = "insert into Designation  values('" + obj.designame + "','" + obj.departmentid + "')";
            SqlCommand cmd = new SqlCommand(s, Getcon());
            return cmd.ExecuteNonQuery();
        }
        public DataTable view_Designation(BAL.DesignationBAL obj)
        {
            string qry = "select d.dept_id,n.designationid,n.designationame from Designation n inner join Department d on d.dept_id=n.dept_id";
            SqlCommand cmd = new SqlCommand(qry, Getcon());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public int update_Designation(BAL.DesignationBAL obj)
        {
            string s = "update Designation  set designationame='" + obj.designame + "' where Designationid='" + obj.desigid + "'";
            SqlCommand cmd = new SqlCommand(s, Getcon());
            return cmd.ExecuteNonQuery();
        }
        public int delete_Designation(BAL.DesignationBAL obj)
        {
            string s = "Delete from Designation  where Designationid='" + obj.desigid + "'";
            SqlCommand cmd = new SqlCommand(s, Getcon());
            return cmd.ExecuteNonQuery();
        }

    }
}
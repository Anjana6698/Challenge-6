using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Assignment6
{
    public partial class designation : System.Web.UI.Page
    {
        BAL.DesignationBAL objdept = new BAL.DesignationBAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Department_bind();
                GridView1.DataSource = objdept.view_Designation();
                GridView1.DataBind();
            }
        }
        public void Department_bind()
        {
            DataTable prod = objdept.Designation_values();
            DropDownList1.DataSource = objdept.Designation_values();
            DropDownList1.DataTextField = "dept_name";
            DropDownList1.DataValueField = "dept_id";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("-- Select --", "0"));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            objdept.designame = TextBox1.Text;
            objdept.departmentid = Convert.ToInt32(DropDownList1.SelectedIndex);

            int i = objdept.Designation_insert();
            GridView1.DataSource = objdept.view_Designation();
            GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridView1.DataSource = objdept.view_Designation();
            GridView1.DataBind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            TextBox txt = new TextBox();
            txt = (TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0];
            objdept.desigid = id;
            objdept.designame = txt.Text;
            int i = objdept.update_Designation();
            GridView1.EditIndex = -1;
            GridView1.DataSource = objdept.view_Designation();
            GridView1.DataBind();

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());

            objdept.desigid = id;

            int i = objdept.delete_Designation();

            GridView1.DataSource = objdept.view_Designation();
            GridView1.DataBind();

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridView1.DataSource = objdept.view_Designation();
            GridView1.DataBind();
        }
    }
}
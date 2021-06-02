//
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace GoodFood.BLL
{
    public class BLL_Restaurant
    {
        public string RestaurantID { get; set; }
        public string RestaurantName { get; set; }
        public string Address { get; set; }

        public DataTable Select(string id)
        {
            //u
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleCommand cmd = new OracleCommand();
            OracleConnection con = new OracleConnection(constr);
            con.Open();
            cmd.Connection = con;
            if (id == null)
            {
                cmd.CommandText = "SELECT * FROM Restaurant";

            }
            else
            { 
                cmd.CommandText = "SELECT * FROM Restaurant where RestaurantId='"+id.ToString()+"'";

            }
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable("Restaurant");

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }
            con.Close();

            return dt;
            // return null;
        }
        public string Insert()
        {
            //uqery           
            try
            {

                string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (OracleConnection con = new OracleConnection(constr))
                {
                    using (OracleCommand cmd = new OracleCommand("Insert into restaurant(RestaurantId, RestaurantName, Address)Values('" + this.RestaurantID + "','" + this.RestaurantName + "','" + this.Address + "')"))
                    {
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
               
                return "Success";
            }
            catch (Exception ex)
            {
                return "Error";
            }

            // this.BindGrid();
            //  return null;


        }
        public string Update()
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (OracleConnection con = new OracleConnection(constr))
                {
                    using (OracleCommand cmd = new OracleCommand(@"update restaurant set
                                                    RestaurantName = '" + this.RestaurantName +
                                                        "',Address = '" + this.Address + 
                                                        "' where RestaurantId = '" + this.RestaurantID+"'"))
                    {

                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

                // GridView1.EditIndex = -1;
                //            this.BindGrid();
                return "success";
            }
            catch (Exception ex)
            {
                return "error";
            }

        }
        public string Delete()
        {
            //uqery
            // int ID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (OracleConnection con = new OracleConnection(constr))
                {

                    using (OracleCommand cmd = new OracleCommand("DELETE FROM Restaurant WHERE RestaurantId ='" + this.RestaurantID+"'"))
                    {

                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                return "success";
            }
            catch (Exception ex)
            {
                return "error";
            }

            //            this.BindGrid();
           // return null;

        }

    }
}




//using Oracle.ManagedDataAccess.Client;
//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Data;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;

//namespace LMS1
//{
//    public partial class Author : System.Web.UI.Page
//    {
//        protected void Page_Load(object sender, EventArgs e)
//        {
//            // data load k garaune
//            if (!this.IsPostBack)
//            {
//                this.BindGrid();
//            }

//        }

//        protected void Button1_Click(object sender, EventArgs e)
//        {
//            // insert Code
//            string name = txtauthor.Text.ToString();
//            string gender = txtgender.Text.ToString();
//            string qualification = txtqualification.Text.ToString();

//            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
//            using (OracleConnection con = new OracleConnection(constr))
//            {
//                using (OracleCommand cmd = new OracleCommand("Insert into author(ID, Name, Gender, Qualification)Values(101,'" + name + "','" + gender + "','" + qualification + "')"))
//                {
//                    cmd.Connection = con;
//                    con.Open();
//                    cmd.ExecuteNonQuery();
//                    con.Close();
//                    txtauthor.Text = "";
//                    txtgender.Text = "";
//                    txtqualification.Text = "";
//                }
//            }


//            this.BindGrid();
//        }

//        private void BindGrid()
//        {
//            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
//            OracleCommand cmd = new OracleCommand();
//            OracleConnection con = new OracleConnection(constr);
//            con.Open();
//            cmd.Connection = con;
//            cmd.CommandText = "SELECT ID, Name, Gender, Qualification FROM Author";
//            cmd.CommandType = CommandType.Text;

//            DataTable dt = new DataTable("author");

//            using (OracleDataReader sdr = cmd.ExecuteReader())
//            {
//                dt.Load(sdr);
//            }
//            con.Close();

//            GridView1.DataSource = dt;
//            GridView1.DataBind();
//        }

//        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
//        {
//            // Update Funcations:
//            GridViewRow row = GridView1.Rows[e.RowIndex];
//            int ID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
//            string Name = (row.Cells[2].Controls[0] as TextBox).Text;
//            string Gender = (row.Cells[3].Controls[0] as TextBox).Text;
//            string Qualification = (row.Cells[4].Controls[0] as TextBox).Text;

//            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
//            using (OracleConnection con = new OracleConnection(constr))
//            {
//                using (OracleCommand cmd = new OracleCommand("update author set Name = '" + Name + "',Gender = '" + Gender + "',Qualification = '" + Qualification + "' where ID = " + ID))
//                {

//                    cmd.Connection = con;
//                    con.Open();
//                    cmd.ExecuteNonQuery();
//                    con.Close();
//                }
//            }

//            GridView1.EditIndex = -1;
//            this.BindGrid();

//        }
//        protected void OnRowCancelingEdit(object sender, EventArgs e)
//        {
//            GridView1.EditIndex = -1;
//            this.BindGrid();
//        }
//        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
//        {
//            // Delete Functions:
//            int ID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
//            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
//            using (OracleConnection con = new OracleConnection(constr))
//            {

//                using (OracleCommand cmd = new OracleCommand("DELETE FROM Author WHERE ID =" + ID))
//                {

//                    cmd.Connection = con;
//                    con.Open();
//                    cmd.ExecuteNonQuery();
//                    con.Close();
//                }
//            }

//            this.BindGrid();
//        }
//        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
//        {
//            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridView1.EditIndex)
//            {
//                (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
//            }

//        }
//        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
//        {
//            GridView1.EditIndex = e.NewEditIndex;
//            this.BindGrid();
//        }
//    }
//}

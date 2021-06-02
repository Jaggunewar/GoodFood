using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoodFood.BLL;

namespace GoodFood
{
    public partial class _Restaurant : Page
    {
        BLL_Restaurant objRestaurant = new BLL_Restaurant();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGrid();


            }
        }

        public void BindGrid()
        {
            //Select
            DataTable dt = objRestaurant.Select(null);
            if (dt.Rows.Count > 0)
            {
                gv.DataSource = dt;
                gv.DataBind();
               // gv.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                DataRow dr = dt.NewRow();
                dr["RestaurantId"] = 1;
                dr["RestaurantName"] = "Test";
                dr["Address"] = "Test";

                dt.Rows.Add(dr);
                gv.DataSource = dt;
                gv.DataBind();
                int columnCount = gv.Rows[0].Cells.Count;
                gv.Rows[0].Cells.Clear();
                gv.Rows[0].Cells.Add(new TableCell());
                gv.Rows[0].Cells[0].ColumnSpan = columnCount;
                gv.Rows[0].Cells[0].Text = "No Records Found.";
            }

        }

        protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                objRestaurant.RestaurantID=gv.DataKeys[e.RowIndex].Values["RestaurantID"].ToString();
                string result=objRestaurant.Delete();
               // = objRestaurant.iud_fy();
                if (result == "success")
                {
                    Lbl_Msg.Text = "Success";
                    Lbl_Msg.CssClass = "alert-success";
                    BindGrid();
                }
            }
            catch (Exception ex)
            {
                Lbl_Msg.Text = ex.Message;
                Lbl_Msg.CssClass = "alert-danger";
            }
        }
        protected void gv_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            objRestaurant.RestaurantID = gv.DataKeys[e.RowIndex].Values["RestaurantID"].ToString();
            DataTable dt = objRestaurant.Select(objRestaurant.RestaurantID);

            if (dt.Rows.Count>0)
            {
                lbl_Variable.Value= gv.DataKeys[e.RowIndex].Values["RestaurantID"].ToString();

                txtAddress.Text = dt.Rows[0]["Address"].ToString();
               // txtId.Text = objRestaurant.RestaurantID.ToString();
                txtName.Text = dt.Rows[0]["RestaurantName"].ToString();
                btnSubmit.Text = "Update";


            }
            //txtId
            //DataTable dt = objRestaurant.select_fy();
            //if (dt.Rows.Count > 0)
            //{
            //    multiview1.ActiveViewIndex = 0;
            //    DataRow dr = dt.Rows[0];
            //    txtFYEng.Text = dr["fyEnglish"].ToString();
            //    txtFYNep.Text = dr["fyNep"].ToString();
            //    txtDetail.Text = dr["res1"].ToString();
            //    btnSave.Text = "Update";
            //    btnCancel.Text = "Cancel";
            //}
        }
      

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (btnSubmit.Text == "Insert")
            {
                objRestaurant.RestaurantID =Guid.NewGuid().ToString();
                objRestaurant.RestaurantName = txtName.Text;
                objRestaurant.Address = txtAddress.Text;
                string result = objRestaurant.Insert();
                if (result == "Success")
                {
                    Lbl_Msg.Text = "Success";
                    Lbl_Msg.CssClass = "alert-success";
                    BindGrid();
                }
                else
                {
                    Lbl_Msg.Text = "Error";
                    Lbl_Msg.CssClass = "alert-dangeer";
                     BindGrid();
                }
            }
            else if (btnSubmit.Text == "Update")
            {
                objRestaurant.RestaurantID = lbl_Variable.Value;
                objRestaurant.RestaurantName = txtName.Text;
                objRestaurant.Address = txtAddress.Text;
                string result = objRestaurant.Update();
                if (result == "Success")
                {
                    Lbl_Msg.Text = "Success";
                    Lbl_Msg.CssClass = "alert-success";
                    BindGrid();
                }
                else
                {
                    Lbl_Msg.Text = "Error";
                    Lbl_Msg.CssClass = "alert-dangeer";
                     BindGrid();
                }

            }

        }

        
    }
}
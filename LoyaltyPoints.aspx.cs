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
    public partial class _LoyaltyPoints : Page
    {
        BLL_LoyaltyPoints objLoyalty = new BLL_LoyaltyPoints();
        BLL_DishRestaurant objDishREs = new BLL_DishRestaurant();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGrid();
                BindDishRes();
            }
        }

        public void BindDishRes()
        {

            DataTable dt = objDishREs.Select(null);
            dt.Columns.Add("dishRes", typeof(string));
            foreach (DataRow dr in dt.Rows)
            {
                dr["dishRes"] = dr["dishName"] + ", " + dr["restaurantName"];
            }
            ddlDishRes.DataSource = dt;
            ddlDishRes.DataValueField = "dishrestaurantId";
            ddlDishRes.DataTextField = "dishRes";
            ddlDishRes.DataBind();

            ddlDishRes.Items.Insert(0, new ListItem { Text = "--Select--", Value = "0" });

        }
        public void BindGrid()
        {
            //Select
            DataTable dt = objLoyalty.Select(null);
            if (dt.Rows.Count > 0)
            {
                gv.DataSource = dt;
                gv.DataBind();
               // gv.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                DataRow dr = dt.NewRow();
                dr["dishId"] = 1;
                dr["restaurantId"] = "Test";
                dr["loyaltyPointId"] =1;
                dr["loyaltyPointsAmount"] = 1;
                dr["dishName"] = "Test";
                dr["restaurantName"] = "Test";

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
                objLoyalty.LoyaltyPointId= gv.DataKeys[e.RowIndex].Values["loyaltyPointId"].ToString();
                string result=objLoyalty.Delete();
               // = objCustomer.iud_fy();
                if (result == "success")
                {
                    Lbl_Msg.Text = "success";
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
            objLoyalty.LoyaltyPointId = gv.DataKeys[e.RowIndex].Values["loyaltyPointId"].ToString();
            DataTable dt = objLoyalty.Select(objLoyalty.LoyaltyPointId);

            if (dt.Rows.Count>0)
            {
                lbl_Variable.Value = gv.DataKeys[e.RowIndex].Values["loyaltyPointId"].ToString();
               // lbl_DishRes.Value = dt.Rows[0]["dishRestaurantId"].ToString();
                txtPoint.Text = dt.Rows[0]["loyaltypointsAmount"].ToString();              
                ddlDishRes.SelectedValue = dt.Rows[0]["dishREstaurantId"].ToString();
                txtStart.Text = dt.Rows[0]["StartTime"].ToString();
                txtEnd.Text = dt.Rows[0]["EndTime"].ToString();
                //ddlDishRes.
                btnSubmit.Text = "Update";


            }
            //txtId
            //DataTable dt = objCustomer.select_fy();
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
                objLoyalty.StartTime = Convert.ToDateTime(txtStart.Text);
                objLoyalty.EndTime = Convert.ToDateTime(txtEnd.Text);
                objLoyalty.StartTimeStr = objLoyalty.StartTime.ToString("yyyy-MM-dd HH:mm:ss ");
                objLoyalty.EndTimeStr = objLoyalty.EndTime.ToString("yyyy-MM-dd HH:mm:ss ");


                    
                objLoyalty.LoyaltyPointId =Guid.NewGuid().ToString();
                objLoyalty.LoyaltyPointsAmount =Convert.ToDecimal(txtPoint.Text);
                objLoyalty.DishRestaurantId = ddlDishRes.SelectedValue.ToString();
              
                string result = objLoyalty.Insert();
                if (result == "success")
                {
                    Lbl_Msg.Text = "success";
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
                objLoyalty.StartTime = Convert.ToDateTime(txtStart.Text);
                objLoyalty.EndTime = Convert.ToDateTime(txtEnd.Text);
                objLoyalty.StartTimeStr = objLoyalty.StartTime.ToString("yyyy-MM-dd HH:mm:ss");
                objLoyalty.EndTimeStr = objLoyalty.EndTime.ToString("yyyy-MM-dd HH:mm:ss");


                objLoyalty.LoyaltyPointId = lbl_Variable.Value;
                objLoyalty.LoyaltyPointsAmount = Convert.ToDecimal(txtPoint.Text);
                objLoyalty.DishRestaurantId = ddlDishRes.SelectedValue;
                string result = objLoyalty.Update();
                if (result == "success")
                {
                    Lbl_Msg.Text = "success";
                    Lbl_Msg.CssClass = "alert-success";
                    BindGrid();
                    BindDishRes();
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
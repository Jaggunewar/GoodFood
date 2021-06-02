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
    public partial class _DishRestaurant : Page
    {
        BLL_DishRestaurant objRestaurant = new BLL_DishRestaurant();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGrid();
                objRestaurant.BindRestaurant(dllRestaurant);

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
                dr["dishId"] = 1;
                dr["dishName"] = "";
                dr["localName"] = "";
                dr["dishRate"] = 0 ;
                dr["dishRestaurantId"] = 0 ;
               //dr["loyaltyPoints"] = 0 ;

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
                objRestaurant.DishRestaurantId=gv.DataKeys[e.RowIndex].Values["DishRestaurantId"].ToString();
                HiddenField hfRestaurant = gv.Rows[e.RowIndex].FindControl("lblRestaurantId") as HiddenField;
                HiddenField hfDish = gv.Rows[e.RowIndex].FindControl("lblDishId") as HiddenField;
                objRestaurant.DishID = hfDish.Value;

                    
                objRestaurant.RestaurantID = hfRestaurant.Value;

                string result =objRestaurant.Delete();
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
            lbl_Variable.Value = gv.DataKeys[e.RowIndex]["DishRestaurantId"].ToString();
           
           HiddenField hfDish = gv.Rows[e.RowIndex].FindControl("lblDishId") as HiddenField;
            lbl_DishId.Text = hfDish.Value;
            objRestaurant.DishRestaurantId = lbl_Variable.Value;
                
            //  objRestaurant.RestaurantID = hfRestaurant.Value;
            // lblVar.Value = objRestaurant.RestaurantID.ToString();

            //objRestaurant.DishID =gv.DataKeys[e.RowIndex]["DishId"].ToString();
            DataTable dt = objRestaurant.Select(objRestaurant.DishRestaurantId);

            if (dt.Rows.Count > 0)
            {
               // txtAddress.Text = dt.Rows[0]["Address"].ToString();
                //txtId.Text = objRestaurant.DishID.ToString();
                objRestaurant.BindRestaurant(dllRestaurant);
                dllRestaurant.SelectedValue = dt.Rows[0]["restaurantId"].ToString();
                txtName.Text = dt.Rows[0]["dishName"].ToString();
                txtLocalName.Text = dt.Rows[0]["localName"].ToString();
                txtRate.Text = dt.Rows[0]["dishRate"].ToString();
               // txtPoints.Text = dt.Rows[0]["loyaltyPoints"].ToString();
                btnSubmit.Text = "Update";
                BindGrid();

            }            
          
        }
      

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            objRestaurant.DishRestaurantId= Guid.NewGuid().ToString(); 
            objRestaurant.DishID = Guid.NewGuid().ToString();
            objRestaurant.DishName = txtName.Text;
            objRestaurant.LocalName = txtLocalName.Text;
            objRestaurant.DishRate = Convert.ToDecimal(txtRate.Text);
            objRestaurant.RestaurantID = dllRestaurant.SelectedValue;
          //  objRestaurant.LoyaltyPoints = Convert.ToInt32(txtPoints.Text);

            if (btnSubmit.Text == "Insert")
            {
               
                string result = objRestaurant.Insert();
                if (result == "success")
                {
                    Lbl_Msg.Text = "Success";
                    Lbl_Msg.CssClass = "alert-success";
                  //  BindGrid();
                }
                else
                {
                    Lbl_Msg.Text = "Error";
                    Lbl_Msg.CssClass = "alert-danger";
                    //  BindGrid();
                }
            }
            else if (btnSubmit.Text == "Update")
            {
                objRestaurant.DishRestaurantId = lbl_Variable.Value;
                objRestaurant.DishID =lbl_DishId.Text;

                //objRestaurant.RestaurantID=
                string result = objRestaurant.Update();
                
                if (result == "success")
                {
                    Lbl_Msg.Text = "Success";
                    Lbl_Msg.CssClass = "alert-success";
                  //  BindGrid();
                }
                else
                {
                    Lbl_Msg.Text = "Error";
                    Lbl_Msg.CssClass = "alert-danger";
                    // BindGrid();
                }

            }
            BindGrid();

        }

        
    }
}
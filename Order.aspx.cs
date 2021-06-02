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
    public partial class _Order : Page
    {
        BLL_DishRestaurant objRestaurant = new BLL_DishRestaurant();
        BLL_Order objOrder = new BLL_Order();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGrid();
                // objRestaurant.BindRestaurant(dllRestaurant);

            }
        }

        public void BindGrid()
        {
            //Select
            DataTable dt = objRestaurant.Select( null);
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
                dr["dishRate"] = 0;
                dr["dishRestaurantId"] = 0;

                dt.Rows.Add(dr);
                gv.DataSource = dt;
                gv.DataBind();
                int columnCount = gv.Rows[0].Cells.Count;
                gv.Rows[0].Cells.Clear();
                gv.Rows[0].Cells.Add(new TableCell());
                gv.Rows[0].Cells[0].ColumnSpan = columnCount;
                gv.Rows[0].Cells[0].Text = "No Records Found.";
            }
            repCart.DataSource = dt.Clone();
            repCart.DataBind();

        }

        protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        //protected void gv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    try
        //    {
        //        objRestaurant.DishID=Convert.ToInt32( gv.DataKeys[e.RowIndex].Values["DishId"].ToString());
        //        HiddenField hfRestaurant = gv.Rows[e.RowIndex].FindControl("lblRestaurantId") as HiddenField;
        //        objRestaurant.RestaurantID = Convert.ToInt32(hfRestaurant.Value);

        //        string result =objRestaurant.Delete();
        //       // = objRestaurant.iud_fy();
        //        if (result == "success")
        //        {
        //            Lbl_Msg.Text = "Success";
        //            Lbl_Msg.CssClass = "alert-success";
        //            BindGrid();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Lbl_Msg.Text = ex.Message;
        //        Lbl_Msg.CssClass = "alert-danger";
        //    }
        //}
        //protected void gv_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    HiddenField hfRestaurant = gv.Rows[e.RowIndex].FindControl("lblRestaurantId") as HiddenField;
        //    objRestaurant.RestaurantID = Convert.ToInt32(hfRestaurant.Value);
        //    lblVar.Value = objRestaurant.RestaurantID.ToString();

        //    objRestaurant.DishID =Convert.ToInt32( gv.DataKeys[e.RowIndex]["DishId"].ToString());
        //    DataTable dt = objRestaurant.Select(objRestaurant.DishID,objRestaurant.RestaurantID);

        //    if (dt.Rows.Count > 0)
        //    {
        //       // txtAddress.Text = dt.Rows[0]["Address"].ToString();
        //        txtId.Text = objRestaurant.DishID.ToString();
        //        objRestaurant.BindRestaurant(dllRestaurant);
        //        dllRestaurant.SelectedValue = objRestaurant.RestaurantID.ToString();
        //        txtName.Text = dt.Rows[0]["dishName"].ToString();
        //        txtLocalName.Text = dt.Rows[0]["localName"].ToString();
        //        txtRate.Text = dt.Rows[0]["dishRate"].ToString();
        //        txtPoints.Text = dt.Rows[0]["loyaltyPoints"].ToString();
        //        btnSubmit.Text = "Update";

        //    }            

        //}


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //objRestaurant.DishID = txtId.Text;
            //objRestaurant.DishName = txtName.Text;
            //objRestaurant.LocalName = txtLocalName.Text;
            //objRestaurant.DishRate = Convert.ToDecimal(txtRate.Text);
            //objRestaurant.RestaurantID = dllRestaurant.SelectedValue;
            //objRestaurant.LoyaltyPoints = Convert.ToInt32(txtPoints.Text);

            //if (btnSubmit.Text == "Create")
            //{


            //    string result = objRestaurant.Insert();
            //    if (result == "success")
            //    {
            //        Lbl_Msg.Text = "Success";
            //        Lbl_Msg.CssClass = "alert-success";
            //        BindGrid();
            //    }
            //    else
            //    {
            //        Lbl_Msg.Text = "Error";
            //        Lbl_Msg.CssClass = "alert-dangeer";
            //        //  BindGrid();
            //    }
            //}
            //else if (btnSubmit.Text == "Update")
            //{

            //    string result = objRestaurant.Update(lblVar.Value);
            //    if (result == "success")
            //    {
            //        Lbl_Msg.Text = "Success";
            //        Lbl_Msg.CssClass = "alert-success";
            //        BindGrid();
            //    }
            //    else
            //    {
            //        Lbl_Msg.Text = "Error";
            //        Lbl_Msg.CssClass = "alert-dangeer";
            //        BindGrid();
            //    }

            //}

        }
        protected void rep_OnItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                HiddenField hfDishRes = e.Item.FindControl("lblDishRestaurant") as HiddenField;
                HiddenField hfRestaurant = e.Item.FindControl("lblRestaurantId") as HiddenField;
                HiddenField hfDish = e.Item.FindControl("lblDishId") as HiddenField;
                DataTable dt = repCart.DataSource as DataTable;
                DataTable dtCart = Session["cart"] as DataTable;
                if (dtCart.AsEnumerable().Any(m => m.Field<string>("dishRestaurantId") == hfDishRes.Value ))
                {
                    DataRow dr = dtCart.AsEnumerable().FirstOrDefault(m => m.Field<string>("dishRestaurantId") == hfDishRes.Value);
                    //  int index = dtCart.AsEnumerable().ToList().IndexOf(dr);
                    List<DataRow> drs = dtCart.AsEnumerable().ToList();
                    drs.Remove(dr);

                    dtCart = drs.Count > 0 ? drs.CopyToDataTable() : dtCart.Clone();
                    Session["cart"] = dtCart;
                    repCart.DataSource = dtCart;
                    repCart.DataBind();
                }


            }
        }

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // DataTable dtCart = new DataTable();
            //  DataTable dtCartRep = repCart.DataSource as DataTable;
            DataTable dtCartRep = Session["cart"] as DataTable;


            if (e.CommandName == "AddToCart")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                // HiddenField hfRestaurant = gv.Rows[index].FindControl("lblRestaurantId") as HiddenField;
                //  objRestaurant.RestaurantID = hfRestaurant.Value;
                //  lblVar.Value = objRestaurant.RestaurantID.ToString();

                objRestaurant.DishRestaurantId = gv.DataKeys[index]["DishRestaurantId"].ToString();
                DataTable dt = objRestaurant.Select(objRestaurant.DishRestaurantId);
                if (dt.Rows.Count > 0)
                {
                    if (dtCartRep != null)
                    {
                        if (!dtCartRep.AsEnumerable().Any(m => m.Field<string>("dishrestaurantId") == objRestaurant.DishRestaurantId))
                        {
                            dtCartRep.Rows.Add(dt.Rows[0].ItemArray);
                        }

                    }
                    else
                    {
                        dtCartRep = dt;

                    }
                    Session["cart"] = dtCartRep;
                    repCart.DataSource = dtCartRep;
                    repCart.DataBind();

                }
            }

            
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            DataTable dtPrev = objOrder.Select(null);
            int count = dtPrev.AsEnumerable().Where(m => m.Field<DateTime>("datetime").Date == DateTime.Now.Date).ToList().Count;

            Session["customerId"] = "C1";
            decimal total = 0;
            objOrder.OrderNumber = Guid.NewGuid().ToString();
            objOrder.totals = new List<DishTotal>();
            objOrder.LoyaltyPoints = new List<LoyaltyPoint>();
            objOrder.SN = count+1;
            objOrder.Datetime =DateTime.Now;
            objOrder.DatetimeStr =DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            objOrder.OrderAmount = 0;
            //objOrder.DeliveryPoint = txtDelPoint.Text;
            objOrder.CustomerId = Session["customerId"].ToString();

            foreach (RepeaterItem item in repCart.Items)
            {

                HiddenField hfRestaurant = item.FindControl("lblRestaurantId") as HiddenField;
                HiddenField hfDishRestaurant = item.FindControl("lblDishRestaurant") as HiddenField;
                HiddenField hfDishId = item.FindControl("lblDishId") as HiddenField;
                HiddenField hfLoyaltyPoint = item.FindControl("lblLoyaltyPoint") as HiddenField;
                TextBox qty = item.FindControl("txtQty") as TextBox;
                Label price = item.FindControl("lblPrice") as Label;
                total = total + Convert.ToDecimal(price.Text) * Convert.ToInt32(qty.Text);
                DishTotal dishTotal = new DishTotal {
                    DishId = hfDishId.Value,
                    RestaurantId = hfRestaurant.Value,
                    LineTotal = Convert.ToDecimal(price.Text) * Convert.ToInt32(qty.Text),
                    DishTotalId = Guid.NewGuid().ToString(),
                    OrderNumberId=objOrder.OrderNumber,
                    OrderUnit=Convert.ToInt32(qty.Text),
                    DishRestaurantId=hfDishRestaurant.Value
                };
                objOrder.totals.Add(dishTotal);

                //LoyaltyPoint lp = new LoyaltyPoint {
                //DishId=hfDishId.Value,
                //LoyalityPoints=Convert.ToInt32(hfLoyaltyPoint.Value)
                //};
                //objOrder.LoyaltyPoints.Add(lp);

            }

            objOrder.OrderAmount = total;

            //Order Insert

            string result=objOrder.Insert();
            if (result.ToLower() == "success") {

                Response.Redirect("OrderView");
            }


        }
    }
}
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
    public partial class _OrderDetails : Page
    {
        BLL_DishRestaurant objRestaurant = new BLL_DishRestaurant();
        BLL_Order objOrder = new BLL_Order();
        BLL_DeliveryAddress objAddress = new BLL_DeliveryAddress();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                BindGridDetails();
                // objRestaurant.BindRestaurant(dllRestaurant);

            }
        }
        public void BindGrid()
        {
            multiview1.ActiveViewIndex = 0;
            repOrders.DataSource = objOrder.Select(null);
            repOrders.DataBind();
        }


        public void BindGridDetails()
        {
            objOrder.CustomerId = "C1";

            DataTable dtOrders = objOrder.Select(null);

            DataRow drOrderFirst = dtOrders.AsEnumerable().FirstOrDefault(m => m.Field<string>("customerId")==objOrder.CustomerId);

            string orderNo = drOrderFirst["orderNumber"].ToString();
            // Data
          //  lbl_OrderNo.Text = e.CommandArgument.ToString();
            // lbl_LocationId.Text = e.CommandArgument.ToString();
            DataTable dtFoods = objOrder.SelectItems(orderNo);

            DataTable dtOrder = objOrder.Select(orderNo);

            DataTable dtDeliveryPoint = objAddress.Select(null);

            DataRow dr = dtDeliveryPoint.AsEnumerable().FirstOrDefault(m => m.Field<string>("orderNumber") == orderNo);

            if (dr != null)
            {
                txtLatitude.Text = dr["latitude"].ToString();
                txtLongitude.Text = dr["longitude"].ToString();
                txtAddress.Text = dr["deliveryPoint"].ToString();
                lblLat.Text = dr["latitude"].ToString();
                lblLong.Text = dr["longitude"].ToString();
                lblPoint.Text = dr["deliveryPoint"].ToString();
                lbl_LocationId.Text = dr["deliveryAddressId"].ToString();
                btnSubmit.Text = "Update";
            }

            multiview1.ActiveViewIndex = 1;

            repOrder.DataSource = dtOrder;
            repOrder.DataBind();

            repCustomer.DataSource = dtOrder;
            repCustomer.DataBind();

            repItems.DataSource = dtFoods;
            repItems.DataBind();
        }

        //protected void OnItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //    {
        //        HiddenField orderNo = e.Item.FindControl("hfOrderNo") as HiddenField;

        //        DataTable dt = objOrder.SelectItems(orderNo.Value);
        //        Repeater repItems = e.Item.FindControl("repOrderItems") as Repeater;
        //        repItems.DataSource = dt;
        //        repItems.DataBind();
        //    }


        //}

        protected void rep_onItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Details")
            {
                objOrder.CustomerId = "C1";

                lbl_OrderNo.Text = e.CommandArgument.ToString();
                // lbl_LocationId.Text = e.CommandArgument.ToString();
                DataTable dtFoods = objOrder.SelectItems(e.CommandArgument.ToString());

                DataTable dtOrder = objOrder.Select(e.CommandArgument.ToString());

                DataTable dtDeliveryPoint = objAddress.Select(null);

                DataRow dr = dtDeliveryPoint.AsEnumerable().FirstOrDefault(m => m.Field<string>("orderNumber") == lbl_OrderNo.Text);

                if (dr != null)
                {
                    txtLatitude.Text = dr["latitude"].ToString();
                    txtLongitude.Text = dr["longitude"].ToString();
                    txtAddress.Text = dr["deliveryPoint"].ToString();
                    lblLat.Text = dr["latitude"].ToString();
                    lblLong.Text = dr["longitude"].ToString();
                    lblPoint.Text = dr["deliveryPoint"].ToString();
                    lbl_LocationId.Text = dr["deliveryAddressId"].ToString();
                    btnSubmit.Text = "Update";
                }




                multiview1.ActiveViewIndex = 1;

                repOrder.DataSource = dtOrder;
                repOrder.DataBind();

                repCustomer.DataSource = dtOrder;
                repCustomer.DataBind();

                repItems.DataSource = dtFoods;
                repItems.DataBind();


            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            objAddress.OrderNo = lbl_OrderNo.Text;
            objAddress.Latitude = Convert.ToDecimal(txtLatitude.Text);
            objAddress.Longitude = Convert.ToDecimal(txtLongitude.Text);
            objAddress.DeliveryAddressId = Guid.NewGuid().ToString();
            objAddress.DeliveryPoint = txtAddress.Text;
            string result = "";
            if (btnSubmit.Text == "Update")
            {
                objAddress.DeliveryAddressId = lbl_LocationId.Text;
                result = objAddress.Update();
            }
            else
            {
                result = objAddress.Insert();
            }
            BindGrid();
        }

        protected void btnView1_Click(object sender, EventArgs e)
        {
            BindGrid();
            //multiview1.ActiveViewIndex = 0;
        }
    }
}
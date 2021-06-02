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
    public partial class _OrderView : Page
    {
        BLL_DishRestaurant objRestaurant = new BLL_DishRestaurant();
        BLL_Order objOrder = new BLL_Order();
        BLL_DeliveryAddress objAddress = new BLL_DeliveryAddress();
        BLL_Restaurant objRes = new BLL_Restaurant();
        string[] months = new string[]{ "January",
                                            "February",
                                            "March",
                                            "April",
                                            "May",
                                            "June",
                                            "July",
                                            "August",
                                            "September",
                                            "October",
                                            "November",
                                            "December"};

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                BindGrid();
                // objRestaurant.BindRestaurant(dllRestaurant);

            }
        }
        protected void ddlMonth_Onchange(object sender, EventArgs e)
        {
            string month = ddlMonth.SelectedValue;
            int monthIndex = Array.IndexOf(months, month)+1;

            DataTable dtRes = objRes.Select(null);
            DataTable dtCount = new DataTable();

            dtCount.Columns.Add("restaurantName", typeof(string));
            dtCount.Columns.Add("dishCount", typeof(int));

            DateTime DateStart = Convert.ToDateTime(DateTime.Now.Year + "-"+monthIndex.ToString()   + "-1");
            DateTime DateEnd = DateStart.AddMonths(1);

            DataTable dtOrders = objOrder.SelectDishTotal();


            IEnumerable<DataRow> drOrders = dtOrders.AsEnumerable().Where(m => m.Field<DateTime>("datetime") >= DateStart && m.Field<DateTime>("datetime") <= DateEnd);
            if (drOrders.ToList().Count > 0)
            {
                dtOrders = drOrders.CopyToDataTable();
            }
            else
            {
                dtOrders = dtOrders.Clone();
            }
            foreach (DataRow dr in dtRes.AsEnumerable())
            {
                DataRow drNew = dtCount.NewRow();
                IEnumerable<DataRow> drDish = dtOrders.AsEnumerable().Where(m => m.Field<string>("restaurantId") == dr["restaurantId"].ToString());
                drNew["restaurantName"] = dr["restaurantName"];
                drNew["dishCount"] = drDish.ToList().Count();
                dtCount.Rows.Add(drNew);
            }

            IEnumerable<DataRow> drCounts = dtCount.AsEnumerable().Where(m => m.Field<int>("dishCount") > 0).OrderByDescending(m => m.Field<int>("dishCount"));

            if (drCounts.ToList().Count > 0)
            {
                dtCount = drCounts.CopyToDataTable();
            }
            else
            {
                dtCount = dtCount.Clone();
            }
            repTop.DataSource = dtCount;
            repTop.DataBind();
        }
        public void BindGrid()
        {
           

            multiview1.ActiveViewIndex = 0;
            repOrders.DataSource = objOrder.Select(null);
            repOrders.DataBind();

            DataTable dtRes = objRes.Select(null);
            DataTable dtCount = new DataTable();

            dtCount.Columns.Add("restaurantName", typeof(string));
            dtCount.Columns.Add("dishCount", typeof(int));

            DateTime DateStart = Convert.ToDateTime(DateTime.Now.Year + "-" + DateTime.Now.Month + "-1");
            DateTime DateEnd = DateStart.AddMonths(1);

            DataTable dtOrders = objOrder.SelectDishTotal();


            IEnumerable<DataRow> drOrders = dtOrders.AsEnumerable().Where(m => m.Field<DateTime>("datetime") >= DateStart && m.Field<DateTime>("datetime") <= DateEnd);
            if (drOrders.ToList().Count > 0)
            {
                dtOrders = drOrders.CopyToDataTable();
            }
            else
            {
                dtOrders = dtOrders.Clone();
            }
            foreach (DataRow dr in dtRes.AsEnumerable())
            {
                DataRow drNew = dtCount.NewRow();
                IEnumerable<DataRow> drDish = dtOrders.AsEnumerable().Where(m => m.Field<string>("restaurantId") == dr["restaurantId"].ToString());
                drNew["restaurantName"] = dr["restaurantName"];
                drNew["dishCount"] = drDish.ToList().Count();
                dtCount.Rows.Add(drNew);
            }

            IEnumerable<DataRow> drCounts = dtCount.AsEnumerable().Where(m => m.Field<int>("dishCount") > 0).OrderByDescending(m => m.Field<int>("dishCount"));

            if (drCounts.ToList().Count > 0)
            {
                dtCount = drCounts.CopyToDataTable();
            }
            else
            {
                dtCount = dtCount.Clone();
            }
            repTop.DataSource = dtCount;
            repTop.DataBind();

            ddlMonth.DataSource = months;
            ddlMonth.DataBind();

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
            else if (e.CommandName == "Delete")
            {
                objOrder.OrderNumber = e.CommandArgument.ToString();

                objOrder.Delete();
                Lbl_Msg.Text = "Success";
                BindGrid();

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
    }
}
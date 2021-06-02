using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;


namespace GoodFood.BLL
{
    public class DishTotal
    {
        public string DishTotalId { get; set; }
        public string DishId { get; set; }
        public string OrderNumberId { get; set; }
        public string RestaurantId { get; set; }
        public decimal LineTotal { get; set; }
        public int OrderUnit { get; set; }
        public string DishRestaurantId { get; set; }
    }
    public class LoyaltyPoint
    {
        public string DishId { get; set; }

        public int LoyalityPoints { get; set; }
    }
    public class BLL_Order
    {
        //Order
        public string OrderNumber { get; set; }

        public string CustomerId { get; set; }
        public int SN { get; set; }
        public DateTime Datetime { get; set; }
        public string DatetimeStr { get; set; }
        public decimal OrderAmount { get; set; }
        public string Status { get; set; }
        public string DeliveryPoint { get; set; }
        public int DeliveryAddressId { get; set; }

        //Dish total
        public List<DishTotal> totals { get; set; }


        //Loyality Points
        public List<LoyaltyPoint> LoyaltyPoints { get; set; }

        //Delivery Address
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }


        public void InsertOrder(string query)
        {

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            //  string insertquery =uery $"Insert into orders(orderNumber, customerId, sn, datetime, orderAmount, status,deliveryPoint) values( {OrderNumber},{CustomerId},{SN},{Datetime},{OrderAmount},'{Status}','{DeliveryPoint}') ";


            using (OracleConnection con = new OracleConnection(constr))
            {
                using (OracleCommand cmd = new OracleCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

            }

        }

        public string Insert()
        {
            //uqery           
            try
            {
                //Insert Order
                InsertOrder($"Insert into orders(orderNumber, customerId, sn, datetime, orderAmount, status) values( '{OrderNumber}','{CustomerId}','{SN}',TO_DATE('{DatetimeStr}', 'YYYY-MM-DD HH24:MI:SS'),{OrderAmount},'{Status}')");


                //Insert Dish Total
                foreach (var item in totals)
                {
                    InsertOrder($"Insert into dishTotal (dishTotalId,orderNumber,lineTotal ,orderUnit, dishrestaurantId ) values ('{Guid.NewGuid().ToString()}', '{OrderNumber}', {item.LineTotal}, '{item.OrderUnit}', '{item.DishRestaurantId}')");
                }

                //Insert loyaltypoint
                //foreach (var item in LoyaltyPoints)
                //{
                //    InsertOrder($"Insert into LoyaltyPoints (orderNumber, loyaltyPoints, dishId) values ('{OrderNumber}', {item.LoyalityPoints}, '{item.DishId}')");
                //}



                return "success";
            }
            catch (Exception ex)
            {
                return "error";
            }

            // this.BindGrid();
            //  return null;


        }

        public DataTable Select(string orderNo)
        {
            string whereClause = $" where orderNumber='{orderNo}'";
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleCommand cmd = new OracleCommand();
            OracleConnection con = new OracleConnection(constr);
            con.Open();
            cmd.Connection = con;

            cmd.CommandText = @"select * from (select c.customerName,c.phoneNumber,ot.* ,da.deliveryPoint from orders ot
                                    inner join customer c on ot.customerId = c.customerId
                                    left join deliveryAddress da on da.orderNumber=ot.orderNumber)
                                     " + (String.IsNullOrEmpty(orderNo) ? "" : whereClause);

            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable();

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }
            con.Close();

            return dt;

        }
        public DataTable SelectDishTotal()
        {
            string whereClause = CustomerId != null ? " where c.customerId='" + CustomerId + "'" : "";

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleCommand cmd = new OracleCommand();
            OracleConnection con = new OracleConnection(constr);
            con.Open();
            cmd.Connection = con;

            cmd.CommandText = @"select da.deliveryPoint,c.customerName, o.customerId,o.datetime,  t.dishTotalId , d.dishName,d.dishRate,r.restaurantName,dr.restaurantId,
                                dr.dishId,t.orderUnit,t.orderNumber,t.lineTotal,t.ordernumber,t.dishrestaurantId, t.orderUnit 
                                    from dishtotal t
                                    left join  DishRestaurant dr on t.DishRestaurantId=dr.dishrestaurantID 
                                    inner join restaurant r on dr.restaurantId=r.restaurantId 
                                    inner join dish d on dr.dishId=d.dishId 
                                    inner join orders o on t.orderNumber=o.orderNumber
                                    left join deliveryAddress da on o.orderNumber=da.orderNumber 
                                    inner join customer c on o.customerId =c.customerId" +    whereClause
                               ;



            //@"select distinct ot.dishTotalId , d.*,r.*,ot.orderUnit,ot.orderNumber,ot.lineTotal, ot.ordernumber,ot.dishrestaurantId, ot.orderUnit from dishTotal ot
            //                    inner join dishrestaurant dr on ot.dishrestaurantId = dr.dishrestaurantId and orderNumber ='"
            //                        +orderNo+"'  inner join restaurant r on dr.restaurantId = r.restaurantId  inner join dish d on dr.dishId = dr.dishId  where orderNumber='" + orderNo+"'";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable();

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }
            con.Close();

            return dt;
        }
        public DataTable SelectItems(string orderNo)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleCommand cmd = new OracleCommand();
            OracleConnection con = new OracleConnection(constr);
            con.Open();
            cmd.Connection = con;
            if (orderNo != null)
            {
                cmd.CommandText = @"select  t.dishTotalId , d.dishName,d.dishRate,r.restaurantName,dr.restaurantId,dr.dishId,t.orderUnit,t.orderNumber,t.lineTotal,t.ordernumber,t.dishrestaurantId, t.orderUnit from dishtotal t
                                    left join  DishRestaurant dr on t.DishRestaurantId=dr.dishrestaurantID 
                                    inner join restaurant r on dr.restaurantId=r.restaurantId 
                                    inner join dish d on dr.dishId=d.dishId 
                                where orderNumber='" + orderNo + "'";
            }
            else
            {
                cmd.CommandText = @"select o.customerId,  t.dishTotalId , d.dishName,d.dishRate,r.restaurantName,dr.restaurantId,dr.dishId,t.orderUnit,t.orderNumber,t.lineTotal,t.ordernumber,t.dishrestaurantId, t.orderUnit from dishtotal t
                                    left join  DishRestaurant dr on t.DishRestaurantId=dr.dishrestaurantID 
                                    inner join restaurant r on dr.restaurantId=r.restaurantId 
                                    inner join dish d on dr.dishId=d.dishId 
                                    inner join orders o on t.orderNumber=o.orderNumber where ='" + CustomerId + "'"
                                ;
            }


            //@"select distinct ot.dishTotalId , d.*,r.*,ot.orderUnit,ot.orderNumber,ot.lineTotal, ot.ordernumber,ot.dishrestaurantId, ot.orderUnit from dishTotal ot
            //                    inner join dishrestaurant dr on ot.dishrestaurantId = dr.dishrestaurantId and orderNumber ='"
            //                        +orderNo+"'  inner join restaurant r on dr.restaurantId = r.restaurantId  inner join dish d on dr.dishId = dr.dishId  where orderNumber='" + orderNo+"'";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable();

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }
            con.Close();

            return dt;
        }
        public DataTable SelectLocations(string orderNo)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleCommand cmd = new OracleCommand();
            OracleConnection con = new OracleConnection(constr);
            con.Open();
            cmd.Connection = con;
            if (orderNo != null)
            {
                cmd.CommandText = @"select  t.dishTotalId , d.dishName,d.dishRate,r.restaurantName,dr.restaurantId,dr.dishId,t.orderUnit,t.orderNumber,t.lineTotal,t.ordernumber,t.dishrestaurantId, t.orderUnit from dishtotal t
                                    left join  DishRestaurant dr on t.DishRestaurantId=dr.dishrestaurantID 
                                    inner join restaurant r on dr.restaurantId=r.restaurantId 
                                    inner join dish d on dr.dishId=d.dishId 
                                where orderNumber='" + orderNo + "'";
            }
            else
            {
                cmd.CommandText = @"select o.customerId,dl.* from deliveryAddress dl
                                    left join  orders o on dl.orderNumber=o.orderNumber";// where customerId='" + CustomerId + "'"
                                
            }


            //@"select distinct ot.dishTotalId , d.*,r.*,ot.orderUnit,ot.orderNumber,ot.lineTotal, ot.ordernumber,ot.dishrestaurantId, ot.orderUnit from dishTotal ot
            //                    inner join dishrestaurant dr on ot.dishrestaurantId = dr.dishrestaurantId and orderNumber ='"
            //                        +orderNo+"'  inner join restaurant r on dr.restaurantId = r.restaurantId  inner join dish d on dr.dishId = dr.dishId  where orderNumber='" + orderNo+"'";
            cmd.CommandType = CommandType.Text;

            DataTable dt = new DataTable();

            using (OracleDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }
            con.Close();

            return dt;
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

                    using (OracleCommand cmd = new OracleCommand($"DELETE FROM dishTotal WHERE orderNumber ='{OrderNumber}'"))
                    {

                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    using (OracleCommand cmd = new OracleCommand($"DELETE FROM orders WHERE orderNumber='{OrderNumber}'"))
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

        //public string Update(int resId)
        //{
        //    try
        //    {

        //        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        //       var updateQuery =
        //          "update dish set dishName='"+DishName+"', localName='"+LocalName+"', dishRate="+DishRate+"where dishId="+DishID;
        //          //  $"update dish set dishName='{DishName}', localName='{LocalName}', dishRate={DishRate} where dishId={DishID}";
        //        using (OracleConnection con = new OracleConnection(constr))
        //        {
        //            using (OracleCommand cmd = new OracleCommand($"update dishRestaurant set dishId={DishID}, restaurantId={RestaurantID } where dishId={DishID} and restaurantId={resId}"))
        //            {
        //                cmd.Connection = con;
        //                con.Open();
        //                cmd.ExecuteNonQuery();
        //                con.Close();
        //            }
        //            using (OracleCommand cmd = new OracleCommand("update dish set dishName='" + DishName + "', localName='" + LocalName + "', dishRate=" + DishRate +  " where dishId=" + DishID))
        //            {
        //                cmd.Connection = con;
        //                con.Open();
        //                cmd.ExecuteNonQuery();
        //                con.Close();
        //            }

        //        }
        //        return "success";
        //    }
        //    catch (Exception ex)
        //    {
        //        return "error";
        //    }

        //}
        //public string Delete()
        //{
        //    //uqery
        //    // int ID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
        //    try
        //    {
        //        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        //        using (OracleConnection con = new OracleConnection(constr))
        //        {

        //            using (OracleCommand cmd = new OracleCommand($"DELETE FROM dishRestaurant WHERE RestaurantId ={RestaurantID} and dishId={DishID}"))
        //            {

        //                cmd.Connection = con;
        //                con.Open();
        //                cmd.ExecuteNonQuery();
        //                con.Close();
        //            }
        //            using (OracleCommand cmd = new OracleCommand($"DELETE FROM dish WHERE dishId={DishID}"))
        //            {

        //                cmd.Connection = con;
        //                con.Open();
        //                cmd.ExecuteNonQuery();
        //                con.Close();
        //            }
        //        }
        //        return "success";
        //    }
        //    catch (Exception ex)
        //    {
        //        return "error";
        //    }

        //    //            this.BindGrid();
        //    // return null;

        //}
        //public void BindRestaurant(DropDownList ddl)
        //{
        //    BLL_Restaurant objRestaurant = new BLL_Restaurant();

        //    DataTable dt = objRestaurant.Select(null);
        //    if (dt.Rows.Count > 0)
        //    {
        //        ddl.DataSource = dt;
        //        ddl.DataTextField = "RestaurantName";
        //        ddl.DataValueField = "Restaurantid";
        //        ddl.DataBind();
        //    }
        //    ddl.Items.Insert(0, new ListItem("--Select--", "0"));
        //}

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

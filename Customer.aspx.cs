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
    public partial class _Customer : Page
    {
        BLL_Customer objCustomer = new BLL_Customer();
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
            DataTable dt = objCustomer.Select(null);
            if (dt.Rows.Count > 0)
            {
                gv.DataSource = dt;
                gv.DataBind();
               // gv.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                DataRow dr = dt.NewRow();
                dr["CustomerId"] = 1;
                dr["CustomerName"] = "Test";
                dr["PhoneNumber"] = "Test";

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
                objCustomer.CustomerId= gv.DataKeys[e.RowIndex].Values["CustomerId"].ToString();
                string result=objCustomer.Delete();
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
            objCustomer.CustomerId = gv.DataKeys[e.RowIndex].Values["CustomerId"].ToString();
            DataTable dt = objCustomer.Select(objCustomer.CustomerId);

            if (dt.Rows.Count>0)
            {
                lbl_Variable.Value = gv.DataKeys[e.RowIndex].Values["CustomerId"].ToString();
                txtPhoneNumber.Text = dt.Rows[0]["PhoneNumber"].ToString();
              //  txtId.Text = objCustomer.CustomerId.ToString();
                txtName.Text = dt.Rows[0]["CustomerName"].ToString();
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
                objCustomer.CustomerId =Guid.NewGuid().ToString();
                objCustomer.CustomerName = txtName.Text;
                objCustomer.PhoneNumber = txtPhoneNumber.Text;
                string result = objCustomer.Insert();
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

                objCustomer.CustomerId = lbl_Variable.Value;
                objCustomer.CustomerName = txtName.Text;
                objCustomer.PhoneNumber = txtPhoneNumber.Text;
                string result = objCustomer.Update();
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

        }

        
    }
}
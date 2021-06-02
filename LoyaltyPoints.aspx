<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoyaltyPoints.aspx.cs" Inherits="GoodFood._LoyaltyPoints" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%--<link href="Content/jquery.datetimepicker.css" rel="stylesheet" />--%>
    <script src="Scripts/jquery1_10.js"></script> 
   <%-- <script  src="https://code.jquery.com/ui/1.12.0/jquery-ui.min.js"  integrity="sha256-eGE6blurk5sHj+rmkfsGYeKyZx3M4bG+ZlFyA7Kns7E="  crossorigin="anonymous"></script>
    <script src="Scripts/jquery.datetimepicker.js"></script>--%>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/flatpickr/dist/flatpickr.min.css">
<script src="https://cdn.jsdelivr.net/npm/flatpickr"></script>


    <%--<asp:MultiView ID="multiview1" runat="server">
      <asp:View ID="View1" runat="server">

      </asp:View>
          <asp:View ID="View1" runat="server">

      </asp:View>
  </asp:MultiView>--%>
    <div class="container">
        <div class="row">

            <div class="col-md-12">
                <h1 style="padding-left: 20px;">Loyalty Points</h1>
                <hr />
            </div>
            <div class="col-md-12">
                <asp:Label runat="server" ID="Lbl_Msg"></asp:Label>
                <asp:HiddenField ID="lbl_Variable" runat="server" />
            </div>
            <div>

                <%--<div class="col-md-3">
            <div class="form-group">
                <label class="label-control">Customer Id</label>
                <asp:TextBox ID="txtId" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>--%>
                <div class="container">
                    <div class="col-md-3">

                        <div class="form-group">
                            <label class="label-control">Loyalty Points</label>
                            <asp:TextBox ID="txtPoint" runat="server" CssClass="form-control" type="Number" step="0.01"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-3">

                        <div class="form-group">
                            <label class="label-control">Start Date</label>
                            <asp:TextBox ID="txtStart" runat="server" CssClass="form-control datePicker" type="Number" step="0.01"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-3">

                        <div class="form-group">
                            <label class="label-control">End Date</label>
                            <asp:TextBox ID="txtEnd" runat="server" CssClass="form-control datePicker" type="Number" step="0.01"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-3">

                        <div class="form-group">
                            <label class="label-control">Dish, Restaurant</label>
                            <asp:DropDownList ID="ddlDishRes" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </div>

                    </div>
                    <div class="col-md-3">
                        <div class="form-group" style="padding-top: 20px;">
                            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" OnClick="btnSubmit_Click" Text="Insert" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="container">
                <div class="col-md-12">

                    <asp:GridView ID="gv" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                        Width="100%" CssClass="table table-bordered table-striped GridViewStyle" AutoGenerateColumns="false" DataKeyNames="loyaltyPointId"
                        AllowPaging="False" PageSize="5" OnPageIndexChanging="gv_PageIndexChanging"
                        OnRowDeleting="gv_RowDeleting" OnRowUpdating="gv_RowUpdating">
                        <Columns>
                            <%-- <asp:TemplateField HeaderText="S.No">
                        <ItemTemplate>
                            <asp:Label ID="lblSn" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>

                            <asp:TemplateField HeaderText="Dish Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblSn" runat="server" Text='<%#Eval("dishName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Restaurant Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblAddn" runat="server" Text='<%#Eval("restaurantName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Loyalty Points">
                                <ItemTemplate>
                                    <asp:Label ID="lblPoint" runat="server" Text='<%#Eval("loyaltyPointsAmount") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:Button ID="btnEdit" CssClass="btn btn-Info" CommandName="Update"
                                        ToolTip="Edit" runat="server" Text="Edit" />
                                    |<asp:Button ID="btnDelete" CommandName="Delete" CssClass="btn btn-danger"
                                        ToolTip="Delete" runat="server" OnClientClick="return confirm('Are you sure you want to delete?');" Text="Delete" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <script>
        //$(document).ready(function () {
        //    $(".datePicker").datetimepicker({
        //        yearOffset: 222,
        //       // lang: 'ch',
        //        timepicker: false,
        //        format: 'd/m/Y',
        //        formatDate: 'Y/m/d',
        //        minDate: '-1970/01/02', // yesterday is minimum date
        //        maxDate: '+1970/01/02'});
        //})
        $(".datePicker").flatpickr({
            enableTime: true,
            dateFormat: "Y-m-d H:i",
        });
    </script>
</asp:Content>

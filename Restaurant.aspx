<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Restaurant.aspx.cs" Inherits="GoodFood._Restaurant" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%--<asp:MultiView ID="multiview1" runat="server">
      <asp:View ID="View1" runat="server">

      </asp:View>
          <asp:View ID="View1" runat="server">

      </asp:View>
  </asp:MultiView>--%>
    <div class="container">
        <div class ="container">
    <div class="row">
        <div class="col-md-12">
            <h1 style="padding-left:20px;">Restaurant</h1>
            <hr />
        </div>
        <div class="col-md-12">
            <asp:Label runat="server" ID="Lbl_Msg"></asp:Label>
            <asp:HiddenField runat="server" ID="lbl_Variable" />
        </div>
        <div >
            </div>
           

       <%-- <div class="col-md-3">
            <div class="form-group">
                <label class="label-control">Restaurant Id</label>
                <asp:TextBox ID="txtId" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>--%>
        <div class ="container">
        <div class="col-md-3">

            <div class="form-group">
                <label class="label-control">Restaurant Name</label>
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-3">

            <div class="form-group">
                <label class="label-control">Restaurant Address</label>
                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

        </div>
        <div class="col-md-3" style="padding-top:20px;">
            <div class="form-group">
            <label></label>
            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" OnClick="btnSubmit_Click" Text="Insert" />
                </div>
        </div>
            
        </div>
        </div>
       
        <div class="col-md-12">

            <asp:GridView ID="gv" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                Width="100%" CssClass="table table-bordered table-striped GridViewStyle" AutoGenerateColumns="false" DataKeyNames="RestaurantID"
                AllowPaging="False" PageSize="5" OnPageIndexChanging="gv_PageIndexChanging"
                OnRowDeleting="gv_RowDeleting" OnRowUpdating="gv_RowUpdating">
                <Columns>
                    <%-- <asp:TemplateField HeaderText="S.No">
                        <ItemTemplate>
                            <asp:Label ID="lblSn" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                 <%--   <asp:TemplateField HeaderText="ID">
                        <ItemTemplate>
                            <asp:Label ID="lbln" runat="server" Text='<%#Eval("RestaurantID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="lblSn" runat="server" Text='<%#Eval("RestaurantName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Address">
                        <ItemTemplate>
                            <asp:Label ID="lblAddn" runat="server" Text='<%#Eval("Address") %>'></asp:Label>
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

</asp:Content>

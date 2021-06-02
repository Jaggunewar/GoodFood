<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DishSearch.aspx.cs" Inherits="GoodFood._DishSearch" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <%--<asp:MultiView ID="multiview1" runat="server">
      <asp:View ID="View1" runat="server">

      </asp:View>
          <asp:View ID="View1" runat="server">

      </asp:View>
  </asp:MultiView>--%>
     <div class="container">
    <div class="row">
        <div class="col-md-12">
            <h1 style="padding-left:20px;">Dish  Search</h1>

            <hr />
        </div>
          <div class="container">
        <div class="col-md-12">
            <div class="row">
            <div class="col-md-12">
                <asp:DropDownList ID="ddlDish" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlDish_OnSelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                <br />
            </div>
            </div>
            
<%--            <asp:Label runat="server" ID="Lbl_Msg"></asp:Label>
            <asp:HiddenField runat="server" ID="lbl_Variable" />
            <asp:Label runat="server" ID="lbl_DishId" Visible="false" />--%>
          </div>
        </div>
        <div class="container">
        <div class="col-md-12">

            <asp:GridView ID="gv" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                Width="100%" CssClass="table table-bordered table-striped GridViewStyle" AutoGenerateColumns="false" DataKeyNames="DishRestaurantId"
                AllowPaging="False" PageSize="5">
             
                <Columns>

                    <asp:TemplateField HeaderText="S.No">
                        <ItemTemplate>
                            <asp:Label ID="lblSn" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                            <asp:HiddenField ID="lblDishId" runat="server" Value='<%#Eval("DishId") %>' />
                            <asp:HiddenField ID="lblRestaurantId" runat="server" Value='<%#Eval("RestaurantId") %>' />

                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Dish Name">
                        <ItemTemplate>
                            <asp:Label ID="lbln" runat="server" Text='<%#Eval("DishName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Local Name">
                        <ItemTemplate>
                            <asp:Label ID="lblln" runat="server" Text='<%#Eval("LocalName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Restaurant Name">
                        <ItemTemplate>
                            <asp:Label ID="lblrn" runat="server" Text='<%#Eval("RestaurantName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Dish Rate">
                        <ItemTemplate>
                            <asp:Label ID="lblDishRate" runat="server" Text='<%#Eval("DishRate") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="Loyalty Points">
                        <ItemTemplate>
                            <asp:Label ID="lblAddn" runat="server" Text='<%#Eval("loyaltyPoints") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                   <%-- <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" CssClass="btn btn-Info" CommandName="Update"
                                ToolTip="Edit" runat="server" Text="Edit" />
                            |<asp:Button ID="btnDelete" CommandName="Delete" CssClass="btn btn-danger"
                                ToolTip="Delete" runat="server" OnClientClick="return confirm('Are you sure you want to delete?');" Text="Delete" />
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>
            </div>
        </div>
       <%-- <div class="card">


           
            <div class="col-md-3">

                <div class="form-group">
                    <label class="label-control">Dish Name</label>
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-3">

                <div class="form-group">
                    <label class="label-control">Local Name</label>
                    <asp:TextBox ID="txtLocalName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>


            </div>
            <div class="col-md-3">

                <div class="form-group">
                    <label class="label-control">Dish Rate</label>
                    <asp:TextBox ID="txtRate" runat="server" CssClass="form-control" type="Number" Step="0.01"></asp:TextBox>
                </div>
            </div>
         
            <div class="col-md-3">

                <div class="form-group">
                    <label class="label-control">Restaurant </label>
                    <asp:DropDownList ID="dllRestaurant" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>


            </div>

            <div class="col-md-3" style="padding-top: 20px;">
                <div class="form-group">
                    <label></label>
                    <asp:HiddenField ID="lblVar" runat="server" />
                    <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" OnClick="btnSubmit_Click" Text="Create" />
                </div>
            </div>

        </div>--%>

    </div>
         </div>

</asp:Content>

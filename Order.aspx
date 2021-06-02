<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="GoodFood._Order" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%-- <asp:MultiView ID="multiview1" runat="server">
        <asp:View ID="View1" runat="server">--%>
    <div class="container">
    <div class="row">
        <div class="col-md-12">
            <h1 style="padding-left:20px;"> Order </h1>
            <hr />
        </div>
        <div class="container">
        <div class="col-md-12">
            <asp:Label runat="server" ID="Lbl_Msg"></asp:Label>
        </div>
        <div class="col-md-12">

            <asp:GridView ID="gv" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                Width="100%" CssClass="table table-bordered table-striped GridViewStyle" AutoGenerateColumns="false" DataKeyNames="DishRestaurantId"
                AllowPaging="false" PageSize="5" OnPageIndexChanging="gv_PageIndexChanging" OnRowCommand="gv_RowCommand">
                <Columns>

                    <asp:TemplateField HeaderText="S.No">
                        <ItemTemplate>
                            <asp:Label ID="lblSn" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                            <asp:HiddenField ID="lblDishRestaurant" runat="server" Value='<%#Eval("DishRestaurantId") %>' />
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
                            <asp:Label ID="lblAddn" runat="server" Text='<%#Eval("DishRate") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                   <%-- <asp:TemplateField HeaderText="Loyalty Points">
                        <ItemTemplate>
                            <asp:Label ID="lblAn" runat="server" Text='<%#Eval("loyaltyPoints") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="btnCart" runat="server" Text="AddToCart" CssClass="btn bt-primary" CommandName="AddToCart" CommandArgument='<%#Container.DataItemIndex %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <asp:Repeater ID="repCart" runat="server" OnItemCommand="rep_OnItemCommand">
                <HeaderTemplate>
                    <table class="table table-bordered">
                        <thead>
                            <th>Dish
                            </th>
                            <th>Restaurant
                            </th>
                            <th>Quantity</th>
                            <th>Price</th>
                            <th>Action
                            </th>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:HiddenField ID="lblDishRestaurant" runat="server" Value='<%#Eval("DishRestaurantId") %>' />
                            <asp:HiddenField ID="lblDishId" runat="server" Value='<%#Eval("DishId") %>' />
                            <asp:HiddenField ID="lblRestaurantId" runat="server" Value='<%#Eval("RestaurantId") %>' />
                            <%--<asp:HiddenField ID="lblLoyaltyPoint" runat="server" Value='<%#Eval("loyaltyPoints") %>' />--%>
                            <%#Eval("DishName") %></td>
                        <td><%#Eval("RestaurantName") %></td>
                        <td id="tdQty">
                            <asp:TextBox ID="txtQty" runat="server" type="number" step="1" CssClass="form-control"></asp:TextBox></td>

                        <th id="tdRate">
                            <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("dishRate") %>'></asp:Label> </th>
                        <td>
                            <asp:Button ID="btnRemove" runat="server" Text="Remove" CssClass="btn btn-danger" CommandName="Remove" /></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            </div>
        </div>
        <div class="col-md-12">&nbsp;</div>
       <%-- <div class="col-md-3">
            <div class="form-group">
                <label class="label-control">Delivery Point</label>
                <asp:TextBox ID="txtDelPoint" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>--%>
        <%--<div class="col-md-3">

            <div class="form-group">
                <label class="label-control">Longitude</label>
                <asp:TextBox ID="txt" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-3">
                
            <div class="form-group">
                <label class="label-control">Longitude</label>
                <asp:TextBox ID="txtDelAddress" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>--%>

        <div class="col-md=6">

            <div class="form-group">
                <label>&nbsp;</label>
                <asp:Button ID="btnOrder" runat="server" Text="Order Items In Cart" CssClass="btn btn-info"   style="margin:12px; " OnClick="btnOrder_Click"/>
            </div>
        </div>
        <div class="col-md-12">
            <h4  style="margin:12px;" >Summary</h4>
            <label style="margin:12px;">Total:<asp:Label ID="lblTotal" runat="server"></asp:Label></label><br />
            <label style="margin:12px;">Loyalty Points:<asp:Label ID="lblLoyalPoint" runat="server"></asp:Label></label><br />
        </div>
        </div>

    </div>
    <%--  </asp:View>

      
        <asp:View ID="View2" runat="server">
           
             
        </asp:View>
    </asp:MultiView>--%>
    <script type="text/javascript">

</script>
</asp:Content>


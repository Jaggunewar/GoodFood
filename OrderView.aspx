<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderView.aspx.cs" Inherits="GoodFood._OrderView" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:MultiView ID="multiview1" runat="server">
        <asp:View ID="View1" runat="server">
          <div class="container">
                <div class="col-md-12">
                    <h1 style="padding:20px">Order Activity Form </h1>
                    <hr />
                </div>
                <div class="col-md-12">
                    <asp:Label runat="server" ID="Lbl_Msg"></asp:Label>
                </div>
                <div class="col-md-12">
                    <%-- <asp:Repeater ID="repOrder" runat="server" OnItemDataBound="OnItemDataBound">
                <HeaderTemplate>
                    <table class="table table-bordered">
                        <tr>
                            <th>Dish
                            </th>
                            <th>Restaurant
                            </th>
                            <th>Quantity</th>
                            <th>Price</th>
                            <th>Sub Total</th>

                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>

                        <td colspan="5">
                            <asp:HiddenField ID="hfOrderNo" Value='<%#Eval("OrderNumber") %>' runat="server" />
                            OrderNo:<%#Eval("OrderNumber") %> ,<%#Eval("sn") %> &nbsp; Order Date:<%#Convert.ToDateTime(Eval("dateTime").ToString()).ToString("yyyy-MM-dd  HH:mm:ss") %>
                        Total:<%#Eval("orderAmount") %>, Delivery Point:<%#Eval("deliveryPoint") %>    
                        </td>
                    </tr>

                    <asp:Repeater ID="repOrderItems" runat="server">
                    
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("dishName") %></td>
                                <td><%#Eval("RestaurantName") %></td>
                                <td><%#Eval("orderUnit") %></td>
                                <td><%#Eval("dishRate") %></td>
                                <td><%#Eval("lineTotal") %></td>

                            </tr>
                        </ItemTemplate>
                       
                    </asp:Repeater>
                    </tr>

                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>--%>
</div>
            <div class="container">

                     <div class="row">
                         <div class="container">
                    <asp:Repeater ID="repOrders" runat="server" OnItemCommand="rep_onItemCommand">

                        <HeaderTemplate>
                            <table class="table table-bordered">
                                <tr>
                                    <th>Order No
                                    </th>
                                    <th>Order Date
                                    </th>
                                    <th>Customer</th>
                                    <th>Delivery Location</th>
                                    <%--  <th>Delivery Location</th>--%>
                                    <th>Total</th>
                                    <th></th>

                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>

                                <td>
                                    <asp:HiddenField ID="hfOrderNo" Value='<%#Eval("OrderNumber") %>' runat="server" />

                                    <%#Convert.ToDateTime(Eval("datetime").ToString()).ToString("yyyyMMdd").ToString()+"-"+ Eval("sn") %>
                                </td>
                                <td><%#Eval("datetime") %></td>
                                <td>
                                    <%#Eval("customerName") %>
                                </td>

                                <td>
                                    <%#Eval("deliveryPoint") %>
                                </td>
                                <td>
                                    <%#Eval("orderAmount") %>
                                </td>

                                <td>
                                    <asp:Button ID="btnDetails" runat="server" Text="Details" CommandArgument='<%#Eval("OrderNumber") %>' CommandName="Details" />
                                    <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-danger" Text="Delete" CommandArgument='<%#Eval("OrderNumber") %>' CommandName="Delete" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
</div>

                    <div class="container">
                    <h3>Top 5 Restaurants</h3>
                        <div>
                            <asp:DropDownList ID="ddlMonth" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlMonth_Onchange"></asp:DropDownList>
                         </div>
                    <asp:Repeater ID="repTop" runat="server">

                        <HeaderTemplate>
                            <table class="table table-bordered">
                                <tr>
                                    <th>Restaurant Name
                                    </th>
                                    <th>Dish Count
                                    </th>

                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>

                                <td>
                                    <%#Eval("restaurantName") %>
                                </td>
                                <td>
                                    <%#Eval("dishCount") %>
                                </td>

                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
            </div>
        </asp:View>
        <asp:View ID="view2" runat="server">
            <div class="container">
            <div class="row">
                <asp:Repeater ID="repOrder" runat="server">
                    <ItemTemplate>
                        <div class="col-md-12">
                            <h2>Order Summary</h2>
                            
                            <label>Order No: </label>
                            <%#Eval("sn") %>&nbsp;&nbsp;&nbsp;&nbsp;
                                <label>Order Date: </label>
                            <%#Eval("DateTime") %>&nbsp;&nbsp;&nbsp;&nbsp;                               
                           <%-- <label>Delivery Location:</label><%#Eval("deliveryPoint") %><br />--%>

                            <label>Total: </label>
                            <%#Eval("orderAmount") %>
                        </div>
                        
<hr />
                    </ItemTemplate>
                </asp:Repeater>
                <div class="col-md-12">
                    <h2>Customer Details</h2>
                    <asp:Repeater ID="repCustomer" runat="server">
                        <HeaderTemplate>
                            <table class="table table-bordered table-stripped">
                                <tr>
                                    <th>Customer Name
                                    </th>
                                    <th>Contact No
                                    </th>


                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("customerName") %></td>
                                <td><%#Eval("phoneNumber") %></td>
                            </tr>

                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
                <div class="col-md-12">
                    <h2>Order Item Details</h2>

                    <asp:Repeater ID="repItems" runat="server">
                        <HeaderTemplate>
                            <table class="table table-bordered table-stripped">
                                <tr>
                                    <th>Dish
                                    </th>
                                    <th>Restaurant
                                    </th>
                                    <th>Quantity</th>
                                    <th>Price</th>
                                    <th>Sub Total</th>

                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("dishName") %></td>
                                <td><%#Eval("RestaurantName") %></td>
                                <td><%#Eval("orderUnit") %></td>
                                <td><%#Eval("dishRate") %></td>
                                <td><%#Eval("lineTotal") %></td>

                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                    </div>
                <hr />
                 <div class="container">
                    <h2>Delivery Address</h2>
                   
                    <div class="row">

                        <div class="col-md-12">
                            <asp:Label ID="lbl_OrderNo" runat="server" Visible="false"> </asp:Label>
                            <asp:Label ID="lbl_LocationId" runat="server" Visible="false"> </asp:Label>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Latitude</label>
                                <asp:TextBox ID="txtLatitude" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Longitude</label>
                                <asp:TextBox ID="txtLongitude" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label>Address</label>
                                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <%--<a href="OrderView.aspx">OrderView.aspx</a>--%>
                        </div>
                        <br />
                        <div class="col-md-3">
                            <div class="form-group">
                                <asp:Button ID="btnSubmit" runat="server" Text="Add Delivery Address" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
                            </div>
                        </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:View>
    </asp:MultiView>
</asp:Content>


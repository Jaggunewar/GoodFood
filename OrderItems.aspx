<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderItems.aspx.cs" Inherits="GoodFood._OrderItems" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:MultiView ID="multiview1" runat="server">
        
        <asp:View ID="View1" runat="server">
             
            <div class="row">
                <div class="col-md-12">
                    <h4>Dish </h4>
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
                     
                    <asp:Repeater ID="repOrders" runat="server">

                        <HeaderTemplate>
                            <table class="table table-bordered">
                                <tr>
                                    <th>Order No
                                    </th>
                                    <th>Order Date
                                    </th>
                                    <th>Customer</th>
                                    <th>Delivery Location</th>
                                    <th>Total</th>
                                    <th></th>

                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>

                                <td>
                                    <asp:HiddenField ID="HiddenField1" Value='<%#Eval("OrderNumber") %>' runat="server" />

                                    <%#Eval("orderNumber") %>
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
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </asp:View>
        <asp:View ID="view2" runat="server">
            <div class="row">
               <%-- <div class="col-md-12">
                    <asp:Button ID="btnView1" runat="server" Text="View All Orders" CssClass="btn btn-primary" OnClick="btnView1_Click"/>
                </div>--%>
                <asp:Repeater ID="repOrder" runat="server">
                    <ItemTemplate>
                        <div class="col-md-12">
                            <h3>Order Summary</h3>

                            <label>Order No: </label>
                            <%#Eval("sn") %>&nbsp;&nbsp;&nbsp;&nbsp;
                                <label>Order Date: </label>
                            <%#Eval("DateTime") %>&nbsp;&nbsp;&nbsp;&nbsp;                               
                           <%-- <label>Delivery Location:</label><%#Eval("deliveryPoint") %><br />--%>

                            <label>Total: </label>
                            <%#Eval("orderAmount") %>
                        </div>

                    </ItemTemplate>
                </asp:Repeater>
                <asp:Repeater ID="repCustomer" runat="server">
                    <ItemTemplate>
                        <div class="col-md-12">
                            <h3>Customer Details</h3>
                            <label>Customer Id:</label><%#Eval("customerId") %>&nbsp;&nbsp;&nbsp;&nbsp;
                            <label>Customer Name:</label><%#Eval("customerName") %>&nbsp;&nbsp;&nbsp;&nbsp;
                            <label>Contact No:</label><%#Eval("phoneNumber") %>&nbsp;&nbsp;&nbsp;&nbsp;
                        </div>

                    </ItemTemplate>
                </asp:Repeater>
                <div class ="container">   
                <div class="col-md-12">
                    <h3>Customer Order Detail form</h3>
                    
                     <asp:DropDownList ID="ddlCustomer" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCustomer_OnSelectedChanged" AutoPostBack="true"></asp:DropDownList>
                      <br />
                    <asp:Repeater ID="repItems" runat="server">
                        <HeaderTemplate>
                            <table class="table table-bordered table-stripped">
                                <tr>
                                    <th>Customer Name
                                    </th> <th>Dish
                                    </th>
                                    <th>Restaurant
                                    </th>
                                    <th>Quantity</th>
                                    <th>Price</th>
                                    <th>Sub Total</th>
                                    <th>Delivery Points</th>

                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>

                                <td><%#Eval("customerName") %></td>
                                <td><%#Eval("dishName") %></td>
                                <td><%#Eval("RestaurantName") %></td>
                                <td><%#Eval("orderUnit") %></td>
                                <td><%#Eval("dishRate") %></td>
                                <td><%#Eval("lineTotal") %></td>
                                <td><%#Eval("deliveryPoint") %></td>

                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                   

                    <%--<h4>Delivery Address</h4>--%>
                    
                   <%-- <div class="row">
                        <div class="col-md-12">
                           <table class="table table-bordered table-stripped">
                                <tr>
                                    <th>Latitude
                                    </th>
                                    <th>Longitude
                                    </th>
                                    <th>Address</th>                                  

                                </tr>
                               <tr>
                                   <td><asp:Label Id="lblLat" runat="server"></asp:Label></td>
                                   <td><asp:Label Id="lblLong" runat="server"></asp:Label></td>
                                   <td><asp:Label Id="lblPoint" runat="server"></asp:Label></td>
                               </tr>
                               </table>
                        </div>
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
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                               <asp:Button ID="btnSubmit" runat="server" Text="Add Delivery Address" CssClass="btn btn-primary" OnClick="btnSubmit_Click"/>
                            </div>
                        </div>
                    </div>--%>
                </div>
            </div>
            </div>
        </asp:View>
    </asp:MultiView>
</asp:Content>


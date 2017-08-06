<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="MealOffers.aspx.cs" Inherits="MealOffers" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="container">
         <div class="row">
            <div class="col-md-offset-2 col-md-5">
                <h3>Offer Posts</h3>
            </div>
        </div>
        <div class="row">
            <div class="col-md-offset-2 col-md-9">
              
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
                    <Columns>
                         <asp:BoundField DataField="username" HeaderText="Username" />
                         <asp:BoundField DataField="Price" HeaderText="Price" />
                         <asp:BoundField DataField="Delivery" HeaderText="Delivery" />
                         <asp:BoundField DataField="Description"  HeaderText="Description" />
                         <asp:BoundField DataField="ContactNumber" HeaderText="Contact Number" />
                    </Columns>
                </asp:GridView>
                <br />
            </div>
        </div>
        <br />
    </div>
</asp:Content>
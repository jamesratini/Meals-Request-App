<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="MealsRequests.aspx.cs" Inherits="MealsRequests" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    
    <div class="container">
        <div class="row">
            <div class="col-md-offset-4 col-md-5">
                <h3>Request Posts</h3>
            </div>
        </div>
        <div class="row">
            <div class="col-md-offset-4 col-md-9">
              
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
                    <Columns>
                         <asp:HyperLinkField DataNavigateUrlFields="RequestId" DataNavigateUrlFormatString="RequestDetails.aspx?ID={0}" DataTextField="username" HeaderText="User Name" SortExpression="UserName" />
                         <asp:BoundField DataField="Pickup" HeaderText="Pickup" />
                         <asp:BoundField DataField="ContactNumber" HeaderText="Contact Number" />
                    </Columns>
                </asp:GridView>
                <br />
                <asp:Button ID="requestPostButton" runat="server" CssClass="btn btn-primary showRequestPostForm" Text="Request Form" OnClick="requestPostButton_Click" />
            </div>
        </div>
        <br />
        <div class="row" runat="server" id="createRequestPost">
            <div class="col-md-6 col-md-offset-4">
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="requestCreateDietLabel" runat="server" Text="Diet Restrictions: "></asp:Label>
                    </div>
                    <div class="col-md-4 requestCreateTextBox">
                        <asp:TextBox ID="requestCreateDietText"  runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-1">
                         <asp:Label ID="requestCreatePickupLabel" runat="server" Text="Pickup?: "></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:RadioButtonList ID="requestCreatePickupButtons" ValidationGroup="pickupVal" runat="server">
                            <asp:ListItem Text="Yes"  Value="1"  Selected="False" />
                            <asp:ListItem Text="No"  Value="0"  Selected="False" />
                        </asp:RadioButtonList>
                        
                    </div>
                    <div class="col-md-4">
                        <asp:RequiredFieldValidator runat="server" ID="valRequestCreatePickupButtons"
                            ControlToValidate="requestCreatePickupButtons" ErrorMessage="You must select an option!" ValidationGroup ="pickupVal" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="requestCreateContactLabel" runat="server" Text="Contact Number: "></asp:Label>
                    </div>
                    <div class="col-md-4 requestCreateTextBox">
                        <asp:TextBox ID="requestCreateContactText" MaxLength="10" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:RegularExpressionValidator ID="valContact" runat="server"
                           ControlToValidate="requestCreateContactText"
                           ErrorMessage="Contact Number must be 10"
                           ValidationExpression=".{10}.*" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="requestCreateDescLabel" runat="server" Text="Description: "></asp:Label>
                    </div>
                    <div class="col-md-4 requestCreateTextBox">
                        <asp:TextBox ID="requestCreateDescText" CssClass="detailsTextBox" TextMode="MultiLine"  runat="server" OnTextChanged="requestCreateDescText_TextChanged"></asp:TextBox>
                    </div>
                </div>
                <asp:Button ID="submitRequest" ValidationGroup="pickupVal" runat="server" Text="SUBMIT REQUEST >" OnClick="submitRequest_Click" />
            </div>
        </div>
    
    </div>
    
</asp:Content>


<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="RequestDetails.aspx.cs" Inherits="RequestDetails" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="container">
        <div class="row">
            <div class="col-md-6 col-md-offset-3 requestDetailsBox">
                <div class="row">
                    <div class="col-md-6">
                        <h2>User Details</h2>
                        <h3> <asp:Label ID="detailsUsername" runat="server" Text=""></asp:Label> </h3>
                        <h4> <asp:Label ID="detailsEmail" runat="server" Text=""></asp:Label> </h4>
                        <h4> <asp:Label ID="detailsContactNumberLabel" runat="server"></asp:Label> </h4>
                          <asp:TextBox ID="detailsContactNumber" MaxLength="10" readonly="true" Text="No Contact Number Given" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-6">
                        <br /><br />
                        <asp:Button ID="detailsUpdateButton" CssClass="btn btn-primary btn-lg" runat="server" Text="Update" OnClick="detailsUpdateButton_Click" />
                        <asp:Button ID="detailsCommitButton" runat="server" Text="Commit" CssClass="btn btn-primary btn-lg"  OnClick="detailsCommitButton_Click" />
                        <asp:Button ID="detailsDeletePostButton" runat="server" Text="Delete Post!!" />
                    </div>
                </div>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-6 col-md-offset-3 requestDetailsBox">
                <h2>Meal Details</h2>
                <h4>Will Pickup: </h4>
                    <asp:RadioButtonList ID="detailsPickup" readonly="true" runat="server">
                        <asp:ListItem Enabled="false" Text="True"  Value="1"  Selected="False" />
                        <asp:ListItem Enabled="false" Text="False"  Value="0"  Selected="False" />
                    </asp:RadioButtonList>
                <h4>Diet Restrictions: </h4>
                    <asp:TextBox ID="detailsDiet" readonly="true" Text="No Diet Restrictions Given" runat="server"></asp:TextBox>
                <h4>Description:</h4>
                    <asp:TextBox ID="detailsDescription" Text="No Description Given" Columns="80" style="height:auto" TextMode="MultiLine" readonly="true" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    
</asp:Content>


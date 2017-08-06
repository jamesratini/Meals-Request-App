<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="RecipeList.aspx.cs" Inherits="RecipeList" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
     <div class="container">
         <div class="row">
            <div class="col-md-offset-2 col-md-5">
                <h3>Recipe List</h3>
            </div>
        </div>
        <div class="row">
            <div class="col-md-offset-2 col-md-9">
              
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
                    <Columns>
                         <asp:BoundField DataField="Meat" HeaderText="Meats" />
                         <asp:BoundField DataField="Fruit" HeaderText="Fruits" />
                         <asp:BoundField DataField="Vegetable" HeaderText="Vegetables" />
                         <asp:BoundField DataField="Grain"  HeaderText="Grain" />
                         <asp:BoundField DataField="Instruction" HeaderText="Instructions" />
                    </Columns>
                </asp:GridView>
                <br />
            </div>
        </div>
        <br />
    </div>
</asp:Content>
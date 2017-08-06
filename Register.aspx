<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Account_Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <div class="row form-horizontal">
        <div class="col-sm-8 col-sm-offset-3">
            <h2>Enter Your Details</h2>
        <hr />
        <div class="row">
            <div class="col-sm-12">
                <h4>Already have an account?</h4>
                <asp:Button ID="loginButton" runat="server" CssClass="btn btn-primary createAccountButton" Text="Login >" OnClick="loginButton_Click" />
            </div>
        </div>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="row">
            <div class="col-sm-9">
                <h5 class="createInfo">Enter your informaton below. Creating an account will let you post requests and offers!</h5>
            </div>
        </div>
            <br />
        <div class="row form-group">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label createLabel">E-mail</asp:Label>
            <div class="col-md-10">
                <asp:TextBox ID="Email" runat="server" CssClass="form-control createInput" />
                <asp:RequiredFieldValidator ValidationGroup="registerVal" runat="server" CssClass="text-danger" ControlToValidate="Email"
                        ErrorMessage="The email field is required" />
            </div>
        </div>
        <div class="row form-group">
            <asp:Label runat="server" AssociatedControlID="UserName" CssClass="col-md-2 control-label createLabel">User name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="UserName" CssClass="form-control createInput" />
                <asp:RequiredFieldValidator ValidationGroup="registerVal" runat="server" ControlToValidate="UserName"
                    CssClass="text-danger" ErrorMessage="The user name field is required." />
            </div>
        </div>
        <div class="row form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label createLabel">Password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control createInput" />
                <asp:RequiredFieldValidator ValidationGroup="registerVal" runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="The password field is required." />
            </div>
        </div>
        <div class="row form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label createLabel">Confirm password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control createInput" />
                <asp:RequiredFieldValidator ValidationGroup="registerVal" runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <asp:CompareValidator ValidationGroup="registerVal" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-10">
                <asp:Button ValidationGroup="registerVal" ID="registerButton" runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-primary createAccountButton" />
            </div>
        </div>
        </div>
        
    </div>
</asp:Content>


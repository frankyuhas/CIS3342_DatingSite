<%@ Page Title="" Language="C#" MasterPageFile="~/Dating.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="CIS3342_TermProject.ForgotPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <div class="container">
        <div class="card w-75 mx-auto">
            <div class="card-body">
                <div class="row">
                    <div class="col">
                        <h3>Reset Password</h3>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <asp:Label ID="lblEnterEmail" runat="server" Text="Enter Email:"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        <asp:Button ID="btnSubmit" runat="server" Text="Reset Password" OnClick="btnSubmit_Click" />
                    </div>
                </div>
                
                
                <hr runat="server" id="dividingLine"/>
                
                <div class="row">
                    <div class="col">
                        <asp:Label ID="lblSecurityQuestion" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:TextBox ID="txtSecAnswer" runat="server"></asp:TextBox>
                        <asp:Button ID="btnAnswerSecQuestion" runat="server" Text="Submit" OnClick="btnAnswerSecQuestion_Click" />
                    </div>
                </div>
                <hr runat="server" id="dividingLine2"/>
                <div class="row">
                    <div class="col">
                        <asp:Label ID="lblNewPassword" runat="server" Text="Enter New Password"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:Button ID="btnSubmitNewPass" runat="server" Text="Change Password" OnClick="btnSubmitNewPass_Click" Mo />
                    </div>
                </div>
            </div>

        </div>
    </div>
        
</asp:Content>

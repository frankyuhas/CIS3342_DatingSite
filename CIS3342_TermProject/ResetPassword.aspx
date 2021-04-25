<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="CIS3342_TermProject.ResetPassword" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <title>Dating Site</title>
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <!-- Bootstrap CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-eOJMYsd53ii+scO/bJGFsiCZc+5NDVN2yr8+0RDqr0Ql0h+rP48ckxlpbzKgwra6" crossorigin="anonymous"/>
    
</head>
<body>
    <form id="form1" runat="server">
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
    </form>
</body>
</html>

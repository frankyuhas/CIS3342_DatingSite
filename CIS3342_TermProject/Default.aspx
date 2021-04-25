<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CIS3342_TermProject.Default" %>

<!doctype html>
<html lang="en">
  <head runat="server">
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <!-- Bootstrap CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-eOJMYsd53ii+scO/bJGFsiCZc+5NDVN2yr8+0RDqr0Ql0h+rP48ckxlpbzKgwra6" crossorigin="anonymous"/>
    
    

    <link href="/css/signin.css" rel="stylesheet"/>
 
    
    <title>Dating Site</title>
  </head>
  <body class="text-center">
   
      <main class="form-signin">
        <form id="form1" runat="server">
        
            <img class="mb-4" src="/images/match.svg" alt="" width="72" height="57">
            <h1 class="h3 mb-3 fw-normal">Please sign in</h1>

            <div class="form-floating">
                <asp:TextBox ID="txtEmail" class="form-control" runat="server" placeholder="name@example.com"></asp:TextBox>
              <label for="txtEmail">Email address</label>
            </div>
            <div class="form-floating">
                <asp:TextBox ID="txtPassword" class="form-control" runat="server" placeholder="password" TextMode="Password"></asp:TextBox>
              <label for="txtPassword">Password</label>
            </div>
            <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            <%--<div class="checkbox mb-3">
              <label>
                <input type="checkbox" value="remember-me"> Remember me
              </label>
            </div>--%>
            <asp:button ID="btnSubmit_signin" class="w-100 btn btn-lg btn-primary" runat="server" type="submit" Text="Sign In" OnClick="btnSubmit_signin_Click"/>
            <asp:Button ID="btnCreate_Account" class="btn btn-link" runat="server" Text="Create Account" OnClick="btnCreate_Account_Click" />
            <asp:Button ID="btnForgotPassword" runat="server" Text="Forgot Password" CssClass="btn btn-link" OnClick="btnForgotPassword_Click" />

            
        
        </form>

    </main>

    
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/js/bootstrap.bundle.min.js" integrity="sha384-JEW9xMcG8R+pH31jmWH6WWP0WintQrMb4s7ZOdauHnUtxwoG2vI5DkLtS3qm9Ekf" crossorigin="anonymous"></script>

  
  </body>
</html>

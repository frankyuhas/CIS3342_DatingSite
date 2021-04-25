<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Verification.aspx.cs" Inherits="CIS3342_TermProject.Verification" %>

<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>--%>



<!doctype html>
<html lang="en">
  <head>
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <!-- Bootstrap CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-eOJMYsd53ii+scO/bJGFsiCZc+5NDVN2yr8+0RDqr0Ql0h+rP48ckxlpbzKgwra6" crossorigin="anonymous">

    <title>Hello, world!</title>
  </head>
  <body>
    
    <form id="form1" runat="server">
        <div class="container p-4">
            <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            <div class="card">
                <header class="card-header">
                    Verify Account
                </header>
                <div class="card-body">
                    <div class="row">
                        <div class="col">
                            <asp:Label ID="Label1" runat="server" Text="Please enter the verification Code that was sent to your email."></asp:Label>
                            <asp:TextBox ID="txtVerify" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <footer class="card-footer">
                    <center>
                        <asp:Button ID="btnSubmitVerification" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmitVerification_Click" />
                    </center> 
                </footer>
            </div>
        </div>
    </form>
   
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/js/bootstrap.bundle.min.js" integrity="sha384-JEW9xMcG8R+pH31jmWH6WWP0WintQrMb4s7ZOdauHnUtxwoG2vI5DkLtS3qm9Ekf" crossorigin="anonymous"></script>

   
  </body>
</html>

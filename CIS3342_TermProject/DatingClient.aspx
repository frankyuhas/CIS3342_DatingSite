<%@ Page Title="" Language="C#" MasterPageFile="~/Dating.Master" AutoEventWireup="true" CodeBehind="DatingClient.aspx.cs" Inherits="CIS3342_TermProject.DatingClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<!doctype html>

<html lang="en">
  <head>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-BmbxuPwQa2lc/FVzBcNJ7UAyJxM6wuqIj61tLrc4wSX0szH/Ev+nYRRuWlolflfl" crossorigin="anonymous"/>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css"/>
    <link rel="stylesheet" href="/resources/demos/style.css"/>
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <link rel="stylesheet" href="CSS/GridStyle.css" />
    
    <title>Dating Master</title>
  </head>
  <body>

      <div class="container-fluid align-top" style="padding-top: 75px;">

          <h1>Discover</h1>
          <asp:Button ID="btnShowUsers" runat="server" Text="Show Users" OnClick="btnShowUsers_Click" />

          <asp:Label ID="lblLikedName" runat="server" Text=""></asp:Label>
          <asp:Label ID="lblMatch" runat="server" Text=""></asp:Label>
          
          <asp:GridView ID="gv_Users"  runat="server" AutoGenerateColumns="False" GridLines="Horizontal" CssClass="table table-hover table-bordered" BorderStyle="None" OnSelectedIndexChanged="gv_Users_SelectedIndexChanged">
              <Columns>
                  <asp:CommandField SelectText="View" ShowSelectButton="True" />
                  <asp:ImageField DataImageUrlField="imgFile" HeaderText="Profile Picture">
                      <ItemStyle Height="50px" Width="50px" />
                  </asp:ImageField>
                  <asp:BoundField DataField="UserName" HeaderText="Name" />
                  <asp:TemplateField HeaderText="Age">
                      <itemtemplate>
				            <%# CalculateAge(Convert.ToDateTime(Eval("Birthday"))) %>
			          </itemtemplate>
                  </asp:TemplateField>
                  <asp:BoundField DataField="Gender" HeaderText="Gender" />
                  <asp:BoundField DataField="Bio" HeaderText="Bio" />
                  <asp:BoundField DataField="Location" HeaderText="Location" />
                  
                  <asp:TemplateField HeaderText="Like">
                      <ItemTemplate>
                          <asp:Button ID="btnLike" runat="server" class="btn-outline-success" Text="Like" CommandName="Like" OnClick="btnLike_Click" />
                      </ItemTemplate>
                  </asp:TemplateField>

                  <asp:TemplateField HeaderText="Pass">
                      <ItemTemplate>
                          <asp:Button ID="BtnPass" runat="server" class="btn-outline-danger" Text="Pass" CommandName="Pass" OnClick="BtnPass_Click" />
                      </ItemTemplate>
                  </asp:TemplateField>
                  
              </Columns>
          </asp:GridView>


      </div>

      <div class="container-fluid align-top" id="displayUser" style="padding-top: 75px;" runat="server">

          <div class="card w-50 mx-auto">
              <div class="card-body mx-auto w-100">
                  <div class="row mx-auto">
                      <div class="col">
                          <img ID="profilePicture" runat="server" src="" style="height: 300px; width: 300px;"/>    
                      </div>
                  </div>
                  <div class="row mx-auto">
                      <div class="col mx-auto">
                          <asp:Label ID="lblUserName" runat="server" Text="" CssClass="h2"></asp:Label>
                      </div>
                      <div class="col mx-auto">
                          <asp:Label ID="lblAge" runat="server" Text="" CssClass="h2"></asp:Label>
                      </div>
                  </div>
                  <div class="row mx-auto">
                      <div class="col mx-auto">
                          <asp:Label ID="lblGender" runat="server" Text=""></asp:Label>
                          <br />
                          <asp:Label ID="lblLocation" runat="server" Text=""></asp:Label>
                          <br />
                          <asp:Label ID="lblBio" runat="server" Text=""></asp:Label>
                      </div>
                  </div>
              </div>
          </div>
          
      </div>


    </body>
</html>

</asp:Content>

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
          <asp:Label ID="lblState2" runat="server" Text="Location:" ></asp:Label>
                        <asp:DropDownList ID="ddlState" runat="server" Width="150px" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" >
                            <asp:ListItem Value="ANY">Any</asp:ListItem>
	                        <asp:ListItem Value="AL">Alabama</asp:ListItem>
	                        <asp:ListItem Value="AK">Alaska</asp:ListItem>
	                        <asp:ListItem Value="AZ">Arizona</asp:ListItem>
	                        <asp:ListItem Value="AR">Arkansas</asp:ListItem>
	                        <asp:ListItem Value="CA">California</asp:ListItem>
	                        <asp:ListItem Value="CO">Colorado</asp:ListItem>
	                        <asp:ListItem Value="CT">Connecticut</asp:ListItem>
	                        <asp:ListItem Value="DC">District of Columbia</asp:ListItem>
	                        <asp:ListItem Value="DE">Delaware</asp:ListItem>
	                        <asp:ListItem Value="FL">Florida</asp:ListItem>
	                        <asp:ListItem Value="GA">Georgia</asp:ListItem>
	                        <asp:ListItem Value="HI">Hawaii</asp:ListItem>
	                        <asp:ListItem Value="ID">Idaho</asp:ListItem>
	                        <asp:ListItem Value="IL">Illinois</asp:ListItem>
	                        <asp:ListItem Value="IN">Indiana</asp:ListItem>
	                        <asp:ListItem Value="IA">Iowa</asp:ListItem>
	                        <asp:ListItem Value="KS">Kansas</asp:ListItem>
	                        <asp:ListItem Value="KY">Kentucky</asp:ListItem>
	                        <asp:ListItem Value="LA">Louisiana</asp:ListItem>
	                        <asp:ListItem Value="ME">Maine</asp:ListItem>
	                        <asp:ListItem Value="MD">Maryland</asp:ListItem>
	                        <asp:ListItem Value="MA">Massachusetts</asp:ListItem>
	                        <asp:ListItem Value="MI">Michigan</asp:ListItem>
	                        <asp:ListItem Value="MN">Minnesota</asp:ListItem>
	                        <asp:ListItem Value="MS">Mississippi</asp:ListItem>
	                        <asp:ListItem Value="MO">Missouri</asp:ListItem>
	                        <asp:ListItem Value="MT">Montana</asp:ListItem>
	                        <asp:ListItem Value="NE">Nebraska</asp:ListItem>
	                        <asp:ListItem Value="NV">Nevada</asp:ListItem>
	                        <asp:ListItem Value="NH">New Hampshire</asp:ListItem>
	                        <asp:ListItem Value="NJ">New Jersey</asp:ListItem>
	                        <asp:ListItem Value="NM">New Mexico</asp:ListItem>
	                        <asp:ListItem Value="NY">New York</asp:ListItem>
	                        <asp:ListItem Value="NC">North Carolina</asp:ListItem>
	                        <asp:ListItem Value="ND">North Dakota</asp:ListItem>
	                        <asp:ListItem Value="OH">Ohio</asp:ListItem>
	                        <asp:ListItem Value="OK">Oklahoma</asp:ListItem>
	                        <asp:ListItem Value="OR">Oregon</asp:ListItem>
	                        <asp:ListItem Value="PA">Pennsylvania</asp:ListItem>
	                        <asp:ListItem Value="RI">Rhode Island</asp:ListItem>
	                        <asp:ListItem Value="SC">South Carolina</asp:ListItem>
	                        <asp:ListItem Value="SD">South Dakota</asp:ListItem>
	                        <asp:ListItem Value="TN">Tennessee</asp:ListItem>
	                        <asp:ListItem Value="TX">Texas</asp:ListItem>
	                        <asp:ListItem Value="UT">Utah</asp:ListItem>
	                        <asp:ListItem Value="VT">Vermont</asp:ListItem>
	                        <asp:ListItem Value="VA">Virginia</asp:ListItem>
	                        <asp:ListItem Value="WA">Washington</asp:ListItem>
	                        <asp:ListItem Value="WV">West Virginia</asp:ListItem>
	                        <asp:ListItem Value="WI">Wisconsin</asp:ListItem>
	                        <asp:ListItem Value="WY">Wyoming</asp:ListItem>
                        </asp:DropDownList>

          <asp:Label ID="lblGender2" runat="server" Text="Gender:" ></asp:Label>
                        <asp:DropDownList ID="ddlGender" runat="server" OnSelectedIndexChanged="ddlGender_SelectedIndexChanged">
                            <asp:ListItem>Any</asp:ListItem>
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                            <asp:ListItem>Non-Binary</asp:ListItem>
                        </asp:DropDownList>

          <asp:Label ID="lblLikedName" runat="server" Text=""></asp:Label>
          <asp:Label ID="lblMatch" runat="server" Text=""></asp:Label>
          
          <asp:GridView ID="gv_Users"  runat="server" AutoGenerateColumns="False" GridLines="Horizontal" CssClass="table border-0 table-responsive" BorderStyle="None" OnSelectedIndexChanged="gv_Users_SelectedIndexChanged">
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

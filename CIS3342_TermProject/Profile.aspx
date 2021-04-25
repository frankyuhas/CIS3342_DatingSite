<%@ Page Title="" Language="C#" MasterPageFile="~/Dating.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="CIS3342_TermProject.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<!doctype html>

<html lang="en">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-BmbxuPwQa2lc/FVzBcNJ7UAyJxM6wuqIj61tLrc4wSX0szH/Ev+nYRRuWlolflfl" crossorigin="anonymous" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <link rel="stylesheet" href="/resources/demos/style.css" />
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <link rel="stylesheet" href="CSS/GridStyle.css" />

    <title>Dating Master</title>
</head>
<body>


    <div class="container-fluid w-50" style="padding-top: 75px;">
        <div class="card">
            <div class="card-body">
                <div class="row p-2 mx-auto">
                    <div class="col" style="text-align: center;">
                        <img class="mb-4" src="/images/match.svg" alt="logo" height="100" width="100">
                    </div>
                    <div class="col mx-auto" style="text-align: center;">
                        <br />
                        <h2>Love Master</h2>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container-fluid align-top" id="displayUser" style="padding-top: 10px;" runat="server">

          <div class="card w-50 mx-auto">
              <div class="card-body mx-auto w-100">
                  <div class="row mx-auto">
                      <div class="col">
                          <img ID="profilePicture" runat="server" src="" style="height: 300px; width: 300px;"/>    
                      </div>
                      <div class="col" style="text-align: right;">
                          <asp:Button ID="btnEditProfile" class="btn-outline-dark" runat="server" Text="Edit Profile" OnClick="btnEditProfile_Click" />
                          <br />
                          <br />
                          <asp:Button ID="btnDeleteProfile" class="btn-outline-danger" runat="server" Text="Delete Profile" OnClick="btnDeleteProfile_Click" />
                          <br />
                          <asp:Label ID="lblConfirm" runat="server" Visible="false" Text="Are you Sure?"></asp:Label>
                          <asp:Button ID="btnYes" runat="server" class="btn-outline-success" Visible="false" Text="Yes" OnClick="btnYes_Click" />
                          <asp:Button ID="btnNo" runat="server" class="btn-outline-danger" Visible="false" Text="No" OnClick="btnNo_Click" />
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

    <div class="container-fluid w-50" id="displayEdit" style="padding-top: 10px;" runat="server">
        <div class="card">
            <div class="card-body">
                <div class="row p-2 mx-auto">
                    <div class="col">
                        <asp:Label ID="lblName" runat="server" Text="Your Name:"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col">
                        <asp:Label ID="Label1" runat="server" Text="Your Location:" ></asp:Label>
                        <br />
                        <asp:DropDownList ID="ddlState" runat="server" CssClass="form-select">
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
                    </div>
                </div>
                <div class="row p-2 mx-auto">
                    <div class="col">
                        <asp:Label ID="lblGenderE" runat="server" Text="Your Gender:"></asp:Label>
                        <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-select">
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                            <asp:ListItem>Non-Binary</asp:ListItem>
                            <asp:ListItem>Other</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col">

                        <asp:Label ID="lblInterestedIn" runat="server" Text="Interested in:"></asp:Label>
                        <asp:DropDownList ID="ddlInterestedIn" runat="server" CssClass="form-select">
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                            <asp:ListItem>Non-Binary</asp:ListItem>
                            <asp:ListItem>Any</asp:ListItem>                            
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="row p-2 mx-auto">
                    <div class="col mx-auto" style="text-align:left;">
                        <asp:Label ID="lblProfilePicturee" runat="server" Text="Profile Picture: "></asp:Label>
                        <asp:FileUpload ID="fileProfilePicture" runat="server" CssClass="form-control-file" />
                    </div>
                </div>
                <div class="row p-2 mx-auto">
                    <div class="col">
                        <asp:Label ID="Label3" runat="server" Text="Your Bio:"></asp:Label>
                        <asp:TextBox ID="txtBio" runat="server" CssClass="form-control" rows="4" TextMode="MultiLine"></asp:TextBox>
                    </div>
                
                </div>

                <div class="row p-2 mx-auto">
                    <div class="col" style="text-align: right;">
                        <asp:Button ID="btnCancelEdit" class="btn-outline-danger" runat="server" Text="Cancel" OnClick="btnCancelEdit_Click" />
                        <asp:Button ID="btnSaveEdit" class="btn-outline-success" runat="server" Text="Save" OnClick="btnSaveEdit_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>


    </body>

</html>

</asp:Content>
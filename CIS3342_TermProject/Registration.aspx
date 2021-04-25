<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="CIS3342_TermProject.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-BmbxuPwQa2lc/FVzBcNJ7UAyJxM6wuqIj61tLrc4wSX0szH/Ev+nYRRuWlolflfl" crossorigin="anonymous"/>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css"/>
    <link rel="stylesheet" href="/resources/demos/style.css"/>
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>

    <script>
        $(function () {
            $('#inputDate').datepicker({ changeYear: true, yearRange: "1950:2002"});
        });
        
    </script>

    <title>Sign Up</title>
</head>
<body>
    <header>
         <nav class="navbar navbar-expand-lg navbar-dark fixed-top bg-danger">
          <div class="container-fluid">
            <a class="navbar-brand" href="Default.aspx">Love Master</a>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
              <span class="navbar-toggler-icon"></span>
            </button>
          </div>
        </nav>
    </header>
   
    <form id="form1" runat="server">
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    <%--registration form start--%>
        <div class="container-fluid w-50" style="padding-top: 75px;">
            <div class="card">
              <div class="card-body">
                <%--Row for logos--%>
                <div class="row p-2 mx-auto">
                    <div class="col" style="text-align: center;">
                        <img class="mb-4" src="/images/match.svg" alt="logo" height="100" width="100">
                    </div>
                    <div class="col mx-auto" style="text-align: center;">
                        <br />
                        <h2>Love Master</h2>
                    </div>
                </div>
                <%--End Logo Row--%>
                <%--Textboxes for registration--%>
                <div class="row p-2 mx-auto">
                    <div class="col">
                        <asp:Label ID="lblName" runat="server" Text="Your Name:"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col">
                        <asp:Label ID="lblEmail" runat="server" Text="Your Email:"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="row p-2 mx-auto">
                    <div class="col">
                        <asp:Label ID="lblPhone" runat="server" Text="Your Phone:"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
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
                        <asp:Label ID="lblBirtdate" runat="server" Text="Your Birthday:"></asp:Label>
                        <br />
                        <asp:TextBox type="DateTime" class="form-control" id="inputDate" runat="server"/>
                    </div>
                    <div class="col">
                        <asp:Label ID="lblGender" runat="server" Text="Your Gender:"></asp:Label>
                        <br />
                        <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-select">
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                            <asp:ListItem>Non-Binary</asp:ListItem>
                            <asp:ListItem>Other</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="row p-2 mx-auto">
                    <div class="col">
                        <asp:Label ID="lblInterestedIn" runat="server" Text="Interested in:"></asp:Label>
                        <asp:DropDownList ID="ddlInterestedIn" runat="server" CssClass="form-select">
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                            <asp:ListItem>Non-Binary</asp:ListItem>
                            <asp:ListItem>Any</asp:ListItem>                            
                        </asp:DropDownList>
                    </div>
                    <div class="col mx-auto" style="text-align:center;">
                        <asp:FileUpload ID="fileProfilePicture" runat="server" CssClass="form-control-file" />
                    </div>
                </div>
                <div class="row p-2 mx-auto">
                    <div class="col">
                        <asp:Label ID="lblBio" runat="server" Text="Your Bio:"></asp:Label>
                        <asp:TextBox ID="txtBio" runat="server" CssClass="form-control" rows="4" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
                <div class="row p-2 mx-auto">
                    <div class="col">
                        <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="col">
                        <asp:Label ID="lblReenterPassword" runat="server" Text="Re-enter Password:"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtReenterPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                    </div>
                </div>
                <div class="row p-2 mx-auto">
                    <div class="col">
                        <asp:Label ID="lblSecQuestion1" runat="server" Text="What town were you born in?"></asp:Label>
                        <asp:TextBox ID="txtSecQuestion1" runat="server"></asp:TextBox>
                    </div>
                </div>
                  <div class="row p-2 mx-auto">
                    <div class="col">
                        <asp:Label ID="lblSecQuestion2" runat="server" Text="What is the name of your first pet?"></asp:Label>
                        <asp:TextBox ID="txtSecQuestion2" runat="server"></asp:TextBox>
                    </div>
                </div>
                  <div class="row p-2 mx-auto">
                    <div class="col">
                        <asp:Label ID="lblSecQuestion3" runat="server" Text="What high school did you attend?"></asp:Label>
                        <asp:TextBox ID="txtSecQuestion3" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="row p-2 mx-auto">
                    <div class="col" style="text-align: center;">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-danger" OnClick="btnSubmit_Click"/>
                    </div>
                </div>
              </div>
            </div>
            <%--Textboxes end--%>
        </div>
    </form>
    <%--registration form end--%>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/js/bootstrap.bundle.min.js" integrity="sha384-JEW9xMcG8R+pH31jmWH6WWP0WintQrMb4s7ZOdauHnUtxwoG2vI5DkLtS3qm9Ekf" crossorigin="anonymous"></script>

</body>
</html>

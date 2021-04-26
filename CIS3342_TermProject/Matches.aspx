<%@ Page Title="" Language="C#" MasterPageFile="~/Dating.Master" AutoEventWireup="true" CodeBehind="Matches.aspx.cs" Inherits="CIS3342_TermProject.Matches" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!doctype html>


  <head>
    <%--<meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-BmbxuPwQa2lc/FVzBcNJ7UAyJxM6wuqIj61tLrc4wSX0szH/Ev+nYRRuWlolflfl" crossorigin="anonymous"/>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css"/>
    <link rel="stylesheet" href="/resources/demos/style.css"/>
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>--%>
    <link rel="stylesheet" href="CSS/GridStyle.css" />
    
    <title>Dating Master</title>
  </head>    
    
    <br />
    <br />
    <br />
    <div class="container">
        <h3>Your Matches</h3>
        <asp:GridView ID="gvMatches" runat="server" AutoGenerateColumns="False" CssClass="table border-0 table-responsive" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvMatches_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="UserName" HeaderText="Name" />
                <asp:ImageField DataImageUrlField="imgFile" HeaderText="Profile Picture">
                </asp:ImageField>
                <asp:BoundField DataField="Bio" HeaderText="Bio" />
                <asp:BoundField DataField="Location" HeaderText="Location" />
                <asp:BoundField DataField="Gender" HeaderText="Gender" />
                <asp:TemplateField HeaderText="Age">
                    <itemtemplate>
				        <%# CalculateAge(Convert.ToDateTime(Eval("Birthday"))) %>
			        </itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Message">
                      <ItemTemplate>
                          <asp:Button ID="btnMessage" runat="server" class="btn btn-danger" Text="Message" CommandName="Message" OnClick="btnMessage_Click" />
                      </ItemTemplate>
                  </asp:TemplateField>
<%--                <asp:ButtonField HeaderText="Message" Text="Message" ButtonType="Button" CommandName="Message" OnClick="btnMessage_Click"/>--%>
                
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
    
</asp:Content>

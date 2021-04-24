<%@ Page Title="" Language="C#" MasterPageFile="~/Dating.Master" AutoEventWireup="true" CodeBehind="Messages.aspx.cs" Inherits="CIS3342_TermProject.Messages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <br />
    <br />
    
    <div class="container border border-danger rounded p-2  bg-light" style="height: 750px; overflow-y: scroll;">
        <h3>Messages</h3>
        <hr />
        
        <div class="container-fluid rounded" >
            
            <asp:Repeater ID="rptMessages" runat="server">
                
                <ItemTemplate>
                    <br />
                    <tr>
                        <td>
                            <asp:Label ID="lblSender" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SenderName") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblMessageReceived" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Content") %>' CssClass="form-control w-50" readonly></asp:Label>
                        </td>
                    </tr>
                
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <br />

        
        
    </div>
    <br />
    <div class="container border border-danger rounded p-2 bg-light">
        <div class="card">
            <div class="card-body bg-light">
                <div class="row">
                    <div class="col">
                        <asp:TextBox ID="txtMessage" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col">
                        <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click" CssClass="btn btn-danger"/>
                    </div>
                </div>
              
                
                <asp:Label ID="lblMessageSent" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </div>
    
    
</asp:Content>

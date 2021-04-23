<%@ Page Title="" Language="C#" MasterPageFile="~/Dating.Master" AutoEventWireup="true" CodeBehind="Messages.aspx.cs" Inherits="CIS3342_TermProject.Messages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <br />
    <br />
    <div class="container border border-danger rounded p-2">
        
        <asp:Label ID="lblMessageSent" runat="server" Text=""></asp:Label>
        <div class="container-fluid border p-5 rounded bg-light">
            <h3>Messages</h3>
            <asp:Repeater ID="rptMessages" runat="server">
                
                <ItemTemplate>
                    <br />
                    <tr>
                        <td>
                            <asp:Label ID="lblSender" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SenderID") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblMessageReceived" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Content") %>' CssClass="form-control w-50"></asp:Label>
                        </td>
                    </tr>
                
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <br />

        <div class="card">
            <div class="card-body">
                <asp:TextBox ID="txtMessage" runat="server"></asp:TextBox>
                <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click" />
            </div>
        </div>
        
    </div>
    
</asp:Content>

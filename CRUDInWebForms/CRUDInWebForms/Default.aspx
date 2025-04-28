<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
    <div style="font-size:x-large" align="center">Student Info Manage Form</div>
       <br />
</div>
    
    <table class="nav-justified">
        <tr>
            <td style="height: 20px; width: 286px"></td>
            <td style="height: 20px; width: 170px">Student ID</td>
            <td style="height: 20px">
                <asp:TextBox ID="TextBox1" runat="server" Font-Size="Medium" Width="221px"></asp:TextBox>
            &nbsp;&nbsp;
                <asp:Button ID="Button5" runat="server" BackColor="#CC00FF" Font-Size="Medium" ForeColor="White" OnClick="Button5_Click" Text="Get" Width="93px" />
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 286px">&nbsp;</td>
            <td class="modal-sm" style="width: 170px">Student Name</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" Font-Size="Medium" Width="221px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 286px">&nbsp;</td>
            <td class="modal-sm" style="width: 170px">Address</td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem>USA</asp:ListItem>
                    <asp:ListItem>Caneda</asp:ListItem>
                    <asp:ListItem>UK</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 286px">&nbsp;</td>
            <td class="modal-sm" style="width: 170px">Age</td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" Font-Size="Medium" Width="221px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 286px">&nbsp;</td>
            <td class="modal-sm" style="width: 170px">Contact</td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server" Font-Size="Medium" Width="221px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 286px">&nbsp;</td>
            <td class="modal-sm" style="width: 170px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 286px">&nbsp;</td>
            <td class="modal-sm" style="width: 170px">&nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" BackColor="#CC00FF" Font-Size="Medium" ForeColor="White" OnClick="Button1_Click" Text="Insert" Width="93px" />
            &nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" BackColor="#CC00FF" Font-Size="Medium" ForeColor="White" OnClick="Button2_Click" Text="Update" Width="93px" />
            &nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button3" runat="server" BackColor="#CC00FF" Font-Size="Medium" ForeColor="White" OnClick="Button3_Click" OnClientClick="return confirm('Are you sure to delete?');" Text="Delete" Width="93px" />
            &nbsp;
                <asp:Button ID="Button4" runat="server" BackColor="#CC00FF" Font-Size="Medium" ForeColor="White" OnClick="Button4_Click" Text="Search" Width="93px" />
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 286px">&nbsp;</td>
            <td class="modal-sm" style="width: 170px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 286px">&nbsp;</td>
            <td class="modal-sm" style="width: 170px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 286px">&nbsp;</td>
            <td class="modal-sm" style="width: 170px">&nbsp;</td>
            <td>
                <asp:GridView ID="GridView1" runat="server" Width="836px">
                </asp:GridView>
            </td>
        </tr>
    </table>
    
</asp:Content>

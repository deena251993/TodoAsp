<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="2" cellspacing="3" align="center">
        <tr>
            <td colspan="2" align="center">
                <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="background-color: #E4E4E4">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table border="0" cellpadding="2" cellspacing="3" style="width: 100%">
                    <tr>
                        <td style="width: 16%; background-color: #E4E4E4" valign="top">
                            <asp:Image ID="imgUsername" runat="server" ImageUrl="images/username.gif" BorderWidth="0px" />
                        </td>
                        <td style="width: 84%">
                            <asp:TextBox ID="txtUsername" runat="server" Columns="12" Width="100px" MaxLength="12"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RValUsername" runat="server" ErrorMessage="*" ControlToValidate="txtUsername"
                                SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 16%; background-color: #E4E4E4">
                            <asp:Image ID="imgPassword" runat="server" ImageUrl="images/password.gif" BorderWidth="0px" />
                        </td>
                        <td style="width: 84%">
                            <asp:TextBox ID="txtPassword" runat="server" Columns="12" TextMode="Password" Width="100px"
                                MaxLength="12"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RValPassword" runat="server" ControlToValidate="txtPassword"
                                ErrorMessage="*" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 16%">
                        </td>
                        <td style="width: 84%">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 16%">
                        </td>
                        <td style="width: 84%" align="right">
                            <asp:ImageButton ID="ImageButtonLogin" runat="server" ImageUrl="images/submit.gif"
                                OnClick="ImageButtonLogin_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
    </table>
</asp:Content>

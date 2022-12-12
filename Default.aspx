<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>

    <table width="100%" border="0" align="right" dir="rtl" style="color: #003366;">
        <tr runat="server" id="trAdd">
            <td>
                <table width="100%" border="0" align="right" dir="rtl" style="color: #003366;">
                    <tr>
                        <td colspan="4">
                            <asp:Button ID="btnNew" Visible="false" runat="server" Font-Bold="True" Text="≈÷«›…"
                                OnClick="btnNew_Click" Width="100px" CausesValidation="false" />&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4" style="background-color: #E4E4E4; font-weight: bold;
                            color: #003366;">
                            ToDo&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:HiddenField ID="hdnId" runat="server" />
                        </td>
                    </tr>
                     <tr>
                        <td align="left" style="background-color: #F0F8FF; border: 1px solid; border-color: #dae4ec;">
                            <asp:Label ID="lblTitle" runat="server" Font-Bold="True" Text="Title"></asp:Label>&nbsp;&nbsp;
                        </td>
                        <td align="right">
                            <asp:TextBox ID="txtTitle" runat="server" Style="border: 1px solid; border-radius: 5px;
                                border-color: #999999; background-color: #E6E6E6;" Width="280px" />
                            <asp:RequiredFieldValidator ID="RValTitle" runat="server" ControlToValidate="txtTitle"
                                SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </td>
                       
                    </tr>
                   
                    <tr>
                        <td colspan="2">
                        </td>
                    </tr>
                   <tr>
                        <td align="left" style="background-color: #F0F8FF; border: 1px solid; border-color: #dae4ec;">
                            <asp:Label ID="lblDueDate" runat="server" Font-Bold="True" Text="Due Date"></asp:Label>&nbsp;&nbsp;
                        </td>
                        <td align="right">
                            <asp:TextBox ID="txtDueDate" runat="server" Style="border: 1px solid; border-radius: 5px;
                                border-color: #999999; background-color: #E6E6E6;" Width="80px" />
                            <asp:Image ID="imgCal" ImageAlign="Bottom" runat="server" ImageUrl="~/Images/Calendar_scheduleHS.png" />
                            <ajaxToolkit:CalendarExtender ID="CalendarExtenderDueDate" runat="server" Format="dd/MM/yyyy"
                                TargetControlID="txtDueDate" PopupButtonID="imgCal">
                            </ajaxToolkit:CalendarExtender>
                            <asp:RegularExpressionValidator ID="REValDueDate" runat="server" ControlToValidate="txtDueDate"
                                Display="Dynamic" ErrorMessage="Invalid date" ValidationExpression="^(?=\d)(?:(?!(?:(?:0?[5-9]|1[0-4])(?:\.|-|\/)10(?:\.|-|\/)(?:1582))|(?:(?:0?[3-9]|1[0-3])(?:\.|-|\/)0?9(?:\.|-|\/)(?:1752)))(31(?!(?:\.|-|\/)(?:0?[2469]|11))|30(?!(?:\.|-|\/)0?2)|(?:29(?:(?!(?:\.|-|\/)0?2(?:\.|-|\/))|(?=\D0?2\D(?:(?!000[04]|(?:(?:1[^0-6]|[2468][^048]|[3579][^26])00))(?:(?:(?:\d\d)(?:[02468][048]|[13579][26])(?!\x20BC))|(?:00(?:42|3[0369]|2[147]|1[258]|09)\x20BC))))))|2[0-8]|1\d|0?[1-9])([-.\/])(1[012]|(?:0?[1-9]))\2((?=(?:00(?:4[0-5]|[0-3]?\d)\x20BC)|(?:\d{4}(?:$|(?=\x20\d)\x20)))\d{4}(?:\x20BC)?)(?:$|(?=\x20\d)\x20))?((?:(?:0?[1-9]|1[012])(?::[0-5]\d){0,2}(?:\x20[aApP][mM]))|(?:[01]\d|2[0-3])(?::[0-5]\d){1,2})?$">dd/mm/yyyy</asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RValDueDate" runat="server" ControlToValidate="txtDueDate"
                                Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                  
                    <tr>
                        <td colspan="2">
                        </td>
                    </tr>
                    <asp:CheckBox ID="chkDone" runat="server" Text="Is Done?" />
                    <tr>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btnAdd" runat="server" Font-Bold="True" Text="≈÷«›…" OnClick="btnAdd_Click"
                                Width="100px" />&nbsp;
                            <asp:Button ID="btnUpdate" Visible="false" runat="server" Font-Bold="True" Text="Õ›Ÿ"
                                OnClick="btnUpdate_Click" Width="100px" />&nbsp;
                            <asp:Button ID="btnCancel" Visible="false" runat="server" Font-Bold="True" Text="≈·€«¡"
                                OnClick="btnCancel_Click" Width="100px" />&nbsp;<asp:Label ID="lblMessage" runat="server"
                                    Text="" Font-Bold="true" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
      
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
       
        <tr>
            <td>
                <asp:GridView ID="gvToDo" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" GridLines="Vertical"
                    DataSourceID="odsToDo" DataKeyNames="Id" AllowPaging="True" PageSize="15"
                    AllowSorting="True" ForeColor="Black" OnRowCommand="gvToDo_RowCommand" OnDataBound="gvToDo_DataBound">
                    <RowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Record No." />
                         <asp:BoundField DataField="Title" HeaderText="Title" ItemStyle-Width="200px">
                            <ItemStyle Width="200px"></ItemStyle>
                        </asp:BoundField>
                       
                        <asp:TemplateField HeaderText="Due Date">
                            <ItemTemplate>
                                <asp:Label ID="lblDueDate" runat="server" Font-Bold="True" Text='<%# getDate(DataBinder.Eval(Container.DataItem, "DueDate"))%>'></asp:Label>&nbsp;&nbsp;
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                        <asp:CommandField ShowSelectButton="True" SelectText="⁄—÷" HeaderText="⁄—÷" />
                        <asp:TemplateField HeaderText="Õ–›">
                            <ItemTemplate>
                                <asp:Button ID="btnDelete" runat="server" CommandArgument="<%# Container.DataItemIndex %>"
                                    CommandName="Delete" Text="Õ–›" OnClientClick="swal('Are you sure you want to delete this?', {
  buttons: ['No', 'Yes'],
});" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#CCCC99" />
                    <PagerStyle BackColor="#E4E4E4" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="PaleGreen" Font-Bold="True" ForeColor="Black" />
                    <HeaderStyle BackColor="#E4E4E4" Font-Bold="True" ForeColor="#003366" />
                    <AlternatingRowStyle BackColor="silver" />
                    <EmptyDataTemplate>
                        <label style="width: 300px;">
                            ·« ÌÊÃœ »Ì«‰« </label>
                    </EmptyDataTemplate>
                    <EmptyDataRowStyle Width="300px" Font-Bold="True" ForeColor="Magenta" BorderStyle="None" VerticalAlign="Middle" />
                </asp:GridView>
                <asp:ObjectDataSource ID="odsToDo" runat="server" EnablePaging="True" SelectCountMethod="getDataCount"
                    SelectMethod="getGVData"  TypeName="ToDoBLL"
                    OldValuesParameterFormatString="original_{0}">
                    <SelectParameters>
                        <asp:Parameter Name="maximumRows" Type="Int32" />
                        <asp:Parameter Name="startRowIndex" Type="Int32" />
                        <asp:SessionParameter SessionField="uid" Name="LoginUserid" Type="Int32" />
                         <asp:SessionParameter SessionField="role" Name="role" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
</asp:Content>

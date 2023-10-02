<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="WebApp.Employee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .newStyle1 {
            font-family: "Poppins Medium";
        }
        .newStyle2 {
            font-family: "Poppins Medium";
        }
        .auto-style1 {
            height: 32px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2 style="color: #0000FF">Employee Form</h2>
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Nama" CssClass="newStyle1"></asp:Label>
                </td>
                <td>
                     <asp:TextBox ID="txtNama" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="NIK / ID" CssClass="newStyle1"></asp:Label>
                </td>
                <td>
                     <asp:TextBox ID="txtID" runat="server" onkeypress="if(event.keyCode<48 || event.keyCode>57)event.returnValue=false;"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label3" runat="server" Text="Usia" CssClass="newStyle1"></asp:Label>
                </td>
                <td class="auto-style1">
                     <asp:TextBox ID="txtUsia" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Tanggal Masuk Kerja" CssClass="newStyle1"></asp:Label>
                </td>
                <td>    
                    <asp:TextBox ID="txtDateTime" runat="server" ReadOnly="false"></asp:TextBox>
                    <asp:Calendar ID="calDateTime" runat="server" OnSelectionChanged="calDateTime_SelectionChanged"></asp:Calendar>

                    <asp:DropDownList ID="ddlDay" runat="server" AutoPostBack="True"></asp:DropDownList>
                    <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged"></asp:DropDownList>
                    <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" ViewStateMode="Enabled"></asp:DropDownList>
                   
                </td>
            </tr>
                        
            <tr>
                <td>
                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" CssClass="newStyle2" style="height: 45px"/>
                </td>
                <td>
                    <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" CssClass="newStyle2"/>
                </td>
                <td>
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>     
                                            
                </td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <br />
        <br />

        <asp:Label ID="lblUpdate" runat="server" Text="" Visible="false"></asp:Label>  
        <asp:Label ID="lblID" runat="server" Text="" Visible="false"></asp:Label> 
        <asp:GridView ID="grid1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="grid1_SelectedIndexChanged" Width="833px" >  
     <AlternatingRowStyle BackColor="White" />  
     <columns>  
         <asp:TemplateField HeaderText="ID" Visible="false">  
             <ItemTemplate>  
                 <asp:Label ID="lblId" runat="server" Text='<%#Bind("IDKaryawan") %>'></asp:Label>  
             </ItemTemplate>  
         </asp:TemplateField>  
         <asp:TemplateField HeaderText="NIK">
    <ItemTemplate>  
        <asp:Label ID="lblNIK" runat="server" Text='<%#Bind("IDKaryawan") %>'></asp:Label>  
    </ItemTemplate>  
</asp:TemplateField>    
         <asp:TemplateField HeaderText="Nama">  
             <ItemTemplate>  
                 <asp:Label ID="lblNama" runat="server" Text='<%#Bind("NmKaryawan") %>'></asp:Label>  
             </ItemTemplate>  
         </asp:TemplateField>           
         <asp:TemplateField HeaderText="Tanggal Masuk Kerja">  
             <ItemTemplate>  
                 <asp:Label ID="lblTglMasukKerja" runat="server" Text='<%#Bind("TglMasukKerja") %>'></asp:Label>  
             </ItemTemplate>  
         </asp:TemplateField>
         <asp:TemplateField HeaderText="Usia">  
             <ItemTemplate>  
                 <asp:Label ID="lblUsia" runat="server" Text='<%#Bind("Usia") %>'></asp:Label>  
             </ItemTemplate>  
         </asp:TemplateField>  
         
         <asp:TemplateField HeaderText="Edit">  
             <ItemTemplate>  
                 <asp:LinkButton ID="btnEdit" runat="server" CommandArgument='<%#Eval("IDKaryawan")%>' OnCommand="btnEdit_Command" Text="Edit">
                      </asp:LinkButton>
             </ItemTemplate>  
         </asp:TemplateField>  
         <asp:TemplateField HeaderText="Hapus">  
             <ItemTemplate>  
                 <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%#Eval("IDKaryawan")%>' OnCommand="btnDelete_Command" Text="Delete">
                      </asp:LinkButton>
             </ItemTemplate>  
         </asp:TemplateField>  
     </columns>  
     <EditRowStyle BackColor="#2461BF" />  
     <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />  
     <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />  
     <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />  
     <RowStyle BackColor="#EFF3FB" />  
     <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />  
     <SortedAscendingCellStyle BackColor="#F5F7FB" />  
     <SortedAscendingHeaderStyle BackColor="#6D95E1" />  
     <SortedDescendingCellStyle BackColor="#E9EBEF" />  
     <SortedDescendingHeaderStyle BackColor="#4870BE" />  
 </asp:GridView> 
        
    </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employee_DataGrid.aspx.cs" Inherits="WebApp.Employee_DataGrid" %>

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
        .auto-style2 {
            width: 128px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <h2 style="color: #0000FF">Employee Form Data Grid</h2>
        <td>
    <asp:Button ID="Button_AddEmployee" runat="server" OnClick="btnSave_Click" Text="Tambah Data Karyawan" CssClass="newStyle2" style="height: 45px"/>
</td>
        <br />
    </div>
        <p>
            <asp:Label ID="Label1" runat="server" Text="Filter Data Karyawan" style="text-align: left"></asp:Label>
        </p>
        <div>
            <table>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Nama Karyawan" CssClass="newStyle1"></asp:Label>
                </td>
                <td class="auto-style2">
                     <asp:TextBox ID="txtNamaKaryawan" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="BtnSearchKaryawan" runat="server" Text="Search" CssClass="newStyle2" OnClick="BtnSearchKaryawan_Click" />
                </td>
            </tr>

                <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Usia Karyawan" CssClass="newStyle1"></asp:Label>
                </td>
                <td class="auto-style2">
                     <asp:TextBox ID="txtUsiaKaryawan" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="BtnSearchUsia" runat="server" Text="Search" CssClass="newStyle2" OnClick="BtnSearchUsia_Click" />
                </td>
            </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Tanggal Masuk Karyawan" CssClass="newStyle1"></asp:Label>
                        
                        </td>

                    <td>
                        <asp:TextBox ID="txtTanggal1" runat="server" ReadOnly="false"></asp:TextBox>
                        <asp:Calendar ID="calDateTime1" runat="server" OnSelectionChanged="calDateTime1_SelectionChanged"></asp:Calendar>
                        </td>
                    <td>
                         <asp:Label ID="Label5" runat="server" Text=" Sampai :" CssClass="newStyle1"></asp:Label>
                        </td>
                    <td>
                        <asp:TextBox ID="txtTanggal2" runat="server" ReadOnly="false"></asp:TextBox>
                        <asp:Calendar ID="calDateTime2" runat="server" OnSelectionChanged="calDateTime2_SelectionChanged"></asp:Calendar>
                        </td>
                    <td>
                        <asp:Button ID="BtnSearchTanggal" runat="server" Text="Search" CssClass="newStyle2" OnClick="BtnSearchTanggal_Click" />
                        </td>
                    </tr>
                </table>
            </div>

        <asp:GridView ID="grid2" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="grid2_SelectedIndexChanged" Width="833px" >  
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
        <br/>
     <asp:Button ID="Btn_Reset" runat="server" OnClick="btnResetData" Text="ResetData" CssClass="newStyle2" style="height: 25px"/>

    </form>
    <p>
        &nbsp;</p>
    <p>
        
        &nbsp;</p>
</body>
</html>

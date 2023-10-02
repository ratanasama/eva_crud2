using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebApp
{
    public partial class Employee_DataGrid : System.Web.UI.Page
    {
        SqlConnection conn;
        public string nama_karyawan = "", usia_karyawan = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            string connection = @"Data Source=DESKTOP-FU2SNPG;Initial Catalog=db_hris;Integrated Security=True";
            conn = new SqlConnection(connection);
            DisplayRecord();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Response.Redirect("Employee.aspx");
        }

        ///
        public DataTable DisplayRecord()
        {
            conn.Open();
            //SqlDataAdapter Adp = new SqlDataAdapter("select * from TblEmployee", conn);
            SqlDataAdapter Adp = new SqlDataAdapter("select * from Tbl_EMPLOYEE_EVA", conn);
            DataTable Dt = new DataTable();
            Adp.Fill(Dt);
            grid2.DataSource = Dt;
            grid2.DataBind();
            conn.Close();
            return Dt;

        }

        void DisplayRecord_Nama()
        {
            conn.Open();
            //SqlDataAdapter Adp = new SqlDataAdapter("select * from TblEmployee", conn);
            SqlDataAdapter Adp = new SqlDataAdapter("select * from Tbl_EMPLOYEE_EVA where NmKaryawan like '%" + nama_karyawan  + "%'", conn);
            DataTable Dt = new DataTable();
            Adp.Fill(Dt);
            grid2.DataSource = Dt;
            grid2.DataBind();
            conn.Close();
           
        }

        void DisplayRecord_Usia()
        {
            conn.Open();
            //SqlDataAdapter Adp = new SqlDataAdapter("select * from TblEmployee", conn);
            SqlDataAdapter Adp = new SqlDataAdapter("select * from Tbl_EMPLOYEE_EVA where Usia like '%" + usia_karyawan + "%'", conn);
            DataTable Dt = new DataTable();
            Adp.Fill(Dt);
            grid2.DataSource = Dt;
            grid2.DataBind();
            conn.Close();

        }

        void DisplayRecord_Tanggal()
        {
            conn.Open();
            //SqlDataAdapter Adp = new SqlDataAdapter("select * from TblEmployee", conn);
            //SqlDataAdapter Adp = new SqlDataAdapter("select * from Tbl_EMPLOYEE_EVA where TglMasukKerja between '" + DateTime.Parse(txtTanggal1.Text) + "' AND '" + DateTime.Parse(txtTanggal2.Text) + "'", conn);
            SqlDataAdapter Adp = new SqlDataAdapter("select * from Tbl_EMPLOYEE_EVA where TglMasukKerja between '" + txtTanggal1.Text + "' AND '" + txtTanggal1.Text + "'", conn);

            DataTable Dt = new DataTable();
            Adp.Fill(Dt);
            grid2.DataSource = Dt;
            grid2.DataBind();
            conn.Close();
        }


        protected void grid2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BtnSearchKaryawan_Click(object sender, EventArgs e)
        {
            nama_karyawan = txtNamaKaryawan.Text;
            DisplayRecord_Nama();
        }

        protected void btnResetData(object sender, EventArgs e)
        {
            DisplayRecord();
            txtNamaKaryawan.Text = "";
            txtUsiaKaryawan.Text = "";
        }

        protected void calDateTime1_SelectionChanged(object sender, EventArgs e)
        {
            txtTanggal1.Text = calDateTime1.SelectedDate.ToString("dd/MM/yyyy HH:mm:ss");
        }

        protected void calDateTime2_SelectionChanged(object sender, EventArgs e)
        {
            txtTanggal2.Text = calDateTime2.SelectedDate.ToString("dd/MM/yyyy HH:mm:ss");
        }

        protected void BtnSearchTanggal_Click(object sender, EventArgs e)
        {

            DisplayRecord_Tanggal();
        }

        protected void BtnSearchUsia_Click(object sender, EventArgs e)
        {
            usia_karyawan = txtUsiaKaryawan.Text;
            DisplayRecord_Usia();
        }
    }
}
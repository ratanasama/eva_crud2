using System;
using System.Data;
using System.Data.SqlClient;

namespace WebApp
{
    public partial class Employee : System.Web.UI.Page
    {
        SqlConnection conn;
        public int Id;
        protected void Page_Load(object sender, EventArgs e)
        {
            //string connection = @"Data Source=DESKTOP-0TD75N5\SQLEXPRESS;Initial Catalog=TestDB;User=sa;password=sa12345";
            string connection = @"Data Source=DESKTOP-FU2SNPG;Initial Catalog=db_hris;Integrated Security=True";
            conn = new SqlConnection(connection);
            p_initDdl();
            DisplayRecord();
        }
        private void p_initDdl()
        {
            ddlMonth.Items.Clear();
            ddlDay.Items.Clear();
            ddlYear.Items.Clear();

            for (int i = 0; i < 31; i++)
            {
                ddlDay.Items.Add((i + 1).ToString());
            }

            ddlMonth.Items.Add("January");
            ddlMonth.Items.Add("February");
            ddlMonth.Items.Add("March");
            ddlMonth.Items.Add("April");
            ddlMonth.Items.Add("May");
            ddlMonth.Items.Add("June");
            ddlMonth.Items.Add("July");
            ddlMonth.Items.Add("Augusts");
            ddlMonth.Items.Add("September");
            ddlMonth.Items.Add("October");
            ddlMonth.Items.Add("November");
            ddlMonth.Items.Add("December");           

            for (int i = 1944; i < 2099; i++)
            {
                ddlYear.Items.Add((i + 1).ToString());
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            p_SaveOrUpdate_BARU();
            DisplayRecord();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            p_UpdateData();
            DisplayRecord();

            //string dateBirth = ddlYear.Text + "-" + (ddlMonth.SelectedIndex + 1).ToString() + "-" + ddlDay.Text;
            //string dateBirth = ddlYear.Text.ToString();
            //lblMessage.Text = dateBirth;

        }
        private void p_ClearData()
        {
            
            txtNama.Text = string.Empty;
            txtID.Text = string.Empty;
            txtUsia.Text = string.Empty;
            ddlDay.SelectedIndex = 0;
            ddlMonth.SelectedIndex = 0;
            ddlYear.SelectedIndex = 0;
            //rdLaki.Checked = false;
            //rdPerempuan.Checked = false;
            lblUpdate.Text = string.Empty;
        }
        public DataTable DisplayRecord()
        {
            conn.Open();
            //SqlDataAdapter Adp = new SqlDataAdapter("select * from TblEmployee", conn);
            SqlDataAdapter Adp = new SqlDataAdapter("select * from Tbl_EMPLOYEE_EVA", conn);
            DataTable Dt = new DataTable();
            Adp.Fill(Dt);
            grid1.DataSource = Dt;
            grid1.DataBind();
            conn.Close();
            return Dt;
            
        }

        private void p_UpdateData()
        {
            try
            {              
                if (txtID.Text == string.Empty ||
                    txtUsia.Text == string.Empty ||
                    txtNama.Text == string.Empty ||
                    txtUsia.Text == string.Empty)
                {
                    lblMessage.Text = "harap isi semua Data";
                    return;
                }
                //if (rdLaki.Checked == false && rdPerempuan.Checked == false)
                //{
                //    lblMessage.Text = "harap pilih Jenis Kelamin";
                //    return;
                //}

                conn.Open();
                //string dateBirth = ddlYear.Text + "-" + (ddlMonth.SelectedIndex + 1).ToString() + "-" + ddlDay.Text;
                string dateBirth = txtDateTime.Text;
                Id = int.Parse(lblID.Text);             

                SqlCommand cmd = new SqlCommand(@"update Tbl_EMPLOYEE_EVA set NmKaryawan='" + txtNama.Text +  "', Usia='" +
                       txtUsia.Text + "' where IDKaryawan ='" + Id+ "'", conn);

                //SqlCommand cmd = new SqlCommand(@"update tb_employeeTaf set nama='" + txtNama.Text + "', nik ='" + txtNIK.Text + "', posisi='" +
                //       txtPosisi.Text + "', divisi ='" + txtDivisi.Text + "', jenis_kelamin ='" + type + "'", conn);


                cmd.ExecuteNonQuery();
                lblMessage.Text = "Success edit Data";


                conn.Close();
                p_ClearData();
            }
            
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
        

        private void p_SaveOrUpdate_BARU()
        {
            try
            {
                //int IDEmployee = 0;
                //if (lblID.Text != string.Empty)
                //{
                //    IDEmployee = int.Parse(lblID.Text);
                //}

                if (txtID.Text == string.Empty ||                   
                    txtNama.Text == string.Empty ||
                    txtUsia.Text == string.Empty)
                {
                    lblMessage.Text = "harap isi semua Data";
                    return;
                }
               

                conn.Open();
                //string dateBirth = ddlYear.Text + "-" + (ddlMonth.SelectedIndex + 1).ToString() + "-" + ddlDay.Text;
                string dateBirth = txtDateTime.Text;
                //string type;
                
                //SqlCommand cmd = new SqlCommand("CreateOrEditTblEmployee", conn);
                SqlCommand cmd = new SqlCommand(@"insert into Tbl_EMPLOYEE_EVA (IDKaryawan, NmKaryawan, TglMasukKerja, Usia) 
                values (@IDKaryawan, @NmKaryawan, @TglMasukKerja, @Usia)", conn);
                //cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@IDKaryawan", txtID.Text);
                cmd.Parameters.AddWithValue("@NmKaryawan", txtNama.Text);
                cmd.Parameters.AddWithValue("@TglMasukKerja", dateBirth);
                cmd.Parameters.AddWithValue("@Usia", txtUsia.Text);
               
                cmd.ExecuteNonQuery();
                lblMessage.Text = "Success save Data";


                conn.Close();
                p_ClearData();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }

        }

        protected void btnDelete_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            conn.Open();
            int Id = Int32.Parse(e.CommandArgument.ToString());
            string query = "delete from Tbl_EMPLOYEE_EVA where IDKaryawan='" + Id+"'";
            SqlCommand command = new SqlCommand(query, conn);
            command.ExecuteNonQuery();
            conn.Close();
            lblMessage.Text = "Sukses Hapus Data";
            DisplayRecord();
        }

        protected void btnEdit_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            conn.Open();
            Id = Int32.Parse(e.CommandArgument.ToString());
            lblUpdate.Text = "Update";
            lblID.Text = Id.ToString();
            SqlDataAdapter Adp = new SqlDataAdapter("select * from Tbl_EMPLOYEE_EVA where IDKaryawan='" + Id +"'", conn);
            DataTable dt = new DataTable();
            Adp.Fill(dt);

            //txtID.Text = dt.Rows[0]["NIK"].ToString();
            //txtNama.Text = dt.Rows[0]["Nama"].ToString();
            //DateTime dtm = DateTime.Parse(dt.Rows[0]["Tanggal Masuk Kerja"].ToString());
            //txtUsia.Text = dt.Rows[0]["Usia"].ToString();
            //txtDateTime.Text = dtm.ToString();

            txtID.Text = dt.Rows[0][0].ToString();
            txtNama.Text = dt.Rows[0][1].ToString();
            DateTime dtm = DateTime.Parse(dt.Rows[0][2].ToString());
            txtUsia.Text = dt.Rows[0][3].ToString();
            txtDateTime.Text = dtm.ToString();

            conn.Close();
        }

        protected void rdLaki_CheckedChanged(object sender, EventArgs e)
        {
            //rdPerempuan.Checked = false;
        }

        protected void rdPerempuan_CheckedChanged(object sender, EventArgs e)
        {
            //rdLaki.Checked = false;
        }

        protected void grid1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        protected void calDateTime_SelectionChanged(object sender, EventArgs e)
        {
            //txtDateTime.Text = calDateTime.SelectedDate.ToString("yyyy-MM-dd HH:mm:ss");
            txtDateTime.Text = calDateTime.SelectedDate.ToString("yyyy-MM-dd");
            //txtDateTime.Text = calDateTime.SelectedDate.ToString("dd/MM/yyyy HH:mm:ss");
            //txtDateTime.Text = calDateTime.SelectedDate.ToString("dd/MM/yyyy");
        }

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedText = ddlYear.Text;
            txtDateTime.Text = selectedText;
        }
    }
}
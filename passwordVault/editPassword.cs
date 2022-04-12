using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace passwordVault
{
    public partial class editPassword : Form
    {
        public string path = "deneme.db";
        public string cs = @"URI=file:"+Application.StartupPath+"\\deneme.db";

        public SQLiteConnection conn;
        public SQLiteCommand cmd;
        public SQLiteDataReader dr;
        Class1 class1 = new Class1();
        Class2 class2 = new Class2();

        public editPassword()
        {
            InitializeComponent();
            data_show();
            textBox5.Visible = false;
        }

        private void data_show()
        {
           


            Class1 class1 = new Class1();
            var con = new SQLiteConnection(cs);
            con.Open();
            string pass = textBox1.Text;
            class1.Encrypt  = pass;
            pass =   class1.Encrypt;

            string stm = "select * FROM passwords" ;
            var cmd = new SQLiteCommand(stm, con);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                dataGridView1.Rows.Insert(0, dr.GetValue(0).ToString(), dr.GetValue(1).ToString(), dr.GetValue(2).ToString(), dr.GetValue(3).ToString());



            }

            con.Close();

            this.dataGridView1.AllowUserToAddRows = false;


            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.ReadOnly = true;

            dataGridView1.Columns[0].Visible = false;



        }



        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow dataGridViewRow = dataGridView1.Rows[e.RowIndex];

             
                textBox2.Text = dataGridViewRow.Cells["Info"].Value.ToString();
                textBox3.Text = dataGridViewRow.Cells["UserName"].Value.ToString();
                textBox4.Text = dataGridViewRow.Cells["PassWord"].Value.ToString();
                textBox5.Text = dataGridViewRow.Cells["id"].Value.ToString();



            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            degistir();
            dataGridView1.Rows.Clear();
            data_show();


        }

        public void degistir()
        {
            String id = textBox5.Text;
            String password = textBox4.Text;
            class1.Encrypt  = password;
            password =   class1.Encrypt;

            var con = new SQLiteConnection(cs);
            con.Open();
            var cmd = new SQLiteCommand(con);
            string sql = "UPDATE passwords set password='"+password+"'  where id ="+id;

            cmd.CommandText = sql;
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Ok.");

        }


    }
}

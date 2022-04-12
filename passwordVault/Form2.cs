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
    public partial class Form2 : Form
    {
        public string path = "deneme.db";
        public string cs = @"URI=file:"+Application.StartupPath+"\\deneme.db";

        public SQLiteConnection conn;
        public SQLiteCommand cmd;
        public SQLiteDataReader dr;
        Class1 class1 = new Class1();
        Class2 class2 = new Class2();

        public Form2()
        {
            InitializeComponent();

            comboBox2.Visible = false;
            listele();


        }


        private void listele()
        {
            
            Class1 class1 = new Class1();
            var con = new SQLiteConnection(cs);
            con.Open();
            string pass = textBox1.Text;
            class1.Encrypt  = pass;
            pass =   class1.Encrypt;

            string stm = "select * FROM passwords ";
            var cmd = new SQLiteCommand(stm, con);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                
                comboBox1.Items.Add(dr.GetString(1));
                string id = dr.GetInt32(0).ToString();
                comboBox2.Items.Add(id);
            }

            con.Close();

      


        }

        private void listele2()
        {
            int index = comboBox1.SelectedIndex;


            string id = comboBox2.Items[index].ToString();



            Class1 class1 = new Class1();
            var con = new SQLiteConnection(cs);
            con.Open();
            string pass = textBox1.Text;
            class1.Encrypt  = pass;
            pass =   class1.Encrypt;

            string stm = "select * FROM passwords where id ="+id;
            var cmd = new SQLiteCommand(stm, con);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                textBox1.Text = dr.GetString(1);
                textBox2.Text = dr.GetString(2);
                textBox3.Text = dr.GetString(3);
            }

            con.Close();




        }

        private void chanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainPass mainPass = new mainPass();
            mainPass.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newPassword newPassword = new newPassword();
            newPassword.Show(); 
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editPassword editPassword = new editPassword();
            editPassword.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listele2();


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                String password = textBox3.Text;
                class2.Decrypt = password;
                password  = class2.Decrypt;
                textBox3.Text=password;
            }
            catch (Exception ex)
            { 
            
            
            
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

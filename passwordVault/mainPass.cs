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
    public partial class mainPass : Form
    {
        public string path = "deneme.db";
        public string cs = @"URI=file:"+Application.StartupPath+"\\deneme.db";

        public SQLiteConnection conn;
        public SQLiteCommand cmd;
        public SQLiteDataReader dr;

        public string donenServer;
        public string donenUsername;
        public string donenPassword;
        public string donenDatabase;
        public static String connectionString = "";
        Class1 class1 = new Class1();
        Class2 class2 = new Class2();

        public mainPass()
        {
            InitializeComponent();
            label1.Text ="Old";
            label2.Text ="New";
            label3.Text ="re-New";
            textBox1.PasswordChar = '*';
            textBox2.PasswordChar = '*';
            textBox3.PasswordChar = '*';
            button1.Text ="Change";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String kontrol11 = kontrol1();
            String kontrol22 = kontrol2();

            if (kontrol11=="1")
            {

                if (kontrol22=="1")
                {

                    degistir();
                    textBox1.Text ="";
                    textBox2.Text ="";
                    textBox3.Text ="";
                    MessageBox.Show("Password Was Changed");

                }
                else
                {
                    MessageBox.Show("New Passwords are not same");
                }



            }
            else 
            {
                MessageBox.Show("Wrong Password");
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void degistir()
        {

            String password = textBox3.Text;
            class1.Encrypt  = password;
            password =   class1.Encrypt;

            var con = new SQLiteConnection(cs);
            con.Open();
            var cmd = new SQLiteCommand(con);
            string sql = "UPDATE baglan set password='"+password+"'  where id = 1";

            cmd.CommandText = sql;
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Ok.");

        }
        public string kontrol1()
        {
            string donus = "0";

         
            Class1 class1 = new Class1();
            var con = new SQLiteConnection(cs);
            con.Open();
            string pass = textBox1.Text;
            class1.Encrypt  = pass;
            pass =   class1.Encrypt;

            string stm = "select * FROM baglan where password LIKE '"+pass+"'";
            var cmd = new SQLiteCommand(stm, con);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                donus = "1";
                //  dataGridView1.Rows.Insert(0, dr.GetValue(1).ToString());
                // public static String connectionString = "server=localhost;username=root;password=;database=follow


                // class2.Decrypt = textBox2.Text;
                //  textBox3.Text = class2.Decrypt;
            }

            con.Close();

          
            return donus;

        
        }

        public string kontrol2()
        {
            string donus = "0";
            string new1 = textBox2.Text;
            string new2 = textBox3.Text;

            if (new1==new2)
            {
                donus = "1";
            }

            return donus;


        }


    }
}

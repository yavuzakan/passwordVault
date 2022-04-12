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
    public partial class Form1 : Form
    {
        public string path = "deneme.db";
        public string cs = @"URI=file:"+Application.StartupPath+"\\deneme.db";

        public SQLiteConnection conn;
        public SQLiteCommand cmd;
        public SQLiteDataReader dr;
        Class1 class1 = new Class1();

        public Form1()
        {
            InitializeComponent();
            textBox1.PasswordChar ='*';
            Create_db();
        }

        private void button1_Click(object sender, EventArgs e)
        {
         String gir = giris();



            if (gir =="1")
            {

                this.Hide();

                Form2 form2 = new Form2();
                form2.ShowDialog();
                this.Close();
            }
            else 
            {

                MessageBox.Show("Wrong Password");
            }









        }

        private void Create_db()
        {
            if (!System.IO.File.Exists(path))
            {
                SQLiteConnection.CreateFile(path);
                using (var sqlite = new SQLiteConnection(@"Data Source="+ path))
                {
                    sqlite.Open();
                    string sql = "CREATE TABLE baglan (id INTEGER, password TEXT,  user TEXT,   PRIMARY KEY(id AUTOINCREMENT))";
                    SQLiteCommand command = new SQLiteCommand(sql, sqlite);

                    command.ExecuteNonQuery();
                    string sql2 = "CREATE TABLE passwords (id INTEGER, info TEXT , username TEXT, password TEXT,  PRIMARY KEY(id AUTOINCREMENT))";
                     command = new SQLiteCommand(sql2, sqlite);

                    command.ExecuteNonQuery();


                    add();

                }

            }



        }

        private string giris()
        {
            string cevap = "0";
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

                cevap = "1";
                //  dataGridView1.Rows.Insert(0, dr.GetValue(1).ToString());
                // public static String connectionString = "server=localhost;username=root;password=;database=follow


                // class2.Decrypt = textBox2.Text;
                //  textBox3.Text = class2.Decrypt;
            }

            con.Close();

            return cevap;


        }






        public void add()
        {
            var con = new SQLiteConnection(cs);
            con.Open();
            var cmd = new SQLiteCommand(con);

            


            //"server=localhost;username=root;password=;database=follow";

            cmd.CommandText = "INSERT INTO baglan(password) VALUES(@password)";
            string password = "admin";
            class1.Encrypt  = password;
            password =   class1.Encrypt;

            cmd.Parameters.AddWithValue("@password", password);

            cmd.ExecuteNonQuery();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }
        public void degistir()
        {

            String password = "admin";
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                try
                {

                    String gir = giris();



                    if (gir =="1")
                    {

                        this.Hide();

                        Form2 form2 = new Form2();
                        form2.ShowDialog();
                        this.Close();
                    }
                    else
                    {

                        MessageBox.Show("Wrong Password");
                    }

                }
                catch (Exception)
                {


                }

            }


        }
    }
    }

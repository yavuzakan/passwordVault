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

    public partial class newPassword : Form
    {
        public string path = "deneme.db";
        public string cs = @"URI=file:"+Application.StartupPath+"\\deneme.db";

        public SQLiteConnection conn;
        public SQLiteCommand cmd;
        public SQLiteDataReader dr;
        Class1 class1 = new Class1();

        String button1name = "Show";
        public newPassword()
        {
            InitializeComponent();
            textBox3.PasswordChar ='*';
            label1.Text = "Info - Site";
            label2.Text = "User Name";
            label3.Text = "Password";



        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1name =="Show")
            {
                textBox3.PasswordChar ='\0';
                button1name = "Hide";
                

            }
            else 
            {
                textBox3.PasswordChar ='*';
                button1name = "Show";
            }

            button1.Text = button1name;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            String donus = kontorl();
            if (donus == "1")
            {
                add();
                temizle();
                mesaj("Ok.");
            }
            else {
                mesaj("at least 6 characters");
            }

        }

        public void add()
        {
            var con = new SQLiteConnection(cs);
            con.Open();
            var cmd = new SQLiteCommand(con);




            //"server=localhost;username=root;password=;database=follow";
            //string sql2 = "CREATE TABLE passwords (id INTEGER, info TEXT , username TEXT, password TEXT,  PRIMARY KEY(id AUTOINCREMENT))";
            cmd.CommandText = "INSERT INTO passwords(info,username,password) VALUES(@info,@username,@password)";
            string info = textBox1.Text;
            string username = textBox2.Text;
            string password = textBox3.Text;
            class1.Encrypt  = password;
            password =   class1.Encrypt;
            cmd.Parameters.AddWithValue("@info", info);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            cmd.ExecuteNonQuery();


        }
        public void temizle()
        {
            textBox1.Text ="";
            textBox2.Text ="";
            textBox3.Text ="";

        }
        public string kontorl()
        {
            String donus = "1";
            int t1 = textBox1.Text.Length;
            int t2 = textBox2.Text.Length;
            int t3 = textBox3.Text.Length;
            if (t1<6 || t2<6 || t3<6)
            {
                donus="0";
            }

            return donus;

        }
        public void mesaj(String gelen)
        {
            MessageBox.Show(gelen);
        
        }

    }
}

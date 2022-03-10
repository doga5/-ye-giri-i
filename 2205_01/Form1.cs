using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2205_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Server=mssql04.turhost.com;Database=Northwind;User Id=Yazilim24;Password=6B!s7z6v";
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Yazilim24.Members where username = @name";
            cmd.Parameters.AddWithValue("name", textBox1.Text);
            cmd.Connection = cn;

            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                if(dr["password"].ToString() == textBox2.Text)
                {
                    this.Hide();
                    Naber n = new Naber();
                    n.userID = (int)dr["id"];           
                    n.Show();
                }
                else
                {
                    MessageBox.Show("Hatalı şifre");
                }
            }
            else
            {
                MessageBox.Show("Böyle bir üye yok");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == textBox5.Text)
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = "Server=mssql04.turhost.com;Database=Northwind;User Id=Yazilim24;Password=6B!s7z6v";
                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO Yazilim24.Members VALUES(@name,@pass,@status)";
                cmd.Parameters.AddWithValue("name", textBox3.Text);
                cmd.Parameters.AddWithValue("pass", textBox4.Text);
                cmd.Parameters.AddWithValue("status", 1);
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Üyeliğiniz başarıyla oluşturuldu");
            }
            else
            {
                MessageBox.Show("Lütfen şifre ve şifre onayı kısmı aynı olsun");
            }
        }
    }
}

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
    public partial class Naber : Form
    {
        public Naber()
        {
            InitializeComponent();
        }
        public int userID;
        private void Naber_Load(object sender, EventArgs e)
        {
            timer1.Interval = 2000;
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Server=mssql04.turhost.com;Database=Northwind;User Id=Yazilim24;Password=6B!s7z6v";
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Yazilim24.Messages VALUES(@metin,@memberId,GETDATE())";
            cmd.Parameters.AddWithValue("metin", textBox1.Text);
            cmd.Parameters.AddWithValue("memberId", userID);
            cmd.Connection = cn;
            cmd.ExecuteNonQuery();
            textBox1.Text = "";
            textBox1.Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Server=mssql04.turhost.com;Database=Northwind;User Id=Yazilim24;Password=6B!s7z6v";
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select TOP 100 * from Yazilim24.Messages mes INNER JOIN Yazilim24.Members mem ON mes.memberID = mem.id order by tarih DESC";
            cmd.Connection = cn;

            SqlDataReader dr = cmd.ExecuteReader();
            panel1.Controls.Clear();
            for (int i=0; dr.Read();i++)
            {
                Label lbl = new Label();
                lbl.Width = 250;
                lbl.Height = 50;
                lbl.Top = i * 60;
                lbl.Text = dr["username"] + ": " + dr["metin"].ToString();
                lbl.BackColor = Color.LightBlue;
                if(dr["memberId"].ToString() == userID.ToString())
                {
                    lbl.Left += 500;
                    lbl.BackColor = Color.Tomato;
                }
                panel1.Controls.Add(lbl);
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data. OleDb;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelefonBok
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {

            //Ger programmet tillgånt till data basen
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = "Provider = Microsoft.ace.oledb.12.0; Data Source = TelefonBok.accdb";
            conn.Open();

            //Lägger till data till data bassen från textboxerna
            OleDbCommand comm = new OleDbCommand();
            comm.CommandText = "insert into Tabell1(Name, Tel, Gmail, Klass) values('" + nameTB.Text + "', '" + pnTB.Text + "', '" + GmailTB.Text + "', '" + KlassTB.Text + "')";
            comm.Connection = conn;
            comm.ExecuteNonQuery();
            conn.Close();

            //Tar bort texten från textboxen efter det har lagits till i data basen
            nameTB.Text = "";
            pnTB.Text = "";
            KlassTB.Text = "";
            GmailTB.Text = "";

            //Medelar att data överförningen lyckades
            MessageBox.Show("Data was sucsefully added");
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //Ger programmet tillgånt till data basen
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = "Provider = Microsoft.ace.oledb.12.0; Data Source = TelefonBok.accdb";
            conn.Open();

            //Tar bort data från databasen där namnet är samma som textboxen
            OleDbCommand comm = new OleDbCommand();
            comm.CommandText = "delete from Tabell1 where Name = '" + nameTB.Text + "'";
            comm.Connection = conn;
            comm.ExecuteNonQuery();
            conn.Close();

            //Tar bort texten från textboxen efter det har lagits till i data basen
            nameTB.Text = "";
            pnTB.Text = "";
            KlassTB.Text = "";
            GmailTB.Text = "";

            //Medelar att data bortagningen lyckades
            MessageBox.Show("Data was sucsefully removed");
        }

        private void button3_Click(object sender, EventArgs e)
        {

            //Ger programmet tillgånt till data basen
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = "Provider = Microsoft.ace.oledb.12.0; Data Source = TelefonBok.accdb";
            conn.Open();


            //Visar datan i ett data grid
            OleDbCommand comm = new OleDbCommand();
            comm.CommandText = "Select * from Tabell1";
            comm.Connection = conn;
            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = comm;

            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;

            conn.Close();
        }
    }
}

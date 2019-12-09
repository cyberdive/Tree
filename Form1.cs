using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace tree
{
    public partial class Form1 : Form
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        public Form1()
        {
            InitializeComponent();
            treeView1.Nodes.Add("noeud");
            server = "";
            database = "";
            uid = "";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";CharSet=utf8;";

            connection = new MySqlConnection(connectionString);
            OpenConnection();
        }
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                //When handling errors, you can your application's response based on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.

                return false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        treeView1.SelectedNode.Nodes.Add("noeud enfant");
            getAllFiles();
        }
  

public string getAllFiles()
{

    string query, status = "";
    query = "select * from Files order by `filename` ASC" + "" + ";";
    if (OpenConnection() == true)
    {
        MySqlCommand cmd = new MySqlCommand(query, connection);
        //Create a data reader and Execute the command
        MySqlDataReader dataReader = cmd.ExecuteReader();
        while (dataReader.Read())
        {
            status = (dataReader[1] + "");
        }

    }
    CloseConnection();
    return status;
}
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}

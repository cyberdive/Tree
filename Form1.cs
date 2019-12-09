using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tree
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            treeView1.Nodes.Add("noeud");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            treeView1.SelectedNode.Nodes.Add("noeud enfant");
        }
    }
}

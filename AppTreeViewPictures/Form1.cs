using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppTreeViewPictures
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private TreeNode CrearArbol(DirectoryInfo directoryInfo)
        {
            TreeNode treeNode = new TreeNode(directoryInfo.Name);
            
            foreach (var item in directoryInfo.GetDirectories())
            {
                treeNode.Nodes.Add(CrearArbol(item));
            }

            foreach (var item in directoryInfo.GetFiles())
            {
                treeNode.Nodes.Add(new TreeNode(item.Name));
            }

            return treeNode;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string rutaBase = "C:\\Users\\Angela\\Downloads\\Carpeta";

            tvFile.Nodes.Clear();
            DirectoryInfo directoryInfo = new DirectoryInfo(rutaBase);
            tvFile.Nodes.Add(CrearArbol(directoryInfo));
        }
    }
}

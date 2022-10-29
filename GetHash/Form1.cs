using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetHash
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string Hash(string path)
        {
            if (!File.Exists(path))
            {
                return "0";
            }
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(path))
                {
                    return Convert.ToBase64String(md5.ComputeHash(stream));
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                textBox1.Text = Hash(openFileDialog.FileName);
            }
        }
    }
}

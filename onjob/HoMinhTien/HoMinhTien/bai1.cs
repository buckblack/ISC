using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoMinhTien
{
    public partial class bai1 : Form
    {
        public bai1()
        {
            InitializeComponent();
        }
        thu_vien tv = new thu_vien();
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tổng là: "+tv.tong_chu_so(int.Parse(textBox1.Text)).ToString());
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}

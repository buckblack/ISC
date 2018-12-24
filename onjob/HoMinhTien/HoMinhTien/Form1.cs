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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        thu_vien tv = new thu_vien();
        private void button1_Click(object sender, EventArgs e)
        {
            bai1 b1 = new bai1();
            b1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(tv.tim_5_so());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int[] a = new int[] { 2, 5, 9, 6, 1, 3, 10, 54 };
            MessageBox.Show(tv.hai_so_lon_nhat(a));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int[] a = new int[] { 2, 5, 9, 6, 1, 3, 10, 54 };
            MessageBox.Show(tv.dem_chan_le(a));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int[] a = new int[] { 2, 5, 9, 6, 1, 3, 10, 54 };
            MessageBox.Show("Trước khi hoán đổi: "+tv.xuat_mang(a));
            tv.hoan_doi(a);
            MessageBox.Show("Sau khi hoán đổi: "+tv.xuat_mang(a));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int[] a = new int[] { 2, 5, 9, 6, 1, 3, 15, 54 };
            string[] s=tv.chuyen_doi_mang_so_nguyen(a);
            MessageBox.Show("Trước khi hoán đổi: " + tv.xuat_mang(s));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int[] a = new int[] { 2, 5, 9, 6, 1, 3, 15, 54 };
            int[] b = new int[] { 2, 5, 9, 6, 1, 3, 15, 54 };
            int kq = tv.so_sanh_hai_mang(a,b);
            if(kq==1)
                MessageBox.Show("Hai mảng trùng nhau");
            else
                MessageBox.Show("Hai mảng khác nhau");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int[] a = new int[] { 2, 5, 9, 6, 1, 3, 15, 54 };
            int[] b = new int[] { 2, 5, 9, 6, 1, 3, 15, 53 };
            int kq = tv.so_sanh_hai_mang(a, b);
            if (kq == 1)
                MessageBox.Show("Hai mảng trùng nhau");
            else
                MessageBox.Show("Hai mảng khác nhau");
        }
    }
}

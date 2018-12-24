using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoMinhTien
{
    public class thu_vien
    {
        //câu1
        public int tong_chu_so(int x)
        {
            if (x < 0)
                return -1;
            else
            {
                int tong = 0;
                while (x != 0)
                {
                    tong += x % 10;
                    x /= 10;
                }
                return tong;
            }
        }

        //câu 2
        public string tim_5_so()
        {
            string kq = "5 số thỏa điều kiện là: ";
            int dem=0;
            for (int i = 5; ; i++)
            {
                if (i % 5 == 4 && i % 4 == 3 && i % 3 == 2)
                {
                    dem++;
                    kq += i.ToString()+"    ";
                }
                if (dem == 5)
                    break;
            }
            return kq;
        }

        //câu 3
        public string hai_so_lon_nhat(int[] a)
        {
            //int[] tmp = a;
            List<int> tmp = a.ToList<int>();
            string kq = "Hai số lớn nhất là: "+tmp.Max();
            tmp.Remove(tmp.Max());
            kq += "    " + tmp.Max();
            return kq;

        }

        //câu 4

        public string dem_chan_le(int[] a)
        {
            int dem_chan = 0, dem_le = 0;
            for (int i = 0; i < a.Length - 1;i++ )
            {
                if (a[i] % 2 == 0)
                    dem_chan++;
                dem_le++;
            }
            return "Phần tử chẵn: "+dem_chan.ToString()+"\nPhần tử lẻ: "+dem_le.ToString();
        }

        //câu 5
        public string xuat_mang(int[] a)
        {
            string kq = "";
            for (int i = 0; i < a.Length; i++)
            {
                kq += a[i]+"   ";
            }
            return kq;
        }

        public void hoan_doi(int[] a)
        {
            for (int i = 0; i < a.Length-1; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[i] == a.Min() && a[j] == a.Max())
                    {
                        int tmp = a[i];
                        a[i] = a[j];
                        a[j] = tmp;
                    }
                }
            }
        }

        //câu 6: lý thuyết

        // câu 7
        public string xuat_mang(string[] a)
        {
            string kq = "";
            for (int i = 0; i < a.Length; i++)
            {
                kq += a[i] + "   ";
            }
            return kq;
        }

        public string[] chuyen_doi_mang_so_nguyen(int[] a)
        {
            List<string> s=new List<string>();
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] % 3 == 0 && a[i] % 5 == 0)
                    s.Add("a@b");
                else if (a[i] % 3 == 0)
                    s.Add("a");
                else if (a[i] % 5 == 0)
                    s.Add("b");
                else
                    s.Add(" ");
            }
            return s.ToArray();
        }

        //câu 8
        public int so_sanh_hai_mang(int[] a, int[] b)
        {
            //1:trùng   0: không trùng
            if (a.Length != b.Length)
                return 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                    return 0;
            }
            return 1;
        }
    }
}

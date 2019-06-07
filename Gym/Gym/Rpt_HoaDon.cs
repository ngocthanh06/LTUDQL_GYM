using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using BLLayer;
using System.Data;

namespace Gym
{
    public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport
    {
       
        HoaDon_BLL HD = new HoaDon_BLL();

        //Chuyển dữ liệu số sang chữ
        public string ChuyenSo(string number)
        {
            string[] dv = { "", "Mươi", "Trăm", "Nghìn", "Triệu", "Tỉ" };
            string[] cs = { "Không", "Một", "Hai", "Ba", "Bốn", "Năm", "Sáu", "Bảy", "Tám", "Chín" };
            string doc;
            int i, j, k, n, len, found, ddv, rd;
            len = number.Length;
            number += "ss";
            doc = "";
            found = 0;
            ddv = 0;
            rd = 0;
            i = 0;
            while (i < len)
            {
                //So chu so o hang dang duyet
                n = (len - i + 2) % 3 + 1;
                //Kiem tra so 0
                found = 0;
                for (j = 0; j < n; j++)
                {
                    if (number[i + j] != '0')
                    {
                        found = 1;
                        break;
                    }
                }
                //Duyet n chu so
                if (found == 1)
                {
                    rd = 1;
                    for (j = 0; j < n; j++)
                    {
                        ddv = 1;
                        switch (number[i + j])
                        {
                            case '0':
                                if (n - j == 3) doc += cs[0] + " ";
                                if (n - j == 2)
                                {
                                    if (number[i + j + 1] != '0') doc += "Lẻ ";
                                    ddv = 0;
                                }
                                break;
                            case '1':
                                if (n - j == 3) doc += cs[1] + " ";
                                if (n - j == 2)
                                {
                                    doc += "Mười ";
                                    ddv = 0;
                                }
                                if (n - j == 1)
                                {
                                    if (i + j == 0) k = 0;
                                    else k = i + j - 1;

                                    if (number[k] != '1' && number[k] != '0')
                                        doc += "Mốt ";
                                    else
                                        doc += cs[1] + " ";
                                }
                                break;
                            case '5':
                                if (i + j == len - 1)
                                    doc += "Lăm ";
                                else
                                    doc += cs[5] + " ";
                                break;
                            default:
                                doc += cs[(int)number[i + j] - 48] + " ";
                                break;
                        }
                        //Doc don vi nho
                        if (ddv == 1)
                        {
                            doc += dv[n - j - 1] + " ";
                        }
                    }
                }
                //Doc don vi lon
                if (len - i - n > 0)
                {
                    if ((len - i - n) % 9 == 0)
                    {
                        if (rd == 1)
                            for (k = 0; k < (len - i - n) / 9; k++)
                                doc += "Tỉ ";
                        rd = 0;
                    }
                    else
                        if (found != 0) doc += dv[((len - i - n + 1) % 9) / 3 + 2] + " ";
                }
                i += n;
            }
            if (len == 1)
                if (number[0] == '0' || number[0] == '5') return cs[(int)number[0] - 48];
            return doc + " Đồng";
        }
        
        public XtraReport1()
        {
            InitializeComponent();            
        }
        int counter = 0;
        private void STT_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            counter++;
            STT.Text = Convert.ToString(counter);
        }
        
        
        private void sotienbangchu_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            // cắt chuỗi vnd cuối cùng để chuyển đổi
            sotienbangchu.Text = ChuyenSo(Convert.ToDecimal(tongtien.Text.Remove(tongtien.Text.Length -4,4)).ToString("#"));
            
        }
        
        
        

        
       
       

        

       
    }
}

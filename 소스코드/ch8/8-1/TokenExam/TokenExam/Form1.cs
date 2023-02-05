using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TokenExam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            string msg = txt_MSG.Text;
            string[] token = msg.Split('#');
            for (int i = 0; i < token.Length; i++)
            {
                if (token[i].IndexOf("&") > 0)
                {
                    txt_Info.AppendText("\r\n" + token[i]);
                    string[] subtoken = token[i].Split('&');
                    for (int j = 0; j < subtoken.Length; j++)
                        txt_Info.AppendText("\r\n=>" + subtoken[j]);
                }
                else
                {
                    txt_Info.AppendText("\r\n" + token[i]);
                }
            }


        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MessengerClient
{
    public partial class AboutWnd : Form
    {
        public AboutWnd()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 창닫기 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 전자 메일 링크
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void link_Emal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string target = e.Link.LinkData.ToString();
            System.Diagnostics.Process.Start(target);           
        }

        /// <summary>
        /// 홈페이지 링크
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void link_Homepage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string target = e.Link.LinkData.ToString();
            if ((target != null) && target.StartsWith("www"))
            {
                System.Diagnostics.Process.Start(target);
            }
        }

        private void AboutWnd_Load(object sender, EventArgs e)
        {
            link_Emal.Links.Add(7, link_Emal.Text.Length,@"mailto:magicsoft@empal.com");
            link_Homepage.Links.Add(10, link_Homepage.Text.Length, "www.magicsoft.pe.kr");
        }
    }
}
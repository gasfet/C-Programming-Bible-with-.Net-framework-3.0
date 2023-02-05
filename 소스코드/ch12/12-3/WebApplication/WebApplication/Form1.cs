using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WebApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Navigate()
        {
            webBrowser1.Navigate(txt_url.Text.Trim());
        }


        private void btn_back_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
            this.txt_url.Text = webBrowser1.Url.ToString();
        }

        private void btn_home_Click(object sender, EventArgs e)
        {            
            webBrowser1.GoHome();
            this.txt_url.Text = webBrowser1.Url.ToString();
        }

        private void btn_forward_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
            this.txt_url.Text = webBrowser1.Url.ToString();
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            webBrowser1.Stop();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            this.Navigate();
        }

        private void txt_url_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
              this.Navigate();
        }        

         private void Form1_Load(object sender, EventArgs e)
         {            
            this.Navigate();
         }      
       
    }
}
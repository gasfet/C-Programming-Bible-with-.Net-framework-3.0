﻿using System;
using System.Drawing;
using System.Windows.Forms;

public class ButtonExam : Form
{
    Button btn;
    public ButtonExam()
    {
        btn = new Button();
        btn.Parent = this;
        btn.Text = "클릭";
        btn.Location = new Point(100, 100);
        btn.Click += new EventHandler(btn_Click);
    }
    private void btn_Click(object sender, EventArgs e)
    {
        Graphics g_form = this.CreateGraphics();
        Graphics g_button = btn.CreateGraphics();

        g_form.FillRectangle(Brushes.Green, this.ClientRectangle);
        g_button.FillRectangle(Brushes.Red, btn.ClientRectangle);
    }
    public static void Main()
    {
        Application.Run(new ButtonExam());
    }
}

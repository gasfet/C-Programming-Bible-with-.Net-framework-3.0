﻿using System;
using System.Drawing;
using System.Windows.Forms;

public class LabelExam : Form
{
    Label lbl = null;
    RadioButton[] radio;

    string[] TextAlign = {"TopLeft", "TopCenter", "TopRight", 
                           "MiddleLeft", "MiddleCenter", "MiddleRight",
                           "BottomLeft", "BottomCenter", "BottomRight"};
    public LabelExam()
    {
        this.Text = "Label 예제";
        lbl = new Label();
        lbl.Parent = this;
        lbl.BorderStyle = BorderStyle.Fixed3D;
        lbl.Location = new Point(20, 30);
        lbl.Size = new Size(150, 200);
        lbl.Text = "동해물과 백두산이\r\n 마르고 닳도록, \r\n 하느님이 보우하사 \r\n 우리나라 만세";

        radio = new RadioButton[9];

        for (int i = 0; i < 9; i++)
        {
            radio[i] = new RadioButton();
            radio[i].Parent = this;
            radio[i].Text = TextAlign[i];
            radio[i].Location = new Point(180, 30 + i * 20);
            radio[i].CheckedChanged += new EventHandler(LabelExam_CheckedChanged);
        }
        radio[0].Checked = true;
        lbl.TextAlign = ContentAlignment.TopLeft;
    }

    private void LabelExam_CheckedChanged(object sender, EventArgs e)
    {
        RadioButton obj = (RadioButton)sender;
        if (obj == radio[0])
        {
            lbl.TextAlign = ContentAlignment.TopLeft;
        }
        else if (obj == radio[1])
        {
            lbl.TextAlign = ContentAlignment.TopCenter;
        }
        else if (obj == radio[2])
        {
            lbl.TextAlign = ContentAlignment.TopRight;
        }
        else if (obj == radio[3])
        {
            lbl.TextAlign = ContentAlignment.MiddleLeft;
        }
        else if (obj == radio[4])
        {
            lbl.TextAlign = ContentAlignment.MiddleCenter;
        }
        else if (obj == radio[5])
        {
            lbl.TextAlign = ContentAlignment.MiddleRight;
        }
        else if (obj == radio[6])
        {
            lbl.TextAlign = ContentAlignment.BottomLeft;
        }
        else if (obj == radio[7])
        {
            lbl.TextAlign = ContentAlignment.BottomCenter;
        }
        else if (obj == radio[8])
        {
            lbl.TextAlign = ContentAlignment.BottomRight;
        }
    }

    public static void Main()
    {
        Application.Run(new LabelExam());

    }
}

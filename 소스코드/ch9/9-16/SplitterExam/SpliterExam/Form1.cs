using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SpliterExam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Text = "Splitter 컨트롤 사용하기";

            TreeView treeView = new TreeView();
            ListView listView = new ListView();
            Splitter splitter = new Splitter();

            treeView.Dock = DockStyle.Left;
            splitter.Dock = DockStyle.Left;

            splitter.MinExtra = 100;
            splitter.MinSize = 75;

            listView.Dock = DockStyle.Fill;

            treeView.Nodes.Add("트리 노드1");
            treeView.Nodes.Add("트리 노드2");
            listView.Items.Add("리스트 아이템1");
            listView.Items.Add("리스트 아이템2");

            this.Controls.AddRange(new Control[] { listView, splitter, treeView });


        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SplitContainerExam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Text = "SplitContainer 사용하기";

            TreeView treeView = new TreeView();
            ListView listView = new ListView();

            treeView.Dock = DockStyle.Fill;
            listView.Dock = DockStyle.Fill;
            treeView.Nodes.Add("트리 노드1");
            treeView.Nodes.Add("트리 노드2");
            listView.Items.Add("리스트 아이템1");
            listView.Items.Add("리스트 아이템2");


            SplitContainer splitContainer = new SplitContainer();
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Panel1MinSize = 30;
            splitContainer.Panel2MinSize = 50;
            splitContainer.SplitterWidth = 10;
            splitContainer.SplitterIncrement = 5;
            
            splitContainer.Panel1.Controls.Add(treeView);
            splitContainer.Panel2.Controls.Add(listView);

            this.Controls.Add(splitContainer);
        }
    }
}
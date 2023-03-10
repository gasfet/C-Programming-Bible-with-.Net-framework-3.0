using System;
using System.Drawing;
using System.Windows.Forms;

public class RichTextBoxExam : Form
{
    RichTextBox richTextBox;
    public RichTextBoxExam()
    {
        richTextBox = new RichTextBox();
        richTextBox.Parent = this;
        richTextBox.Dock = DockStyle.Fill;
        this.Load += new EventHandler(RichTextBoxExam_Load);
    }

    private void RichTextBoxExam_Load(object sender, EventArgs e)
    {
        richTextBox.LoadFile("song.rtf");        
        richTextBox.Find("소나무 철갑을", RichTextBoxFinds.MatchCase);

        richTextBox.SelectionFont = new Font("궁서체", 30, FontStyle.Bold);
        richTextBox.SelectionColor = Color.Blue;
    }

    public static void Main()
    {
        Application.Run(new RichTextBoxExam());
    }
}

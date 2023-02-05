using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;


public class MetafileExam : System.Windows.Forms.Form
{
    private Metafile metafile;
    private int index;
    private Graphics.EnumerateMetafileProc metafileDelegate;
    private Point destPoint;

    public MetafileExam()
    {
        metafile = new Metafile("test.wmf");
        index = 0;

        metafileDelegate = new Graphics.EnumerateMetafileProc(MetafileCallback);
        destPoint = new Point(20, 10);
        this.Text = "Metafile 이미지 출력";
    }

    static void Main()
    {
        Application.Run(new MetafileExam());
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        e.Graphics.EnumerateMetafile(metafile, destPoint, metafileDelegate);
    }

    private bool MetafileCallback(
        EmfPlusRecordType recordType,
        int flags,
        int dataSize,
        IntPtr data,
        PlayRecordCallback callbackData)
    {
        byte[] dataArray = null;
        if (data != IntPtr.Zero)
        {
            dataArray = new byte[dataSize];
            Marshal.Copy(data, dataArray, 0, dataSize);
        }

        metafile.PlayRecord(recordType, flags, dataSize, dataArray);
        Console.WriteLine("{0} -> type:{1}, flags:{2}, size:{3}", this.index++, recordType, flags, dataSize);

        return true;
    }
}


using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ImageProcess
{
    /// <summary>
    /// �̹��� ó�� Ŭ���� 
    /// Convert_Gray_Bitmap() : ��� �̹��� ��ȯ
    /// Convert_Invert_Gray_Bitmap() : ��� �̹��� ����
    /// Flip() : �¿� ��Ī
    /// Mirror() : �¿� ��Ī
    /// Get_Color_Byte() : �ö��̹��� ���� ��������
    /// Get_Gray_Byte() : ��� �̹��� ���� ��������
    /// Sobel_Edge(): �Һ����� ���ϱ�
    /// Robert() : �ι�Ʈ ���� ���ϱ�
    /// Laplacian() : ���ö�þ� �̹��� ���ϱ�
    /// 
    /// </summary>
    public struct RGB
    {
        public byte red;
        public byte green;
        public byte blue;
    }

    public class CImage
    {

        Bitmap m_Image = null, bmp = null;
        byte[,] ptr = null;
        public int m_Width = 0;
        public int m_Height = 0;


        /// <summary>
        /// �̹��� ó�� ������
        /// </summary>
        /// <param name="file_name">�ҷ��� �̹���</param>
        public CImage(string file_name)
        {
            try
            {
                m_Image = new Bitmap(@file_name);
                m_Width = m_Image.Width;
                m_Height = m_Image.Height;
                bmp = new Bitmap(m_Width, m_Height);
                ptr = new byte[this.m_Width, this.m_Height];
                ptr = this.Get_Gray_Byte();
            }
            catch
            {
                MessageBox.Show(file_name + "�� �о�� �� �����ϴ�.");
            }

        }

        /// <summary>
        /// �Ҹ���
        /// </summary>
        public void Dispose()
        {
            if (m_Image != null) m_Image.Dispose();
            if (bmp != null) bmp.Dispose();
        }


        /// <summary>
        /// �÷� ���� ��ȯ
        /// </summary>
        /// <returns>RGB����ü</returns>
        public RGB[,] Get_Color_Byte()
        {
            RGB[,] ptr1 = new RGB[this.m_Width, this.m_Height];
            for (int j = 0; j < this.m_Height; j++)
                for (int i = 0; i < this.m_Width; i++)
                {
                    ptr1[i, j].red = m_Image.GetPixel(i, j).R;
                    ptr1[i, j].green = m_Image.GetPixel(i, j).G;
                    ptr1[i, j].blue = m_Image.GetPixel(i, j).B;
                }
            return ptr1;

        }

        /// <summary>
        /// ��� ���� ���
        /// </summary>
        /// <returns>byte</returns>
        public byte[,] Get_Gray_Byte()
        {

            for (int j = 0; j < m_Image.Height; j++)
                for (int i = 0; i < m_Image.Width; i++)
                {
                    ptr[i, j] = (byte)(0.30 * m_Image.GetPixel(i, j).R +
                        0.59 * m_Image.GetPixel(i, j).G +
                        0.11 * m_Image.GetPixel(i, j).B);
                }
            return ptr;

        }

        /// <summary>
        /// �ö� �̹����� ������� ��ȯ
        /// </summary>
        /// <returns></returns>
        public Bitmap Covert_Gray_Bitmap()
        {
            for (int j = 0; j < this.m_Height; j++)
                for (int i = 0; i < this.m_Width; i++)
                {
                    bmp.SetPixel(i, j, Color.FromArgb(ptr[i, j], ptr[i, j], ptr[i, j]));
                }
            return bmp;
        }

        public byte[,] Invert_Gray_Byte(byte[,] ptr)
        {
            for (int j = 0; j < this.m_Height; j++)
            {
                for (int i = 0; i < this.m_Width; i++)
                {
                    ptr[i, j] = (byte)(255 - ptr[i, j]);
                }
            }
            return ptr;
        }


        /// <summary>
        /// ��鿵�� ���� ó��
        /// </summary>
        /// <returns></returns>
        public Bitmap Covert_Invert_Gray_Bitmap()
        {
            byte[,] m_ptr = this.Invert_Gray_Byte(ptr);
            for (int j = 0; j < this.m_Height; j++)
                for (int i = 0; i < this.m_Width; i++)
                {
                    bmp.SetPixel(i, j, Color.FromArgb(m_ptr[i, j], m_ptr[i, j], m_ptr[i, j]));
                }
            return bmp;
        }


        /// <summary>
        /// �ø� �ݻ�
        /// </summary>
        /// <returns></returns>
        public Bitmap Flip()
        {
            int i, j, temp;
            byte[,] m_ptr = this.Invert_Gray_Byte(ptr);

            for (j = 0; j < this.m_Height; j++)
                for (i = 0; i < this.m_Width; i++)
                {
                    temp = this.m_Height - j - 1;
                    m_ptr[i, temp] = m_ptr[i, j];
                }


            for (j = 0; j < this.m_Height; j++)
                for (i = 0; i < this.m_Width; i++)
                {
                    bmp.SetPixel(i, j, Color.FromArgb(m_ptr[i, j], m_ptr[i, j], m_ptr[i, j]));
                }
            return bmp;
        }

        /// <summary>
        /// ������ �̷�ȿ��
        /// </summary>
        /// <returns></returns>
        public Bitmap Mirror()
        {
            int i, j, temp;
            byte[,] m_ptr = this.Invert_Gray_Byte(ptr);

            for (j = 0; j < this.m_Height; j++)
                for (i = 0; i < this.m_Width; i++)
                {
                    temp = this.m_Width - i - 1;
                    m_ptr[temp, j] = m_ptr[i, j];
                }


            for (j = 0; j < this.m_Height; j++)
                for (i = 0; i < this.m_Width; i++)
                {
                    bmp.SetPixel(i, j, Color.FromArgb(m_ptr[i, j], m_ptr[i, j], m_ptr[i, j]));
                }
            return bmp;
        }

        /// <summary>
        /// �Һ� ����
        /// </summary>
        /// <returns></returns>
        public Bitmap Sobel_Edge()
        {
            int i, j;
            byte[,] src = ptr;
            byte[,] des = new byte[this.m_Width, this.m_Height];

            for (i = 0; i < this.m_Height; i++)
                for (j = 0; j < this.m_Width; j++)
                    des[j, i] = 0;



            int sum_h, sum_v, sum;
            for (i = 1; i < this.m_Height - 1; i++)
            {
                for (j = 1; j < this.m_Width - 1; j++)
                {
                    sum = sum_v = sum_h = 0;

                    sum_v = -src[j - 1, i - 1] + src[j - 1, i + 1]
                        - 2 * src[j, i - 1] + 2 * src[j, i + 1]
                        - src[j + 1, i - 1] + src[j + 1, i + 1];

                    sum_h = -src[j - 1, i - 1] - 2 * src[j - 1, i] - src[j - 1, i + 1]
                        + src[j + 1, i - 1] + 2 * src[j + 1, i] + src[j + 1, i + 1];

                    sum = (int)(Math.Sqrt(sum_v * sum_v + sum_h * sum_h));

                    des[j, i] = (byte)Math.Max(Math.Min(255, sum), 0);
                }
            }

            for (i = 1; i < this.m_Height - 1; i++)
                for (j = 1; j < this.m_Width - 1; j++)
                {
                    bmp.SetPixel(j, i, Color.FromArgb(des[j, i], des[j, i], des[j, i]));
                }
            return bmp;
        }



        /// <summary>
        /// �ι�Ʈ ���� �˰���
        /// </summary>
        /// <returns></returns>
        public Bitmap Robert()
        {
            int i, j;

            int centerValue1 = 0;
            int centerValue2 = 0;
            int sum = 0;

            byte[,] src = ptr;
            byte[,] des = new byte[this.m_Width, this.m_Height];

            int[,] mask1 = new int[,]  { { 0, 0, -1},
										 { 0, 1, 0 },
										 { 0, 0, 0 }};
            int[,] mask2 = new int[,]  { {-1, 0, 0},
										 {0, 1, 0},
										 {0, 0, 0}};

            for (i = 0; i < this.m_Height; i++)
                for (j = 0; j < this.m_Width; j++)
                    des[j, i] = 0;


            for (int row = 0; row < this.m_Height - 3; row++)
            {
                for (int column = 0; column < this.m_Width - 3; column++)
                {
                    for (i = 0; i < 3; i++)
                    {
                        for (j = 0; j < 3; j++)
                        {
                            centerValue1 += ptr[j + column, i + row] * mask1[i, j];
                            centerValue2 += ptr[j + column, i + row] * mask2[i, j];
                        }
                    }
                    sum = Math.Abs(centerValue1) + Math.Abs(centerValue2);

                    if (sum > 255) sum = 255;
                    des[column + 1, row + 1] = (byte)sum;
                    centerValue1 = 0;
                    centerValue2 = 0;
                    sum = 0;
                }
            }

            for (i = 1; i < this.m_Height - 1; i++)
                for (j = 1; j < this.m_Width - 1; j++)
                {
                    bmp.SetPixel(j, i, Color.FromArgb(des[j, i], des[j, i], des[j, i]));
                }
            return bmp;

        }

        /// <summary>
        /// ���ö�þ� �˰�
        /// </summary>
        /// <returns></returns>
        public Bitmap Laplacian()
        {
            int i, j;

            int centerValue = 0;
            int sum = 0;

            byte[,] src = ptr;
            byte[,] des = new byte[this.m_Width, this.m_Height];

            int[,] mask = new int[,] { {-1, -1, -1},
									   {-1, 8, -1},
									   {-1, -1, -1}};

            for (i = 0; i < this.m_Height; i++)
                for (j = 0; j < this.m_Width; j++)
                    des[j, i] = 0;



            for (int row = 0; row < this.m_Height - 3; row++)
            {
                for (int column = 0; column < this.m_Width - 3; column++)
                {
                    for (i = 0; i < 3; i++)
                    {
                        for (j = 0; j < 3; j++)
                        {
                            centerValue += ptr[j + column, i + row] * mask[i, j];

                        }
                    }
                    sum = Math.Abs(centerValue);

                    if (sum > 255) sum = 255;
                    des[column + 1, row + 1] = (byte)sum;
                    centerValue = 0;
                    sum = 0;
                }
            }

            for (i = 1; i < this.m_Height - 1; i++)
                for (j = 1; j < this.m_Width - 1; j++)
                {
                    bmp.SetPixel(j, i, Color.FromArgb(des[j, i], des[j, i], des[j, i]));
                }
            return bmp;
        }
    }
}

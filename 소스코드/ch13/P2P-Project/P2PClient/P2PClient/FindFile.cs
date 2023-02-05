using System;
using System.IO;

namespace P2PClient
{
    /// <summary>
    /// FindFileŬ����
    /// ���� �˻� ����� �����մϴ�.
    /// </summary>
    public class FindFile
    {
        string sharedirectory = null;  // ���� ���丮 �˻�

        /// <summary>
        /// FindFile ������
        /// </summary>
        /// <param name="dir">�˻��� ���丮</param>
        public FindFile(string dir)
        {
            sharedirectory = dir;
        }


        /// <summary>
        ///  ���丮 �˻� 
        /// </summary>
        /// <param name="str">�˻��� ���丮</param>
        /// <returns></returns>
        public string SearchFile(string str)
        {
            // ��ȯ��
            string return_value = null;

            // �˻� ���� ����Ʈ ���� ����
            string[] files_list;

            // ���� �̸�
            string file_name;

            try // ���� �˻��� �߻��� ���� ó��
            {
                // ���丮���� ���� �˻�
                files_list = Directory.GetFiles(sharedirectory, str);

                return_value = files_list.Length.ToString() + "#";// ���� ���� ����

                for (int i = 0; i < files_list.Length; i++)
                {
                    FileInfo finfo = new FileInfo(files_list[i]); // �˻��� ���� ��ο��� 	

                    int index = files_list[i].LastIndexOf(@"\") + 1;  // ���� �̸��� ����
                    file_name = files_list[i].Substring(index, files_list[i].Length - index);
                    return_value += file_name + "&";                 // ���� �̸� �߰�
                    return_value += finfo.Length.ToString() + "&";    // ���� ������ �߰�
                    return_value += finfo.CreationTime.ToShortDateString() + "&";// ���� ������			
                }
            }
            catch { }
            // ��ȯ�� ���� : �˻����ϰ���#�����̸�&���ϻ�����&���ϻ�����....
            return return_value;
        }
    }
}

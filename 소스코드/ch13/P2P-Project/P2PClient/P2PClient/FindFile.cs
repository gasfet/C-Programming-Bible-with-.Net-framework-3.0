using System;
using System.IO;

namespace P2PClient
{
    /// <summary>
    /// FindFile클래스
    /// 파일 검색 기능을 제공합니다.
    /// </summary>
    public class FindFile
    {
        string sharedirectory = null;  // 공유 디렉토리 검사

        /// <summary>
        /// FindFile 생성자
        /// </summary>
        /// <param name="dir">검색할 디렉토리</param>
        public FindFile(string dir)
        {
            sharedirectory = dir;
        }


        /// <summary>
        ///  디렉토리 검색 
        /// </summary>
        /// <param name="str">검색할 디렉토리</param>
        /// <returns></returns>
        public string SearchFile(string str)
        {
            // 반환값
            string return_value = null;

            // 검색 파일 리스트 저장 변수
            string[] files_list;

            // 파일 이름
            string file_name;

            try // 파일 검색시 발생할 예외 처리
            {
                // 디렉토리에서 파일 검색
                files_list = Directory.GetFiles(sharedirectory, str);

                return_value = files_list.Length.ToString() + "#";// 파일 개수 저장

                for (int i = 0; i < files_list.Length; i++)
                {
                    FileInfo finfo = new FileInfo(files_list[i]); // 검색된 파일 경로에서 	

                    int index = files_list[i].LastIndexOf(@"\") + 1;  // 파일 이름만 추출
                    file_name = files_list[i].Substring(index, files_list[i].Length - index);
                    return_value += file_name + "&";                 // 파일 이름 추가
                    return_value += finfo.Length.ToString() + "&";    // 파일 사이즈 추가
                    return_value += finfo.CreationTime.ToShortDateString() + "&";// 파일 생성일			
                }
            }
            catch { }
            // 반환값 형식 : 검색파일갯수#파일이름&파일사이즈&파일생성일....
            return return_value;
        }
    }
}

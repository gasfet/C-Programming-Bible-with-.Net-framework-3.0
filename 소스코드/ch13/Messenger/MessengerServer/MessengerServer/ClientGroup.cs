using System;
using System.Collections;

namespace MessengerServer
{
    /// <summary>
    /// ClientGroup에 대한 요약 설명입니다.
    /// </summary>
    public class ClientGroup
    {
        #region 멤버 변수/속성

        private Msg_Queue msg_queue = null;
        private ArrayList member = null;

        /// <summary>
        /// 현재 접속된 클라이언트 수
        /// </summary>
        public int Length
        {
            get
            {
                return this.member.Count;
            }
        }

        public ArrayList Member
        {
            get
            {
                return this.member;
            }
        }

        #endregion


        #region 멤버 생성자/소멸자

        /// <summary>
        /// 클라이언트 그룹 생성자
        /// </summary>
        public ClientGroup()
        {
            this.msg_queue = new Msg_Queue();
            this.member = new ArrayList();
        }

        /// <summary>
        /// 클라이언트 그룹 소멸자
        /// </summary>
        public void Dispose()
        {
            try
            {
                foreach (Client obj in this.member)
                {
                    obj.Dispose();
                }
            }
            catch
            {
            }
        }

        #endregion


        #region 멤버 메서드

        /// <summary>
        /// 멤버 추가
        /// </summary>
        /// <param name="client"></param>
        public void AddMember(Client client)
        {
            try
            {
                lock (this.member)
                {
                    client.Send_All += new Send_Message(Send_All);      // BroadCast 효과
                    client.Close_MSG += new Close_Message(Close_MSG);   // 로그아웃 메시지
                    client.msg_queue = this.msg_queue;
                    this.member.Add(client);
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 멤버 제거
        /// </summary>
        /// <param name="user_id">사용자 아이디로 제거</param>
        public void DeleteMember(string user_id)
        {
            try
            {
                lock (this.member)
                {
                    int index = 0;
                    foreach (Client obj in this.member)
                    {
                        if (obj.User_ID == user_id)
                        {
                            this.member.RemoveAt(index);
                            obj.Dispose();
                        }
                        index++;
                    }
                }
            }
            catch
            {
            }
        }


        /// <summary>
        /// 멤버 전체 제거
        /// </summary>		
        public void DeleteAllMember()
        {
            try
            {
                int index = 0;
                lock (this.member)
                {
                    foreach (Client obj in this.member)
                    {
                        this.member.RemoveAt(index);
                        try
                        {
                            obj.Dispose();
                        }
                        catch
                        {
                        }
                        index++;
                    }
                    this.member.Clear();
                }
            }
            catch
            {
            }
        }


        /// <summary>
        /// Send_All 이벤트를 통한 클라이언트 메시지 방송
        /// </summary>
        /// <param name="sender"></param>
        public void Send_All(object sender)
        {
            try
            {
                lock (this.member)
                {
                    string msg = this.msg_queue.Dequeue();

                    foreach (Client obj in this.member)
                    {
                        if (sender != obj)
                            obj.Send(msg);
                    }
                }
            }
            catch
            {
            }
        }

        public void Close_MSG(object sender)
        {
            string msg = this.msg_queue.Dequeue();
            this.DeleteMember(msg);
        }

        /// <summary>
        /// 서버에 접속한 모든 클라이언트에 메시지 방송
        /// </summary>
        /// <param name="msg">방송할 메시지</param>
        /// <returns>성공 유무</returns>
        public bool BroadCast(string msg)
        {
            try
            {
                lock (this.member)
                {
                    foreach (Client obj in this.member)
                    {
                        if (obj.Connect)
                            obj.Send(msg);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 지정된 아이피 그룹에게만 문자열 방송
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="ips"></param>
        /// <returns></returns>
        public bool BroadCast(string msg, string ips)
        {
            try
            {
                string[] ip = ips.Split(';'); // 아이피 주소가 ; 형태로 들어옴
                for (int i = 0; i < ip.Length; i++)
                {
                    lock (this.member)
                    {
                        foreach (Client obj in this.member)
                        {
                            if ((obj.Client_IP == ip[i]) && (obj.Connect))
                                obj.Send(msg);
                        }
                    }

                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

    }
}

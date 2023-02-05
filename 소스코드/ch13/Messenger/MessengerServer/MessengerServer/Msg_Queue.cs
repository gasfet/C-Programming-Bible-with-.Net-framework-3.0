using System;
using System.Collections;

namespace MessengerServer
{
    /// <summary>
    /// Msg_Queue에 대한 요약 설명입니다.
    /// </summary>
    public class Msg_Queue
    {
        Queue msg_queue = null;

        public Msg_Queue()
        {
            msg_queue = new Queue();
        }

        /// <summary>
        /// 메시지 입력
        /// </summary>
        /// <param name="msg"></param>
        public void Enqueue(string msg)
        {
            lock (msg_queue)
            {
                msg_queue.Enqueue(msg);
            }
        }

        /// <summary>
        /// 메시지 출력
        /// </summary>
        /// <returns></returns>
        public string Dequeue()
        {
            lock (msg_queue)
            {
                if (msg_queue.Count != 0)
                {
                    return msg_queue.Dequeue().ToString().Trim();
                }
                else
                {
                    return null;
                }
            }
        }
    }
}

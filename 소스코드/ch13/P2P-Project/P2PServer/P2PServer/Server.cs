using System;
using System.Collections;
using System.IO;                   // ����� ó��
using System.Threading;            // ������ ó��
using System.Net.Sockets;          // ��Ʈ��ũ ���� ó��
using System.Net;                 // ��Ʈ��ũ ó��


namespace P2PServer
{

    /// <summary>
    ///  P2P ���� ��� ���� Ŭ����
    /// </summary>
    class Server
    {
        // TCP ���� ���� ������ ����
        TcpListener listener = null;
        // ������ ���� ��� Ŭ���� 
        ClientGroup member = null;
        // ������ ����
        Thread th = null;

        // ���� ���� flag
        bool stop;
        // P2P ���� ��Ʈ ��ȣ ����
        int port = 7007;


        /// <summary>
        /// ������ 
        /// </summary>
        /// <param name="port">p2p���� ��Ʈ��ȣ</param>
        public Server(int port)
        {
            //�ܺο��� �Է��� ��Ʈ ��ȣ ����          
            this.port = port;
        }

        /// <summary>
        /// Ŭ���̾�Ʈ ��û�� ��ٸ�
        /// </summary>
        public void Accept()
        {

            try
            {  // TCP������ ó���� ����ó���� �ʿ���

                // TCP ������ ����
                listener = new TcpListener(IPAddress.Any, port);
                // TCP ������ �۵� ����
                listener.Start();

            }
            catch
            { // ���� �߻��� ��� Accept �޼��� ��ȯ
                return;
            }

            // ������� ����( Ŭ���̾�Ʈ ������ ��ٸ� )
            while (true)
            {
                // Ŭ���̾�Ʈ  ���� �����
                Socket socket = listener.AcceptSocket();

                if (socket.Connected)
                { // Ŭ���̾�Ʈ�� �����ϸ�...
                    // Client Ŭ������ �����ϰ�, ����Ʈ�� �߰�
                    member.Add(new Client(socket));

                }
            }
        }

        /// <summary>
        ///  P2P ���� �۵� ����
        /// </summary>
        public void Start()
        {
            // ClientGroup ���� �ʱ�ȭ
            member = new ClientGroup();
            // Accep �޼��� ������ ó��
            th = new Thread(new ThreadStart(Accept));
            th.IsBackground = true;  // Background ������ ó��
            // ������ ����
            th.Start();
            // ���� ���� ���� ó�� (���� ����)
            stop = true;
        }

        /// <summary>
        /// P2P ���� ����
        /// </summary>
        public void Stop()
        {
            if (stop)
            {          // stop �÷��׸� �˻��ؼ�
                listener.Stop();  // Listener ����
                member.Dispose(); // ClientGroup()���� ����
                stop = false;     // stop �÷��׸� false�� �ٲ�
                th.Abort();       // ������ ����
            }
        }
    }


    /// <summary>
    ///  ������ Ŭ���̾�Ʈ ó�� Ŭ����
    /// </summary>
    class Client
    {

        StreamReader read;    // �Է� ��Ʈ��
        StreamWriter write;   // ��� ��Ʈ��
        NetworkStream stream;  // ��Ʈ��
        Socket socket;  // ����

        Thread reader;   // �о���� ������


        /// <summary>
        ///  ������
        /// </summary>
        /// <param name="socket">������ Ŭ���̾�Ʈ ����</param>
        public Client(Socket socket)
        {

            this.socket = socket; // ���� ����

            if (this.socket.Connected)
            {           // ����ȴٸ�
                stream = new NetworkStream(socket);// ���Ͽ��� ��Ʈ�� ����
                read = new StreamReader(stream);   // ��Ʈ�� �б� ����
                write = new StreamWriter(stream);  // ��Ʈ�� ���� ����

                // Receive �޼��� ������ �غ�
                reader = new Thread(new ThreadStart(Receive));
                reader.IsBackground = true;
                // ������ ����
                reader.Start();
            }
        }

        /// <summary>
        ///  Ŭ���̾�Ʈ ���� ����
        /// </summary>
        public void Close()
        {
            read.Close();       // ��Ʈ�� �б� ����
            write.Close();		// ��Ʈ�� ���� ����				 		
            stream.Close();     // ��Ʈ�� ����
            socket.Close();     // ���� ����
            reader.Abort();     // Receive �޼��忡 ���� ������ ���� 
        }

        /// <summary>
        ///  ������ Ŭ���̾�Ʈ�� ��� 
        /// </summary>
        public void Receive()
        {
            try
            {
                while (true)
                {
                    // Ŭ���̾�Ʈ �޽��� ����
                    string message = read.ReadLine().Trim(); // �о�ö� ���� ����
                    // �޽������о��
                    if (message != null)
                    {  // �޽����� ������ 
                        char[] ch = { '#' }; // # ��ū�� �޽����� �м�
                        string[] token = message.Split(ch);

                        switch (token[0])
                        {  // ù��° ���ڿ��� 

                            // �α��� �α׾ƿ��� ���� �޽���
                            case "C_REQ_LOGIN":  // �α��� ��û�̸�
                                Login(message);   // �α��� �޼��� ȣ��
                                break;

                            case "C_REQ_LOGOUT": // �α� �ƿ� ��û�̸�
                                Logout(token[1]); // �α� �ƿ� �޼��� ȣ��
                                break;

                            // ������ ��� ������ ���ŵ� ��������Ʈ ����
                            case "C_REQ_REFRESH":   // ���� ����Ʈ ���� ��û�̸�
                                Send_All(token[1]); // ����Ʈ ���� �޼��� ȣ��
                                break;

                            // ȸ�����Կ� ���õ� �޽���
                            case "C_REQ_MEMBERID_CHECK": // ���̵� �ߺ� üũ
                                Id_Check(token[1]);    // ���̵� �ߺ� �޼��� ȣ�� 
                                break;

                            case "C_REQ_MEMBER":         // ȸ�� ���� ��û 
                                Register(message);      // ȸ�� ���� �޼��� ȣ��
                                break;
                        }
                    }
                }
            }
            catch
            { // ���ܰ� �߻��ϸ� ( Ŭ���̾�Ʈ�� ��� ���� )
                Close();  // ��� ���� ���� ����
            }
        }

        /// <summary>
        ///  ������ Ŭ���̾�Ʈ�� �޽��� ������
        /// </summary>
        /// <param name="msg">������ �޽���</param>
        public void Send(string msg)
        {
            // Ŭ���̾�Ʈ�� ���ڿ� ���� 
            write.WriteLine(msg);
            // ���ۿ� �ִ� ���� ����
            write.Flush();
        }

        /// <summary>
        /// �α��� üũ �Լ�
        /// </summary>
        /// <param name="message">�α��� ��û �޽���</param>
        private void Login(string message)
        {
            // �޽��� �޾ƿ���
            string str = message;

            // # ��ū�� �̿��� ���ڿ� ����
            char[] ch = { '#' };
            string[] token = str.Split(ch);

            // �޽��� ���� : #C_REQ_LOGIN#�α��ξ��̵�#��й�ȣ#������IP

            // �α��� ó�� Ŭ���� ����
            Login login = new Login(token[1], token[2], token[3]);

            // �α��� ��� ����
            Send(login.Connection());
        }

        /// <summary>
        /// �α׾ƿ� ó��
        /// </summary>
        /// <param name="user_ip">�α� �ƿ��� IP </param>
        private void Logout(string user_ip)
        {
            // Pass ���̺��� IP��ȣ ����
            string str = "Delete from TBL_Pass where ip='" + user_ip + "'";


            // DB ó�� ����
            DB_conn conn = new DB_conn();
            conn.Open();
            try
            {
                // ������ ����
                conn.ExecuteNonQuery(str);
            }
            finally
            {
                // DB ���� ����
                if (conn != null) conn.Close();
            }
            Send("S_RES_LOGOUT#"); // �α׾ƿ� ���� �޽��� ����
        }


        /// <summary>
        /// ���̵� �ߺ� üũ �޼���
        /// </summary>
        /// <param name="id">�ߺ� �˻��� ���̵�</param>
        private void Id_Check(string id)
        {
            // ȸ�� ���� Ŭ���� ���� ( Id_Checkted(id) ȣ��)
            Reg_User reg = new Reg_User();
            // ���̵� üũ ��� ������
            Send(reg.Id_Check(id));
        }

        /// <summary>
        ///  ȸ�� ���
        /// </summary>
        /// <param name="message">ȸ�� ��� ����</param>
        private void Register(string message)
        {
            // ȸ�� ��� ó�� Ŭ���� ����
            Reg_User reg = new Reg_User();

            if (reg.IsRegister(message))     // ȸ�� ���� �õ�
                Send("S_RES_MEMBEROK#");   // ȸ�� ���� ����
            else
                Send("S_RES_MEMBERFAIL#"); // ȸ�� ���� ���� 

        }

        /// <summary>
        ///  ����Ʈ ���� �޼���
        /// </summary>
        /// <param name="myIP">���� ��û Ŭ���̾�Ʈ IP</param>
        private void Send_All(string myIP)
        {

            // 7008 �� ���� �˻� ������ �޽��� ����
            // �ϱ� ���ؼ� ���ο� Socket ����

            Socket conn = null;           // ����
            NetworkStream stream = null;   // ��Ʈ��
            StreamWriter write = null;     // �۽� ��Ʈ��

            // Pass ���̺� ���� ��������
            PassTableInfo info = new PassTableInfo();
            // �α��� ������ ������ ��� ���� ����Ʈ ��ȯ
            string str = info.Get_Current_Server(myIP);

            try
            {
                // �޽��� & ��ū�� �̿��� �м�
                string[] token = str.Split('&');

                // ������ ��� ������ �޽��� ����
                for (int i = 1; i < token.Length; i++)
                {

                    // ������ ���� 7008(���ϰ˻�)��Ʈ�� ���� �õ�
                    conn = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    // ��Ʈ ��ȣ ����  
                    IPEndPoint E_IP = new IPEndPoint(IPAddress.Parse(token[i]), 7008);


                    try
                    {
                        conn.Connect(E_IP);   // ���� �õ� 				 
                        stream = new NetworkStream(conn);       // ��Ʈ�� ����
                        write = new StreamWriter(stream);     // �۽� ��Ʈ�� ����
                        write.WriteLine("S_RES_REFRESH#" + myIP); // ���� ���� ������ IP����
                        write.Flush();
                    }
                    finally
                    {
                        if (write != null) write.Close();         // �۽� ��Ʈ�� ����
                        if (stream != null) stream.Close();      // ��Ʈ�� ����
                        if (conn != null) conn.Close();          // ���� ����
                    }
                }
            }
            catch
            { // ���� �߻�
            }

        }
    }

    /// <summary>
    ///  ������ Ŭ���̾�Ʈ �׷� ó��
    /// </summary>
    class ClientGroup
    {
        ArrayList member = new ArrayList(); // Ŭ���̾�Ʈ ����Ʈ

        /// <summary>
        ///  Ŭ���̾�Ʈ �߰�
        /// </summary>
        /// <param name="client">���� ������ Ŭ���̾�Ʈ</param> 
        public void Add(Client client)
        {
            // member������ �߰�
            member.Add(client);
        }

        /// <summary>
        ///  ���� �����  Client  ����
        /// </summary>
        public void Dispose()
        {
            foreach (Client client in member)
            {
                // ���� ������ Ŭ���̾�Ʈ ����
                client.Close();
            }
        }
    }
}
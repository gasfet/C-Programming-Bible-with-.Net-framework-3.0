using System;

namespace MainChat
{
	/// <summary>
	/// �޽��� ä�� �޽��� ��Ģ ���� 
	/// </summary>
	
	// ä�� ���� �޽��� ��Ģ
	enum MESSAGE 
	{	
		CTOC_CHAT_INITIAL_INFO,    // ä�� �ʱ�ȭ ����
        CTOC_CHAT_NEWTEXT_INFO,    // ���ο� �޽��� �Է� ��ȣ
		CTOC_CHAT_MESSAGE_INFO,    //
		CTOC_CHAT_MESSAGE_TEXT,    // ä�� �޽���
		CTOC_CHAT_MESSAGE_FONT,    // ä�� ���ڿ� ��Ʈ
		CTOC_CHAT_MESSAGE_COLOR,   // ä�� ���ڿ� ����
		CTOC_CHAT_TERMINATE_INFO   // ä�� ���� ����		
	};

	/*
	 // ä�� & ���� ���� �޽��� ��Ģ
	enum MSG 
	{	
		CTOC_CHAT_INITIAL_INFO,    // ä�� �ʱ�ȭ ����
        CTOC_CHAT_NEWTEXT_INFO,    // ���ο� �޽��� �Է� ��ȣ
		CTOC_CHAT_MESSAGE_TEXT,    // ä�� �޽���
		CTOC_CHAT_MESSAGE_FONT,    // ä�� ���ڿ� ��Ʈ
		CTOC_CHAT_MESSAGE_COLOR,   // ä�� ���ڿ� ����
		CTOC_CHAT_TERMINATE_INFO   // ä�� ���� ����		
		
	    CTOC_FILE_TRANS_INFO,      // ������ ���� ���� ����
		CTOC_FILE_TRANS_YES,       // ���� ���� ���
		CTOC_FILE_TRANS_NO,        // ���� ���� �ź�  
		
	    �̸�Ƽ�� ä�� �޽���
		CTOC_CHAT_EMOTICON_DATA,   // �̸�Ƽ�� ������
		
	};
	*/


}

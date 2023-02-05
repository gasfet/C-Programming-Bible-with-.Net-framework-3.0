using System;

namespace MessengerClient
{
	/// <summary>
	/// Ŭ���̾�Ʈ ���� ���� 
	/// </summary>	
	public enum ClientStates : byte
	{
		online  = 0,                              // �¶���
		offline = 1,                              // ��������
		tel     = 2,                              // ��ȭ��ȭ��
		meal    = 3,                              // �Ļ���
		etc     = 4,                              // �ٸ� �빫��
		leave   = 5,                              // ��� �ڸ����
		retun   = 6                               // �� ���ƿ����� 
	}

	/// <summary>
	/// �޽��� ��Ģ
	/// </summary>
	public enum MSG : byte
	{
		CTOS_MESSAGE_LOGIN_REQUEST        = 10,  // �α��� ��û �޽��� + ���̵� + �н�����
		CTOS_MESSAGE_LOGOUT_REQUEST       = 11,  // �α׾ƿ� ��û �޽���
		STOC_MESSAGE_LOGIN_OK             = 12,  // ���� �α��� ����
		STOC_MESSAGE_LOGIN_FAIL           = 13,  // ���� �α��� ����
		STOC_MESSAGE_LOGOUT_OK            = 14,  // ���� �α׾ƿ� ����
		STOC_MESSAGE_LOGOUT_FAIL          = 15,  // ���� �α׾ƿ� ����
	   
	   
		STOC_MESSAGE_FRIEND_LOGIN         = 20,  // ģ�� �α���
		STOC_MESSAGE_FRIEND_LOGOUT        = 21,  // ģ�� �α׾ƿ�


		CTOS_MESSAGE_GROUP_ADD            = 30,  // �׷� ���� �߰�
		STOC_MESSAGE_GROUP_ADD_OK         = 31,  // �׷� ���� �߰� ����
		STOC_MESSAGE_GROUP_ADD_FAIL       = 32,  // �׷� ���� �߰� ����

		CTOS_MESSAGE_GROUP_MODIFY         = 33,  // �׷� ���� ����
		STOC_MESSAGE_GROUP_MODIFY_OK      = 34,  // �׷� ���� ���� ����
		STOC_MESSAGE_GROUP_MODIFY_FAIL    = 35,  // �׷� ���� ���� ����

		CTOS_MESSAGE_GROUP_REMOVE         = 36,  // �׷� ���� ����
		STOC_MESSAGE_GROUP_REMOVE_OK      = 37,  // �׷� ���� ���� ����
		STOC_MESSAGE_GROUP_REMOVE_FAIL    = 38,  // �׷� ���� ���� ����
       

		CTOS_MESSAGE_FRIEND_ADD            = 40,  // ģ�� ���� �߰�
		STOC_MESSAGE_FRIEND_ADD_OK         = 41,  // �׷� ���� ���� ����
		STOC_MESSAGE_FRIEND_ADD_FAIL       = 42,  // �׷� ���� ���� ����

		CTOS_MESSAGE_FRIEND_MODIFY         = 43,  // ģ�� ���� ����
		STOC_MESSAGE_FRIEND_MODIFY_OK      = 44,  // �׷� ���� ���� ����
		STOC_MESSAGE_FRIEND_MODIFY_FAIL    = 45,  // �׷� ���� ���� ����

		CTOS_MESSAGE_FRIEND_REMOVE         = 46,  // ģ�� ���� ����
		STOC_MESSAGE_FRIEND_REMOVE_OK      = 47,  // �׷� ���� ���� ����
		STOC_MESSAGE_FRIEND_REMOVE_FAIL    = 48,  // �׷� ���� ���� ����
 
		CTOS_MESSAGE_FRIEND_SEARCH         = 50,  // ģ�� ���� �˻�
		STOC_MESSAGE_FRIEND_SEARCH_OK      = 51,  // ģ�� ���� �˻� ����
		STOC_MESSAGE_FRIEND_SEARCH_FAIL    = 52,  // ģ�� ���� �˻� ����
        

		CTOS_MESSAGE_REGISTER_REQUEST     = 60, // ȸ������ ��û �޽���
		STOC_MESSAGE_REGISTER_OK          = 61, // ȸ������ ����
		STOC_MESSAGE_REGISTER_FAIL        = 62, // ȸ������ ����

		CTOS_MESSAGE_REGISTER_IDSEARCH    = 70, // ȸ�������� ���� ID ��ȸ��û
		STOC_MESSAGE_REGISTER_IDYES       = 71, // ID ��� ����
		STOC_MESSAGE_REGISTER_IDNO        = 72, // ID ��� �Ұ�

		CTOS_MESSAGE_REGISTER_ZIPCODE     = 80, // �����ȣ ��ȸ ��û
		STOC_MESSAGE_REGISTER_ZIPCODEDATA = 81, // �����ȣ ��ȸ ���
		STOC_MESSAGE_REGISTER_ZIPCODERR   = 82, // �����ȣ ��ȸ ����

		STOC_MESSAGE_BROADCAST            = 90,  // ���� ��ε�ĳ��Ʈ ��ȣ

		CTOS_MESSAGE_MY_STATES            = 91,  // Ŭ���̾�Ʈ ���¸� ������ ����
		STOC_MESSAGE_FRIEND_STATES        = 92,  // ģ�� ���� ���� ���� Ŭ���̾�Ʈ�� ����

		// ä�� �޽��� ( Ŭ���̾�Ʈ - Ŭ���̾�Ʈ )		
		CTOC_CHAT_NEWTEXT_INFO            = 100, // ���ο� �޽��� �Է� ��ȣ
		CTOC_CHAT_MESSAGE_INFO            = 101, // ä�� �޽��� ����
	    
		CTOC_FILE_TRANS_INFO              = 110, // ���� ���� �غ� ��ȣ
		CTOC_FILE_TRANS_YES               = 111, // ���� ���� ���� 
		CTOC_FILE_TRANS_NO                = 112  // ���� ���� �ź� 


	}

}

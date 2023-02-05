using System;

namespace MainChat
{
	/// <summary>
	/// 메신저 채팅 메시지 규칙 설정 
	/// </summary>
	
	// 채팅 전용 메시지 규칙
	enum MESSAGE 
	{	
		CTOC_CHAT_INITIAL_INFO,    // 채팅 초기화 정보
        CTOC_CHAT_NEWTEXT_INFO,    // 새로운 메시지 입력 신호
		CTOC_CHAT_MESSAGE_INFO,    //
		CTOC_CHAT_MESSAGE_TEXT,    // 채팅 메시지
		CTOC_CHAT_MESSAGE_FONT,    // 채팅 문자열 폰트
		CTOC_CHAT_MESSAGE_COLOR,   // 채팅 문자열 색상
		CTOC_CHAT_TERMINATE_INFO   // 채팅 종료 정보		
	};

	/*
	 // 채팅 & 파일 전송 메시지 규칙
	enum MSG 
	{	
		CTOC_CHAT_INITIAL_INFO,    // 채팅 초기화 정보
        CTOC_CHAT_NEWTEXT_INFO,    // 새로운 메시지 입력 신호
		CTOC_CHAT_MESSAGE_TEXT,    // 채팅 메시지
		CTOC_CHAT_MESSAGE_FONT,    // 채팅 문자열 폰트
		CTOC_CHAT_MESSAGE_COLOR,   // 채팅 문자열 색상
		CTOC_CHAT_TERMINATE_INFO   // 채팅 종료 정보		
		
	    CTOC_FILE_TRANS_INFO,      // 전송할 파일 정보 전송
		CTOC_FILE_TRANS_YES,       // 파일 전송 허락
		CTOC_FILE_TRANS_NO,        // 파일 전송 거부  
		
	    이모티콘 채팅 메시지
		CTOC_CHAT_EMOTICON_DATA,   // 이모티콘 데이터
		
	};
	*/


}

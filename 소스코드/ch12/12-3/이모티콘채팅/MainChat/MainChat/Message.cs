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
        CTOC_CHAT_MESSAGE_INFO,    // 채팅 메시지 정보
        CTOC_CHAT_MESSAGE_TEXT,    // 채팅 메시지
        CTOC_CHAT_MESSAGE_FONT,    // 채팅 문자열 폰트
        CTOC_CHAT_MESSAGE_COLOR,   // 채팅 문자열 색상
        CTOC_CHAT_TERMINATE_INFO   // 채팅 종료 정보		
    };
}

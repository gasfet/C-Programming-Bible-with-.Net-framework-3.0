using System;

namespace MessengerClient
{
	/// <summary>
	/// 클라이언트 상태 정보 
	/// </summary>	
	public enum ClientStates : byte
	{
		online  = 0,                              // 온라인
		offline = 1,                              // 오프라인
		tel     = 2,                              // 전화통화중
		meal    = 3,                              // 식사중
		etc     = 4,                              // 다른 용무중
		leave   = 5,                              // 잠시 자리비움
		retun   = 6                               // 곧 돌아오겠음 
	}

	/// <summary>
	/// 메시지 규칙
	/// </summary>
	public enum MSG : byte
	{
		CTOS_MESSAGE_LOGIN_REQUEST        = 10,  // 로그인 요청 메시지 + 아이디 + 패스워드
		CTOS_MESSAGE_LOGOUT_REQUEST       = 11,  // 로그아웃 요청 메시지
		STOC_MESSAGE_LOGIN_OK             = 12,  // 서버 로그인 성공
		STOC_MESSAGE_LOGIN_FAIL           = 13,  // 서버 로그인 실패
		STOC_MESSAGE_LOGOUT_OK            = 14,  // 서버 로그아웃 성공
		STOC_MESSAGE_LOGOUT_FAIL          = 15,  // 서버 로그아웃 실패
	   
	   
		STOC_MESSAGE_FRIEND_LOGIN         = 20,  // 친구 로그인
		STOC_MESSAGE_FRIEND_LOGOUT        = 21,  // 친구 로그아웃


		CTOS_MESSAGE_GROUP_ADD            = 30,  // 그룹 정보 추가
		STOC_MESSAGE_GROUP_ADD_OK         = 31,  // 그룹 정보 추가 성공
		STOC_MESSAGE_GROUP_ADD_FAIL       = 32,  // 그룹 정보 추가 실패

		CTOS_MESSAGE_GROUP_MODIFY         = 33,  // 그룹 정보 변경
		STOC_MESSAGE_GROUP_MODIFY_OK      = 34,  // 그룹 정보 변경 성공
		STOC_MESSAGE_GROUP_MODIFY_FAIL    = 35,  // 그룹 정보 변경 실패

		CTOS_MESSAGE_GROUP_REMOVE         = 36,  // 그룹 정보 삭제
		STOC_MESSAGE_GROUP_REMOVE_OK      = 37,  // 그룹 정보 삭제 성공
		STOC_MESSAGE_GROUP_REMOVE_FAIL    = 38,  // 그룹 정보 삭제 실패
       

		CTOS_MESSAGE_FRIEND_ADD            = 40,  // 친구 정보 추가
		STOC_MESSAGE_FRIEND_ADD_OK         = 41,  // 그룹 정보 삭제 성공
		STOC_MESSAGE_FRIEND_ADD_FAIL       = 42,  // 그룹 정보 삭제 실패

		CTOS_MESSAGE_FRIEND_MODIFY         = 43,  // 친구 정보 변경
		STOC_MESSAGE_FRIEND_MODIFY_OK      = 44,  // 그룹 정보 삭제 성공
		STOC_MESSAGE_FRIEND_MODIFY_FAIL    = 45,  // 그룹 정보 삭제 실패

		CTOS_MESSAGE_FRIEND_REMOVE         = 46,  // 친구 정보 삭제
		STOC_MESSAGE_FRIEND_REMOVE_OK      = 47,  // 그룹 정보 삭제 성공
		STOC_MESSAGE_FRIEND_REMOVE_FAIL    = 48,  // 그룹 정보 삭제 실패
 
		CTOS_MESSAGE_FRIEND_SEARCH         = 50,  // 친구 정보 검색
		STOC_MESSAGE_FRIEND_SEARCH_OK      = 51,  // 친구 정보 검색 성공
		STOC_MESSAGE_FRIEND_SEARCH_FAIL    = 52,  // 친구 정보 검색 실패
        

		CTOS_MESSAGE_REGISTER_REQUEST     = 60, // 회원가입 요청 메시지
		STOC_MESSAGE_REGISTER_OK          = 61, // 회원가입 성공
		STOC_MESSAGE_REGISTER_FAIL        = 62, // 회원가입 실패

		CTOS_MESSAGE_REGISTER_IDSEARCH    = 70, // 회원가입을 위한 ID 조회요청
		STOC_MESSAGE_REGISTER_IDYES       = 71, // ID 사용 가능
		STOC_MESSAGE_REGISTER_IDNO        = 72, // ID 사용 불가

		CTOS_MESSAGE_REGISTER_ZIPCODE     = 80, // 우편번호 조회 요청
		STOC_MESSAGE_REGISTER_ZIPCODEDATA = 81, // 우편번호 조회 결과
		STOC_MESSAGE_REGISTER_ZIPCODERR   = 82, // 우편번호 조회 에러

		STOC_MESSAGE_BROADCAST            = 90,  // 서버 브로드캐스트 신호

		CTOS_MESSAGE_MY_STATES            = 91,  // 클라이언트 상태를 서버에 전송
		STOC_MESSAGE_FRIEND_STATES        = 92,  // 친구 상태 변경 정보 클라이언트에 전송

		// 채팅 메시지 ( 클라이언트 - 클라이언트 )		
		CTOC_CHAT_NEWTEXT_INFO            = 100, // 새로운 메시지 입력 신호
		CTOC_CHAT_MESSAGE_INFO            = 101, // 채팅 메시지 정보
	    
		CTOC_FILE_TRANS_INFO              = 110, // 파일 전송 준비 신호
		CTOC_FILE_TRANS_YES               = 111, // 파일 전송 수락 
		CTOC_FILE_TRANS_NO                = 112  // 파일 전송 거부 


	}

}

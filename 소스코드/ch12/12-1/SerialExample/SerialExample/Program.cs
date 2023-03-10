using System;
[Serializable]
public class SerialExample
{
    public int id;       // 학번
    public string name;     // 이름
    public int kor;      // 국어 성적
    public int math;      // 수학 성적
    public int eng;      // 영어 성적
    public DateTime date;  // 입력 날짜

    public SerialExample()  // 생성자
    {
        this.id = 0;
        this.name = null;
        this.kor = 0;
        this.math = 0;
        this.eng = 0;
        date = DateTime.Now;
    }
}


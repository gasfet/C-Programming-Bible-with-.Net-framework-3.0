class CastExam
{
    static void Main()
    {
	    byte A ;
	    int B = 365 ;
	    double C = 1024.512 ;
	    System.Console.WriteLine( "축소 형 변환 결과 ");
	    A = (byte) B ;
	    System.Console.WriteLine(" int 형 365 를 byte형으로 바꾸면 "+ A);
	    B = (int) C ;
	    System.Console.WriteLine(" double 형 1024.512를 int 형으로 바꾸면 "+ B);
	    A = (byte) C ;
        System.Console.WriteLine(" double 형 1024.512를 byte 형으로 바꾸면 " + A);        
    }
}

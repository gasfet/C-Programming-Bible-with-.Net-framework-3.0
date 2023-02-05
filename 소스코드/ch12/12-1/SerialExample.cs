using System;

[Serializable]
public class SerialExample
{
	public int    id  ;
	public string name;
	public int    kor ;
	public int    math;
	public int    eng ;
	public DateTime date;

	public SerialExample()
	{
		this.id = 0;
		this.name = null;
		this.kor = 0;
		this.math = 0;
		this.eng = 0;
		date = DateTime.Now;
	}	
}
	
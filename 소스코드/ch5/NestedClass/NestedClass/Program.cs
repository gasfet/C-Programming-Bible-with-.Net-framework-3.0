using System;
class National
{
    public string str_national = "";
    public National(string str)
    {
        str_national = str;
    }
    public class State
    {
        public string str_state = "";
        public State(string str)
        {
            str_state = str;
        }
        public class City
        {
            public string str_city = "";
            public City(string str)
            {
                str_city = str;
            }
        }
    }
}

class NestedClass
{
    static void Main(string[] args)
    {
        National national = new National("대한민국");
        National.State state = new National.State("경기도");
        National.State.City city = new National.State.City("수원시");

        Console.WriteLine("{0} {1} {2}", national.str_national, state.str_state, city.str_city);
    }
}


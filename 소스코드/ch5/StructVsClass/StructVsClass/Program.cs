
class ClassData
{
    public string data;
}

struct StructData
{
    public string data;
}

class StructVsClass
{
    static void ClassCopy(ClassData obj)
    {
        obj.data = "변경";
    }

    static void StructCopy(StructData obj)
    {
        obj.data = "변경";
    }

    static void Main()
    {
        ClassData obj_class = new ClassData();
        StructData obj_struct = new StructData();

        obj_class.data  = "변경되지 않음";
        obj_struct.data = "변경되지 않음";

        ClassCopy(obj_class);
        StructCopy(obj_struct);

        System.Console.WriteLine("Class  field = {0}", obj_class.data);
        System.Console.WriteLine("Struct field = {0}", obj_struct.data);
    }
}
using System;


public class FileModel
{
    
public static void Main()
{
    

}
public static string GetConcat(params string[] names)
{
    var z = names;
    string result = "";
    if (names.Length > 0)
    {
        result += names[0];
    }
    for (int i = 1; i < names.Length; i++)
    {
        result += ", " + names[i];
    }
    return result;
}
}


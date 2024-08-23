namespace LEW.Resources.Class.API.Words.Random;

public class Shuffle
{
    public static List<T> List<T>(List<T> list)  
    {  
        var rnd = new System.Random();
        return list.OrderBy(item => rnd.Next()).ToList(); 
    }
}
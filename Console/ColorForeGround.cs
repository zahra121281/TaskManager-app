using System ; 
public enum Colors 
{
    Success , 
    Danger, 
    Menue , 
    General ,
    Warning 
}

public static class ColerForGround
{
    public static void ChangeColer(Colors color)
    {
        if(color == Colors.Danger )
            Console.ForegroundColor = ConsoleColor.Red  ; 
        else if(color == Colors.Menue )
            Console.ForegroundColor = ConsoleColor.Cyan  ; 
        else if(color == Colors.Success )
            Console.ForegroundColor  =  ConsoleColor.Green  ; 
        else if(color == Colors.Success )
            Console.ForegroundColor  =  ConsoleColor.Yellow  ; 
        else
            Console.ForegroundColor = ConsoleColor.Gray  ; 

    }
}
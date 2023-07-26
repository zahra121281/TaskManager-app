public partial class CRUDMethods
{
    public bool CheckAnswer(string? answer)
    {
        if(answer == string.Empty)
        {
            ColerForGround.ChangeColer(Colors.Danger) ; 
            Console.WriteLine("Empty Answer is not allowed") ;
            ColerForGround.ChangeColer(Colors.General) ; 
            return false ; 
        }
        return true ; 
         
    }
    public bool ValidateTime(string? time)
    {
        string[] tokens = time.Split("/") ;
        if(tokens.Length != 3 )
            return false ; 
        if(tokens[0] == "0000" || tokens[1] == "00" || tokens[2] == "00")
            return false ; 
        if(tokens[0].StartsWith("0"))
            return false ; 
        return true ; 
    }
    public bool CheckId(string id)
    {
        try
        {
            return apiInsstance.ToDoGet().ToList().Select(u => u.MyitemId).Contains(id) ; 
        }
        catch(ArgumentNullException e)
        {
            ColerForGround.ChangeColer(Colors.Danger) ; 
            Console.WriteLine($"ERROR HAS OCCURED ") ;
            ColerForGround.ChangeColer(Colors.General) ;
            System.Environment.Exit(0) ;
            throw e;
        }

    }
    
}
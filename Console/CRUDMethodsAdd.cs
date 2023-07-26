using ToDoApiCli.Api ; 
using ToDoApiCli.Client ; 
using ToDoApiCli.Model ; 
public partial class CRUDMethods
{
    ProgramConsole pc  ;
    public CRUDMethods()
    {
        config = new Configuration(){BasePath = "http://localhost:5000"} ; 
        apiInsstance = new ToDoApi(config) ; 
        pc = new ProgramConsole() ; 
    }
    Configuration config ; 
    ToDoApi apiInsstance ; 
    public static CRUDMethods Instance = new CRUDMethods() ; 
    public static CRUDMethods NewObject()
    {
        return Instance ; 
    }
    public void Creat()
    {
        Console.Clear() ; 
        ColerForGround.ChangeColer(Colors.General) ; 
        Console.Write("Please Enter The Description Of Item :") ; 
        string? description =  Console.ReadLine() ;
        while(! CheckAnswer(description) )
        {
            description = Console.ReadLine() ; 
        
        }
    
        Console.WriteLine("Pleas Enter The Date InForm Of yyyy/mm/dd") ; 
        string? Date = Console.ReadLine() ; 
        while(!CheckAnswer(Date))
        {
            description = Console.ReadLine() ;
        }
        
        while(!ValidateTime(Date))
        {
            ColerForGround.ChangeColer(Colors.Danger ) ;
            Console.WriteLine("Time is not Validate.Please Enter Time in Requested Form!!") ; 
            ColerForGround.ChangeColer(Colors.General) ; 
            description = Console.ReadLine() ;
            ValidateTime(Date) ;
        }
        ColerForGround.ChangeColer(Colors.General) ; 
        DateTime Time = Date.CreatTheTime() ; 
        Console.WriteLine("Please Enter The Id") ; 
        string id = Console.ReadLine() ; 
        while(!CheckAnswer(id))
        {
            id = Console.ReadLine() ;
    
        }
    
        while(CheckId(id))
        {
            ColerForGround.ChangeColer(Colors.Danger ) ;
            Console.WriteLine("Id Is Repeated .Enter A New One") ;
            ColerForGround.ChangeColer(Colors.General) ; 
            id = Console.ReadLine();
        }
        
        try{
            ColerForGround.ChangeColer(Colors.Success ) ;
            apiInsstance.ToDoPost(new Myitem(){Description = description , DateToDone= Time 
                                                , IsDone=false , MyitemId=id}) ; 
            Console.WriteLine("New Item Succesfully Added.") ; 
            pc.NotifyHubServer() ; 
            ProgramConsole.Recovery() ; 
        }
        catch(InvalidOperationException e)
        {
            ColerForGround.ChangeColer(Colors.Danger) ; 
            Console.WriteLine($"ERROR HAS OCCURED ") ;
            ColerForGround.ChangeColer(Colors.General) ;
            System.Environment.Exit(0) ;
            throw e;
        }
        
    }
    
}
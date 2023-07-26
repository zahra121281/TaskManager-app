using System ; 
using ToDoApiCli.Api ; 
using ToDoApiCli.Client ; 
using ToDoApiCli.Model ; 
using Microsoft.AspNetCore.SignalR.Client; 


public class ProgramConsole
{
    static System.ConsoleColor color ;
    HubConnection? hubConnection; 
    public ProgramConsole()
    {
        hubConnection = new HubConnectionBuilder() 
        .WithUrl("http://localhost:5000/HubServer") .Build();
        hubConnection.StartAsync() ; 
        hubConnection.On("Notify", () => 
        { 
            Console.WriteLine("an update have been occured in items!!!"); 
        }); 
    }
    public static void ShowMenue()
    {
        ColerForGround.ChangeColer(Colors.Menue) ; 
        Console.WriteLine("1-Add Item\n2-Delete Item\n3-Update Item\n4-Do an Item\n5-Show All Items") ; 
    }
    public static void ChooseOption()
    {
        CRUDMethods methods = CRUDMethods.NewObject() ; 
        Console.WriteLine("\n\nChoose An Option ") ; 
        var option = Console.ReadLine() ; 
        switch(option){
            case("1") :
                methods.Creat() ; 
                break ; 
            case("2") :
                methods.DeleteItem() ; 
                break ; 
            case("3") :
                methods.UpdateItem(); 
                break ; 
            case("4") :
                methods.MakeDone(); 
                break ; 
            case("5"):
                ShowAllItems() ;
                break ; 
            default:
                Console.WriteLine("No match found");
                Console.WriteLine("If You Want To Exit The Program Press Any Key") ; 
                Console.ReadKey(true); 
                System.Environment.Exit(0) ; 
                return ; 
        }
        
    }
    
    public void NotifyHubServer()
    {
        if (hubConnection is not null) 
        { 
            Console.WriteLine("in NotifyHubServer "); 
            hubConnection.SendAsync("HubServer"); 
        }
        else{
            Console.WriteLine("connection has been interupted!!") ; 
            hubConnection.StartAsync().Wait(); 
            Console.WriteLine("start connection") ; 
        }
    }
    public static void ShowAllItems()
    {
        CRUDMethods methods = CRUDMethods.NewObject() ; 
        methods.ReadItems() ; 
        Recovery() ; 
    }
    public static void Main()
    {
        
        color = Console.ForegroundColor;
        Console.Clear() ; 
        CRUDMethods methods = CRUDMethods.NewObject() ;  
        ColerForGround.ChangeColer(Colors.General)   ;
        Console.WriteLine("Welcome Zahra") ; 
        Console.WriteLine("ToDoList Menue :\n\n") ;
        methods.ShowItemsForToday() ;
        ShowMenue() ; 
        ChooseOption() ; 
    }
    public static void Recovery()
    {
        ColerForGround.ChangeColer(Colors.General) ;
        Console.WriteLine("Do You Want Back To Menue Or Exit Program? Menue/Exit") ; 
        var answer = Console.ReadLine() ; 
        while(answer != "Menue" && answer != "Exit")
        {
            ColerForGround.ChangeColer(Colors.Danger) ; 
            Console.WriteLine("Request Is Not Defineed Enter Again") ;  
            ColerForGround.ChangeColer(Colors.General) ;
            answer = Console.ReadLine() ; 
        }
        
        if(answer == "Menue") 
        {
            ShowMenue() ; 
            ChooseOption() ; 
        }
        else 
        {
            Console.ForegroundColor = color ; 
            System.Environment.Exit(0) ;
        } 
       
    }


}

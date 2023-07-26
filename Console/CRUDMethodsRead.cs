using ToDoApiCli.Api ; 
using ToDoApiCli.Client ; 
using ToDoApiCli.Model ; 
public partial class CRUDMethods
{
    public void ReadItems()
    {
        ColerForGround.ChangeColer(Colors.General) ; 
        var listofitems = apiInsstance.ToDoGet();
        try
        {
            Console.WriteLine("\n\nAll Your Items:------------------------------------------------------------\n\n") ; 
            if(listofitems.Count() == 0 || listofitems == null)
            {
                Console.WriteLine("You Have No Items Yet!!") ; 
            } 
            else
            {
                foreach(var i in apiInsstance.ToDoGet()) 
                    Console.WriteLine(i.ToString()) ; 
            }
            ProgramConsole.Recovery() ; 
        }
        catch(ArgumentNullException e)
        {
            ColerForGround.ChangeColer(Colors.Danger) ; 
            Console.WriteLine($"ERROR HAS OCCURED {e.Message}") ; 
             ColerForGround.ChangeColer(Colors.General) ; 
             System.Environment.Exit(0) ;
        }
        return ; 

    }
    public void GetItem()
    {
        try
        {
            ColerForGround.ChangeColer(Colors.General) ;  
            Console.WriteLine("Enter The Id Of Which Item You Want To Check") ; 
            var answer = Console.ReadLine() ; 
            var item = apiInsstance.ToDoTidGet(answer) ; 
            Console.WriteLine(item) ; 
            ProgramConsole.Recovery() ; 
        }
        catch(NullReferenceException e)
        {
            ColerForGround.ChangeColer(Colors.Danger) ; 
            Console.WriteLine($"ERROR HAS OCCURED {e.Message}") ; 
            
            ColerForGround.ChangeColer(Colors.General) ; 
            System.Environment.Exit(0) ;
        }
    }

    public void ShowItemsForToday()
    {
        try
        {
            ColerForGround.ChangeColer(Colors.General) ; 
            List<Myitem> ListOfItemsForToday = new List<Myitem>();
            ListOfItemsForToday = apiInsstance.ToDoTodayItemsGet() ;
            if(ListOfItemsForToday.Count() == 0 || ListOfItemsForToday == null )
            {
                Console.WriteLine("You Have No Item For Today") ;
            }
            else{
                Console.WriteLine("Your Today's Items--------------------------------------------------------------------------------") ; 
                foreach(var i in apiInsstance.ToDoGet()) 
                    Console.WriteLine(i.ToString()) ; 
            }
        }
        catch(Exception e)
        {
            ColerForGround.ChangeColer(Colors.Danger) ; 
            Console.WriteLine($"ERROR HAS OCCURED {e.Message}") ; 
            ColerForGround.ChangeColer(Colors.General) ; 
            System.Environment.Exit(0) ;
        }


    }

}
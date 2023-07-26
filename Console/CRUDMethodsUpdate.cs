using ToDoApiCli.Api ; 
using ToDoApiCli.Client ; 
using ToDoApiCli.Model ; 
public partial class CRUDMethods
{
    public void UpdateItem()
    {
        try
        {
            ColerForGround.ChangeColer(Colors.General) ;  
            Console.WriteLine("Enter The Id Of Which Item You Want To Edit") ; 
            string itemid = Console.ReadLine() ;
            Console.WriteLine("Enter The New Description Or Enter 0 To Pass This Field") ; 
            var answer1 = Console.ReadLine() ;
            string Description1 = "" ; 
            if(answer1 != null )
            {
                if(answer1 != "0")
                {
                    Description1 += answer1  ;
                }
                else
                {
                    Description1 += apiInsstance.ToDoTidGet(itemid).Description ; 
                } 
            }
            Console.WriteLine("Enter The New DateToDone Or Enter 0 To Pass This Field") ; 
            string answer2 = Console.ReadLine() ;
            DateTime date = new DateTime() ; 
            if(answer2 != null )
            {
                if(answer2 != "0")
                {
                    if(ValidateTime(answer2))
                        date = answer2.CreatTheTime() ;
                    return ; 
                }
                else
                {
                    date = apiInsstance.ToDoTidGet(itemid).DateToDone ; 
                } 
            }
            var item = apiInsstance.ToDoTidGet(itemid) ;
            Myitem DummyItem = new Myitem(){Description=Description1  , DateToDone=date , MyitemId=itemid , IsDone = item.IsDone  } ; 
            apiInsstance.ToDoUpdatePost(DummyItem) ;
            pc.NotifyHubServer() ; 
            ColerForGround.ChangeColer(Colors.Success) ; 
            Console.WriteLine($"Item with id: {itemid} Has Been Successfully Changed.") ;
            ColerForGround.ChangeColer(Colors.General) ; 
            ProgramConsole.Recovery() ;
        }
        catch(Exception e)
        {
            ColerForGround.ChangeColer(Colors.Danger) ; 
            Console.WriteLine($"ERROR HAS OCCURED ") ;
            ColerForGround.ChangeColer(Colors.General) ;
            System.Environment.Exit(0) ;
            throw e; 
        }

    }
    public void MakeDone()
    {
        try
        {
            
            ColerForGround.ChangeColer(Colors.General) ;  
            Console.WriteLine("Enter The Id Of Whic Item You Have Done") ; 
            string itemid = Console.ReadLine() ; 
            Myitem DummyItem = new Myitem(){Description="bella bella bella" , DateToDone=DateTime.Now , MyitemId=itemid , IsDone = true } ; 
            apiInsstance.ToDoMakeDonePost(DummyItem) ; 
            pc.NotifyHubServer() ; 
            ColerForGround.ChangeColer(Colors.Success) ; 
            Console.WriteLine($"Item with id :{itemid} Has Been Successfully Changed.") ;
            
            ProgramConsole.Recovery() ;
        }
        catch(NullReferenceException e)
        {
            ColerForGround.ChangeColer(Colors.Danger) ; 
            Console.WriteLine($"ERROR HAS OCCURED ") ;
            ColerForGround.ChangeColer(Colors.General) ;
            System.Environment.Exit(0) ;
            throw e; 
        }

    }
    
}
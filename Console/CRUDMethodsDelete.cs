public partial class CRUDMethods
{
    public void DeleteItem()
    {
        try
        {
            ColerForGround.ChangeColer(Colors.General) ; 
            Console.WriteLine("Enter The Id of Which Item You Want To Delete.") ; 
            var itemid = Console.ReadLine() ; 
            ColerForGround.ChangeColer(Colors.Danger ) ; 
            Console.WriteLine("Are You Sure You Want To Delete This Item? Y/N") ;
            var answer = Console.ReadLine() ; 
            while(answer != "Y" && answer != "N")
            {
                ColerForGround.ChangeColer(Colors.Warning);
                Console.WriteLine("Entered Request Not Found.Enter again:") ; 
                ColerForGround.ChangeColer(Colors.General) ; 
                answer = Console.ReadLine() ; 
            }
            if(answer == "Y")
            {
                apiInsstance.ToDoItemidDelete(itemid) ; 
                ColerForGround.ChangeColer(Colors.Success) ; 
                Console.WriteLine("Item has been Successfully Deleted") ;
                ColerForGround.ChangeColer(Colors.General) ; 
            }
            pc.NotifyHubServer() ; 
            ProgramConsole.Recovery() ; 
                 
        }
        catch(InvalidOperationException e)
        {
            ColerForGround.ChangeColer(Colors.Danger) ; 
            Console.WriteLine(e.Message) ; 
            ColerForGround.ChangeColer(Colors.General) ; 
            System.Environment.Exit(0) ; 
        }
    }

}
public static class MyExtensionMethods
{
    public static DateTime CreatTheTime(this string date)
    {
        try{
            var tokens = date.Split("/") ;
            int year = 0 ; int mounth = 0 ; int day = 0 ; 
            if(int.TryParse(tokens[0] , out int i ))
                year = int.Parse(tokens[0]) ;
            if(int.TryParse(tokens[1] , out int j ))    
                mounth = int.Parse(tokens[1] ) ; 
            if(int.TryParse(tokens[2] , out int k ))
            {
                day = int.Parse(tokens[2]) ; 
            }
            var newtime = new DateTime(year , mounth , day ) ; 
            return newtime ; 

        }
        catch(ArgumentOutOfRangeException e)
        {
            ColerForGround.ChangeColer(Colors.Danger) ;
            Console.WriteLine("YOU HAVE ENTERD AN UN-REPRESENTABLE DATETIME")  ; 
            ColerForGround.ChangeColer(Colors.General) ; 
            System.Environment.Exit(0) ;
            throw e;
            
        }
       
                
    }

}

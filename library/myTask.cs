using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace library;
public class myitem 
{
    public myitem(){} 

    public string Description {get ;set ; }
  
    [MaxLength(5)]
    [MinLength(1)]
    public string myitemId {get ;set ;} 

    public DateTime DateToDone {get ;set ;}

    
    public bool IsDone {get ;set ; }  
}


using Microsoft.EntityFrameworkCore ; 
using library ;
using System.Collections.Generic;
using System.Linq;
using System;

public class ToDoAppService 
{
    
    private readonly AppContext _todoapp ; 
    public ToDoAppService(AppContext todoapp)
    {
        this._todoapp = todoapp ; 
    }
    
    //creat t
    public async Task<myitem> Postitem(myitem task)
    {
    
        if ( task is not null )
        {
            _todoapp.items.Add(task ) ; 
            await _todoapp.SaveChangesAsync();     
            return task ; 
        }
       
        throw new InvalidOperationException("task does not exist.") ; 
        
    }
    
    //update t
    public async Task<myitem> Updateitem( myitem item )
    {
        var ot = await GetitemById(item.myitemId ) ; 
    
        if(ot is not  null )
        {   
            _todoapp.items.Remove(ot) ; 
            _todoapp.items.Add(item) ;
            await _todoapp.SaveChangesAsync() ;  
            return ot ; 
        }
    
        throw new InvalidOperationException("task does not exist!");
    }
    //update t
    public async Task<myitem> itemDone(myitem item)
    {
        var ot = await GetitemById(item.myitemId) ;
        if(ot is not null)
        {
            item.Description = ot.Description ; 
            item.DateToDone = ot.DateToDone ; 
            item.IsDone = true ; 
            _todoapp.items.Remove(ot) ; 
            _todoapp.items.Add(item) ;
            await _todoapp.SaveChangesAsync() ;  
            return ot; 
        }

        throw new NullReferenceException("task could not be null") ;  
       
    }
    //delete t
    public async Task Deleteitem(string taskid )
    {
        var ot = await GetitemById(taskid) ; 
        if(ot is not  null )
        {
            _todoapp.items.Remove(ot) ; 
            await _todoapp.SaveChangesAsync() ; 
        }
        else
             throw new InvalidOperationException("task does not exist!");
    }
    //Read all t
    public async Task<IEnumerable<myitem>> GetMyitems() => await _todoapp.items.AsNoTracking().ToListAsync() ; 
   
    //Read t
    public async  Task<myitem> GetitemById(string tid )
    {
        var item =  await _todoapp.items.AsNoTracking().SingleOrDefaultAsync(t => t.myitemId == tid ) ;  
        if(item != null )
            return item ;
        else
            throw new  NullReferenceException() ; 
    }
    //get
    public bool IsRepeated(string id) =>
    
        _todoapp.items.AsNoTracking().ToList().Select(u => u.myitemId).Contains(id) ; 
    //get today's tasks

    public  IEnumerable<myitem> GetTodaysItems()
    {
       return  _todoapp.items.AsNoTracking().ToList()
                .Where(i => i.DateToDone.Day == DateTime.Now.Day ) ;
    }

    /*             
    4-creat task
    5-update task 
    6-delete task
    7-get tasks
    8-check tasks
    */
    
}
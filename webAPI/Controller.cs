using System;
using System.Collections.Generic;
using library;
using Microsoft.AspNetCore.Mvc ;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client ; 

[ApiController]

[Route("[controller]")]

public class ToDoController : ControllerBase
{
    ToDoAppService _appservice ; 

    public ToDoController(ToDoAppService appservice )
    {
        _appservice = appservice ; 
    
    }

    [HttpGet]
    public  async Task<IEnumerable<myitem>> Getmyitems()
    {
        return await _appservice.GetMyitems() ; 
    }

    [HttpGet("today-items")]
    public IEnumerable<myitem> GetmyitemsforToday()
    {
        return  _appservice.GetTodaysItems() ; 
    }

    [HttpGet("check/{id}")]
    [ProducesResponseType(typeof(bool) , StatusCodes.Status200OK)]
    public ActionResult<bool> GetIsRepeated(string id) => 
        Ok(_appservice.IsRepeated(id)) ; 
    

    [HttpGet("{tid}")]
    [ProducesResponseType(typeof(myitem) , StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ActionName("GetmyitembyId")]
    public async Task<IActionResult> GetmyitembyId(string tid )
    {
        var task =  _appservice.GetitemById(tid ) ; 
        return await task == null ? NotFound() : Ok(_appservice.GetitemById(tid ) );
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Creatmyitem([FromBody] myitem item)
    {
        var t = await _appservice.Postitem(item) ; 
        
        // return t == null ? BadRequest() : Ok(t) ; 
        if(t is not null )
        {
            // await _connection.Clients.All.SendAsync("UpdateUI") ; 
            return Ok(t) ; 
        }
        else 
        {
            return BadRequest() ; 
        }
    }

   

    [HttpDelete("{itemid}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteTask(string itemid )
    {   
        var task = _appservice.GetitemById(itemid) ; 
        
        if(task is not null)
        {
            await _appservice.Deleteitem(itemid ) ;
            // await _connection.Clients.All.SendAsync("UpdateUI") ; 
            return Ok(task); 
        }
        else 
            return NotFound() ; 
    }

    [HttpPost("update")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Itemupdate([FromBody] myitem newtask )
    { 
        var task = _appservice.GetitemById(newtask.myitemId) ; 
        
        if(task is not null)
        {
            var mytask = await _appservice.Updateitem(newtask );
            // await _connection.Clients.All.SendAsync("UpdateUI") ; 
            return NoContent() ; 
        }
        else 
            return NotFound() ;    
    }
    
    [HttpPost("make-done")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Makedone(myitem item)
    {
        var task = _appservice.GetitemById(item.myitemId) ; 
        
        if( task is not null)
        {
            var ot = await _appservice.itemDone(item ) ;  
            // await _connection.Clients.All.SendAsync("UpdateUI") ;   
            return Ok(ot) ; 
        }
        else 
            return NotFound() ; 
    }

}



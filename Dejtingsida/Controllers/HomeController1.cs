using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Datalager.Models;
using Datalager;
using System.Security.Claims;
using Dejtingsida.Models;
using Dejtingsida.Viewmodels;

namespace Dejtingsida.Controllers
{
    public class Homecontroller1 : Controller 
    { 
    public readonly UserManager<Registrerad> _userManager;
    private readonly DejtingContext _dejtingContext;
    public Homecontroller1(UserManager<Registrerad> users, DejtingContext context)
    {
        _userManager = users;
        _dejtingContext = context;
    }


    [Route("Person")]
    public IActionResult Person()
    {
        try
        {
            ClaimsPrincipal claim = this.User;
            Registrerad user = _userManager.GetUserAsync(claim).Result;
            AnvandareViewModel model = new AnvandareViewModel()
            {
                Anvandare = user,
            };


            return View(model);
        }
        catch (Exception e)
        {

            Console.WriteLine(e.Message);
            return View();
        }
    }

    //Returns view of a specific profile
    
    [Route("Profile/{Id}")]
    public IActionResult Person(string Id)
    {
        Registrerad user;
        //If user with given Id exists
        if (_userManager.FindByIdAsync(Id).Result != null)
        {
            user = _userManager.FindByIdAsync(Id).Result;
                AnvandareViewModel model = new AnvandareViewModel()
            {
                Anvandare = user
            };
            return View(model);
        }
        else
        {
            return View("Error");
        }
    }
}
}

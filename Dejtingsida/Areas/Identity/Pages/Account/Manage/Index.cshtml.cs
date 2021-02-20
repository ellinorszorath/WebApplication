using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Datalager.Models;

namespace Dejtingsida.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<Registrerad> _userManager;
        private readonly SignInManager<Registrerad> _signInManager;

        public IndexModel(
            UserManager<Registrerad> userManager,
            SignInManager<Registrerad> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
            
            [Display(Name = "Förnamn")]
            public string Förnamn { get; set; }
           
            [Display(Name = "Efternamn")]
            public string Efternamn { get; set; }
            [Display (Name = "Födelsedatum")]
            public DateTime Födelsedatum { get; set; }
            [Display(Name = "URL")]
            public string BildNamn { get; set; }


        }

        private async Task LoadAsync(Registrerad user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                Förnamn = user.Förnamn,
                Efternamn = user.Efternamn
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var Anvandare = await _userManager.GetUserAsync(User);
            if (Anvandare == null)
            {
                return NotFound($"Kunde inte hämta information om användare: '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(Anvandare);
                return Page();
            }

            if (Input.Förnamn != Anvandare.Förnamn)
            {
                Anvandare.Förnamn = Input.Förnamn;

            }
            if (Input.Efternamn != Anvandare.Efternamn) 
            {
                Anvandare.Efternamn = Input.Efternamn;
            }
            if (Input.Födelsedatum != Anvandare.Födelsedatum)
            {
                Anvandare.Födelsedatum = Input.Födelsedatum;
            }
            if (Input.BildNamn != Anvandare.BildNamn)
            {
                Anvandare.BildNamn = Input.BildNamn;
            }

            await _userManager.UpdateAsync(Anvandare);
            await _signInManager.RefreshSignInAsync(Anvandare);
            StatusMessage = "Din profil har uppdaterats!";
            return RedirectToPage();
        }
    }
}

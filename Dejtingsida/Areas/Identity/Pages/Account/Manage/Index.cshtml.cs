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

        public string anvandarNamn { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Förnamn")]
            public string Förnamn { get; set; }
            [Required]
            [Display(Name = "Efternamn")]
            public string Efternamn { get; set; }
            [Required]
            [Display (Name = "Födelsedatum")]
            public DateTime Födelsedatum { get; set; }
            [Required]
            [Display(Name = "BildURL")]
            public string BildNamn { get; set; }
            [Required]
            [Display(Name = "Visas i sökresultat")]
            public bool Visas { get; set; }
        }

        private async Task LoadAsync(Registrerad Anvandare)
        {
            var AnvandarNamn = await _userManager.GetUserNameAsync(Anvandare);

            anvandarNamn = AnvandarNamn;

            Input = new InputModel
            {
                Förnamn = Anvandare.Förnamn,
                Efternamn = Anvandare.Efternamn,
                Födelsedatum = Anvandare.Födelsedatum,
                BildNamn = Anvandare.BildNamn,
                Visas = Anvandare.Visas
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var Anvandare = await _userManager.GetUserAsync(User);
            if (Anvandare == null)
            {
                return NotFound($"Kunde inte hämta information om användare:'{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(Anvandare);
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

            if (Input.Visas != Anvandare.Visas)
            {
                Anvandare.Visas = Input.Visas;
            }

            await _userManager.UpdateAsync(Anvandare);
            await _signInManager.RefreshSignInAsync(Anvandare);
            StatusMessage = "Din profil har uppdaterats!";
            return RedirectToPage();
        }
    }
}

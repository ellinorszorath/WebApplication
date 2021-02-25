using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Datalager;
using Datalager.Models;

namespace Dejtingsida
{
    public class InitieraDatabas
    {
        public static async Task Initialize(UserManager<Registrerad> _userManager, DejtingContext _dejtingContext)
        {
            Registrerad anv1 = new Registrerad
            {
                Email = "anv1@anv1.com",
                UserName = "anv1@anv1.com",
                Förnamn = "Anders",
                Efternamn = "Andersson",
                Födelsedatum = new DateTime(1980, 2, 3),
                BildNamn = "https://webstockreview.net/images/clipart-child-wave-goodbye-5.png",
                Visas = true
            };
            await _userManager.CreateAsync(anv1, "Pass123!");

            Registrerad anv2 = new Registrerad
            {
                Email = "anv2@anv2.com",
                UserName = "anv2@anv2.com",
                Förnamn = "Erik",
                Efternamn = "Eriksson",
                Födelsedatum = new DateTime(1990, 1, 12),
                BildNamn = "https://www.pinclipart.com/picdir/middle/11-118996_sensational-idea-person-clip-art-clipart-cartoon-man.png",
                Visas = false
            };
            await _userManager.CreateAsync(anv2, "Pass123!");

            Registrerad anv3 = new Registrerad
            {
                Email = "anv3@anv3.com",
                UserName = "anv3@anv3.com",
                Förnamn = "Lotta",
                Efternamn = "Hejsson",
                Födelsedatum = new DateTime(1960, 12, 12),
                BildNamn = "https://www.pngitem.com/pimgs/m/243-2432074_person-clipart-png-download-presenter-clipart-transparent-png.png",
                Visas = true
            };
            await _userManager.CreateAsync(anv3, "Pass123!");

            Registrerad anv4 = new Registrerad
            {
                Email = "anv4@anv4.com",
                UserName = "anv4@anv4.com",
                Förnamn = "Elin",
                Efternamn = "Berg",
                Födelsedatum = new DateTime(1999, 7, 5),
                BildNamn = "https://www.vhv.rs/dpng/d/124-1243789_office-man-clipart-png-download-person-on-phone.png",
                Visas = true
            };
            await _userManager.CreateAsync(anv4, "Pass123!");

            //Skapar 4 exempel på inlägg.
            Inlägg inlägg1 = new Inlägg {SkickareID = anv3.Id, MottagareID = anv1.Id, Skapad = new DateTime(2021, 01, 24, 12, 35, 0), Message = "Hej snygging ;)" };
            Inlägg inlägg2 = new Inlägg {SkickareID = anv2.Id, MottagareID = anv1.Id, Skapad = new DateTime(2020, 12, 24, 16, 15, 0), Message = "God Jul!" };
            Inlägg inlägg3 = new Inlägg {SkickareID = anv4.Id, MottagareID = anv2.Id, Skapad = new DateTime(2021, 02, 12, 08, 00, 0), Message = "Vilken trevlig profil!" };
            Inlägg inlägg4 = new Inlägg {SkickareID = anv2.Id, MottagareID = anv4.Id, Skapad = new DateTime(2021, 01, 02, 17, 12, 0), Message = "Sju sjösjuka sjömän på sjunkande skeppet Shanghai sköttes av sju sköna sjuksköterskor." };

            await _dejtingContext.Inlägg.AddAsync(inlägg1);
            await _dejtingContext.Inlägg.AddAsync(inlägg2);
            await _dejtingContext.Inlägg.AddAsync(inlägg3);
            await _dejtingContext.Inlägg.AddAsync(inlägg4);

            //Skapar 4 exempel på vänförfrågningar/vänner.
            Vänförfrågning vänförfrågning1 = new Vänförfrågning {FörfrågareID = anv3.Id, MottagareID = anv2.Id, FörfrågningsDatum = DateTime.Now, Accepterad = false };
            Vänförfrågning vänförfrågning2 = new Vänförfrågning {FörfrågareID = anv4.Id, MottagareID = anv1.Id, FörfrågningsDatum = DateTime.Now, Accepterad = false };
            Vänförfrågning vänförfrågning3 = new Vänförfrågning {FörfrågareID = anv3.Id, MottagareID = anv1.Id, FörfrågningsDatum = DateTime.Now, Accepterad = true };
            Vänförfrågning vänförfrågning4 = new Vänförfrågning {FörfrågareID = anv2.Id, MottagareID = anv4.Id, FörfrågningsDatum = DateTime.Now, Accepterad = true };

            await _dejtingContext.Vänförfrågning.AddAsync(vänförfrågning1);
            await _dejtingContext.Vänförfrågning.AddAsync(vänförfrågning2);
            await _dejtingContext.Vänförfrågning.AddAsync(vänförfrågning3);
            await _dejtingContext.Vänförfrågning.AddAsync(vänförfrågning4);

            //Sparar inlägg och vänner i databasen.
            await _dejtingContext.SaveChangesAsync();
        }
    }
}

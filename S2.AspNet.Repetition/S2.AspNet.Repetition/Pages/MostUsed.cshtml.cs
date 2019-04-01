using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using S2.AspNet.Repetition.DAL;
using S2.AspNet.Repetition.Entities;

namespace S2.AspNet.Repetition.Pages
{
    public class MostUsedModel : PageModel
    {
        public MemeImage MostUsedImage { get; set; }
        public MemeCreation MostUsedPosition { get; set; }
        public MemeCreation MostUsedColor { get; set; }
        public void OnGet()
        {
            MemeImageRepository memeImageRepo = new MemeImageRepository(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=MemeGenerator;Integrated Security=True;");
            MemeCreationRepository memeCreationRepo = new MemeCreationRepository(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=MemeGenerator;Integrated Security=True;");

            MostUsedImage = memeImageRepo.GetMostUsedImg();

            MostUsedPosition = memeCreationRepo.GetMostUsedPosition();

            MostUsedColor = memeCreationRepo.GetMostUsedColor();

        }
    }
}
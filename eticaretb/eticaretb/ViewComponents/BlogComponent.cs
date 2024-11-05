using eticaretb.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eticaretb.ViewComponents
{
    public class BlogComponent : ViewComponent
    {

        private readonly eticaretbContext db;

        public BlogComponent(eticaretbContext context)
        {
            db = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var sayfa = db.Blog.Where(a => a.AktifMi && a.Language == "tr-TR").OrderBy(a => a.Sira);
            return View("Blog", sayfa);
        }
    }
}

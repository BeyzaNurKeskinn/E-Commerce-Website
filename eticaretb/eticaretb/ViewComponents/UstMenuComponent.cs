using eticaretb.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eticaretb.ViewComponents
{
    public class UstMenuComponent : ViewComponent
    {

        private readonly eticaretbContext db;

        public UstMenuComponent(eticaretbContext context)
        {
            db = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var menuler = db.UstMenu.Where(a => a.AktifMi && a.Language == "tr-TR").OrderBy(a => a.Sira);
            return View("UstMenu", menuler); //Views klasöründe shared içinde Components->UstMenuComponent içinde UstMenu.cshtml'i render yap
        }
    }
}

using System.Threading.Tasks;
using LnuCampaign.Core.Data.Dto;
using LnuCampaign.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LnuCampaign.Controllers
{
    public class ProfileController : Controller
    {
        private IProfileService _profileService;
        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserDataDto model)
        {
            if (ModelState.IsValid)
            {
                var resultOfCreation = _profileService.UpdateUserData(model);
                if (resultOfCreation != null)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }
    }
}

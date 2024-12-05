using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebMexiFly.Pages.Users.Models;
using WebMexiFly.Utils;

namespace WebMexiFly.Pages.Users
{
    public class UserRegisterModel : PageModel
    {
        private readonly ApiService _apiService;

        public UserRegisterModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public void OnGet()
        {
        }
    // Método para crear un nuevo recurso (POST)
    public async Task<IActionResult> OnPostCreateAsync(RegistrationUserModel client)
    {
        // var success = await _apiService.PostAsync(RepositoryUrls.RegistrationUrl, client);
        // if (success)
        // {
        //     return RedirectToPage(); // Recargar la página
        // }
        
        ModelState.AddModelError("", "Error al crear el elemento.");
        return Page();
    }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebMexiFly.Pages.Flights.List.ResponseApp;
using WebMexiFly.Pages.Flights.Models;
using WebMexiFly.Utils;

namespace WebMexiFly.Pages.Flights.List
{
    public class ListFlightsModel : PageModel
    {
        private readonly ApiService _apiService;

        public ListFlightsModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public List<FlightsViewModel> Flights { get; set; } = new();

        [BindProperty]
        public string SelectedFlightId { get; set; }

        [BindProperty]
        public int SelectedCategoryId { get; set; }

        public async Task OnGetAsync()
        {
            // Llama a la API para obtener la lista de vuelos disponibles
            var result = await _apiService.GetAsync<List<FlightsViewModel>>(RepositoryUrls.GetAllFlights) ?? new ResponseGeneral<List<FlightsViewModel>>();

            Flights = result.Data;
        }

        public async Task<IActionResult> OnPostCreateAsync(ClientViewModel clientViewModel)
        {
            // Verifica si un vuelo ha sido seleccionado
            if (string.IsNullOrEmpty(SelectedFlightId))
            {
                ModelState.AddModelError("", "Por favor, seleccione un vuelo.");
                return RedirectToPage("/ListFlights", new {});
            }

            var responseClient = await _apiService.PostAsync<CreateUserResponseDto, ClientViewModel>
                                        (RepositoryUrls.RegistrationUrl, clientViewModel);
            if (responseClient.Status != "Success")
            {
                return RedirectToPage(); // Recargar la página
            }

            var newTilcet = new NewTicketViewModel() 
            {
                ClientId = responseClient.Data!.ClientId,
                CategoryId = SelectedCategoryId,
                FlightId = int.Parse(SelectedFlightId)
            };

            var ticketCreated = await _apiService.PostAsync<TicketResponse, NewTicketViewModel>(RepositoryUrls.BuyTicket, newTilcet);

            if (ticketCreated.Status != "Success")
            {
                ModelState.AddModelError("", "Error al crear el boleto.");
                return Page();
            }

            return RedirectToPage("/Flights/List/TicketConfirmation", new {});
        }
    }
}

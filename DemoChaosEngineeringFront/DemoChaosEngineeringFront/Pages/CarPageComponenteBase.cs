using DemoChaosEngineeringFront.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace DemoChaosEngineeringFront.Pages
{
    public class CarPageComponenteBase : ComponentBase
    {
        [Inject] public CarService CarService { get; set; }
        [Inject] public IJSRuntime JsRuntime { get; set; }
        [Inject] NavigationManager NavManager { get; set; }
        public List<Car> Cars { get; set; } = new List<Car>();
        public string Search { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await BindGridAsync();
        }

        protected async void SearchClickAsync()
        {
            if (!string.IsNullOrEmpty(Search))
                Cars = await CarService.GetCarsAsync();
        }

        protected async void ClearClickAsync()
        {
            Search = string.Empty;
            Cars = await CarService.GetCarsAsync();
        }

        protected async void DeleteAsync(int id)
        {
            bool confirmed = await JsRuntime.InvokeAsync<bool>("confirm", "Are you sure?"); // Confirm
            if (confirmed)
            {
                await CarService.DeleteCarAsync(id);
                StateHasChanged();
                await BindGridAsync();
                NavManager.NavigateTo("CarPage", false);
            }
        }

        private async Task BindGridAsync()
        {
            Cars = await CarService.GetCarsAsync();
        }
    }
}

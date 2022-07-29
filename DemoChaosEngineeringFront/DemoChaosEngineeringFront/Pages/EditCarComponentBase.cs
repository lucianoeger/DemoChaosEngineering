using DemoChaosEngineeringFront.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.JSInterop;

namespace DemoChaosEngineeringFront.Pages
{
    public class EditCarComponentBase : ComponentBase
    {
        [Inject] public IJSRuntime JsRuntime { get; set; }
        [Inject] NavigationManager NavManager { get; set; }
        [Inject] public CarService CarService { get; set; }
        public Car CarModel { get; set; } = new Car();
        [Parameter] public int Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            CarModel = await CarService.GetCarByIdAsync(Id);
        }

        protected async void FormSubmitted()
        {
            bool confirmed = await JsRuntime.InvokeAsync<bool>("confirm", "Are you sure you Want to Update User Details?"); 
            if (confirmed)
            {
                await CarService.UpdateCarAsync(CarModel);
                NavManager.NavigateTo("CarPage", false);
            }
            else
            {
                await JsRuntime.InvokeVoidAsync("showAlert", "Cancel");
            }
        }
    }
}
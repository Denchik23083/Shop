using Microsoft.AspNetCore.Components;
using Shop.Contracts.Models;
using Shop.Db.Entities;
using Shop.Services.AdminService;
using Shop.Services.CategoryService;

namespace Shop.Web.Components.PagesComponents
{
    public partial class EditProductModalComponent
    {
        [Parameter] public required Product Product { get; set; }

        [Parameter] public bool IsEditOpen { get; set; }

        [Inject] public IAdminService Service { get; set; } = null!;
        
        [Inject] public ICategoryService CategoryService { get; set; } = null!;

        [Inject] public NavigationManager NavigationManager { get; set; } = null!;

        private IEnumerable<Category> Categories { get; set; } = [];

        private readonly ProductEditModel ProductEditModel = new();
        
        private bool _isShowMessage;
        private bool _isSuccess;
        private string _messageText = "";

        protected override async Task OnInitializedAsync()
        {
            Categories = await CategoryService.GetAllCategoriesAsync();
        }

        protected override void OnParametersSet()
        {
            if (Product is null) return;

            ProductEditModel.Name = Product.Name;
            ProductEditModel.PurchasePrice = Product.PurchasePrice;
            ProductEditModel.Price = Product.Price;
            ProductEditModel.CategoryId = Product.CategoryId;
        }
        
        private void CloseEditModal() => IsEditOpen = false;

        private async Task SaveEdit()
        {
            var result = await Service.UpdateProductAsync(ProductEditModel, Product.Id);

            await Task.Delay(500);

            _isSuccess = result;
            _messageText = result
                ? "Товар изменен"
                : "Не удалось изменить товар";

            _isShowMessage = true;
            StateHasChanged();

            await Task.Delay(1500);

            _isShowMessage = false;
            StateHasChanged();

            if (result)
            {
                NavigationManager.NavigateTo($"/products/{Product.Id}", true);
            }
        }
    }
}

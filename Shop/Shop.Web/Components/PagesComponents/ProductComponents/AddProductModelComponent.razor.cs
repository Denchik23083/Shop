using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Shop.Contracts.Models;
using Shop.Db.Entities;
using Shop.Services.AdminService;
using Shop.Services.CategoryService;

namespace Shop.Web.Components.PagesComponents.ProductComponents
{
    public partial class AddProductModelComponent
    {
        [Parameter] public bool IsAddProductOpen { get; set; }

        [Inject] public IAdminService Service { get; set; } = null!;

        [Inject] public ICategoryService CategoryService { get; set; } = null!;

        [Inject] public NavigationManager NavigationManager { get; set; } = null!;

        private IEnumerable<Category> Categories { get; set; } = [];

        private readonly ProductModel ProductModel = new();

        private IBrowserFile? _selectedFile;

        private bool _isShowMessage;
        private bool _isSuccess;
        private string _messageText = "";
        private int _dayExpired = 1;

        protected override async Task OnInitializedAsync()
        {
            Categories = await CategoryService.GetAllCategoriesAsync();
        }

        private void CloseAddProductModal() => IsAddProductOpen = false;

        private void LoadFile(InputFileChangeEventArgs e) => _selectedFile = e.File;

        private void ClearSelectedImage() => _selectedFile = null;

        private async Task SaveAdd()
        {
            if (_selectedFile is null) return;

            await BuildProductModel(_selectedFile);

            var result = await Service.AddProductAsync(ProductModel);

            await Task.Delay(500);

            _isSuccess = result;
            _messageText = result
                ? "Товар добавлен"
                : "Не удалось добавить товар";

            _isShowMessage = true;
            StateHasChanged();

            await Task.Delay(1500);

            _isShowMessage = false;
            StateHasChanged();

            if (result)
            {
                NavigationManager.NavigateTo("/", true);
            }
        }

        private async Task BuildProductModel(IBrowserFile selectedFile)
        {
            var relativePath = await Service.SaveFileAsync(selectedFile);

            if (relativePath is not null)
            {
                ProductModel.Image = relativePath;
            }

            ProductModel.Expiration = DateTime.UtcNow.AddDays(_dayExpired);
        }
    }
}

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Shop.Contracts.Models;
using Shop.Services.AdminService;

namespace Shop.Web.Components.PagesComponents
{
    public partial class AddProductModelComponent
    {
        [Parameter] public bool IsAddProductOpen { get; set; }

        [Inject] public IAdminService Service { get; set; } = null!;

        private readonly ProductModel ProductModel = new();
        private IBrowserFile? _selectedFile;

        private void CloseAddProductModal() => IsAddProductOpen = false;

        private void LoadFile(InputFileChangeEventArgs e) => _selectedFile = e.File;

        private void ClearSelectedImage() => _selectedFile = null;

        private async Task SaveAdd()
        {
            if (_selectedFile is null) return;

            var relativePath = await Service.SaveFileAsync(_selectedFile);

            if (relativePath is not null)
            {
                ProductModel.Image = relativePath;
            }
        }
    }
}

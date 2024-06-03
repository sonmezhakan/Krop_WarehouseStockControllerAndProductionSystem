﻿using Krop.Business.Features.Categories.Constants;
using Krop.Common.Helpers.WebApiRequests.Categories;
using Krop.DTO.Dtos.Categroies;
using Krop.WinForms.HelpersClass;

namespace Krop.WinForms.Categories
{
    public partial class frmCategoryAddRange : Form
    {
        private readonly ICategoryRequest _categoryRequest;

        public frmCategoryAddRange(ICategoryRequest categoryRequest)
        {
            InitializeComponent();
            _categoryRequest = categoryRequest;
        }

        private async void bttnCategoryAdd_Click(object sender, EventArgs e)
        {
            List<CreateCategoryDTO> categoryDTOs = new();//Oluşturulacak kategorilerin atanacağı liste
            foreach (var item in panelMid.Controls)//panelMid nesnesinin içerisindeki nesneler kadar dön
            {
                if (item is TextBox)//Tipi textBox olanlar
                {
                    TextBox newTextBox = item as TextBox;//item nesnesini TextBox tipine dönüştürerek newTexBox aktar.

                    if (!string.IsNullOrEmpty(newTextBox.Text))//newTextBox içerisi boş değil ise listeye kategorileri ekle
                    {
                        categoryDTOs.Add(new CreateCategoryDTO
                        {
                            CategoryName = newTextBox.Text
                        });
                    }
                }
            }

            if(categoryDTOs.Count <= 0)//Tüm TextBoxlar boş ise hata fırlat.
                MessageBox.Show(CategoryMessages.CategoryNotNullAndEmpty, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            HttpResponseMessage response = await _categoryRequest.AddRangeAsync(categoryDTOs);

            if (!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return;
            }
        }

        private void frmCategoryAddRange_Load(object sender, EventArgs e)
        {

        }
    }
}

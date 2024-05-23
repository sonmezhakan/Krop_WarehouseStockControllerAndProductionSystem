using Krop.Business.Features.Brands.Dtos;
using Krop.WinForms.HelpersClass.BrandHelpers;

namespace Krop.WinForms.Brands
{
    public partial class frmBrandCart : Form
    {
        private readonly IBrandHelper _brandHelper;
        public Guid Id;

        public frmBrandCart(IBrandHelper brandHelper)
        {
            InitializeComponent();
            _brandHelper = brandHelper;
        }

        private async void frmBrandCart_Load(object sender, EventArgs e)
        {
           await BrandList();
            cmbBoxBrandSelect.SelectedValue = Id;
        }

        private async Task BrandList()
        {
            List<GetBrandComboBoxDTO> result = await _brandHelper.GetAllComboBoxAsync();

            cmbBoxBrandSelect.SelectedIndexChanged -= CmbBoxBrandSelect_SelectedIndexChanged;

            cmbBoxBrandSelect.DataSource = null;
            cmbBoxBrandSelect.DataSource = result;

            cmbBoxBrandSelect.DisplayMember = "BrandName";
            cmbBoxBrandSelect.ValueMember = "Id";

            cmbBoxBrandSelect.SelectedIndexChanged += CmbBoxBrandSelect_SelectedIndexChanged;
        }

        private async void CmbBoxBrandSelect_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if(cmbBoxBrandSelect.SelectedValue is not null)
            {
               GetBrandDTO result = await _brandHelper.GetByBrandIdAsync((Guid)cmbBoxBrandSelect.SelectedValue);

                txtPhoneNumber.Text = result.PhoneNumber;
                txtEmail.Text = result.Email;
            }
        }
    }
}

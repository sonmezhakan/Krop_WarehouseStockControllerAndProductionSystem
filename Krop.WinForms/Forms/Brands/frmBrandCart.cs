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
            if (cmbBoxBrandSelect.DataSource != null && Id != Guid.Empty)
                cmbBoxBrandSelect.SelectedValue = Id;
        }

        private async Task BrandList()
        {
            List<GetBrandComboBoxDTO> result = await _brandHelper.GetAllComboBoxAsync();

            cmbBoxBrandSelect.DataSource = null;

            cmbBoxBrandSelect.DisplayMember = "BrandName";
            cmbBoxBrandSelect.ValueMember = "Id";

            cmbBoxBrandSelect.SelectedIndexChanged -= cmbBoxBrandSelect_SelectedIndexChanged;
            cmbBoxBrandSelect.DataSource = result;
            cmbBoxBrandSelect.SelectedIndex = -1;
            cmbBoxBrandSelect.SelectedIndexChanged += cmbBoxBrandSelect_SelectedIndexChanged;
        }

        private async void cmbBoxBrandSelect_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbBoxBrandSelect.SelectedValue is not null)
            {
                GetBrandDTO result = await _brandHelper.GetByBrandIdAsync((Guid)cmbBoxBrandSelect.SelectedValue);

                txtPhoneNumber.Text = result.PhoneNumber;
                txtEmail.Text = result.Email;
            }

        }
    }
}

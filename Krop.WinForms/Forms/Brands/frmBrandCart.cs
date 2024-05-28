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

        private void frmBrandCart_Load(object sender, EventArgs e)
        {
            BrandList();
            if (cmbBoxBrandSelect.DataSource != null && Id != Guid.Empty)
                cmbBoxBrandSelect.SelectedValue = Id;
        }

        private void BrandList()
        {
            List<GetBrandComboBoxDTO> result = _brandHelper.GetAllComboBoxAsync();
            if (result is null)
                return;

            cmbBoxBrandSelect.DataSource = null;

            cmbBoxBrandSelect.DisplayMember = "BrandName";
            cmbBoxBrandSelect.ValueMember = "Id";

            cmbBoxBrandSelect.SelectedIndexChanged -= cmbBoxBrandSelect_SelectedIndexChanged;
            cmbBoxBrandSelect.DataSource = result;
            cmbBoxBrandSelect.SelectedIndex = -1;
            cmbBoxBrandSelect.SelectedIndexChanged += cmbBoxBrandSelect_SelectedIndexChanged;
        }

        private void cmbBoxBrandSelect_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbBoxBrandSelect.SelectedValue is not null)
            {
                GetBrandDTO result = _brandHelper.GetByBrandIdAsync((Guid)cmbBoxBrandSelect.SelectedValue);

                txtPhoneNumber.Text = result.PhoneNumber;
                txtEmail.Text = result.Email;
            }

        }
    }
}

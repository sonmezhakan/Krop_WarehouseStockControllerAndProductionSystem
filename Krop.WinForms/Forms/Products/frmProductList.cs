using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krop.WinForms.Products
{
    public partial class frmProductList : Form
    {
        public frmProductList()
        {
            InitializeComponent();
            
        }

        private void frmProductList_Load(object sender, EventArgs e)
        {
            dgwProductList.Rows.Add("asdasd", "2131213", "123123", "asdasd");
            dgwProductList.Rows.Add("asdasd", "2131213", "123123", "asdasd");
            dgwProductList.Rows.Add("asdasd", "2131213", "123123", "asdasd");
            dgwProductList.Rows.Add("asdasd", "2131213", "123123", "asdasd");
            dgwProductList.Rows.Add("asdasd", "2131213", "123123", "asdasd");
            dgwProductList.Rows.Add("asdasd", "2131213", "123123", "asdasd");
            dgwProductList.Rows.Add("asdasd", "2131213", "123123", "asdasd");
        }
    }
}

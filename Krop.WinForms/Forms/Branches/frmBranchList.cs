﻿using Krop.Common.Helpers.WebApiRequests.Branches;
using Krop.DTO.Dtos.Branches;
using Krop.WinForms.HelpersClass;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;

namespace Krop.WinForms.Forms.Branches
{
    public partial class frmBranchList : Form
    {
        private readonly IBranchRequest _branchRequest;
        private readonly IServiceProvider _serviceProvider;
        private BindingList<GetBranchDTO> _originalData;
        private BindingList<GetBranchDTO> _filteredData;

        public frmBranchList(IBranchRequest branchRequest1, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _branchRequest = branchRequest1;
            _serviceProvider = serviceProvider;
        }

        private void frmBranchList_Load(object sender, EventArgs e)
        {
            BranchList();
        }
        private void DgwBranchListSettings()
        {
            dgwBranchList.Columns[0].HeaderText = "Id";
            dgwBranchList.Columns[1].HeaderText = "Şube Adı";
            dgwBranchList.Columns[2].HeaderText = "Telefon Numarası";
            dgwBranchList.Columns[3].HeaderText = "Email";
            dgwBranchList.Columns[4].HeaderText = "Ülke";
            dgwBranchList.Columns[5].HeaderText = "Şehir";
            dgwBranchList.Columns[6].HeaderText = "Adres";

            dgwBranchList.Columns[0].Visible = false;
        }
        private async void BranchList()
        {
            HttpResponseMessage response = await _branchRequest.GetAllAsync();
            if(!response.IsSuccessStatusCode)
            {
                ResponseController.ErrorResponseController(response);
                return;
            }

            var result = ResponseController.SuccessDataListResponseController<GetBranchDTO>(response).Data;

            _originalData = new BindingList<GetBranchDTO>(result);
            _filteredData = new BindingList<GetBranchDTO>(_originalData.ToList());

            dgwBranchList.DataSource = _filteredData;

            DgwBranchListSettings();
        }
        private void Search()
        {
            string searchText = txtSearch.Text.ToLower();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                var filteredList = _originalData.Where(x =>
                (x.BranchName != null && x.BranchName.ToLower().Contains(searchText)) ||
                (x.PhoneNumber != null && x.PhoneNumber.ToString().Contains(searchText)) ||
                (x.Email != null && x.Email.ToLower().Contains(searchText)) ||
                (x.Country != null && x.Country.ToLower().Contains(searchText)) ||
                (x.City != null && x.City.ToLower().Contains(searchText)) ||
                (x.Addres != null && x.Addres.ToLower().Contains(searchText))
                );

                _filteredData.Clear();
                foreach (var item in filteredList)
                {
                    _filteredData.Add(item);
                }
            }
            else
            {
                _filteredData.Clear();
                foreach (var item in _originalData)
                {
                    _filteredData.Add(item);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void bttnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void branchCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBranchCart frmBranchCart = _serviceProvider.GetRequiredService<frmBranchCart>();
            frmBranchCart.Id = (Guid)dgwBranchList.SelectedRows[0].Cells[0].Value;
            FormController.FormOpenController(frmBranchCart);
        }

        private void branchAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBranchAdd frmBranchAdd = _serviceProvider.GetRequiredService<frmBranchAdd>();
            FormController.FormOpenController(frmBranchAdd);
        }

        private void branchUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBranchUpdate frmBranchUpdate = _serviceProvider.GetRequiredService<frmBranchUpdate>();
            frmBranchUpdate.Id = (Guid)dgwBranchList.SelectedRows[0].Cells[0].Value;
            FormController.FormOpenController(frmBranchUpdate);
        }

        private void branchDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBranchDelete frmBranchDelete = _serviceProvider.GetRequiredService<frmBranchDelete>();
            frmBranchDelete.Id = (Guid)dgwBranchList.SelectedRows[0].Cells[0].Value;
            FormController.FormOpenController(frmBranchDelete);
        }

        private void branchListRefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BranchList();
        }
    }
}

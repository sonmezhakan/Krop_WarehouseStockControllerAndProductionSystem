namespace Krop.WinForms.HelpersClass
{
    internal static class DialogResultHelper
    {
        internal static DialogResult UpdateDialogResult()
        {
            DialogResult result = MessageBox.Show("Güncellemek İstediğinize Emin Misiniz?","Onay",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            return result;
        }
    }
}

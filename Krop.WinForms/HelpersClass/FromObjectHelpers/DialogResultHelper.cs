namespace Krop.WinForms.HelpersClass.FromObjectHelpers
{
    internal static class DialogResultHelper
    {
        internal static DialogResult UpdateDialogResult()
        {
            DialogResult result = MessageBox.Show("Güncellemek İstediğinize Emin Misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            return result;
        }
        internal static DialogResult DeleteDialogResult()
        {
            DialogResult result = MessageBox.Show("Silmek İstediğinize Emin Misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            return result;
        }
    }
}

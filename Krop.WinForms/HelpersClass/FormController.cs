namespace Krop.WinForms.HelpersClass
{
    internal static class FormController
    {
        internal static async void FormOpenController(Form form)
        {
            if (Application.OpenForms[form.Name] == null)
                form.Show();
            else
                Application.OpenForms[form.Name].BringToFront();
        }
    }
}

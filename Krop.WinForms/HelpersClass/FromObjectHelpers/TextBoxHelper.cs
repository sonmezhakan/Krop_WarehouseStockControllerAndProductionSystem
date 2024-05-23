namespace Krop.WinForms.HelpersClass.FromObjectHelpers
{
    internal static class TextBoxHelper
    {
        public static void TextBoxDecimalKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')//Char değil,unicode değil, . olabilir
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
        public static void TextBoxDecimalValidating(TextBox textBox, System.ComponentModel.CancelEventArgs e)
        {
            if (!decimal.TryParse(textBox.Text, out _))
            {
                MessageBox.Show("Geçerli Bir Fiyat Giriniz!", "Geçersiz İşlem!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        public static void TextBoxInt32KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        public static void TextBoxInt32Validating(TextBox textBox, System.ComponentModel.CancelEventArgs e)
        {
            if (!int.TryParse(textBox.Text, out _))
            {
                MessageBox.Show("Geçerli Bir Kritik Miktar Giriniz!", "Geçersiz İşlem!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }
    }
}

using System.Windows.Forms;

namespace Sudoku
{
    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 450,
                Height = 125,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                StartPosition = FormStartPosition.CenterScreen,
                Text = caption
            };
            Label textLabel = new Label() { Left = 7, Top = 6, Text = text, Width = 130, Height = 30,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 18) };
            TextBox textBox = new TextBox() { Left = 160, Top = 6, Width = 268,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 15) };
            Button confirmation = new Button() { Text = "OK", Left = 260, Width = 167, Height = 36, Top = 45,
                DialogResult = DialogResult.OK, Font = new System.Drawing.Font("Microsoft Sans Serif", 14) };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}

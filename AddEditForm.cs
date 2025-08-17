using System;
using System.Windows.Forms;

namespace AstronomyGuide
{
    public partial class AddEditForm : Form
    {
        public Star NewStar { get; private set; }

        public AddEditForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
           
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtConstellation.Text) ||
                !double.TryParse(txtMagnitude.Text, out double magnitude) ||
                !double.TryParse(txtDistance.Text, out double distance))
            {
                MessageBox.Show("Будь ласка, заповніть всі поля правильно.");
                return;
            }

          
            NewStar = new Star
            {
                Name = txtName.Text,
                Constellation = txtConstellation.Text,
                Magnitude = magnitude,
                Distance = distance
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
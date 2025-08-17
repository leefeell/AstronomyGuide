using System;
using System.Windows.Forms;

namespace AstronomyGuide
{
    public partial class Form1 : Form
    {
        private StarCatalog catalog = new StarCatalog(); 

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            catalog = StarCatalog.LoadFromFile("stars.json");
            LoadDataToGrid();
        }

        private void LoadDataToGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = catalog.Stars;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            catalog.SaveToFile("stars.json");
            MessageBox.Show("Збережено!");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            catalog = StarCatalog.LoadFromFile("stars.json");
            LoadDataToGrid();
            MessageBox.Show("Завантажено!");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new AddEditForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                catalog.Stars.Add(form.NewStar);
                LoadDataToGrid();  
            }
        }

    }
}

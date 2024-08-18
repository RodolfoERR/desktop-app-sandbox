using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace controlAlmacen
{
    public partial class consultarRefaccion : Form
    {
        private static readonly HttpClient client = new HttpClient();
        private List<Refaction> refactions;

        public consultarRefaccion()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            comboBoxRefactions.TextChanged += new EventHandler(comboBoxRefactions_TextChanged);
        }

        private async void consultarRefaccion_Load(object sender, EventArgs e)
        {
            await LoadRefactionsAsync();

            // Asigna la lista de refacciones al DataGridView
            dataGridView1.DataSource = refactions;

            // Configurar columnas específicas
            dataGridView1.Columns["Id"].HeaderText = "ID";
            dataGridView1.Columns["Name"].HeaderText = "Nombre de la Refacción";
            dataGridView1.Columns["Total_quantity"].HeaderText = "Cantidad Total";

            // Ocultar columnas innecesarias
            dataGridView1.Columns["Description"].Visible = false;
            dataGridView1.Columns["Unit_price"].Visible = false;
            dataGridView1.Columns["Active"].Visible = false;
            dataGridView1.Columns["LocationId"].Visible = false;
            dataGridView1.Columns["Image"].Visible = false;
            dataGridView1.Columns["LocationName"].Visible = false;
            dataGridView1.Columns["ImageUrl"].Visible = false;

            // Opcional: ajustar el tamaño de las columnas
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private async Task LoadRefactionsAsync()
        {
            refactions = await GetAllRefactionsAsync();
        }

        private async Task<List<Refaction>> GetAllRefactionsAsync()
        {
            var refactionUrl = "http://127.0.0.1:8000/api/v1/refactions/all/";

            HttpResponseMessage response = await client.GetAsync(refactionUrl);

            if (response.IsSuccessStatusCode)
            {
                string refactionJson = await response.Content.ReadAsStringAsync();

                // Parsear solo los campos necesarios
                var refactionData = JsonDocument.Parse(refactionJson);
                var refactionList = new List<Refaction>();

                foreach (var refaction in refactionData.RootElement.GetProperty("data").EnumerateArray())
                {
                    var refactionItem = new Refaction
                    {
                        Id = refaction.GetProperty("id").GetInt32(),
                        Name = refaction.GetProperty("name").GetString(),
                        Total_quantity = refaction.GetProperty("total_quantity").GetInt32()
                    };

                    refactionList.Add(refactionItem);
                }

                return refactionList;
            }

            return new List<Refaction>();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void comboBoxRefactions_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void label10_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label14_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBoxRefactions_TextChanged(object sender, EventArgs e)
        {
            // Convertir el texto ingresado a minúsculas para facilitar la comparación
            string searchText = comboBoxRefactions.Text.ToLower();

            // Filtrar la lista de refacciones por ID o Nombre
            var filteredList = refactions.Where(r =>
                r.Id.ToString().Contains(searchText) ||
                r.Name.ToLower().Contains(searchText)).ToList();

            // Asignar la lista filtrada al DataGridView
            dataGridView1.DataSource = null; // Limpiar la fuente de datos para evitar errores
            dataGridView1.DataSource = filteredList;

            // Configurar columnas específicas después de actualizar la fuente de datos
            dataGridView1.Columns["Id"].HeaderText = "ID";
            dataGridView1.Columns["Name"].HeaderText = "Nombre de la Refacción";
            dataGridView1.Columns["Total_quantity"].HeaderText = "Cantidad Total";

            // Ocultar columnas innecesarias
            dataGridView1.Columns["Description"].Visible = false;
            dataGridView1.Columns["Unit_price"].Visible = false;
            dataGridView1.Columns["Active"].Visible = false;
            dataGridView1.Columns["LocationId"].Visible = false;
            dataGridView1.Columns["Image"].Visible = false;
            dataGridView1.Columns["LocationName"].Visible = false;
            dataGridView1.Columns["ImageUrl"].Visible = false;

            // Opcional: ajustar el tamaño de las columnas si es necesario
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


    }
}

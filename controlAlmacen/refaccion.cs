using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using controlAlmacen.Properties;
using System.Diagnostics;

namespace controlAlmacen
{
    public partial class refaccion : Form
    {
        private static readonly HttpClient client = new HttpClient();

        private Refaction _refaction;
        private main _mainForm; // Campo para almacenar la referencia del formulario principal
        public event Action RefactionsUpdated;

        public refaccion(Refaction refaction, main mainForm)
        {
            InitializeComponent();
            _refaction = refaction;
            _mainForm = mainForm; // Asignar la referencia del formulario principal
            DisplayRefactionDetails();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void DisplayRefactionDetails()
        {
            LabelIDX.Text = _refaction.Id.ToString();
            label12.Text = _refaction.Name;
            label14.Text = _refaction.Total_quantity.ToString();
            label13.Text = _refaction.LocationName;
            string baseUrl = "http://127.0.0.1:8000/images/";
            string imageUrl = baseUrl + _refaction.Image;
            if (!string.IsNullOrEmpty(_refaction.Image))
            {
                try
                {
                    pictureBox2.Load(imageUrl);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la imagen: " + ex.Message);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label11_Click(object sender, EventArgs e)
        {
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show(
                "¿Estás seguro de que deseas tomar las piezas?",
                "Confirmar Acción",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.No)
            {
                return;
            }

            if (!int.TryParse(label14.Text, out int cantidadTotal))
            {
                MessageBox.Show("No se pudo determinar la cantidad total.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(texboxCantidad.Text, out int cantidadSolicitada))
            {
                MessageBox.Show("Por favor ingresa una cantidad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cantidadSolicitada > cantidadTotal)
            {
                MessageBox.Show("No hay suficientes piezas disponibles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            var url = $"http://127.0.0.1:8000/api/v1/refactions/taking/{_refaction.Id}";
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.Accesstoken);

            var contenido = new StringContent(
                JsonConvert.SerializeObject(new { quantity = cantidadSolicitada }),
                Encoding.UTF8,
                "application/json"
            );

            try
            {
                var respuesta = await client.PutAsync(url, contenido);

                if (respuesta.IsSuccessStatusCode)
                {
                    MessageBox.Show("Operación exitosa", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await ReloadRefactionDetails();

                }
                else
                {
                    MessageBox.Show($"Error: {respuesta.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar la solicitud: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
        }



        private async Task ReloadRefactionDetails()
        {
            var url = $"http://127.0.0.1:8000/api/v1/refactions/by/{_refaction.Id}";
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.Accesstoken);

            try
            {
                HttpResponseMessage refactionResponse = await client.GetAsync(url);
                Debug.WriteLine(refactionResponse);

                if (refactionResponse.IsSuccessStatusCode)
                {
                    string refactionJson = await refactionResponse.Content.ReadAsStringAsync();
                    Debug.WriteLine(refactionJson);

                    var refactionSingleResponse = JsonConvert.DeserializeObject<RefactionSingleResponse>(refactionJson);

                    if (refactionSingleResponse != null && refactionSingleResponse.Data != null)
                    {
                        var updatedRefaction = refactionSingleResponse.Data;

                       
                        _refaction.Total_quantity = updatedRefaction.Total_quantity;

                        DisplayRefactionDetails();
                    }
                    else
                    {
                        MessageBox.Show("No se encontró la refacción actualizada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"Error al obtener la refacción actualizada: {refactionResponse.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar la solicitud: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void label13_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void txtBuscarRefaccion_TextChanged(object sender, EventArgs e)
        {
        }
    }
}

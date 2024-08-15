using DPFP;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace controlAlmacen.Properties
{
    public partial class main : Form
    {
        private static readonly HttpClient client = new HttpClient();
        private List<Refaction> allRefactions = new List<Refaction>();
        private bool isInitialized = false;
        private refaccion detailsForm;



        public main()
        {
            InitializeComponent();

            // Evitar que la ventana se redimensione
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Deshabilitar el botón de maximizar
            this.MaximizeBox = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private async void main_Load(object sender, EventArgs e)
        {
            await LoadRefactionsAsync();
        }

        private async Task LoadRefactionsAsync()
        {
            allRefactions = await GetAllRefactionsAsync();
            comboBoxRefactions.DataSource = null;
            comboBoxRefactions.DataSource = allRefactions;
            comboBoxRefactions.DisplayMember = "Name";
            comboBoxRefactions.ValueMember = "Id";
            comboBoxRefactions.SelectedIndex = -1;
            isInitialized = true;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private async Task<List<Refaction>> GetAllRefactionsAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                var refactionUrl = "https://quintaesencia.website/api/v1/refactions/all-minus";
                var locationUrl = "https://quintaesencia.website/api/v1/refactions/all-locations";

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.Accesstoken);

                HttpResponseMessage refactionResponse = await client.GetAsync(refactionUrl);
                HttpResponseMessage locationResponse = await client.GetAsync(locationUrl);
                Debug.WriteLine(refactionResponse);

                if (refactionResponse.IsSuccessStatusCode && locationResponse.IsSuccessStatusCode)
                {
                    string refactionJson = await refactionResponse.Content.ReadAsStringAsync();
                    Debug.WriteLine(refactionJson);
                    string locationJson = await locationResponse.Content.ReadAsStringAsync();
                    Debug.WriteLine(locationJson);
                    var refactionData = JsonConvert.DeserializeObject<RefactionResponse>(refactionJson);
                    var locationData = JsonConvert.DeserializeObject<LocationResponse>(locationJson);

                    Debug.WriteLine(refactionData);

                    var locationDict = locationData.Data.ToDictionary(loc => loc.Id);

                    foreach (var refaction in refactionData.Data)
                    {
                        if (locationDict.TryGetValue((int)refaction.LocationId, out var location))
                        {
                            refaction.LocationName = location.Name;
                        }
                        else
                        {
                            refaction.LocationName = "Unknown";
                        }
                    }

                    return refactionData.Data;
                }
                return new List<Refaction>();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private async void label3_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                var url = "https://quintaesencia.website/api/v1/users/log-out";

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.Accesstoken);

                var response = await client.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Deslogueo exitoso.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    login loginForm = new login();
                    loginForm.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show($"Error: {response.StatusCode}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
        }

        private void txtBuscarRefaccion_Leave(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBoxRefactions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isInitialized) return;

            if (comboBoxRefactions.SelectedItem is Refaction selectedRefaction)
            {
                // Cierra el formulario anterior si aún está abierto
                if (detailsForm != null && !detailsForm.IsDisposed)
                {
                    detailsForm.Close();
                    detailsForm.Dispose();
                    detailsForm = null;
                }

                detailsForm = new refaccion(selectedRefaction, this);
                detailsForm.RefactionsUpdated += async () => await LoadRefactionsAsync();
                detailsForm.FormClosed += (s, args) => detailsForm = null; // Limpiar la referencia cuando se cierre
                detailsForm.ShowDialog(); // Mostrar el formulario de manera modal
            }
        }

        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
        }

        private void label9_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(capturarHuella capturarFp =  new capturarHuella())
            {
                capturarFp.OnTemplate += this.OnTemplate;
                capturarFp.ShowDialog();
            }
        }
        private Template Template = null;

        private async void OnTemplate(Template template)
        {
            this.Invoke(new Action(async () =>
            {
                Template = template;

                if (template != null)
                {
                    MessageBox.Show("Fingerprint was correct and set to go");

                    byte[] fingerprint = Template.Bytes;

                    // Convertir la huella a Base64
                    string base64String = Convert.ToBase64String(fingerprint);

                    // Crear un objeto JSON con la variable base64String
                    var jsonData = new
                    {
                        fp = base64String
                    };

                    // Convertir el objeto a una cadena JSON
                    string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(jsonData);

                    // Crear el contenido para la solicitud POST
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    // Realizar la solicitud POST
                    using (HttpClient client = new HttpClient())
                    {
                        try
                        {
                            // Asegúrate de que la URL esté correcta y accesible
                            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.Accesstoken);
                            HttpResponseMessage response = await client.PostAsync("https://quintaesencia.website/api/v1/fp/save-digital-fp", content);

                            if (response.IsSuccessStatusCode)
                            {
                                MessageBox.Show("Fingerprint was successfully sent to the server.");
                            }
                            else
                            {
                                MessageBox.Show("Failed to send fingerprint: " + response.ReasonPhrase);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Fingerprint was not correctly captured");
                }
            }));
        }


    }
}

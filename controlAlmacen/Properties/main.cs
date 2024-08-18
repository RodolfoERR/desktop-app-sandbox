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
using System.Text.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics.Eventing.Reader;

namespace controlAlmacen.Properties
{
    public partial class main : Form
    {
        private static readonly HttpClient client = new HttpClient();
        private List<Refaction> allRefactions = new List<Refaction>();
        private bool isInitialized = false;
        private refaccion detailsForm;
        private bool suppressComboBoxEvent = false; // Variable para suprimir eventos innecesarios

        public main()
        {
            InitializeComponent();

            // Evitar que la ventana se redimensione
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Deshabilitar el botón de maximizar
            this.MaximizeBox = false;

            // Conectar el evento de actualización de texto para el filtrado incremental
            comboBoxRefactions.TextUpdate += comboBoxRefactions_TextUpdate;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private async void main_Load(object sender, EventArgs e)
        {
            await LoadRefactionsAsync();
            SetUserLabel();

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

        private async Task<List<Refaction>> GetAllRefactionsAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                var refactionUrl = "http://127.0.0.1:8000/api/v1/refactions/all-minus";
                var locationUrl = "http://127.0.0.1:8000/api/v1/refactions/all-locations";

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



        private void SetUserLabel()
        {
            if (!string.IsNullOrEmpty(Session.UserName))
            {
                // Asigna el nombre de usuario al Label
                labelUser.Text = $"Bienvenido {Session.UserName} 👤​";
            }
            else
            {
                labelUser.Text = "Usuario no identificado";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private async void label3_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                var url = "http://127.0.0.1:8000/api/v1/users/log-out";

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.Accesstoken);

                var response = await client.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                   
                    Session.ClearSession();

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

        // Método para manejar la selección en el ComboBox
        private void comboBoxRefactions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (suppressComboBoxEvent || !isInitialized) return;

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

        // Método para manejar el filtrado incremental mientras se escribe en el ComboBox
        private void comboBoxRefactions_TextUpdate(object sender, EventArgs e)
        {
            if (!isInitialized) return;

            suppressComboBoxEvent = true;

            string searchText = comboBoxRefactions.Text.ToLower();
            List<Refaction> filteredList = allRefactions
                .Where(r => r.Name.ToLower().Contains(searchText))
                .ToList();

            comboBoxRefactions.DataSource = null; // Limpia el ComboBox
            comboBoxRefactions.DataSource = filteredList;
            comboBoxRefactions.DisplayMember = "Name";
            comboBoxRefactions.ValueMember = "Id";

            // Establecer el texto de nuevo, ya que se borra al cambiar el DataSource
            comboBoxRefactions.Text = searchText;

            // Mueve el cursor al final del texto
            comboBoxRefactions.SelectionStart = comboBoxRefactions.Text.Length;

            suppressComboBoxEvent = false;
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

        private bool auth = true;
        private async void button1_Click(object sender, EventArgs e)
        {
            using (capturarHuella capturarFp = new capturarHuella())

            {
                bool isactivate;
                isactivate = await CheckIfFingerprintExistsAsync(Session.UserId);
                Debug.WriteLine(isactivate);
                if (isactivate == true)
                {
                    MessageBox.Show("Huella ya registrada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    capturarFp.OnTemplate += this.OnTemplate;
                    capturarFp.ShowDialog();
                }

            }
        }

        private async Task<bool> CheckIfFingerprintExistsAsync(int userId)
        {
            string base64Fingerprint = string.Empty;

            try
            {
                Debug.WriteLine(userId);
                var data = new Dictionary<string, string> { { "user_id", userId.ToString() } };
                var content = new FormUrlEncodedContent(data);
                Debug.WriteLine(content);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.Accesstoken);

                HttpResponseMessage response = await client.PostAsync("http://127.0.0.1:8000/api/v1/fp/check-digital-fp", content);
                Debug.WriteLine(response.StatusCode);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine(jsonResponse);

                    using (JsonDocument doc = JsonDocument.Parse(jsonResponse))
                    {
                        if (doc.RootElement.TryGetProperty("data", out JsonElement dataElement))
                        {
                            base64Fingerprint = dataElement.GetString();
                            Debug.WriteLine(base64Fingerprint);
                            //button1.Enabled = false;
                        }
                        else
                        {
                            Debug.WriteLine("No se encontró la propiedad 'data' en la respuesta JSON.");
                        }
                    }

                    // Validación: Verificar si la huella dactilar está registrada
                    if (string.IsNullOrEmpty(base64Fingerprint))
                    {
                        // No se encontró huella dactilar registrada
                        return false;
                    }

                    // La huella dactilar está registrada
                    return true;
                }
                else
                {
                    MessageBox.Show("Error al verificar la huella dactilar: " + response.ReasonPhrase, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con el servidor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
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
                    MessageBox.Show("Huella dactilar generada correctamente, Lista para funcionar");

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
                            HttpResponseMessage response = await client.PostAsync("http://127.0.0.1:8000/api/v1/fp/save-digital-fp", content);

                            if (response.IsSuccessStatusCode)
                            {
                                //MessageBox.Show("La huella dactilar se envió con éxito al servidor.");
                               
                            }
                            else
                            {
                                MessageBox.Show("No se pudo enviar la huella dactilar:" + response.ReasonPhrase);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Se ha producido un error: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("La huella dactilar no se capturó correctamente");
                }
            }));
        }

        private void labelUser_Click(object sender, EventArgs e)
        {

        }
    }
}

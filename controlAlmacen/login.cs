using System;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using controlAlmacen.Properties;

namespace controlAlmacen
{
    public partial class login : Form
    {
        private static readonly HttpClient client = new HttpClient();

        public login()
        {
            try
            {
                InitializeComponent();
                Log("InitializeComponent completed");

                // Evitar que la ventana se redimensione
                this.FormBorderStyle = FormBorderStyle.FixedSingle;

                // Deshabilitar el botón de maximizar
                this.MaximizeBox = false;
            }
            catch (Exception ex)
            {
                Log($"Error in constructor: {ex.Message}\n{ex.StackTrace}");
                MessageBox.Show($"Error in constructor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void login_Load(object sender, EventArgs e)
        {
            Log("login_Load triggered");

            try
            {
                // Simulación de un retraso en la inicialización
                await Task.Delay(1000);
            }
            catch (Exception ex)
            {
                Log($"Error in login_Load: {ex.Message}\n{ex.StackTrace}");
                MessageBox.Show($"Error in login_Load: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Log("pictureBox1_Click triggered");
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Log("pictureBox1_Click_1 triggered");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Log("panel1_Paint triggered");
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Log("panel2_Paint triggered");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Log("textBox1_TextChanged triggered");
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Log("label2_Click triggered");
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Log("button1_Click triggered");

            botonLogin.Enabled = false; 

            var emaila = textBox1.Text;
            var passworda = textBox2.Text;

            if (string.IsNullOrWhiteSpace(emaila) || string.IsNullOrWhiteSpace(passworda))
            {
                MessageBox.Show("Por favor, complete ambos campos.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                botonLogin.Enabled = true; 
                return;
            }

            var loginData = new
            {
                email = emaila,
                password = passworda
            };

            var json = JsonConvert.SerializeObject(loginData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync("https://quintaesencia.website/api/v1/users/log-in/", content);

                var responseString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var responseJson = JsonConvert.DeserializeObject<dynamic>(responseString);
                    Session.Accesstoken = responseJson.token;
                    MessageBox.Show("Login exitoso.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    main mainForm = new main();
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Nombre de usuario o contraseña incorrectos.", "Login fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Log($"Error in button1_Click: {ex.Message}\n{ex.StackTrace}");
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                botonLogin.Enabled = true; 
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Log("textBox2_TextChanged triggered");
        }

        private void Log(string message)
        {
            // Aquí puedes implementar la lógica de registro, por ejemplo, escribir en un archivo de texto o consola
            Console.WriteLine(message);
        }
    }
}       

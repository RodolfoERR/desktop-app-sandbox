using controlAlmacen.Properties;
using DPFP;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace controlAlmacen
{
    public partial class compararHuella : CaptureForm
    {
        private static readonly HttpClient client = new HttpClient();
        private DPFP.Template Template;
        private DPFP.Verification.Verification Verification;
        public bool VerificationSuccessful { get; private set; }

        public compararHuella()
        {
            InitializeComponent();
            Verification = new DPFP.Verification.Verification();
        }

        protected override void Init()
        {
            base.Init();
            base.Text = "Comparador";
            Verification = new DPFP.Verification.Verification();
            UpdateStatus(0);
        }

        private void UpdateStatus(int FAR)
        {
            SetStatus(String.Format("False Accept Rate (FAR) = {0}", FAR));
        }

        protected override async void Process(DPFP.Sample Sample)
        {
            base.Process(Sample);

            string base64Fingerprint = "";

            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session.Accesstoken);

                var data = new Dictionary<string, string> { { "user_id", "some_value" } };
                var content = new FormUrlEncodedContent(data);
                HttpResponseMessage response = await client.PostAsync("http://127.0.0.1:8000/api/v1/fp/check-digital-fp", content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    dynamic jsonResult = JsonConvert.DeserializeObject(jsonResponse);
                    base64Fingerprint = jsonResult.data;
                    Debug.WriteLine(base64Fingerprint);

                    // Validación: Verificar si la huella dactilar está registrada
                    if (string.IsNullOrEmpty(base64Fingerprint))
                    {
                        MessageBox.Show("No se ha encontrado ninguna huella dactilar registrada. Por favor, registre su huella dactilar para poder proceder con la extracción de una refacción o suministro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.Cancel; // Indica que la verificación falló
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Failed to retrieve fingerprint: " + response.ReasonPhrase);
                    this.DialogResult = DialogResult.Cancel; // Indica que la verificación falló
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
                this.DialogResult = DialogResult.Cancel; // Indica que hubo un error
                return;
            }

            try
            {
                byte[] fingerprint = Convert.FromBase64String(base64Fingerprint);
                DPFP.Template template = new DPFP.Template(new MemoryStream(fingerprint));
                DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification);

                if (features != null)
                {
                    DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
                    Verification.Verify(features, template, ref result);
                    UpdateStatus(result.FARAchieved);

                    if (result.Verified)
                    {
                        MessageBox.Show("Huella correcta");
                        VerificationSuccessful = true;
                        this.DialogResult = DialogResult.OK; // Indica que la verificación fue exitosa
                    }
                    else
                    {
                        MessageBox.Show("Huella incorrecta");
                        VerificationSuccessful = false;
                        this.DialogResult = DialogResult.Cancel; // Indica que la verificación falló
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("El formato de la huella dactilar es inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel; // Indica que la verificación falló
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error durante el procesamiento de la huella digital: " + ex.Message);
                this.DialogResult = DialogResult.Cancel; // Indica que la verificación falló
            }
        }
    }
}

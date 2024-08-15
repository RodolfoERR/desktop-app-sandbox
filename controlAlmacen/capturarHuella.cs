using DPFP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace controlAlmacen
{
    public partial class capturarHuella : CaptureForm
    {
        public delegate void OnTemplateEventHandler(Template template);
        public event OnTemplateEventHandler OnTemplate;
        private DPFP.Processing.Enrollment Enroller;
        public capturarHuella()
        {
            InitializeComponent();
        }

        protected override void Init()
        {
            base.Init();
            base.Text = "Huella digital para cargar";
            Enroller = new DPFP.Processing.Enrollment();
            UpdateStatus();
        }

        private void UpdateStatus()
        {
            // Somehow this one doesn't work here
            //SetStatus(String.Format("Fingerprint samples needed: {0}"), Enroller.FeaturesNeeded);

            SetStatus("Necesitamos más huellas dactilares para crear la plantilla.");
        }

        protected override void Process(DPFP.Sample Sample)
        {
            base.Process(Sample);

            // Process the sample and create a feature set for the enrollment purpose.
            DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Enrollment);

            // Check quality of the sample and add to enroller if it's good
            if (features != null) try
                {
                    MakeReport("Se creó el conjunto de funciones de huellas dactilares1.");
                    Enroller.AddFeatures(features);     // Add feature set to template.
                }
                finally
                {
                    UpdateStatus();

                    // Check if template has been created.
                    switch (Enroller.TemplateStatus)
                    {
                        case DPFP.Processing.Enrollment.Status.Ready:   // report success and stop capturing
                            OnTemplate(Enroller.Template);
                            SetPrompt("Haga clic en Cerrar y luego haga clic en Verificación de huellas digitales.");
                            Stop();
                            break;

                        case DPFP.Processing.Enrollment.Status.Failed:  // report failure and restart capturing
                            Enroller.Clear();
                            Stop();
                            UpdateStatus();
                            OnTemplate(null);
                            Start();
                            break;
                    }
                }
        }

        private void capturarHuella_Load(object sender, EventArgs e)
        {

        }
    }
}

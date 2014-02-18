using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Autodesk.Adn.InfrworksService.Models;
using Autodesk.Adn.InfrworksService.Service;
using Autodesk.Adn.OAuthentication;

namespace SampleApp
{
    public partial class Form1 : Form
    {

        // Hard coded consumer and secret keys and base URL.
        // In real world Apps, these values need to secured.
        // One approach is to encrypt and/or obfuscate these values
        private const string m_ConsumerKey = "REPLACE YOUR KEY HERE";
        private const string m_ConsumerSecret = "REPLACE YOUR KEY HERE";
        private const string m_OAuthBaseURL = "REPLACE The OAUTH URL HERE";

        InfraworksRestService iwSvc;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OAuthService oauthSvc = new OAuthService(m_ConsumerKey, m_ConsumerSecret, m_OAuthBaseURL);
            bool authenticated = oauthSvc.StartOAuth();
            if (!authenticated)
            {
                MessageBox.Show("authentication failed.");
                return;
            }
            else
            {
                iwSvc = new InfraworksRestService(oauthSvc);
            }


            List<InfraworksService> allServices = iwSvc.GetServices();
            if (allServices == null) return;

            cbServices.DataSource = allServices;
            cbServices.DisplayMember = "name";
            cbServices.ValueMember = "href";



            bindModeles();
        }

        private void bindModeles()
        {

            List<ModelInfo> allModels = iwSvc.GetModels();
            if (allModels == null) return;

            cbModels.DataSource = allModels;
            cbModels.DisplayMember = "name";
            cbModels.ValueMember = "id";
        }

    

        private void cbModels_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = cbModels.SelectedValue.ToString();
            int modelId;
            Int32.TryParse(id, out modelId);

            ModelInfo modelInfo = iwSvc.GetModelById(modelId);
            if (modelInfo == null) return;

            cbModelClasses.DataSource = modelInfo.modelClasses;
            cbModelClasses.DisplayMember = "name";
            cbModelClasses.ValueMember = "name";
            

        }

        private void cbModelClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}

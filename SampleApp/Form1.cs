using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InfraworkApiLib.Models;
using InfraworkApiLib.Client;

namespace SampleApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bindServices();

            bindModeles();
        }

        private void bindModeles()
        {
            InfraworksRestClient iwSvc = new InfraworksRestClient();
            List<ModelInfo> allModels = iwSvc.GetModels();
            if (allModels == null) return;

            cbModels.DataSource = allModels;
            cbModels.DisplayMember = "name";
            cbModels.ValueMember = "id";
        }

        private void bindServices()
        {
            InfraworksRestClient iwSvc = new InfraworksRestClient();
            List<InfraworksService> allServices = iwSvc.GetServices();
            if (allServices == null) return;

            cbServices.DataSource = allServices;
            cbServices.DisplayMember = "name";
            cbServices.ValueMember = "href";

 

        }

        private void cbModels_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = cbModels.SelectedValue.ToString();
            int modelId;
            Int32.TryParse(id,out modelId);
            InfraworksRestClient iwSvc = new InfraworksRestClient();
            ModelInfo modelInfo = iwSvc.GetModelById(modelId);
            if (modelInfo == null) return;

            cbModelClasses.DataSource = modelInfo.modelClasses;
            cbModelClasses.DisplayMember = "name";
            cbModelClasses.ValueMember = "href";
            

        }
    }
}

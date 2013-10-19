using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.CarSearch
{
    public partial class SearchForm : System.Web.UI.Page
    {
        List<Producer> allProducers;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.allProducers = CreateProducers();

            if (!Page.IsPostBack)
            {
                this.ProducersDropDown.DataSource = this.allProducers;
                this.ProducersDropDown.DataBind();
                this.ProducersDropDown.SelectedIndex = 0;

                this.ModelsDropDown.DataSource = this.allProducers[0].Models;
                this.ModelsDropDown.DataBind();

                var extras = CreateExtras();
                this.ExtrasList.DataSource = extras;
                this.ExtrasList.DataBind();

                this.EnginesList.DataSource = new string[5] { "Petroleum", "Diesel", "Gas", "Electric", "Hybrid" };
                this.EnginesList.DataBind();

                this.EnginesList.SelectedIndex = 0;
            }
        }

        protected void ProducerChanged(object sender, EventArgs e)
        {
            var selectedProducer = this.allProducers.Where(p => p.Name == 
                this.ProducersDropDown.SelectedItem.Text).FirstOrDefault();
            this.ModelsDropDown.DataSource = selectedProducer.Models;
            this.ModelsDropDown.DataBind();
        }

        protected void SubmitData(object sender, EventArgs e)
        {
            StringBuilder results = new StringBuilder();
            var separator = "<br />";
            results.Append("Brand: " + this.ProducersDropDown.SelectedItem.Text + separator);
            results.Append("Model: " + this.ModelsDropDown.SelectedItem.Text + separator);
            results.Append("Extras:" + separator);
            bool isSelected = false;
            foreach (ListItem item in this.ExtrasList.Items)
            {
                if (item.Selected)
                {
                    isSelected = true;
                    results.Append("-" + item.Text + separator);
                }
            }

            if (!isSelected)
            {
                results.Append("-None." + separator);
            }

            results.Append("Engine: " + this.EnginesList.SelectedItem.Text + separator);

            this.ResultView.Text = results.ToString();
        }

        private List<Extra> CreateExtras()
        {
            List<Extra> extras = new List<Extra>();
            extras.Add(new Extra()
            {
                Name = "Air Conditioner"
            });

            extras.Add(new Extra()
            {
                Name = "On-board computer"
            });

            extras.Add(new Extra()
            {
                Name = "Full digital stereo system"
            });

            extras.Add(new Extra()
            {
                Name = "Nitro"
            });

            extras.Add(new Extra()
            {
                Name = "Personal android"
            });

            return extras;
        }

        private List<Producer> CreateProducers()
        {
            List<Producer> producers = new List<Producer>();
            producers.Add(new Producer(){
                Name = "BMW",
                Models = new List<string> {
                    "E85",
                    "E70",
                    "E81",
                    "E65"
                }
            });

            producers.Add(new Producer()
            {
                Name = "Mercedes-Benz",
                Models = new List<string> {
                    "W163",
                    "W164",
                    "R170"
                }
            });

            producers.Add(new Producer()
            {
                Name = "Opel",
                Models = new List<string> {
                    "GT",
                    "Meriva A",
                    "Sintra",
                    "Antara",
                    "Blitz"
                }
            });

            return producers;
        }
    }
}
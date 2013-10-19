using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.LinkMenu
{
    public partial class LinkMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public List<Link> DataSource
        {
            get;
            set; 
        }

        public string Font
        {
            get
            {
                return this.LinkMenuDataList.Font.Name;
            }

            set
            {
                this.LinkMenuDataList.Font.Name = value;
            }
        }

        public Color color;

        public Color Color
        {
            get
            {
                return this.color;
            }

            set
            {
                
                this.color = value;              
            }
        }


        protected void LinkMenuDataList_DataBinding(object sender, EventArgs e)
        {
            
        }

        protected override void OnDataBinding(EventArgs e)
        {
            this.LinkMenuDataList.DataSource = this.DataSource;
            this.LinkMenuDataList.DataBind();
        }

        protected void LinkMenuDataList_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            var item = (HyperLink)e.Item.FindControl("LinkItem");
            item.ForeColor = this.Color;
            this.Font = this.Font;
        }
    }
}
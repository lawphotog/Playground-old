using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var radioList = new List<Category>() {
                new Category { Id = 1, Text = "Primary"},
                new Category { Id = 2, Text = "Secondary"},
                new Category { Id = 3, Text = "Alis"}
            };

                RadioButtonList1.DataSource = radioList;
                RadioButtonList1.DataValueField = "Id";
                RadioButtonList1.DataTextField = "Text";
                RadioButtonList1.DataBind();

                GridView1.DataSource = GetPdfs();
                GridView1.DataBind();
            }

            
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var category = RadioButtonList1.SelectedItem.Text;

            var res = FilterData(category);
            GridView1.DataSource = res;
            GridView1.DataBind();

        }

        protected List<pdf> GetPdfs()
        {
            var pdfs = new List<pdf>()
            {
                new pdf { Id = 1, Name = "hello", Category = "Primary"},
                new pdf { Id = 1, Name = "hello", Category = "Primary"},
                new pdf { Id = 1, Name = "hello", Category = "Secondary"},
                new pdf { Id = 1, Name = "hello", Category = "Secondary"},
                new pdf { Id = 1, Name = "hello", Category = "Alis"},
                new pdf { Id = 1, Name = "hello", Category = "Alis"},
            };

            return pdfs;
        }

        private List<pdf> FilterData(string category)
        {
            var pdfs = GetPdfs();

            var res = pdfs.Where(c => c.Category == category);

            return res.ToList();
        }

        
    }
}
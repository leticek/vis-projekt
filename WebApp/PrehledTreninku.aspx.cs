using BusinessLayer;
using BusinessLayer.Models;
using PresentationLayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AktualniUzivatel<KlientModel>.Uzivatel = new KlientModel(13, "Shoshana", "Clayton", DateTime.Now, "Nunc@ornare.ca", "(536) 149-5243", 1, 13);
            //RegisterAsyncTask(new PageAsyncTask(LoadData));
        }



        protected void calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            PrehledTreninkuController.setDay(e);
        }

        protected void calendar1_Init(object sender, EventArgs e)
        {
            
        }

        public async Task LoadData()
        {

            await PrehledTreninkuController.loadTreninky();
        }
    }
}
using BusinessLayer;
using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace PresentationLayer
{
    public static class PrehledTreninkuController
    {

        private static List<PlanovanyTreninkModel> treninky = new List<PlanovanyTreninkModel>();

        public async static Task loadTreninky()
        {
            treninky = await PlanovanyTreninkModel.GetAllByKlientId(AktualniUzivatel<KlientModel>.Uzivatel.Id);
        }


        public static void setDay(DayRenderEventArgs e)
        {
            foreach(PlanovanyTreninkModel trenink in treninky)
            {
                string currentDay = e.Day.Date.ToShortDateString();
                string denTreninku = trenink.CasKonani.ToShortDateString();
                if (currentDay.Equals(denTreninku))
                {
                    if (trenink.Potvrzen)
                        e.Cell.BackColor = Color.Green;
                    else
                        e.Cell.BackColor = Color.Red;
                }
            }
        }
    } 
}

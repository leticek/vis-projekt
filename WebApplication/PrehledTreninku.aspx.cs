using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using WebAppPresentationLayer;

namespace WebApplication
{
    public partial class PrehledTreninkuForm : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            AktualniUzivatel<KlientModel>.Uzivatel = new KlientModel(13, "Shoshana", "Clayton", DateTime.Now.ToUniversalTime(), "Nunc@ornare.ca", "(536) 149-5243", 1, 13);
            await PrehledTreninkuController.LoadTreninky();
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            PrehledTreninkuController.SetDay(e);
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {

            switch (PrehledTreninkuController.HandleDaySelected(sender, e, Calendar1))
            {
                case 0:
                    PrehledTreninkuController.Hide(new List<WebControl> { coachName, time, notes, acceptBtton, rejectButton, proposedDate, TextArea1, errorText });
                    break;
                case 1:
                    PrehledTreninkuController.SetText(coachName, time, notes);
                    PrehledTreninkuController.Show(new List<WebControl> { coachName, time, notes });
                    PrehledTreninkuController.Hide(new List<WebControl> { acceptBtton, rejectButton, proposedDate, TextArea1, errorText });
                    break;
                case 2:
                    PrehledTreninkuController.SetText(coachName, time, notes); //todo
                    PrehledTreninkuController.Show(new List<WebControl> { coachName, time, notes, acceptBtton, rejectButton, proposedDate, TextArea1 });
                    break;
            }

        }

        protected void AcceptBtton_Click(object sender, EventArgs e)
        {
            PrehledTreninkuController.Hide(new List<WebControl> { coachName, time, notes, acceptBtton, rejectButton, proposedDate, TextArea1 });
            PrehledTreninkuController.HandleAccept();
        }

        protected async void RejectButton_Click(object sender, EventArgs e)
        {
            //PrehledTreninkuController.hide(new List<WebControl> { coachName, time, notes, acceptBtton, rejectButton, proposedDate, TextArea1 });
            if (!await PrehledTreninkuController.HandleReject(proposedDate, TextArea1))
            {
                PrehledTreninkuController.Show(new List<WebControl> { errorText });
            }
            else
                PrehledTreninkuController.Hide(new List<WebControl> { errorText, coachName, time, notes, acceptBtton, rejectButton, proposedDate, TextArea1 });
        }
    }
}
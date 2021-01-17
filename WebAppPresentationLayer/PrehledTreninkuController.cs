using BusinessLayer;
using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace WebAppPresentationLayer
{
    public static class PrehledTreninkuController
    {

        private static List<PlanovanyTreninkModel> treninky = new List<PlanovanyTreninkModel>();
        private static PlanovanyTreninkModel currentSelection = null;
        private static TrenerModel currentTrener = null;

        public async static Task LoadTreninky()
        {
            treninky = await PlanovanyTreninkModel.GetAllByKlientId(AktualniUzivatel<KlientModel>.Uzivatel.Id);
            foreach (PlanovanyTreninkModel t in treninky)
            {
                Debug.WriteLine(t.ToString());
            }
        }

        public static void SetDay(DayRenderEventArgs e)
        {
            foreach (PlanovanyTreninkModel trenink in treninky)
            {
                string currentDay = e.Day.Date.ToShortDateString();
                string denTreninku = trenink.CasKonani.ToShortDateString();
                if (currentDay.Equals(denTreninku))
                {
                    e.Cell.ID = trenink.Id.ToString();
                    Debug.WriteLine(e.Cell.ID);
                    if (trenink.Potvrzen)
                        e.Cell.BackColor = Color.Green;
                    else
                        e.Cell.BackColor = Color.Red;
                }
            }
        }

        public static void Show(List<WebControl> controls) => controls.ForEach(x => x.Visible = true);




        public static void Hide(List<WebControl> controls) => controls.ForEach(x => x.Visible = false);

        public static async void HandleAccept()
        {
            currentSelection.Potvrzen = true;
            string body = $"Dobrý den, informujeme vás, že Váš naplánovaný trénink byl přijat.\n" +
                    $"\nS pozdravem Fitness Informační systém.";
            EmailSender.SendEmail(currentTrener.Jmeno + ' ' + currentTrener.Prijmeni, "Trénink byl odmítnut", body);
            await PlanovanyTreninkModel.Save(currentSelection);
            await LoadTreninky();
        }

        public static void SetText(Label coachName, Label time, Label notes)
        {
            time.Text = currentSelection.CasKonani.ToString();
            notes.Text = currentSelection.Poznamka;
            coachName.Text = currentTrener.Jmeno + ' ' + currentTrener.Prijmeni;
        }

        public static async Task<bool> HandleReject(Calendar proposedDate, TextBox textArea1)
        {

            if (proposedDate.SelectedDates.Count == 0 || textArea1.Text.Length == 0 || DateTime.Now.CompareTo(proposedDate.SelectedDate.Date) >= 0)
                return false;
            else
            {
                await PlanovanyTreninkModel.Remove(currentSelection);
                string body = $"Dobrý den, informujeme vás, že Váš naplánovaný trénink byl odmítnut.\n Důvodem odmítnutí je: {textArea1.Text} \n" +
                    $"\n Klient navrhuje náhradní datum {proposedDate.SelectedDate.ToShortDateString()}" +
                    $"\nS pozdravem Fitness Informační systém.";
                EmailSender.SendEmail(currentTrener.Jmeno + ' ' + currentTrener.Prijmeni, "Trénink byl odmítnut", body);
                proposedDate.SelectedDate = DateTime.Now;
                textArea1.Text = "";
                await LoadTreninky();
                return true;
            }
        }

        public static int HandleDaySelected(object sender, EventArgs e, Calendar calendar)
        {

            List<PlanovanyTreninkModel> tmp = treninky.Where(x => x.IdKlienta == AktualniUzivatel<KlientModel>.Uzivatel.Id).ToList();
            tmp = tmp.Where(x => calendar.SelectedDate.Day == x.CasKonani.Day &&
                                            calendar.SelectedDate.Month == x.CasKonani.Month &&
                                            calendar.SelectedDate.Year == x.CasKonani.Year).ToList();
            if (tmp.Count == 0)
                return 0; //nic
            foreach (PlanovanyTreninkModel t in tmp)
            {
                currentSelection = t;
                currentTrener = TrenerModel.GetById(t.IdTrenera);
                if (t.Potvrzen)
                    return 1; // jen display
                Debug.WriteLine(DateTime.Now.ToString());
                Debug.WriteLine(t.ToString());
            }
            return 2; // display i s formem

        }



    }
}

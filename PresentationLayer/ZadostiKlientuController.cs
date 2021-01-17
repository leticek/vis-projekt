using BusinessLayer;
using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public static class ZadostiKlientuController
    {
        private static List<ZadostModel> zadosti = new List<ZadostModel>();
        private static readonly List<KlientModel> klienti = new List<KlientModel>();
        public static async void LoadZadosti(DataGridView dataGridView)
        {
            zadosti.Clear();
            klienti.Clear();
            dataGridView.Rows.Clear();
            zadosti = await ZadostModel.GetByTrenerId(AktualniUzivatel<TrenerModel>.Uzivatel.Id);
            List<KlientModel> tmp = KlientModel.GetByTrenerId(AktualniUzivatel<TrenerModel>.Uzivatel.Id);
            foreach (ZadostModel zadost in zadosti)
            {
                klienti.Add(tmp.Where(x => x.SpolupraceId == zadost.SpolupraceId).ToList()[0]);
                DataGridViewRow row = (DataGridViewRow)dataGridView.RowTemplate.Clone();
                row.Tag = zadost.Id;
                string buttonText = zadost.TypZadosti == DTO.Enums.TypZadosti.ZRUSENI ? "Přijmout" : "Vyřídit";
                string typ = zadost.TypZadosti == DTO.Enums.TypZadosti.ZRUSENI ? "Zrušení" : "Prodloužení";
                row.CreateCells(dataGridView, new[] { zadost.Datum.ToLocalTime().ToShortDateString(),
                    klienti.Where(x => x.SpolupraceId == zadost.SpolupraceId).ToList()[0].Jmeno,
                    klienti.Where(x => x.SpolupraceId == zadost.SpolupraceId).ToList()[0].Prijmeni,
                    typ,
                    buttonText
                });
                dataGridView.Rows.Add(row);
            }
        }

        public static bool OdmitnoutZadost(DataGridView dgw, DataGridViewCellMouseEventArgs e, string reason)
        {
            if (reason.Length <= 0)
            {
                return false;
            }
            int idZadosti = (int)dgw.Rows[e.RowIndex].Tag;
            ZadostModel zadost = zadosti.Where(x => x.Id == idZadosti).ToList()[0];
            ZadostModel.DeleteById(zadost);
            string clientName = klienti.Where(x => x.SpolupraceId == zadost.SpolupraceId).ToList()[0].Jmeno +
                    " " + klienti.Where(x => x.SpolupraceId == zadost.SpolupraceId).ToList()[0].Prijmeni;
            string subject = "Spolupráce nebyla prodloužena";
            string body = $"Dobrý den, trenér odmítl Váš požadavek z následujících důvodů: \n {reason} \nS pozdravem VIS-FITNESS";
            EmailSender.SendEmail(clientName, subject, body);
            return true;
        }

        public static void PrijmoutZadost(DataGridView dgw, DataGridViewCellMouseEventArgs e)
        {
            int idZadosti = (int)dgw.Rows[e.RowIndex].Tag;
            ZadostModel zadost = zadosti.Where(x => x.Id == idZadosti).ToList()[0];
            ZadostModel.DeleteById(zadost);
            SpolupraceModel.ProdlouzitSpolupraci(zadost.SpolupraceId);
            string clientName = klienti.Where(x => x.SpolupraceId == zadost.SpolupraceId).ToList()[0].Jmeno +
                    " " + klienti.Where(x => x.SpolupraceId == zadost.SpolupraceId).ToList()[0].Prijmeni;
            string subject = "Spolupráce prodloužena";
            string body = "Dobrý den, \ntrenér přijal Váš požadavek o prodloužení spolupráce. \nS pozdravem VIS-FITNESS";
            EmailSender.SendEmail(clientName, subject, body);
        }

        public static bool HandleMouseClick(DataGridView dgw, DataGridViewCellMouseEventArgs e)
        {
            int idZadosti = (int)dgw.Rows[e.RowIndex].Tag;
            ZadostModel zadost = zadosti.Where(x => x.Id == idZadosti).ToList()[0];
            if (zadost.TypZadosti == DTO.Enums.TypZadosti.ZRUSENI)
            {
                string clientName = klienti.Where(x => x.SpolupraceId == zadost.SpolupraceId).ToList()[0].Jmeno +
                    " " + klienti.Where(x => x.SpolupraceId == zadost.SpolupraceId).ToList()[0].Prijmeni;
                MessageBox.Show($"{clientName} zrušil s Vámi spolupráci.", "Oznámení");
                PrijmoutUkonceniSpoluprace(zadost);
                string subject = "Trener přijal vaše oznámení";
                string body = "Dobrý den, \ntrenér byl informován o zrušení Vaší spolupráce. \nS pozdravem VIS-FITNESS";
                EmailSender.SendEmail(clientName, subject, body);
                LoadZadosti(dgw);
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void PrijmoutUkonceniSpoluprace(ZadostModel zadost)
        {
            ZadostModel.DeleteById(zadost);
            KlientModel.DeleteById(klienti.Where(x => x.SpolupraceId == zadost.SpolupraceId).ToList()[0].Id);
            SpolupraceModel.DeleteById(zadost.SpolupraceId);
        }
    }
}

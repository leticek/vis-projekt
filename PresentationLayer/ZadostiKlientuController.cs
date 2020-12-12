using BusinessLayer;
using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public static class ZadostiKlientuController
    {
        private static List<ZadostModel> zadosti = new List<ZadostModel>();
        private static List<KlientModel> klienti = new List<KlientModel>();
        public static async void LoadZadosti(DataGridView dataGridView)
        {
            ZadostModel z = new ZadostModel();
            zadosti = await ZadostModel.GetByTrenerId(AktualniUzivatel<TrenerModel>.Uzivatel.Id);
            List<KlientModel> tmp = KlientModel.GetByTrenerId(AktualniUzivatel<TrenerModel>.Uzivatel.Id);
            foreach (ZadostModel zadost in zadosti)
            {
                klienti.Add(tmp.Where(x => x.SpolupraceId == zadost.SpolupraceId).ToList()[0]);
                DataGridViewRow row = (DataGridViewRow)dataGridView.RowTemplate.Clone();
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

    }
}

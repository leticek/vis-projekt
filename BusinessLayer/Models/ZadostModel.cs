using DataLayer.FirestoreMappers;
using DataLayer.MSSQLMappers;
using DTO.DTO;
using DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class ZadostModel
    {
        public ZadostModel()
        {

        }

        public ZadostModel(ZadostDTO zadostDTO)
        {
            Id = zadostDTO.Id;
            SpolupraceId = zadostDTO.SpolupraceId;
            TypZadosti = zadostDTO.TypZadosti;
            Datum = zadostDTO.Datum;

        }
        public int Id { get; set; }
        public int SpolupraceId { get; set; }
        public TypZadosti TypZadosti { get; set; }
        public DateTime Datum { get; set; }
        ZadostDTO ToDTO() => new ZadostDTO(Id, SpolupraceId, TypZadosti, Datum);
        public override string ToString()
        {
            return $"ID: {Id} SpolupraceId: {SpolupraceId} TypZadost: {TypZadosti} Datum {Datum}";
        }

        public static async Task<List<ZadostModel>> GetByTrenerId(int id)
        {
            SpolupraceDataMapper spolupraceDataMapper = new SpolupraceDataMapper();
            List<SpolupraceDTO> spolupraceResult = new List<SpolupraceDTO>();
            spolupraceResult = spolupraceDataMapper.GetAll();
            spolupraceResult = spolupraceResult.Where(x => x.TrenerId == id).ToList();
            List<ZadostDTO> zadostDTOs = new List<ZadostDTO>();
            FirestoreDataMapper<ZadostDTO> zadostMapper = new FirestoreDataMapper<ZadostDTO>();
            foreach (SpolupraceDTO spoluprace in spolupraceResult)
            {
                List<ZadostDTO> tmp = await zadostMapper.GetByParameter("SpolupraceId", spoluprace.SpolupraceId);
                if (tmp.Count > 0)
                {
                    ZadostDTO zadost = tmp[0];
                    zadostDTOs.Add(zadost);
                }
            }
            List<ZadostModel> result = zadostDTOs.Select(x => new ZadostModel(x)).ToList();
            return result;
        }

        public async static void DeleteById(ZadostModel zadost)
        {
            FirestoreDataMapper<ZadostDTO> firestoreDataMapper = new FirestoreDataMapper<ZadostDTO>();
            SpolupraceDataMapper spolupraceDataMapper = new SpolupraceDataMapper();
            await firestoreDataMapper.Delete(zadost.Id);
        }

    }
}

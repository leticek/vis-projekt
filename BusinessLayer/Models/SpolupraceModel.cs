﻿using DataLayer.MSSQLMappers;
using DTO.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class SpolupraceModel
    {
        public SpolupraceModel(int spolupraceId, int trenerId, DateTime platnost, decimal cena)
        {
            this.SpolupraceId = spolupraceId;
            this.TrenerId = trenerId;
            this.Platnost = platnost;
            this.Cena = cena;
        }

        public SpolupraceModel(SpolupraceDTO spolupraceDTO)
        {
            this.SpolupraceId = spolupraceDTO.SpolupraceId;
            this.TrenerId = spolupraceDTO.TrenerId;
            this.Platnost = spolupraceDTO.Platnost;
            this.Cena = spolupraceDTO.Cena;
        }

        public int SpolupraceId { get; set; }
        public int TrenerId { get; set; }
        public TrenerModel Trener { get; set; }
        public DateTime Platnost { get; set; }
        public decimal Cena { get; set; }

        public SpolupraceDTO ToDTO() => new SpolupraceDTO(SpolupraceId, TrenerId, Platnost, Cena);

        public static void ProdlouzitSpolupraci(int id)
        {
            SpolupraceDataMapper spolupraceDataMapper = new SpolupraceDataMapper();
            SpolupraceDTO spolupraceDTO = spolupraceDataMapper.GetById(id);
            spolupraceDTO.Platnost = spolupraceDTO.Platnost.AddDays(30);
            spolupraceDataMapper.Update(spolupraceDTO);
        }

        public override string ToString()
        {
            return $"ID: {this.SpolupraceId} TrenerID: {this.TrenerId} Platnost: {this.Platnost} Cena: {this.Cena}";
        }

        public static void DeleteById(int spolupraceId)
        {
            SpolupraceDataMapper spolupraceDataMapper = new SpolupraceDataMapper();
            spolupraceDataMapper.Delete(spolupraceId);
        }
    }
}

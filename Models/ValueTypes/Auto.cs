using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;

namespace People.Models.ValueTypes
{
    public class Auto
    {
        public string Targa { get; set; }

        public string Marca { get; set; }

        public string Modello { get; set; }

        public string Colore { get; set; }

        public Auto(string targa, string marca, string modello, string colore)
        {
            this.Targa = targa;
            this.Marca = marca;
            this.Modello = modello;
            this.Colore = colore;
        }

        public static Auto FromDataRow(DataRow carRow)
        {
            var car = new Auto
            (
                Convert.ToString(carRow["Targa"]),
                Convert.ToString(carRow["Marca"]),
                Convert.ToString(carRow["Modello"]),
                Convert.ToString(carRow["Colore"])
            );

        return car;
        }
    }
}
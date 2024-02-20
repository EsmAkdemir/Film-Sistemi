using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmKütüphanesiYönetimSistemi
{
     public class FilmData
    {
        public int FilmId { get; set; }
        public string FilmName { get; set; }
        public string Director { get; set; }
        public string ImagePath { get; set; }
        public string PosterPath { get; set; }
        public string Description { get; set; }
        public double OrtPuan { get; set; }
        public int Yorum { get; set; }


    }
}

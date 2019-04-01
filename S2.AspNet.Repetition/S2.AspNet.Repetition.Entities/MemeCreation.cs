using System;
using System.Collections.Generic;
using System.Text;

namespace S2.AspNet.Repetition.Entities
{
    public class MemeCreation
    {
        public MemeCreation()
        {

        }

        public MemeCreation(int id, MemeImage memeImg, DateTime creationDate, string memeText, string position, string color, string size)
        {
            Id = id;
            MemeImg = memeImg;
            CreationDate = creationDate;
            MemeText = memeText;
            Position = position;
            Color = color;
            Size = size;
        }

        public int Id { get; set; }
        public MemeImage MemeImg { get; set; }
        public DateTime CreationDate { get; set; }
        public string MemeText { get; set; }
        public string Position { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
    }
}

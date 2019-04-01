using S2.AspNet.Repetition.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace S2.AspNet.Repetition.DAL
{
    public class MemeImageRepository : BaseRepository
    {
        public MemeImageRepository(string conString) : base(conString)
        {
        }

        public List<MemeImage> GetAllMemeImages()
        {
            List<MemeImage> memeImages = new List<MemeImage>();

            string sql = "SELECT * FROM MemeImages";

            DataTable memeImagesTable = ExecuteQuery(sql);

            foreach (DataRow row in memeImagesTable.Rows)
            {
                int id = (int)row["Id"];
                string url = (string)row["Url"];
                string altText = (string)row["AltText"];

                MemeImage memeImage = new MemeImage(id, url, altText);

                memeImages.Add(memeImage);
            }


            return memeImages;
        }

        public string GetUrlFrom(int imageId)
        {
            string sql = $"SELECT Url FROM MemeImages WHERE Id ={imageId}";

            DataTable memeImagesTable = ExecuteQuery(sql);

            if (memeImagesTable.Rows.Count == 1)
            {
                return (string)memeImagesTable.Rows[0]["Url"];
            }
            else
            {
                throw new ArgumentException($"MemeImage with id={imageId} was not found");
            }
        }

        public MemeImage GetMemeImage(int imageSelected)
        {
            string sql = $"SELECT * FROM MemeImages WHERE Id={imageSelected}";

            DataTable memeImagesTable = ExecuteQuery(sql);

            if (memeImagesTable.Rows.Count == 1)
            {
                int id = (int)memeImagesTable.Rows[0]["Id"];
                string url = (string)memeImagesTable.Rows[0]["Url"];
                string altText = (string)memeImagesTable.Rows[0]["AltText"];

                MemeImage memeImage = new MemeImage(id, url, altText);
                return memeImage;
            }
            else
            {
                throw new ArgumentException($"MemeImage with id={imageSelected} was not found");
            }
        }
        public MemeImage GetMostUsedImg()
        {
            string sql = $"SELECT TOP(1) COUNT(MemeImages.Id) as Occurences, Url, AltText FROM MemeImages JOIN MemeCreations ON MemeCreations.MemeImg = MemeImages.Id GROUP BY Url, AltText ORDER BY Occurences DESC";

            DataTable memeImagesTable = ExecuteQuery(sql);

            if (memeImagesTable.Rows.Count == 1)
            {
                int id = (int)memeImagesTable.Rows[0]["Occurences"];
                string url = (string)memeImagesTable.Rows[0]["Url"];
                string altText = (string)memeImagesTable.Rows[0]["AltText"];

                MemeImage memeImage = new MemeImage(id, url, altText);
                return memeImage;
            }
            else
            {
                throw new ArgumentException($"MemeImage was not found");
            }
        }
    }
}

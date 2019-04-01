using S2.AspNet.Repetition.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace S2.AspNet.Repetition.DAL
{
    public class MemeCreationRepository : BaseRepository
    {
        public MemeCreationRepository(string conString) : base(conString)
        {
        }

        public int Insert(MemeCreation memeCreation)
        {
            string sql = $"INSERT INTO MemeCreations VALUES(" +
                $"{memeCreation.MemeImg.Id}, " +
                $"CURRENT_TIMESTAMP, " +
                $"'{memeCreation.MemeText}', " +
                $"'{memeCreation.Position}', " +
                $"'{memeCreation.Color}', " +
                $"'{memeCreation.Size}')";

            return ExecuteNonQuery(sql);
        }

        public MemeCreation GetRandomMeme()
        {
            string sql = $"SELECT TOP(1) MemeCreations.*, MemeImages.Url, MemeImages.AltText FROM MemeCreations JOIN MemeImages ON MemeCreations.MemeImg = MemeImages.Id ORDER BY NEWID()";

            DataTable memeCreationsTable = ExecuteQuery(sql);

            if (memeCreationsTable.Rows.Count == 1)
            {
                int memeCreationsId = (int)memeCreationsTable.Rows[0]["Id"];
                string url = (string)memeCreationsTable.Rows[0]["Url"];
                string altText = (string)memeCreationsTable.Rows[0]["AltText"];
                int memeImageId = (int)memeCreationsTable.Rows[0]["MemeImg"];
                DateTime creationTime = (DateTime)memeCreationsTable.Rows[0]["TimeStamp"];
                string memeText = (string)memeCreationsTable.Rows[0]["MemeText"];
                string position = (string)memeCreationsTable.Rows[0]["Position"];
                string color = (string)memeCreationsTable.Rows[0]["Color"];
                string size = (string)memeCreationsTable.Rows[0]["Size"];
                                
                MemeImage memeImage = new MemeImage(memeImageId, url, altText);
                MemeCreation memeCreation = new MemeCreation(memeCreationsId, memeImage, creationTime, memeText, position, color, size);
                return memeCreation;
            }
            else
            {
                throw new ArgumentException($"GetRandomMeme was not found");
            }
        }

        public MemeCreation GetMostRecentMeme()
        {
            string sql = $"SELECT TOP(1) MemeCreations.*, MemeImages.Url, MemeImages.AltText FROM MemeCreations JOIN MemeImages ON MemeCreations.MemeImg = MemeImages.Id ORDER BY TimeStamp DESC";

            DataTable memeCreationsTable = ExecuteQuery(sql);

            if (memeCreationsTable.Rows.Count == 1)
            {
                int memeCreationsId = (int)memeCreationsTable.Rows[0]["Id"];
                string url = (string)memeCreationsTable.Rows[0]["Url"];
                string altText = (string)memeCreationsTable.Rows[0]["AltText"];
                int memeImageId = (int)memeCreationsTable.Rows[0]["MemeImg"];
                DateTime creationTime = (DateTime)memeCreationsTable.Rows[0]["TimeStamp"];
                string memeText = (string)memeCreationsTable.Rows[0]["MemeText"];
                string position = (string)memeCreationsTable.Rows[0]["Position"];
                string color = (string)memeCreationsTable.Rows[0]["Color"];
                string size = (string)memeCreationsTable.Rows[0]["Size"];

                MemeImage memeImage = new MemeImage(memeImageId, url, altText);
                MemeCreation memeCreation = new MemeCreation(memeCreationsId, memeImage, creationTime, memeText, position, color, size);
                return memeCreation;
            }
            else
            {
                throw new ArgumentException($"GetMostRecentMeme was not found");
            }
        }
        public MemeCreation GetMostUsedPosition()
        {
            string sql = $"SELECT TOP(1) COUNT(Id) as TimesUsed, Position FROM MemeCreations GROUP BY Position ORDER BY TimesUsed DESC";

            DataTable memeCreationsTable = ExecuteQuery(sql);

            if (memeCreationsTable.Rows.Count == 1)
            {
                int memeCreationsId = (int)memeCreationsTable.Rows[0]["TimesUsed"];
                string position = (string)memeCreationsTable.Rows[0]["Position"];
                
                MemeCreation memeCreation = new MemeCreation()
                {
                    Id = memeCreationsId,
                    Position = position
                };
                return memeCreation;
            }
            else
            {
                throw new ArgumentException($"GetMostUsedPosition was not found");
            }
        }
        public MemeCreation GetMostUsedColor()
        {
            string sql = $"SELECT TOP(1) COUNT(Id) as TimesUsed, Color FROM MemeCreations GROUP BY Color ORDER BY TimesUsed DESC";

            DataTable memeCreationsTable = ExecuteQuery(sql);

            if (memeCreationsTable.Rows.Count == 1)
            {
                int memeCreationsId = (int)memeCreationsTable.Rows[0]["TimesUsed"];
                string color = (string)memeCreationsTable.Rows[0]["Color"];

                MemeCreation memeCreation = new MemeCreation()
                {
                    Id = memeCreationsId,
                    Color = color
                };
                return memeCreation;
            }
            else
            {
                throw new ArgumentException($"GetMostUsedColor was not found");
            }
        }
    }
}

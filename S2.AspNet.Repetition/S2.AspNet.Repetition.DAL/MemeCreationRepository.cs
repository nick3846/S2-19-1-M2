using S2.AspNet.Repetition.Entities;
using System;
using System.Collections.Generic;
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
    }
}

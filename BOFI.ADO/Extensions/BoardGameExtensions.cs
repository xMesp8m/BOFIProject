using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOFI.Model;

namespace BOFI.Dao.Extensions
{
    public static class BoardGameExtensions
    {
        public static BoardGame ToBoardGameObject(this DataRow item)
        {
            try
            {
                var response = new BoardGame
                    {
                        Id = item[0].ToString(),
                        Name = item[1].ToString(),
                        Description = item[2].ToString(),
                        DateCreated = item[3].ToDateTime(),
                        DateUpdated = item[4].ToDateTime(),
                    };
                return response;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static DateTime ToDateTime(this object obj)
        {
            return obj == null ? DateTime.MinValue : Convert.ToDateTime(obj);
        }
    }
}

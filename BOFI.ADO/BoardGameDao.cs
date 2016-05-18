using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using BOFI.Contracts.Dao;
using BOFI.Dao.Extensions;
using BOFI.Model;

namespace BOFI.Dao
{
    public class BoardGameDao : IBoardGameDao
    {
        private readonly DataSet _context;
        private readonly DataTable _dt = new DataTable("BoardGame");
        const int BoardGameTableId = 0;


        public BoardGameDao()
        {
            _context = GetDbContext();
        }

        public IEnumerable<BoardGame> GetAll()
        {
            var response = _context.Tables[BoardGameTableId].AsEnumerable()
                .Select(x => x.ToBoardGameObject());
            return response;
        }

        public BoardGame Add(BoardGame boardGame)
        {
            var item = _dt.NewRow();
            item[0] = boardGame.Id;
            item[1] = boardGame.Name;
            item[2] = boardGame.Description;
            item[3] = boardGame.DateCreated;
            item[4] = boardGame.DateUpdated;
            try
            {
                _context.Tables[BoardGameTableId].Rows.Add(item);
                _context.WriteXml(DbFile);
                return boardGame;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public bool Update(BoardGame boardGame)
        {
            try
            {
                var item = _context.Tables[BoardGameTableId]
                        .AsEnumerable()
                        .FirstOrDefault(x => x.Field<string>("Id") == boardGame.Id);

                if (item == null) return false;
                item[1] = boardGame.Name;
                item[2] = boardGame.Description;
                item[4] = DateTime.Now;
                _context.WriteXml(DbFile);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Remove(string boardGameId)
        {
            try
            {
                var itemToRemove = _context.Tables[BoardGameTableId].AsEnumerable()
                       .FirstOrDefault(x => x.Field<string>("Id") == boardGameId);
                if (itemToRemove == null) return false;
                _context.Tables[BoardGameTableId].Rows.Remove(itemToRemove);
                _context.WriteXml(DbFile);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public BoardGame GetById(string boardGameId)
        {
            var item = _context.Tables[BoardGameTableId]
                .AsEnumerable()
                .FirstOrDefault(x => x.Field<string>("Id") == boardGameId);
            return item == null ? null : item.ToBoardGameObject();
        }

        #region Private
        private String DbFile
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                var assemblyPath = Path.GetDirectoryName(path);
                return Path.Combine(assemblyPath, "BOFIDB", "DbBofi.xml");
                //return Path.Combine(
                //    new Uri(Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)))
                //    .LocalPath, "Local", "BOFI", "DbBOFI.xml");
            }
        }
        private DataSet GetDbContext()
        {
            var ds = new DataSet("BOFI");
            if (!File.Exists(DbFile))
            {
                var dirName = Path.GetDirectoryName(DbFile);
                var folderExist = Directory.Exists(dirName);
                if (!folderExist)
                {
                    Directory.CreateDirectory(dirName);
                }
                ds.WriteXml(DbFile);
            }
            CreateSchema(ds);
            ds.ReadXml(DbFile);
            return ds;

        }

        private void CreateSchema(DataSet ds)
        {
            _dt.Columns.Add("Id", typeof(string));
            _dt.Columns.Add("Name", typeof(string));
            _dt.Columns.Add("Description", typeof(string));
            _dt.Columns.Add("DateCreated", typeof(DateTime));
            _dt.Columns.Add("DateUpdated", typeof(DateTime));
            ds.Tables.Add(_dt);
        }
        #endregion
    }
}

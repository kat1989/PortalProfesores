using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DataAccess
{
    public class BaseRepository<TEntity> where TEntity : class, new()
    {

        #region Miembros
        private readonly JenzabarEntities _context;
        #endregion

        public BaseRepository()
        {
            _context =new JenzabarEntities();
        }
        /// <summary>
        /// Permite ejecutar consultas SQL Limpias (RAW_SQL)
        /// </summary>
        /// <param name="query">Query o consulta a realizar.</param>
        /// <param name="parameters">Argumentos para la consulta</param>
        /// <returns>Lista de valores en base al resultado</returns>
        public ICollection<TEntity> ExecSqlCollection(string query, params object[] parameters)
        {
            var result = _context.ExecuteStoreQuery<TEntity>(query, parameters).ToList();

            return result;
        }

        public TEntity ExecSqlCollectionSingle(string query, params object[] parameters)
        {
            var result = _context.ExecuteStoreQuery<TEntity>(query, parameters).FirstOrDefault();

            return result;
        }

        public int ExcecuteProcedure(string query, params object[] parameters)
        {
            return _context.ExecuteStoreCommand(query, parameters);
        }
    }
}

using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public class RequestMethods : IRequestMethods
    {
        public List<Output> GetMatsTwo(decimal qty)
        {

            DataAccess objData = new DataAccess();
            objData.AddParameter("pqty", qty);
            objData.CommandText = "sr_GET_MATS2";
            objData.CommandType = CommandType.StoredProcedure;

            DataTable tempdt = objData.ReturnDataTable();

            var _output = (from DataRow dr in tempdt.Rows
                           select new Output
                           {
                               description = dr["description"].ToString(),
                               qty = decimal.Parse(dr["qty"].ToString()),
                               uom = dr["uom"].ToString(),
                               hasraw = 0
                           }).ToList();

            return _output;

        }

        public List<Output> GetMatsThree(decimal qty)
        {

            DataAccess objData = new DataAccess();
            objData.AddParameter("pqty", qty);
            objData.CommandText = "sr_GET_MATS3";
            objData.CommandType = CommandType.StoredProcedure;

            DataTable tempdt = objData.ReturnDataTable();

            var _output = (from DataRow dr in tempdt.Rows
                           select new Output
                           {
                               description = dr["description"].ToString(),
                               qty = decimal.Parse(dr["qty"].ToString()),
                               uom = dr["uom"].ToString(),
                               hasraw = int.Parse(dr["hasraw"].ToString())
                           }).ToList();

            return _output;

        }
        public List<Output> GetMatsRawMats(decimal qty)
        {

            DataAccess objData = new DataAccess();
            objData.AddParameter("pfbqty", qty);
            objData.CommandText = "sr_GET_COMPUTERAWMATS";
            objData.CommandType = CommandType.StoredProcedure;

            DataTable tempdt = objData.ReturnDataTable();

            var _output = (from DataRow dr in tempdt.Rows
                           select new Output
                           {
                               description = dr["description"].ToString(),
                               qty = decimal.Parse(dr["qty"].ToString()),
                               uom = dr["uom"].ToString(),
                               hasraw = 0
                           }).ToList();

            return _output;

        }
    }
}

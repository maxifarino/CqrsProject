using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GAP.Cqrs.Implementation.Query.GrupoFamiliar;
using GAP.Base.Helper;
using System.Configuration;

using Oracle.DataAccess.Client;
using System.Data;

namespace UnitTest
{
    [TestClass]
    public class ADOCallTest
    {
        [TestMethod]
        public void ConsultaADOTest()
        {
            var connextionString = ConfigurationManager.ConnectionStrings["default_conection"].ConnectionString;
                  
            var query = new GrupoFamiliarQuery(){
            FechaDesde = null,
            FechaHasta = null,
            PersonaJuridicaId = 139,
            SalaCunaId = 242,
            Codigo = null,
            NroDocumento = null,
            DadosBaja= false,
            DepartamentoId=0,
            LocalidadId=0,
            BarrioId=0,
            SituacionCritica = 0,
            PageNumber=0,
            PageSize=50
            };

            Int64 cero = 0;
            DataSet ds = new DataSet("TimeRanges");

            using (OracleConnection conn = new OracleConnection(connextionString))
            {
                //OracleCommand sqlComm = new OracleCommand("call PR_REPORTE_GRUPO_FAMILIAR_1(?,?,?,?,?,?,?,?,?,?,?,?,?)", conn);
                //OracleCommand sqlComm = new OracleCommand("PR_REPORTE_GRUPO_FAMILIAR_1(@P_FEC_DESDE,@P_FEC_HASTA, @P_ID_PERSONA_JURIDICA, @P_ID_SALA_CUNA, @P_COD_SALA_CUNA, @P_NRO_DOCUMENTO, @P_INCLUIR_BAJAS, @P_ID_DEPARTAMENTO, @P_ID_LOCALIDAD, @P_ID_BARRIO, @P_ES_VULNERABLE, @P_NU_PAG_DESDE, @P_NU_PAG_HASTA)", conn);
                OracleCommand sqlComm = new OracleCommand("PR_REPORTE_GRUPO_FAMILIAR_1", conn);
                sqlComm.CommandType = CommandType.StoredProcedure;

                DateTime? fechaDesde = query.FechaDesde != null ? query.FechaDesde : DateTimeHelper.GetMinDateTimeNullable(query.FechaDesde);
                DateTime? fechaHasta = query.FechaHasta == null && query.FechaDesde != null ? DateTime.Today : DateTimeHelper.GetMinDateTimeNullable(query.FechaHasta);

                sqlComm.Parameters.Add("T_CURSOR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                sqlComm.Parameters.Add("P_FEC_DESDE", OracleDbType.Varchar2).Value = fechaDesde.Value.ToString("dd-MM-yyyy");
                sqlComm.Parameters.Add("P_FEC_HASTA", OracleDbType.Varchar2).Value = fechaHasta.Value.ToString("dd-MM-yyyy"); 
                sqlComm.Parameters.Add("P_ID_PERSONA_JURIDICA", OracleDbType.Long).Value = query.PersonaJuridicaId != null ? query.PersonaJuridicaId : -1;
                sqlComm.Parameters.Add("P_ID_SALA_CUNA", OracleDbType.Long).Value = query.SalaCunaId != null ? query.SalaCunaId : -1;

                if (query.Codigo != null)
                {
                    sqlComm.Parameters.Add("P_COD_SALA_CUNA", OracleDbType.Varchar2).Value = query.Codigo;
                }
                else
                {
                    sqlComm.Parameters.Add("P_COD_SALA_CUNA", OracleDbType.Varchar2).Value = DBNull.Value;
                }

                if (query.NroDocumento != null)
                {
                    sqlComm.Parameters.Add("P_NRO_DOCUMENTO", OracleDbType.Varchar2).Value = query.NroDocumento;
                }
                else {
                    sqlComm.Parameters.Add("P_NRO_DOCUMENTO", OracleDbType.Varchar2).Value = DBNull.Value;
                }      
                
                sqlComm.Parameters.Add("P_INCLUIR_BAJAS", OracleDbType.Varchar2).Value = query.DadosBaja ? 'S' : 'N';
                sqlComm.Parameters.Add("P_ID_DEPARTAMENTO", OracleDbType.Long).Value = query.DepartamentoId != cero ? query.DepartamentoId : -1;
                sqlComm.Parameters.Add("P_ID_LOCALIDAD", OracleDbType.Long).Value = query.LocalidadId != cero ? query.LocalidadId : -1;
                sqlComm.Parameters.Add("P_ID_BARRIO", OracleDbType.Long).Value = query.BarrioId != cero ? query.BarrioId : -1;
                sqlComm.Parameters.Add("P_ES_VULNERABLE", OracleDbType.Long).Value = query.SituacionCritica;
                sqlComm.Parameters.Add("P_NU_PAG_DESDE", OracleDbType.Long).Value = query.PageNumber != null ? query.PaginationFrom : -1;
                sqlComm.Parameters.Add("P_NU_PAG_HASTA", OracleDbType.Long).Value = query.PageNumber != null ? query.PaginationTo : -1;
                
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = sqlComm;
                da.Fill(ds);
                Assert.AreEqual(11, ds.Tables[0].Rows.Count);
            }
        }

        [TestMethod]
        public void ConsultaHARDADOTest()
        {
            var connextionString = ConfigurationManager.ConnectionStrings["default_conection"].ConnectionString;

            var query = new GrupoFamiliarQuery()
            {
                FechaDesde = null,
                FechaHasta = null,
                PersonaJuridicaId = 139,
                SalaCunaId = 242,
                Codigo = null,
                NroDocumento = null,
                DadosBaja = false,
                DepartamentoId = 0,
                LocalidadId = 0,
                BarrioId = 0,
                SituacionCritica = 0,
                PageNumber = 0,
                PageSize = 50
            };

            Int64 cero = 0;
            DataSet ds = new DataSet("TimeRanges");

            using (OracleConnection conn = new OracleConnection(connextionString))
            {

                var sql = String.Format("call PR_REPORTE_GRUPO_FAMILIAR_1({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12})",
                    "'01-01-0001'", "'01-01-0001'", 139, 242, "NULL", "NULL", "N", -1, -1, -1, 0, 0, 51);
                OracleCommand sqlComm = new OracleCommand(sql, conn);
                sqlComm.CommandType = CommandType.Text;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = sqlComm;
                da.Fill(ds);
                Assert.AreEqual(11, ds.Tables[0].Rows.Count);
            }
        }
    
    }
}

using ConexaoDll;
using NotaDll.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotaDll
{
    public class nota
    {
        private conexao _conn;

        public nota() 
        {
            _conn = new conexao();
        }


        public DataTable CarregaDadosGridNota()
        {
            try
            {

                string query = string.Format(@" 
                SELECT 
                    ID_NOTA AS ID,
                    Data_Emissao_Nota AS 'Data Emissão',
                    Valor_Mercadoria_Nota as 'Valor da Mercadoria',
                    Valor_Desconto_Nota as 'Valor do Desconto',
                    Valor_Frete_Nota as 'Valor do Frete',
                    Valor_Total_Nota as 'Valor Total',
                    Status_Nota as 'Status da Nota' 
                from 
                    nota
                where 
                    UPPER(Status_Nota) = UPPER('p') and 
                    Quantidade_Visto_Nota >= 0 and 
                    Quantidade_Visto_Nota < 2 and 
                    Quantidade_Aprovacao_Nota = 0
                ");


                _conn.Open();

                
                DataTable table = new DataTable();

                table = _conn.ExecuteDataTable(query);

                if (table != null)
                {
                    return table;
                }

                return table;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar os usuários - " + ex.Message);
            }
            finally
            {
                _conn.Close();
                //_conn.Dispose();
            }
        }

        public DataTable CarregaDadosGridNotaAprovacao()
        {
            try
            {

                string query = string.Format(@" 
                SELECT 
	                ID_NOTA AS ID,
	                Data_Emissao_Nota AS 'Data Emissão',
	                Valor_Mercadoria_Nota as 'Valor da Mercadoria',
	                Valor_Desconto_Nota as 'Valor do Desconto',
	                Valor_Frete_Nota as 'Valor do Frete',
	                Valor_Total_Nota as 'Valor Total',
	                Status_Nota as 'Status da Nota',
	                Quantidade_Visto_Nota as 'Quantidade de Visto da Nota' 
                from 
	                nota
                where 
	                UPPER(Status_Nota) = UPPER('p') and 
	                Quantidade_Visto_Nota >= 1 and 
	                Quantidade_Aprovacao_Nota <= 2
                ");


                _conn.Open();


                DataTable table = new DataTable();

                table = _conn.ExecuteDataTable(query);

                if (table != null)
                {
                    return table;
                }

                return table;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar os usuários - " + ex.Message);
            }
            finally
            {
                _conn.Close();
                //_conn.Dispose();
            }
        }

        public bool VistoNota(int idNota, int qtdVisto)
        {
            try
            {
                string query = string.Format(@"
                update nota 
                set 
                    Quantidade_Visto_Nota = @Quantidade_Visto_Nota, 
                    Data_Alteracao_Nota = @Data_Alteracao_Nota 
                where 
                    UPPER(Status_Nota) = UPPER('p') and Id_Nota = @Id_Nota");


                _conn.Open();

                List<SqlParameter> parameters = new List<SqlParameter>()
                {
                    new SqlParameter("@Quantidade_Visto_Nota", qtdVisto),
                    new SqlParameter("@Id_Nota", idNota),
                    new SqlParameter("@Data_Alteracao_Nota",DateTime.Now)
                };

                _conn.Open();

                _conn.BeginTransaction();


                if (_conn.ExecuteNonQueryTransaction(query, parameters) > 0)
                {
                    _conn.CommitTransaction();
                }

                return true;



            }
            catch (Exception ex)
            {
                if (_conn.IsOpen() && _conn.ExisteTransacao())
                {
                    _conn.RollBackTransaction();
                }
                throw new Exception("Erro ao dar visto na nota - " + ex.Message);
            }
            finally
            {
                _conn.Close();
                //_conn.Dispose();
            }
        }

        public bool VistoNotaAprovacao(int idNota, int qtdVisto)
        {
            try
            {
                string query = string.Format(@"
                update nota 
                set 
                    Quantidade_Visto_Nota = @Quantidade_Visto_Nota, Status_Nota = @Status_Nota, 
                    Data_Alteracao_Nota = @Data_Alteracao_Nota 
                where 
                    UPPER(Status_Nota) = UPPER('p') and Id_Nota = @Id_Nota");


                _conn.Open();

                List<SqlParameter> parameters = new List<SqlParameter>()
                {
                    new SqlParameter("@Quantidade_Visto_Nota", qtdVisto),
                    new SqlParameter("@Status_Nota", 'A'),
                    
                    new SqlParameter("@Data_Alteracao_Nota",DateTime.Now),
                    new SqlParameter("@Id_Nota", idNota)
                };

                _conn.Open();

                _conn.BeginTransaction();


                if (_conn.ExecuteNonQueryTransaction(query, parameters) > 0)
                {
                    _conn.CommitTransaction();
                }

                return true;



            }
            catch (Exception ex)
            {
                if (_conn.IsOpen() && _conn.ExisteTransacao())
                {
                    _conn.RollBackTransaction();
                }
                throw new Exception("Erro ao dar visto na nota - " + ex.Message);
            }
            finally
            {
                _conn.Close();
                //_conn.Dispose();
            }
        }

        public bool AprovacaoNota(int idNota, int qtdAprovacao)
        {
            try
            {
                string query = string.Format(@"
                update nota 
                set 
                    Quantidade_Aprovacao_Nota = @Quantidade_Aprovacao_Nota, 
                    Data_Alteracao_Nota = @Data_Alteracao_Nota 
                where 
                    UPPER(Status_Nota) = UPPER('p') and Id_Nota = @Id_Nota");


                _conn.Open();

                List<SqlParameter> parameters = new List<SqlParameter>()
                {
                    new SqlParameter("@Quantidade_Aprovacao_Nota", qtdAprovacao),
                    new SqlParameter("@Id_Nota", idNota),
                    new SqlParameter("@Data_Alteracao_Nota",DateTime.Now)
                };

                _conn.Open();

                _conn.BeginTransaction();


                if (_conn.ExecuteNonQueryTransaction(query, parameters) > 0)
                {
                    _conn.CommitTransaction();
                }

                return true;



            }
            catch (Exception ex)
            {
                if (_conn.IsOpen() && _conn.ExisteTransacao())
                {
                    _conn.RollBackTransaction();
                }
                throw new Exception("Erro ao dar visto na nota - " + ex.Message);
            }
            finally
            {
                _conn.Close();
                //_conn.Dispose();
            }
        }

        public bool AprovacaoNotaDefinitiva(int idNota, int qtdAprovacao)
        {
            try
            {
                string query = string.Format(@"
                update nota 
                set 
                    Quantidade_Aprovacao_Nota = @Quantidade_Aprovacao_Nota, Status_Nota = @Status_Nota, 
                    Data_Alteracao_Nota = @Data_Alteracao_Nota 
                where 
                    UPPER(Status_Nota) = UPPER('p') and Id_Nota = @Id_Nota");


                _conn.Open();

                List<SqlParameter> parameters = new List<SqlParameter>()
                {
                    new SqlParameter("@Quantidade_Aprovacao_Nota", qtdAprovacao),
                    new SqlParameter("@Status_Nota", 'A'),

                    new SqlParameter("@Data_Alteracao_Nota",DateTime.Now),
                    new SqlParameter("@Id_Nota", idNota)
                };

                _conn.Open();

                _conn.BeginTransaction();


                if (_conn.ExecuteNonQueryTransaction(query, parameters) > 0)
                {
                    _conn.CommitTransaction();
                }

                return true;



            }
            catch (Exception ex)
            {
                if (_conn.IsOpen() && _conn.ExisteTransacao())
                {
                    _conn.RollBackTransaction();
                }
                throw new Exception("Erro ao dar visto na nota - " + ex.Message);
            }
            finally
            {
                _conn.Close();
                //_conn.Dispose();
            }
        }

        public configuracaoFaixaObter ObterConfiguracaoFaixaPorIdNota(int idNota)
        {
            try
            {

                string query = string.Format(@"
                SELECT 
                    N.ID_CONFIGURACAO_FAIXA_VALOR_NOTA,
                    C.QUANTIDADE_VISTO_CONFIGURACAO,
                    C.QUANTIDADE_APROVACAO_CONFIGURACAO,
                    C.FAIXA_MINIMA_CONFIGURACAO,
                    C.FAIXA_MAXIMA_CONFIGURACAO
                FROM 
                    NOTA AS N
                    INNER JOIN CONFIGURACAO_FAIXA_VALOR AS C ON C.ID_CONFIGURACAO = N.ID_CONFIGURACAO_FAIXA_VALOR_NOTA
                WHERE 
                    N.ID_NOTA = @ID_NOTA
                ");


                _conn.Open();

                List<SqlParameter> parameters = new List<SqlParameter>()
                {
                    new SqlParameter("@ID_NOTA", idNota),
                };

                using (SqlDataReader dataReader = _conn.ExecuteReaderParametroLista(query, parameters))
                {
                    if (dataReader.Read())
                    {
                        return new configuracaoFaixaObter
                        {
                            Id_Configuracao = Convert.ToInt32(dataReader["ID_CONFIGURACAO_FAIXA_VALOR_NOTA"]),
                            Quantidade_Visto_Configuracao = Convert.ToInt32(dataReader["QUANTIDADE_VISTO_CONFIGURACAO"]),
                            Quantidade_Aprovacao_Configuracao = Convert.ToInt32(dataReader["QUANTIDADE_APROVACAO_CONFIGURACAO"]),
                            Faixa_Minima_Configuracao = Convert.ToDecimal(dataReader["FAIXA_MINIMA_CONFIGURACAO"]),
                            Faixa_Maxima_Configuracao = Convert.ToDecimal(dataReader["FAIXA_MAXIMA_CONFIGURACAO"])
                        };
                    }
                    else
                    {
                        return null;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar os usuários - " + ex.Message);
            }
            finally
            {
                _conn.Close();
                //_conn.Dispose();
            }
        }

        public obterNota ObterNotaPorIdNota(int idNota)
        {
            try
            {

                string query = string.Format(@"
                SELECT 
                    ID_NOTA,
                    DATA_EMISSAO_NOTA,
                    VALOR_MERCADORIA_NOTA,
                    VALOR_DESCONTO_NOTA,
                    VALOR_FRETE_NOTA,
                    VALOR_TOTAL_NOTA,
                    ID_CONFIGURACAO_FAIXA_VALOR_NOTA,
                    QUANTIDADE_VISTO_NOTA,
                    QUANTIDADE_APROVACAO_NOTA,
                    STATUS_NOTA 
                FROM 
                    NOTA
                WHERE 
                    ID_NOTA = @ID_NOTA
                ");


                _conn.Open();

                SqlParameter parameters = new SqlParameter("@ID_NOTA", idNota);

                using (SqlDataReader dataReader = _conn.ExecuteReader(query, parameters))
                {
                    if (dataReader.Read())
                    {
                        return new obterNota
                        {
                            Id_Nota = Convert.ToInt32(dataReader["ID_NOTA"]),
                            Data_Emissao_Nota = Convert.ToDateTime(dataReader["DATA_EMISSAO_NOTA"]),
                            Valor_Mercadoria_Nota = Convert.ToDouble(dataReader["VALOR_MERCADORIA_NOTA"]),
                            Valor_Desconto_Nota = Convert.ToDouble(dataReader["VALOR_DESCONTO_NOTA"]),
                            Valor_Frete_Nota = Convert.ToDouble(dataReader["VALOR_FRETE_NOTA"]),
                            Valor_Total_Nota = Convert.ToDouble(dataReader["VALOR_TOTAL_NOTA"]),
                            Id_Configuracao_Faixa_Valor_Nota = Convert.ToInt32(dataReader["ID_CONFIGURACAO_FAIXA_VALOR_NOTA"]),
                            Quantidade_Visto_Nota = Convert.ToInt32(dataReader["QUANTIDADE_VISTO_NOTA"]),
                            Quantidade_Aprovacao_Nota = Convert.ToInt32(dataReader["QUANTIDADE_APROVACAO_NOTA"]),
                            Status_Nota = Convert.ToChar(dataReader["STATUS_NOTA"])
                        };
                    }
                    else
                    {
                        return null;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar os usuários - " + ex.Message);
            }
            finally
            {
                _conn.Close();
                //_conn.Dispose();
            }
        }

        public bool CadastarNotaHistorico(cadastrarHistorico cadHis)
        {
            try
            {
                string query = string.Format(@"
                insert into historico_visto_aprovacao 
                (
                    Data_Historico, 
                    Id_Usuario_Historico, 
                    Operacao_Historico, 
                    Id_Nota_Historico, 
                    Quantidade_Visto_Historico, 
                    Quantidade_Aprovacao_Historico, 
                    Id_Configuracao_Faixa_Valor_Historico, 
                    Status_Historico, 
                    Data_Inclusao_Historico,
                    Data_Alteracao_Historico
                )
                values
                (
                    @Data_Historico, 
                    @Id_Usuario_Historico, 
                    @Operacao_Historico, 
                    @Id_Nota_Historico, 
                    @Quantidade_Visto_Historico, 
                    @Quantidade_Aprovacao_Historico, 
                    @Id_Configuracao_Faixa_Valor_Historico, 
                    @Status_Historico, 
                    @Data_Inclusao_Historico,
                    @Data_Alteracao_Historico
                )
");


                _conn.Open();

                List<SqlParameter> parameters = new List<SqlParameter>()
                {
                    new SqlParameter("@Data_Historico", cadHis.Data_Historico),
                    new SqlParameter("@Id_Usuario_Historico", cadHis.Id_Usuario_Historico),
                    new SqlParameter("@Operacao_Historico",cadHis.Operacao_Historico),
                    new SqlParameter("@Id_Nota_Historico", cadHis.Id_Nota_Historico),
                    new SqlParameter("@Quantidade_Visto_Historico", cadHis.Quantidade_Visto_Historico),
                    new SqlParameter("@Quantidade_Aprovacao_Historico",cadHis.Quantidade_Aprovacao_Historico),
                    new SqlParameter("@Id_Configuracao_Faixa_Valor_Historico", cadHis.Id_Configuracao_Faixa_Valor_Historico),
                    new SqlParameter("@Status_Historico", 'A'),
                    new SqlParameter("@Data_Inclusao_Historico",DateTime.Now),
                    new SqlParameter("@Data_Alteracao_Historico",DateTime.Now)
                };

                _conn.BeginTransaction();


                if (_conn.ExecuteNonQueryTransaction(query, parameters) > 0)
                {
                    _conn.CommitTransaction();
                }

                return true;



            }
            catch (Exception ex)
            {
                if (_conn.IsOpen() && _conn.ExisteTransacao())
                {
                    _conn.RollBackTransaction();
                }
                throw new Exception("Erro ao cadastrar o histórico da nota - " + ex.Message);
            }
            finally
            {
                _conn.Close();
                //_conn.Dispose();
            }
        }

        public historicoModelo ObterHistoricoPorIdUsuario(int idUsuario)
        {
            try
            {

                string query = string.Format(@"
                SELECT 
                    Id_Historico,
                    Data_Historico, 
                    Id_Usuario_Historico, 
                    Operacao_Historico, 
                    Id_Nota_Historico, 
                    Quantidade_Visto_Historico, 
                    Quantidade_Aprovacao_Historico, 
                    Id_Configuracao_Faixa_Valor_Historico, 
                    Status_Historico, 
                    Data_Inclusao_Historico, 
                    Data_Alteracao_Historico
                FROM 
                    historico_visto_aprovacao
                WHERE 
                    Id_Usuario_Historico = @Id_Usuario_Historico
                ");


                _conn.Open();

                SqlParameter parameters = new SqlParameter("@Id_Usuario_Historico", idUsuario);

                using (SqlDataReader dataReader = _conn.ExecuteReader(query, parameters))
                {
                    if (dataReader.Read())
                    {
                        return new historicoModelo
                        {
                            Id_Historico = Convert.ToInt32(dataReader["Id_Historico"]),
                            Data_Historico = Convert.ToDateTime(dataReader["Data_Historico"]),
                            Id_Usuario_Historico = Convert.ToInt32(dataReader["Id_Usuario_Historico"]),
                            Operacao_Historico = dataReader["Operacao_Historico"].ToString(),
                            Id_Nota_Historico = Convert.ToInt32(dataReader["Id_Nota_Historico"]),
                            Quantidade_Visto_Historico = Convert.ToInt32(dataReader["Quantidade_Visto_Historico"]),
                            Quantidade_Aprovacao_Historico = Convert.ToInt32(dataReader["Quantidade_Aprovacao_Historico"]),
                            Id_Configuracao_Faixa_Valor_Historico = Convert.ToInt32(dataReader["Id_Configuracao_Faixa_Valor_Historico"]),
                            Status_Historico = Convert.ToChar(dataReader["Status_Historico"]),
                            Data_Inclusao_Historico = Convert.ToDateTime(dataReader["Data_Inclusao_Historico"]),
                            Data_Alteracao_Historico = Convert.ToDateTime(dataReader["Data_Alteracao_Historico"])
                        };
                    }
                    else
                    {
                        return null;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter histórico por usuário - " + ex.Message);
            }
            finally
            {
                _conn.Close();
                //_conn.Dispose();
            }
        }

        public historicoModelo ObterHistoricoPorIdNota(int idNota)
        {
            try
            {

                string query = string.Format(@"
                SELECT 
                    Id_Historico,
                    Data_Historico, 
                    Id_Usuario_Historico, 
                    Operacao_Historico, 
                    Id_Nota_Historico, 
                    Quantidade_Visto_Historico, 
                    Quantidade_Aprovacao_Historico, 
                    Id_Configuracao_Faixa_Valor_Historico, 
                    Status_Historico, 
                    Data_Inclusao_Historico, 
                    Data_Alteracao_Historico
                FROM 
                    historico_visto_aprovacao
                WHERE 
                    Id_Nota_Historico = @Id_Nota_Historico
                ");


                _conn.Open();

                SqlParameter parameters = new SqlParameter("@Id_Nota_Historico", idNota);

                using (SqlDataReader dataReader = _conn.ExecuteReader(query, parameters))
                {
                    if (dataReader.Read())
                    {
                        return new historicoModelo
                        {
                            Id_Historico = Convert.ToInt32(dataReader["Id_Historico"]),
                            Data_Historico = Convert.ToDateTime(dataReader["Data_Historico"]),
                            Id_Usuario_Historico = Convert.ToInt32(dataReader["Id_Usuario_Historico"]),
                            Operacao_Historico = dataReader["Operacao_Historico"].ToString(),
                            Id_Nota_Historico = Convert.ToInt32(dataReader["Id_Nota_Historico"]),
                            Quantidade_Visto_Historico = Convert.ToInt32(dataReader["Quantidade_Visto_Historico"]),
                            Quantidade_Aprovacao_Historico = Convert.ToInt32(dataReader["Quantidade_Aprovacao_Historico"]),
                            Id_Configuracao_Faixa_Valor_Historico = Convert.ToInt32(dataReader["Id_Configuracao_Faixa_Valor_Historico"]),
                            Status_Historico = Convert.ToChar(dataReader["Status_Historico"]),
                            Data_Inclusao_Historico = Convert.ToDateTime(dataReader["Data_Inclusao_Historico"]),
                            Data_Alteracao_Historico = Convert.ToDateTime(dataReader["Data_Alteracao_Historico"])
                        };
                    }
                    else
                    {
                        return null;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter histórico por nota - " + ex.Message);
            }
            finally
            {
                _conn.Close();
                //_conn.Dispose();
            }
        }

        public List<historicoModelo> ObterListaHistoricoPorIdNota(int idNota)
        {
            try
            {

                string query = string.Format(@"
                SELECT 
                    Id_Historico,
                    Data_Historico, 
                    Id_Usuario_Historico, 
                    Operacao_Historico, 
                    Id_Nota_Historico, 
                    Quantidade_Visto_Historico, 
                    Quantidade_Aprovacao_Historico, 
                    Id_Configuracao_Faixa_Valor_Historico, 
                    Status_Historico, 
                    Data_Inclusao_Historico, 
                    Data_Alteracao_Historico
                FROM 
                    historico_visto_aprovacao
                WHERE 
                    Id_Nota_Historico = @Id_Nota_Historico
                ");


                _conn.Open();

                SqlParameter parameters = new SqlParameter("@Id_Nota_Historico", idNota);

                List<historicoModelo> retorno = new List<historicoModelo>();

                using (SqlDataReader dataReader = _conn.ExecuteReader(query, parameters))
                {
                    while (dataReader.Read())
                    {
                        retorno.Add(new historicoModelo()
                        {
                            Id_Historico = Convert.ToInt32(dataReader["Id_Historico"]),
                            Data_Historico = Convert.ToDateTime(dataReader["Data_Historico"]),
                            Id_Usuario_Historico = Convert.ToInt32(dataReader["Id_Usuario_Historico"]),
                            Operacao_Historico = dataReader["Operacao_Historico"].ToString(),
                            Id_Nota_Historico = Convert.ToInt32(dataReader["Id_Nota_Historico"]),
                            Quantidade_Visto_Historico = Convert.ToInt32(dataReader["Quantidade_Visto_Historico"]),
                            Quantidade_Aprovacao_Historico = Convert.ToInt32(dataReader["Quantidade_Aprovacao_Historico"]),
                            Id_Configuracao_Faixa_Valor_Historico = Convert.ToInt32(dataReader["Id_Configuracao_Faixa_Valor_Historico"]),
                            Status_Historico = Convert.ToChar(dataReader["Status_Historico"]),
                            Data_Inclusao_Historico = Convert.ToDateTime(dataReader["Data_Inclusao_Historico"]),
                            Data_Alteracao_Historico = Convert.ToDateTime(dataReader["Data_Alteracao_Historico"])
                        });
                    }
                }

                return retorno.Count > 0 ? retorno : null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter histórico por nota - " + ex.Message);
            }
            finally
            {
                _conn.Close();
                //_conn.Dispose();
            }
        }

        public historicoModelo ObterHistoricoPorIdUsuarioIdNota(int idUsuario, int idNota)
        {
            try
            {

                string query = string.Format(@"
                SELECT 
                    Id_Historico,
                    Data_Historico, 
                    Id_Usuario_Historico, 
                    Operacao_Historico, 
                    Id_Nota_Historico, 
                    Quantidade_Visto_Historico, 
                    Quantidade_Aprovacao_Historico, 
                    Id_Configuracao_Faixa_Valor_Historico, 
                    Status_Historico, 
                    Data_Inclusao_Historico, 
                    Data_Alteracao_Historico
                FROM 
                    historico_visto_aprovacao
                WHERE 
                    Id_Usuario_Historico = @Id_Usuario_Historico 
                    and Id_Nota_Historico = @Id_Nota_Historico
                ");


                _conn.Open();

                List<SqlParameter> parameters = new List<SqlParameter>()
                {
                    new SqlParameter("@Id_Usuario_Historico", idUsuario),
                    new SqlParameter("@Id_Nota_Historico", idNota)
                };

                using (SqlDataReader dataReader = _conn.ExecuteReaderParametroLista(query, parameters))
                {
                    if (dataReader.Read())
                    {
                        return new historicoModelo
                        {
                            Id_Historico = Convert.ToInt32(dataReader["Id_Historico"]),
                            Data_Historico = Convert.ToDateTime(dataReader["Data_Historico"]),
                            Id_Usuario_Historico = Convert.ToInt32(dataReader["Id_Usuario_Historico"]),
                            Operacao_Historico = dataReader["Operacao_Historico"].ToString(),
                            Id_Nota_Historico = Convert.ToInt32(dataReader["Id_Nota_Historico"]),
                            Quantidade_Visto_Historico = Convert.ToInt32(dataReader["Quantidade_Visto_Historico"]),
                            Quantidade_Aprovacao_Historico = Convert.ToInt32(dataReader["Quantidade_Aprovacao_Historico"]),
                            Id_Configuracao_Faixa_Valor_Historico = Convert.ToInt32(dataReader["Id_Configuracao_Faixa_Valor_Historico"]),
                            Status_Historico = Convert.ToChar(dataReader["Status_Historico"]),
                            Data_Inclusao_Historico = Convert.ToDateTime(dataReader["Data_Inclusao_Historico"]),
                            Data_Alteracao_Historico = Convert.ToDateTime(dataReader["Data_Alteracao_Historico"])
                        };
                    }
                    else
                    {
                        return null;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter histórico por usuário e nota - " + ex.Message);
            }
            finally
            {
                _conn.Close();
                //_conn.Dispose();
            }
        }

        public DataTable CarregaDadosGridNotaFiltroData(string dataInicial, string dataFinal)
        {
            try
            {

                string query = string.Format(@" 
                SELECT 
                    ID_NOTA AS ID,
                    Data_Emissao_Nota AS 'Data Emissão',
                    Valor_Mercadoria_Nota as 'Valor da Mercadoria',
                    Valor_Desconto_Nota as 'Valor do Desconto',
                    Valor_Frete_Nota as 'Valor do Frete',
                    Valor_Total_Nota as 'Valor Total',
                    Status_Nota as 'Status da Nota',
                    Id_Configuracao_Faixa_Valor_Nota,
                    Quantidade_Visto_Nota,
                    Quantidade_Aprovacao_Nota 
                from 
                    nota
                where 
                    UPPER(Status_Nota) = UPPER('p') and 
                    Quantidade_Visto_Nota >= 0 and 
                    Quantidade_Visto_Nota < 2 and 
                    Quantidade_Aprovacao_Nota = 0
                    and Data_Emissao_Nota between '" + dataInicial + "' and '" + @dataFinal + "'");


                _conn.Open();


                DataTable table = new DataTable();

                table = _conn.ExecuteDataTable(query);

                if (table != null)
                {
                    return table;
                }

                return table;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar os usuários - " + ex.Message);
            }
            finally
            {
                _conn.Close();
                //_conn.Dispose();
            }
        }

        public DataTable CarregaDadosGridNotaAprovacaoFiltroData(string dataInicial, string dataFinal)
        {
            try
            {

                string query = string.Format(@" 
                SELECT 
	                ID_NOTA AS ID,
	                Data_Emissao_Nota AS 'Data Emissão',
	                Valor_Mercadoria_Nota as 'Valor da Mercadoria',
	                Valor_Desconto_Nota as 'Valor do Desconto',
	                Valor_Frete_Nota as 'Valor do Frete',
	                Valor_Total_Nota as 'Valor Total',
	                Status_Nota as 'Status da Nota',
	                Id_Configuracao_Faixa_Valor_Nota,
	                Quantidade_Visto_Nota,
	                Quantidade_Aprovacao_Nota 
                from 
	                nota
                where 
	                UPPER(Status_Nota) = UPPER('p') and 
	                Quantidade_Visto_Nota >= 1 and 
	                Quantidade_Aprovacao_Nota <= 2
                    and Data_Emissao_Nota between '" + dataInicial + "' and '" + @dataFinal + "'");


                _conn.Open();


                DataTable table = new DataTable();

                table = _conn.ExecuteDataTable(query);

                if (table != null)
                {
                    return table;
                }

                return table;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar os usuários - " + ex.Message);
            }
            finally
            {
                _conn.Close();
                //_conn.Dispose();
            }
        }

        public ComboBox carregarComboFaixaValor()
        {
            try
            {

                ComboBox aux = new ComboBox();

                
                string query = string.Format(@" 
                SELECT 
                    Id_Configuracao,
	                Descricao_Configuracao 
                from 
                    configuracao_faixa_valor
                order by 
                    Id_Configuracao");

                _conn.Open();

                SqlDataReader dataReader = _conn.ExecuteReader(query);
                
                if(dataReader != null)
                {
                    DataTable dt = new DataTable();
                    
                    dt.Load(dataReader);

                    if(dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.NewRow();

                        dr["Descricao_Configuracao"] = "";

                        dt.Rows.InsertAt(dr, 0);

                        aux.DataSource = dt;
                        aux.ValueMember = "Id_Configuracao";
                        aux.DisplayMember = "Descricao_Configuracao";

                        
                    }
                    else
                    {
                        return null;
                    }

                    
                }
                else
                { 
                    return null; 
                }

                dataReader.Close();
                dataReader.Dispose();

                return aux;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar os usuários - " + ex.Message);
            }
            finally
            {
                _conn.Close();
                //_conn.Dispose();
            }
        }


        public bool IncluirNota(cadastrarNota nota)
        {
            try
            {

                string query = @"INSERT INTO nota(
                                    Data_Emissao_Nota, 
                                    Valor_Mercadoria_Nota, 
                                    Valor_Desconto_Nota, 
                                    Valor_Frete_Nota, 
                                    Valor_Total_Nota, 
                                    Id_Configuracao_Faixa_Valor_Nota, 
                                    Quantidade_Visto_Nota, 
                                    Quantidade_Aprovacao_Nota, 
                                    Status_Nota, 
                                    Data_Inclusao_Nota, 
                                    Data_Alteracao_Nota
                                )
                                VALUES
                                (
                                    @Data_Emissao_Nota, 
                                    @Valor_Mercadoria_Nota, 
                                    @Valor_Desconto_Nota, 
                                    @Valor_Frete_Nota, 
                                    @Valor_Total_Nota, 
                                    @Id_Configuracao_Faixa_Valor_Nota, 
                                    @Quantidade_Visto_Nota, 
                                    @Quantidade_Aprovacao_Nota, 
                                    @Status_Nota, 
                                    @Data_Inclusao_Nota, 
                                    @Data_Alteracao_Nota
                                )";

                List<SqlParameter> parameters = new List<SqlParameter>()
                {
                    new SqlParameter("@Data_Emissao_Nota", nota.Data_Emissao_Nota),
                    new SqlParameter("@Valor_Mercadoria_Nota", nota.Valor_Mercadoria_Nota),
                    new SqlParameter("@Valor_Desconto_Nota", nota.Valor_Desconto_Nota),
                    new SqlParameter("@Valor_Frete_Nota", nota.Valor_Frete_Nota),
                    new SqlParameter("@Valor_Total_Nota", nota.Valor_Total_Nota),
                    new SqlParameter("@Id_Configuracao_Faixa_Valor_Nota", nota.Id_Configuracao_Faixa_Valor_Nota),
                    new SqlParameter("@Quantidade_Visto_Nota", nota.Quantidade_Visto_Nota),
                    new SqlParameter("@Quantidade_Aprovacao_Nota", nota.Quantidade_Aprovacao_Nota),
                    new SqlParameter("@Status_Nota", nota.Status_Nota.ToString().ToUpper()),
                    new SqlParameter("@Data_Inclusao_Nota", DateTime.Now),
                    new SqlParameter("@Data_Alteracao_Nota",DateTime.Now)
                };

                _conn.Open();

                _conn.BeginTransaction();


                if (_conn.ExecuteNonQueryTransaction(query, parameters) > 0)
                {
                    _conn.CommitTransaction();
                }

                return true;
            }
            catch (Exception ex)
            {
                if (_conn.IsOpen() && _conn.ExisteTransacao())
                {
                    _conn.RollBackTransaction();
                }
                throw new Exception("Erro ao incluir a nota - " + ex.Message);
            }
            finally
            {
                _conn.Close();
                //_conn.Dispose();
            }

        }


        public DataTable CarregaDadosGridHistorico()
        {
            try
            {

                string query = string.Format(@" 
                select
                    h.Data_Historico as 'Data do Histórico',
                    h.Id_Nota_Historico as 'Número da Nota',
                    h.Operacao_Historico as 'Operação da Nota',
                    h.Quantidade_Visto_Historico as 'Visto',
                    h.Quantidade_Aprovacao_Historico as 'Aprovação',
                    u.Nome_Usuario as 'Nome do usuário', 
                    u.Email_Usuario  as 'Email do usuário' 
                    from
                    historico_visto_aprovacao as h
                    inner join usuario as u on u.Id_Usuario = h.Id_Usuario_Historico
                order 
                    by h.Id_Nota_Historico");


                _conn.Open();


                DataTable table = new DataTable();

                table = _conn.ExecuteDataTable(query);

                if (table != null)
                {
                    return table;
                }

                return table;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar os usuários - " + ex.Message);
            }
            finally
            {
                _conn.Close();
                //_conn.Dispose();
            }
        }

        public DataTable CarregaDadosGridHistoricoFiltroData(string dataInicial, string dataFinal)
        {
            try
            {

                string query = string.Format(@" 
                select
                    h.Data_Historico as 'Data do Histórico',
                    h.Id_Nota_Historico as 'Número da Nota',
                    h.Operacao_Historico as 'Operação da Nota',
                    h.Quantidade_Visto_Historico as 'Visto',
                    h.Quantidade_Aprovacao_Historico as 'Aprovação',
                    u.Nome_Usuario as 'Nome do usuário', 
                    u.Email_Usuario  as 'Email do usuário' 
                    from
                    historico_visto_aprovacao as h
                    inner join usuario as u on u.Id_Usuario = h.Id_Usuario_Historico
                where 
                    Data_Historico between '" + dataInicial + "' and '" + @dataFinal + "'" +
                "order by h.Id_Nota_Historico");


                _conn.Open();


                DataTable table = new DataTable();

                table = _conn.ExecuteDataTable(query);

                if (table != null)
                {
                    return table;
                }

                return table;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar os usuários - " + ex.Message);
            }
            finally
            {
                _conn.Close();
                //_conn.Dispose();
            }
        }
    }
}


using ConexaoDll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuarioDll
{
    public class usuario
    {
        private conexao _conn;

        public usuario() 
        { 
            _conn = new conexao();
        }

        public usuarioModelo LogonUsuario(string login, string senha)
        {
            try
            {
                
                string query = string.Format(@"SELECT 
                                                Id_Usuario,
                                                Nome_Usuario, 
                                                Email_Usuario,  
                                                Papel_Usuario,
                                                Quantidade_Minimo_Visto,
                                                Quantidade_Maximo_Visto,
                                                Quantidade_Minimo_Aprovacao,
                                                Quantidade_Maximo_Aprovacao,
                                                Status_Usuario
                                               FROM 
                                                usuario 
                                               WHERE 
                                                Email_Usuario = @Email_Usuario and Senha_Usuario = @Senha_Usuario");


                _conn.Open();

                List<SqlParameter> parameters = new List<SqlParameter>()
                {
                    new SqlParameter("@Email_Usuario", login),
                    new SqlParameter("@Senha_Usuario", senha)
                };

                using (SqlDataReader dataReader = _conn.ExecuteReaderParametroLista(query, parameters))
                {
                    if (dataReader.Read())
                    {
                        return new usuarioModelo
                        {
                            Id_Usuario = Convert.ToInt32(dataReader["Id_Usuario"]),
                            Nome_Usuario = dataReader["Nome_Usuario"].ToString(),
                            Email_Usuario = dataReader["Email_Usuario"].ToString(),
                            Papel_Usuario = Convert.ToChar(dataReader["Papel_Usuario"]),
                            Quantidade_Minimo_Visto = Convert.ToInt32(dataReader["Quantidade_Minimo_Visto"]),
                            Quantidade_Maximo_Visto = Convert.ToInt32(dataReader["Quantidade_Maximo_Visto"]),
                            Quantidade_Minimo_Aprovacao = Convert.ToInt32(dataReader["Quantidade_Minimo_Aprovacao"]),
                            Quantidade_Maximo_Aprovacao = Convert.ToInt32(dataReader["Quantidade_Maximo_Aprovacao"]),
                            Status_Usuario = Convert.ToChar(dataReader["Status_Usuario"])
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


        public bool IncluirUsuario(usuarioCadastro user)
        {
            try
            {

                string query = @"INSERT INTO usuario(
                                Nome_Usuario, 
                                Email_Usuario, 
                                Senha_Usuario, 
                                Confirmar_Senha_Usuario, 
                                Papel_Usuario,
                                Quantidade_Minimo_Visto,
                                Quantidade_Maximo_Visto,
                                Quantidade_Minimo_Aprovacao,
                                Quantidade_Maximo_Aprovacao, 
                                Status_Usuario, 
                                Data_Inclusao_Usuario,
                                Data_Alteracao_Usuario
                                )
                                VALUES
                                (
                                @Nome_Usuario, 
                                @Email_Usuario, 
                                @Senha_Usuario, 
                                @Confirmar_Senha_Usuario,  
                                @Papel_Usuario,
                                @Quantidade_Minimo_Visto,
                                @Quantidade_Maximo_Visto,
                                @Quantidade_Minimo_Aprovacao,
                                @Quantidade_Maximo_Aprovacao, 
                                @Status_Usuario, 
                                @Data_Inclusao_Usuario,
                                @Data_Alteracao_Usuario);";

                List<SqlParameter> parameters = new List<SqlParameter>()
                {
                    new SqlParameter("@Nome_Usuario", user.Nome_Usuario),
                    new SqlParameter("@Email_Usuario", user.Email_Usuario),
                    new SqlParameter("@Senha_Usuario", user.Senha_Usuario),
                    new SqlParameter("@Confirmar_Senha_Usuario", user.Confirmar_Senha_Usuario),
                    new SqlParameter("@Papel_Usuario", user.Papel_Usuario),
                    new SqlParameter("@Quantidade_Minimo_Visto", user.Quantidade_Minimo_Visto),
                    new SqlParameter("@Quantidade_Maximo_Visto", user.Quantidade_Maximo_Visto),
                    new SqlParameter("@Quantidade_Minimo_Aprovacao", user.Quantidade_Minimo_Aprovacao),
                    new SqlParameter("@Quantidade_Maximo_Aprovacao", user.Quantidade_Maximo_Aprovacao),
                    new SqlParameter("@Status_Usuario", user.Status_Usuario.ToString().ToUpper()),
                    new SqlParameter("@Data_Inclusao_Usuario", DateTime.Now),
                    new SqlParameter("@Data_Alteracao_Usuario",DateTime.Now)
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
                throw new Exception("Erro ao incluir o usuário - " + ex.Message);
            }
            finally
            {
                _conn.Close();
                //_conn.Dispose();
            }

        }


    }
}

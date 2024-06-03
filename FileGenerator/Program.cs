using Microsoft.Data.SqlClient;
using MongoDB.Driver;
using Repositories;

namespace FileGenerator
{
    public class GerenciadorConexoesBD
    {
        private static GerenciadorConexoesBD instancia;
        private static readonly object objInstancia = new object();

        private MongoClient clienteMongo;
        private SqlConnection conexaoSQL;

        private GerenciadorConexoesBD()
        {
            clienteMongo = new MongoClient("mongodb://root:Mongo%402024%23@localhost:27017");
            conexaoSQL = new SqlConnection("Server=127.0.0.1; Database=DBRadar; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=True");
        }

        public static GerenciadorConexoesBD ObterInstancia()
        {
            lock (objInstancia)
            {
                if (instancia == null)
                {
                    instancia = new GerenciadorConexoesBD();
                }
                return instancia;
            }
        }

        public MongoClient ObterClienteMongo()
        {
            //conectar Mongo
            MongoClient mongoClient = DBconexao.obterClientMongo();
            if (mongoClient == null)
            {
                mongoClient = new MongoClient("mongodb://root:Mongo%402024%23@localhost:27017");
            }
            return mongoClient;
        }

        public SqlConnection ObterConexaoSQL()
        {
            //conectar SQL
            SqlConnection conexaoSQL = DBconexao.obterConexaoSQL();
            if (conexaoSQL == null)
            {
                conexaoSQL = new SqlConnection("Server=127.0.0.1; Database=DBRadar; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=True");
            }
            return conexaoSQL;
        }

        public void FecharConexoes()
        {
            mongoClient.Cluster.Dispose();
            DBconexao.FecharConexao();
        }
        public void OperacoesBancoDeDados()
        {
            // Recuperar dados do SQL
            // Recuperar dados do MongoDB
            // Gravar dados no MongoDB e SQL (CSV)
            // Gravar dados no MongoDB e SQL (JSON)
            // Gravar dados no MongoDB e SQL (XML)
        }
    }
}
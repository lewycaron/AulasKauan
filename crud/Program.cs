using crud.model.db;
using crud.model;


namespace crud
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = Conexao(args);
            
            Crud(app);          
            app.Run();
        }

        public static void Crud(WebApplication app){

            Cadastrar(app);
            Read(app);
        	ReadAll(app);
            Update(app);
            Delete(app);
        }

        public static WebApplication Conexao(string[]dados){

            var builder = WebApplication.CreateBuilder(dados);
                       
            var connectionString = builder.Configuration.GetConnectionString("model/db/dados")??"Data Source=model/db/dados.db";
            builder.Services.AddSqlite<Db_crud>(connectionString);

            return builder.Build();

        }


        public static void Cadastrar(WebApplication App){
            
            App.MapPost("/cadastro", (Db_crud baseDados, Refrigerante refri)=> {
            if(refri.nomeRefri == null){
                
            }

            baseDados.Refrigerante.Add(refri);
            baseDados.SaveChanges();

            });
        }

            public static void ReadAll(WebApplication App){
            App.MapGet("/pesquisar", (Db_crud baseDados) =>{
                return baseDados.Refrigerante.ToList();

            });
        }
        

        public static void Read(WebApplication App){
            App.MapGet("/pesquisar/{id}", (Db_crud baseDados, int id) =>{
                return baseDados.Refrigerante.Find(id);

            });
        }



        public static void Delete(WebApplication App){
                App.MapDelete("/deletar/{id}", (Db_crud baseDados, int id) =>{
                 
                var delRefri =  baseDados.Refrigerante.Find(id);
                baseDados.Refrigerante.Remove(delRefri);
                baseDados.SaveChanges();

                return "DELETÉDE";

            });

        }

      
        public static void Update(WebApplication App){
            App.MapPut("/atualizar/{id}", (Db_crud baseDados, Refrigerante refri, int id) =>{
            
            var oldRefri =  baseDados.Refrigerante.Find(id);
            oldRefri.nomeRefri = refri.nomeRefri;
            oldRefri.qtdConsumida = refri.qtdConsumida;
            oldRefri.tamanhoMls = refri.tamanhoMls; 

            baseDados.SaveChanges();

            return oldRefri;

            });


        }

    }
}



using Agendamento.Models;

namespace Agendamento.Data
{
    public class SeedingService
    {
        // Declara uma referência para o contexto do banco de dados.
        // O AppDbContext permite consultar, adicionar, atualizar e remover registros.
        // O modificador readonly impede que essa referência seja substituída
        // depois que o objeto SeedingService for construído.
        private readonly AppDbContext _context;

        // O AppDbContext é recebido pelo construtor por meio da
        // injeção de dependência (DI).
        // O ASP.NET Core cria a instância configurada do AppDbContext
        // e a fornece automaticamente quando cria o SeedingService.
        public SeedingService(AppDbContext context)
        {
            // Armazena a instância recebida para que ela possa ser utilizada
            // pelos outros métodos da classe.
            _context = context;
        }

        // Popula o banco de dados com os registros iniciais.
        public void Popula()
        {
            // Utiliza o contexto para consultar a tabela Medicos.
            // Any() retorna true quando a tabela já possui pelo menos um registro.

            //Só popula a tabela Medicos se estiver vazia no banco
            if (!_context.Medicos.Any())
            {

                // Cria o primeiro objeto que será inserido no banco.
                Medico m1 = new Medico
                {
                    Nome = "Luiza",
                    Crm = "123456",
                    Especialidade = "Vascular"
                };

                // Cria o segundo objeto que será inserido no banco.
                Medico m2 = new Medico
                {
                    Nome = "João",
                    Crm = "456789",
                    Especialidade = "Ortopedista"
                };

                // Adiciona os dois médicos ao contexto de uma única vez.
                // Mas ainda não salva no banco de dados
                _context.Medicos.AddRange(m1, m2);

                // Confirma as alterações pendentes.
                // O EF Core gera e executa os comandos INSERT no banco de dados.
                _context.SaveChanges();

            }


            if (!_context.Pacientes.Any()) 
            {

                 Paciente p1 = new Paciente
                  {

                        Nome = "Gabriel",
                        Cpf = "111.111.111-11",
                        Telefone = "(18) 99999-1111",
                        Endereco = "Rua das Flores, 100",
                        DataNascimento = new DateTime(1995, 5, 10)


                  };

                  Paciente p2 = new Paciente
                   {

                        Nome            = "Mariana Souza",
                        Cpf             = "222.222.222-22",
                        Telefone        = "(18) 99999-2222",
                        Endereco        = "Avenida Brasil, 200",
                        DataNascimento = new DateTime(2000, 8, 20)

                   };

                 //Add os objetos ao contexto
                 //Salva as mudanças 
                 _context.Pacientes.AddRange(p1, p2);
                 _context.SaveChanges();
                
            }    
        }
    }
}

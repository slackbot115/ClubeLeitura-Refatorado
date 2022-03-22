using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp
{
    internal class TelaCadastroAmigo
    {
        public Amigo[] amigos;
        public int numeroAmigo;
        public Notificador notificador;

        public string MostrarOpcoes()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Amigos");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");

            Console.WriteLine("Digite s para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public void InserirNovoAmigo()
        {
            MostrarTitulo("Inserindo nova Caixa");

            Amigo amigo = ObterAmigo();

            amigo.idAmigo = ++numeroAmigo;

            int posicaoVazia = ObterPosicaoVazia();
            amigos[posicaoVazia] = amigo;

            notificador.ApresentarMensagem("Caixa inserida com sucesso!", "Sucesso");
        }

        private Amigo ObterAmigo()
        {
            Console.Write("Digite o nome do amigo: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o nome do responsavel: ");
            string nomeResponsavel = Console.ReadLine();

            Console.Write("Digite o telefone do amigo: ");
            string telefone = Console.ReadLine();

            Console.Write("Digite o endereço: ");
            string endereco = Console.ReadLine();

            Amigo amigo = new Amigo();

            amigo.nome = nome;
            amigo.nomeResponsavel = nomeResponsavel;
            amigo.telefone = telefone;
            amigo.endereco = endereco;

            return amigo;
        }

        public void EditarAmigo()
        {
            MostrarTitulo("Editando Amigo");

            VisualizarAmigos("Pesquisando");

            Console.Write("Digite o número do amigo que deseja editar: ");
            int numeroAmigo = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i].idAmigo == numeroAmigo)
                {
                    Amigo amigo = ObterAmigo();

                    amigo.idAmigo = numeroAmigo;
                    amigos[i] = amigo;

                    break;
                }
            }

            notificador.ApresentarMensagem("Amigo editado com sucesso", "Sucesso");
        }

        public void ExcluirAmigo()
        {
            MostrarTitulo("Excluindo Amigo");

            VisualizarAmigos("Pesquisando");

            Console.Write("Digite o número do amigo que deseja excluir: ");
            int numeroAmigo = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i].idAmigo == numeroAmigo)
                {
                    amigos[i] = null;
                    break;
                }
            }

            notificador.ApresentarMensagem("Caixa excluída com sucesso", "Sucesso");
        }

        public void VisualizarAmigos(string tipo)
        {
            if (tipo == "Tela")
                MostrarTitulo("Visualização de Amigos");

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] == null)
                    continue;

                Amigo a = amigos[i];

                Console.WriteLine("ID: " + a.idAmigo);
                Console.WriteLine("Nome: " + a.nome);
                Console.WriteLine("Nome responsavel: " + a.nomeResponsavel);
                Console.WriteLine("Telefone: " + a.telefone);
                Console.WriteLine("Endereço: " + a.endereco);

                Console.WriteLine();
            }
        }

        public void MostrarTitulo(string titulo)
        {
            Console.Clear();

            Console.WriteLine(titulo);

            Console.WriteLine();
        }

        public int ObterPosicaoVazia()
        {
            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] == null)
                    return i;
            }

            return -1;
        }

    }
}

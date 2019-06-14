using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projPilha1_Transporte_nTktTna
{
    class Program
    {

        static Garagens garagens;
        static Veiculos frota;
        static Viagens viagens;
        static int opcao;

        static void Main(string[] args)
        {
            garagens = new Garagens();
            frota = new Veiculos();
            viagens = new Viagens();

            carregamentoInicial();
            construaOMenu();
        }
        

        static void carregamentoInicial() {
            Garagem congonhas = new Garagem("Congonhas - CGH");
            Garagem guarulhos = new Garagem("Guarulhosx - GRU");
            garagens.incluirGaragem(congonhas);
            garagens.incluirGaragem(guarulhos);
            Veiculo van1 = new Veiculo("CBT-0001", 8);
            Veiculo van2 = new Veiculo("CBT-0002", 8);
            Veiculo van3 = new Veiculo("CBT-0003", 8);
            Veiculo van4 = new Veiculo("CBT-0004", 8);
            Veiculo van5 = new Veiculo("CBT-0005", 8);
            Veiculo van6 = new Veiculo("CBT-0006", 8);
            Veiculo van7 = new Veiculo("CBT-0007", 8);
            Veiculo van8 = new Veiculo("CBT-0008", 8);
            frota.cadastrarVeiculo(van1);
            frota.cadastrarVeiculo(van2);
            frota.cadastrarVeiculo(van3);
            frota.cadastrarVeiculo(van4);
            frota.cadastrarVeiculo(van5);
            frota.cadastrarVeiculo(van6);
            frota.cadastrarVeiculo(van7);
            frota.cadastrarVeiculo(van8);
        }

        static void construaOMenu() {

            do
            {
                Console.Clear();
                Console.SetCursorPosition(15, 6); Console.Write("1 - Cadastrar veículo ");
                Console.SetCursorPosition(15, 7); Console.Write("2 - Cadastrar garagem");
                Console.SetCursorPosition(15, 8); Console.Write("3 - Iniciar jornada ");
                Console.SetCursorPosition(15, 9); Console.Write("4 - Encerrar jornada");
                Console.SetCursorPosition(15, 10); Console.Write("5 - Liberar viagem de uma determinada origem para um determinado destino ");
                Console.SetCursorPosition(15, 11); Console.Write("6 - Listar veículos em determinada garagem (informando a qtde de veículos e seu potencial de transporte)");
                Console.SetCursorPosition(15, 12); Console.Write("7 - Informar qtde de viagens efetuadas de uma determinada origem para um determinado destino");
                Console.SetCursorPosition(15, 13); Console.Write("8 - Listar viagens efetuadas de uma determinada origem para um determinado destino");
                Console.SetCursorPosition(15, 14); Console.Write("9 - Informar qtde de passageiros transportados de uma determinada origem para um determinado destino");
                Console.SetCursorPosition(15, 15); Console.Write("0 - Sair");
                Console.SetCursorPosition(15, 17); Console.Write("Digite a opção desejada: ");

                try
                {
                    opcao = int.Parse(Console.ReadLine());
                    if (opcao > 9)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(15, 10); Console.Write("                     Opção inválida, escolha um número entre 0 e 9");
                        Console.ReadKey();
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.SetCursorPosition(15, 10); Console.Write("                     Opção inválida, escolha um número entre 0 e 9");
                    Console.ReadKey();
                    continue;
                }
                                
                switch (opcao)
                {
                    case 1: cadastraVeiculo(); break;
                    case 2: cadastrarGaragem(); break;
                    case 3: iniciarJornada(); break;
                    case 4: encerrarJornada(); break;
                    case 5: liberarViagem(); break;
                    case 6: listarVeicPorGaragem(); break;
                    case 7: informarQuantViagens(); break;
                    case 8: listarViagens(); break;
                    case 9: informarQuantPassageiros(); break;
                }
            } while (opcao != 0);
        }

        static void cadastraVeiculo() {
            if (!garagens.JornadaAtiva)
            {
                string placa;
                int lotacao;

                Console.Clear();
                Console.SetCursorPosition(15, 10); Console.Write("----------------------------------------CADASTRAR VEICULOS---------------------------------------------");
                Console.SetCursorPosition(15, 11); Console.Write("Digite a placa: ");
                placa = Console.ReadLine();
                Console.SetCursorPosition(12, 12); lotacao = recebeInt("Informe a lotação: ");
                frota.cadastrarVeiculo(new Veiculo(placa, lotacao));
            }
            else
            {
                Console.Clear();
                Console.SetCursorPosition(15, 12); Console.Write("                                     Jornada já foi iniciada");
            }
            Console.ReadKey();
        }

        static void cadastrarGaragem() {
            if (!garagens.JornadaAtiva)
            {
                int opc;
                Console.Clear();
                Console.SetCursorPosition(15, 10); Console.Write("----------------------------------------CADASTRAR GARAGEM----------------------------------------------");
                Console.SetCursorPosition(15, 11); Console.Write("Informe o nome da garagem: ");
                string nomeGaragem = Console.ReadLine();
                Console.SetCursorPosition(15, 13); Console.Write("Você inseriu a garagem " + nomeGaragem + ", confirmar?");
                Console.SetCursorPosition(15, 17); Console.Write("1 - Sim | 2 - Não --> ");
                opc = int.Parse(Console.ReadLine());
                try
                {
                    if (opc > 2)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(15, 10); Console.Write("                     Opção inválida, escolha 1 para sim ou 2 para não");
                        opc = int.Parse(Console.ReadLine());
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.Clear();
                    Console.SetCursorPosition(15, 10); Console.Write("                     Opção inválida, escolha 1 para sim ou 2 para não");
                    opc = int.Parse(Console.ReadLine());
                }
                switch (opc) {
                    case 1:
                        try {
                            Garagem garagem = new Garagem(nomeGaragem);
                            garagens.incluirGaragem(garagem);
                            Console.Clear();
                            Console.SetCursorPosition(15, 12); Console.Write("                                   Garagem adicionada com sucesso!");
                            Console.ReadKey();
                            construaOMenu();
                        }
                        catch {

                        }
                    break;
                    case 2: Console.Clear(); break;
                }
                Console.ReadKey();
                
            }
            else
            {
                Console.Clear();
                Console.SetCursorPosition(15, 12); Console.Write("                                      Jornada já foi iniciada");
                Console.ReadKey();
            }
            Console.ReadKey();
        }

        static void iniciarJornada() {

            if (!garagens.JornadaAtiva)
            {
                garagens.inciarJornada(frota.ListDeVeiculos);
                Console.Clear();
                Console.SetCursorPosition(15, 12); Console.Write("                                   Jornada iniciada com sucesso!");
            }
            else {
                Console.Clear();
                Console.SetCursorPosition(15, 12); Console.Write("                                    Jornada já foi iniciada");
            }
            Console.ReadKey();
        }

        static void encerrarJornada() {

            garagens.encerrarJornada();
            foreach (Veiculo veiculo in frota.ListDeVeiculos)
            {
                foreach (Viagem viagem in viagens.ListaDeViagens)
                {
                    Console.Clear();
                    Console.WriteLine("                                   Encerramento de Frota");
                    if (viagem.Veiculo.Equals(veiculo))
                    {
                        Console.Write("Veiculo: "+veiculo.Id + ". " + " Placa: " + veiculo.Placa + " Transportados: " + veiculo.Lotacao + " Origem: "+ viagem.Origem.Local+" Destino "+viagem.Destino.Local);
                    }
                }
            }
            frota = new Veiculos();

            Console.WriteLine("                                            Fim da Jornada!");
            Console.ReadKey();

        }

        static void liberarViagem() {
            int idOrigem, idDestino;
           
            Veiculo veiculo;
            Garagem garOrigem = null, garDestino = null;


            if (garagens.JornadaAtiva)
            {
                Console.Clear();
                mostreGaragens();
                Console.SetCursorPosition(15, 9); Console.Write("Digite o ID origem: ");
                idOrigem = int.Parse(Console.ReadLine());
                Console.SetCursorPosition(15, 10); Console.Write("Digite o ID destino: ");
                idDestino = int.Parse(Console.ReadLine());
                foreach (Garagem garagem in garagens.ListaDeGaragens)
                {
                    if (garagem.Id == idOrigem)
                        garOrigem = garagem;
                    if (garagem.Id == idDestino)
                        garDestino = garagem;
                }
                if(garOrigem == null && garDestino == null)
                {
                    Console.Clear();
                    Console.SetCursorPosition(15, 12); Console.Write("                                   Origem ou Destino não existem");
                    Console.ReadKey();
                }
                else if (garOrigem.Id== garDestino.Id)
                {
                    Console.Clear();
                    Console.SetCursorPosition(15, 12); Console.Write("                                      Origem igual destino");
                    Console.ReadKey();
                }
                else if (garOrigem.PilhaVeiculos.Count() != 0)
                {
                    veiculo = garOrigem.PilhaVeiculos.Pop();
                    garDestino.PilhaVeiculos.Push(veiculo);
                    Viagem viagem = new Viagem(veiculo, garOrigem, garDestino);
                    Transporte tranporte = new Transporte(veiculo, veiculo.Lotacao);
                    Console.Clear();
                    Console.SetCursorPosition(15, 12); Console.Write("                                  Viagem iniciada com sucesso!");
                    Console.ReadKey();
                    viagens.incluirViagem(viagem);
                }
                else
                {
                    Console.Clear();
                    Console.SetCursorPosition(15, 12); Console.Write("                                         Garagem vazia");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.Clear();
                Console.SetCursorPosition(15, 12); Console.Write("                                    Jornada ainda não foi iniciada");
                Console.ReadKey();
            }
            Console.ReadKey();
        }

        static void listarVeicPorGaragem() {
            int idGaragem;

            if (garagens.JornadaAtiva)
            {
                mostreGaragens();
                Console.Clear();
                Console.WriteLine("Qual o ID da Garagem: ");
                idGaragem = int.Parse(Console.ReadLine());
        
                foreach (Garagem g in garagens.ListaDeGaragens)
                {
                    if (g.Id == idGaragem) {
                        Console.WriteLine("Garagem: " + g.Local);
                        Console.WriteLine("Potencial de transporte: " + g.potencialDeTransporte());
                        foreach (Veiculo v in g.PilhaVeiculos)
                        {
                            Console.WriteLine("Veículo id: " + v.Id + " - Lotação: " + v.Lotacao);
                        }
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.SetCursorPosition(15, 12); Console.Write("                                    Jornada ainda não foi iniciada");
            }
            Console.ReadKey();
        }

        static void informarQuantViagens() {
            int idOrigem,idDestino, contViagem = 0;
            if (garagens.JornadaAtiva)
            {
                mostreGaragens();

                Console.Clear();
                Console.WriteLine("Digite o ID origem: ");
                idOrigem = int.Parse(Console.ReadLine());
                Console.WriteLine("Digite o ID destino: ");
                idDestino = int.Parse(Console.ReadLine());
        
                if (viagens.ListaDeViagens.Count != 0)
                {
                    foreach (Viagem viagem in viagens.ListaDeViagens)
                    {
                        if (viagem.Origem.Id == idOrigem && viagem.Destino.Id == idDestino)
                            ++contViagem;
                    }
                    Console.Clear();
                    Console.SetCursorPosition(15, 12); Console.Write("                     Esse trecho possui " + contViagem + " viagen(s) feita(s)");
                    Console.ReadKey();
                }
                if (contViagem == 0)
                {
                    Console.Clear();
                    Console.SetCursorPosition(15, 12); Console.Write("                           Esse trecho ainda não possui viagens feitas");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.Clear();
                Console.SetCursorPosition(15, 12); Console.Write("                                    Jornada ainda não foi iniciada");
            }
            Console.ReadKey();

        }

        static void listarViagens() {
            int idOrigem, idDestino;

            if (garagens.JornadaAtiva)
            {
                mostreGaragens();
                Console.Clear();
                Console.WriteLine("Digite o ID origem: ");
                idOrigem = int.Parse(Console.ReadLine());
                Console.WriteLine("Digite o ID destino: ");
                idDestino = int.Parse(Console.ReadLine());
                if (viagens.ListaDeViagens.Count != 0 && idDestino != idOrigem)
                {
                    foreach (Viagem viagem in viagens.ListaDeViagens)
                    {
                        if (viagem.Origem.Id == idOrigem && viagem.Destino.Id == idDestino)
                            Console.WriteLine("Lista de viagens:");
                            Console.WriteLine("Viagem nº: " + viagem.Id +". Origem: "+ viagem.Origem.Local +" Destino: "+ viagem.Destino.Local);
                    }
                }
                else
                {
                    Console.Clear();
                    Console.SetCursorPosition(15, 12); Console.Write("                           Esse trecho ainda não possui viagens feitas");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.Clear();
                Console.SetCursorPosition(15, 12); Console.Write("                                    Jornada ainda não foi iniciada");
            }
            Console.ReadKey();
        }

        static void informarQuantPassageiros() {
            int idOrigem, idDestino, quantidade = 0;

            if (garagens.JornadaAtiva)
            {
                mostreGaragens();
                Console.Clear();
                Console.WriteLine("Digite o ID origem: ");
                idOrigem = int.Parse(Console.ReadLine());
                Console.WriteLine("Digite o ID destino: ");
                idDestino = int.Parse(Console.ReadLine());
                if (viagens.ListaDeViagens.Count != 0)
                {
                    foreach (Viagem viagem in viagens.ListaDeViagens)
                    {
                        if (viagem.Origem.Id == idOrigem && viagem.Destino.Id == idDestino)
                            quantidade += viagem.Veiculo.Lotacao;
                    }
                    Console.WriteLine("Esse trecho possui " + quantidade + " passageiros transportados");
                }
                else
                {
                    Console.Clear();
                    Console.SetCursorPosition(15, 12); Console.Write("                           Esse trecho ainda não possui viagens feitas");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.Clear();
                Console.SetCursorPosition(15, 12); Console.Write("                                    Jornada ainda não foi iniciada");
            }
            Console.ReadKey();
        }
        

        static public int recebeInt(String str) {
            try
            {
                Console.Write(str);
                return int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.SetCursorPosition(15, 13); Console.Write("Digite um número inteiro: ");
                return recebeInt(str);
            }
        }

        static public void print(string arg) {
            Console.Write("   " + arg);
        }

        static public void println(string arg) {
            Console.WriteLine("   " + arg);
        }

        static void mostreGaragens()
        {
            Console.WriteLine("                                 Origens e destinos possíveis: ");
            Console.WriteLine("ID  |  GARAGEM");

            foreach (Garagem g in garagens.ListaDeGaragens)
            {
                Console.WriteLine(g.Id + ". " + g.Local);
            }
        }

    }
}

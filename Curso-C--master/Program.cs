using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace SistemaGerenciamentoCampeonato
{
    class Program
    {
        static List<Team> teams = new List<Team>();
        static List<Match> matches = new List<Match>();
        static List<Result> results = new List<Result>();

        static string pathTeams = @"C:\Users\Aluno Noite\Downloads\Curso-C--master\Curso-C--master\times.json"; // Caminho para o arquivo teams.json
        static string pathMatches = @"C:\Users\Aluno Noite\Downloads\Curso-C--master\Curso-C--master\partidas.json"; // Caminho para o arquivo matches.json
        static string pathResults = @"C:\Users\Aluno Noite\Downloads\Curso-C--master\Curso-C--master\resultados.json"; // Caminho para o arquivo results.json

        static void Main(string[] args)
        {
            LoadData();

            int option;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("╔═══════════════════════════════════════════════════════╗");
                Console.WriteLine("║                 SISTEMA DE GERENCIAMENTO              ║");
                Console.WriteLine("║                      DE FUTEBOL                       ║");
                Console.WriteLine("║                         Autor: Atila                  ║");
                Console.WriteLine("║                       Data: 18/09/2024                ║");
                Console.WriteLine("║                       Versão: 1.0                     ║");
                Console.WriteLine("╚═══════════════════════════════════════════════════════╝");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("║ 1. Gerenciar Times                                    ║");
                Console.WriteLine("║ 2. Gerenciar Partidas                                 ║");
                Console.WriteLine("║ 3. Gerenciar Resultados                               ║");
                Console.WriteLine("║ 0. Sair                                               ║");
                Console.WriteLine("╚═══════════════════════════════════════════════════════╝");

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("               Escolha uma opção: ");

                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        TeamMenu();
                        break;
                    case 2:
                        MatchMenu();
                        break;
                    case 3:
                        ResultMenu();
                        break;
                    case 0:
                        SaveData();
                        Console.WriteLine("\nSaindo do programa...");
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida, tente novamente.");
                        break;
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            } while (option != 0);

        }

        static void TeamMenu()
        {
            int option;
            do
{
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("╔═══════════════════════════════════════════════════════╗");
                Console.WriteLine("║               SISTEMA DE GERENCIAMENTO                ║");
                Console.WriteLine("║                      DE FUTEBOL                       ║");
                Console.WriteLine("║                     GERENCIAR TIMES                   ║");
                Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("║ 1. Adicionar Time                                     ║");
                Console.WriteLine("║ 2. Listar Times                                       ║");
                Console.WriteLine("║ 3. Atualizar Time                                     ║");
                Console.WriteLine("║ 4. Remover Time                                       ║");
                Console.WriteLine("║ 0. Voltar                                             ║");
                Console.WriteLine("╚═══════════════════════════════════════════════════════╝");

                Console.Write("Escolha uma opção: ");
                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        AddTeam();
                        break;
                    case 2:
                        ListTeams();
                        break;
                    case 3:
                        UpdateTeam();
                        break;
                    case 4:
                        RemoveTeam();
                        break;
                    case 0:
                        Console.WriteLine("\nVoltando ao menu principal...");
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida, tente novamente.");
                        break;
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            } while (option != 0) ;            
            
        }

        static void MatchMenu()
        {
            int option;
            do
            {
                Console.Clear();
                Console.WriteLine("╔═══════════════════════════════════════════════════════╗");
                Console.WriteLine("║               SISTEMA DE GERENCIAMENTO                ║");
                Console.WriteLine("║                     DE FUTEBOL                        ║");
                Console.WriteLine("║                     GERENCIAR PARTIDAS                ║");
                Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
                Console.WriteLine("║ 1. Adicionar Partida                                  ║");
                Console.WriteLine("║ 2. Listar Partidas                                    ║");
                Console.WriteLine("║ 3. Atualizar Partida                                  ║");
                Console.WriteLine("║ 4. Remover Partida                                    ║");
                Console.WriteLine("║ 0. Voltar                                             ║");
                Console.WriteLine("╚═══════════════════════════════════════════════════════╝");

                Console.Write("Escolha uma opção: ");
                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        AddMatch();
                        break;
                    case 2:
                        ListMatches();
                        break;
                    case 3:
                        UpdateMatch();
                        break;
                    case 4:
                        RemoveMatch();
                        break;
                    case 0:
                        Console.WriteLine("\nVoltando ao menu principal...");
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida, tente novamente.");
                        break;
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            } while (option != 0);

        }

        static void ResultMenu()
        {
            int option;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("╔═══════════════════════════════════════════════════════╗");
                Console.WriteLine("║               SISTEMA DE GERENCIAMENTO                ║");
                Console.WriteLine("║                     DE FUTEBOL                        ║");
                Console.WriteLine("║                     GERENCIAR RESULTADOS              ║");
                Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("║ 1. Adicionar Resultado                                ║");
                Console.WriteLine("║ 2. Listar Resultados                                  ║");
                Console.WriteLine("║ 3. Atualizar Resultado                                ║");
                Console.WriteLine("║ 4. Remover Resultado                                  ║");
                Console.WriteLine("║ 0. Voltar                                             ║");
                Console.WriteLine("╚═══════════════════════════════════════════════════════╝");

                Console.Write("Escolha uma opção: ");
                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        AddResult();
                        break;
                    case 2:
                        ListResults();
                        break;
                    case 3:
                        UpdateResult();
                        break;
                    case 4:
                        RemoveResult();
                        break;
                    case 0:
                        Console.WriteLine("\nVoltando ao menu principal...");
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida, tente novamente.");
                        break;
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            } while (option != 0);
        }

        static void AddTeam()
        {
            Console.Clear();
            Console.WriteLine("**********************************************   ");
            Console.WriteLine("     ADICIONAR NOVO TIME   ");
            Console.WriteLine("**********************************************   ");
            Console.Write("Digite o nome do time: ");
            string name = Console.ReadLine();

            int id = teams.Count > 0 ? teams[^1].Id + 1 : 1;
            Team team = new Team(id, name);
            teams.Add(team);

            Console.WriteLine("\nTime adicionado com sucesso!");
            SaveData();
        }

        static void ListTeams()
        {
            Console.Clear();
            Console.WriteLine("**********************************************   ");
            Console.WriteLine("      LISTA DE TIMES   ");
            Console.WriteLine("**********************************************   ");

            if (teams.Count == 0)
            {
                Console.WriteLine("\nNenhum time cadastrado.");
            }
            else
            {
                foreach (var team in teams)
                {
                    Console.WriteLine($"ID: {team.Id} - Nome: {team.Name}");
                }
            }
        }

        static void UpdateTeam()
        {
            Console.Clear();
            Console.WriteLine("**********************************************   ");
            Console.WriteLine("   ATUALIZAR TIME   ");
            Console.WriteLine("**********************************************   ");

            Console.Write("Digite o ID do time a ser atualizado: ");
            int id = int.Parse(Console.ReadLine());

            var team = teams.Find(t => t.Id == id);

            if (team != null)
            {
                Console.Write("Digite o novo nome do time: ");
                team.Name = Console.ReadLine();

                Console.WriteLine("\nTime atualizado com sucesso!");
                SaveData();
            }
            else
            {
                Console.WriteLine("\nTime não encontrado.");
            }
        }

        static void RemoveTeam()
        {
            Console.Clear();
            Console.WriteLine("**********************************************   ");
            Console.WriteLine("    REMOVER TIME    ");
            Console.WriteLine("**********************************************   ");
            Console.Write("Digite o ID do time a ser removido: ");
            int id = int.Parse(Console.ReadLine());

            var team = teams.Find(t => t.Id == id);

            if (team != null)
            {
                teams.Remove(team);
                Console.WriteLine("\nTime removido com sucesso!");
                SaveData();
            }
            else
            {
                Console.WriteLine("\nTime não encontrado.");
            }
        }

        static void AddMatch()
        {
            Console.Clear();
            Console.WriteLine("**********************************************   ");
            Console.WriteLine("     ADICIONAR NOVA PARTIDA   ");
            Console.WriteLine("**********************************************   ");
            Console.Write("Digite o ID do time da casa: ");
            int homeTeamId = int.Parse(Console.ReadLine());
            var homeTeam = teams.Find(t => t.Id == homeTeamId);

            Console.Write("Digite o ID do time visitante: ");
            int awayTeamId = int.Parse(Console.ReadLine());
            var awayTeam = teams.Find(t => t.Id == awayTeamId);

            if (homeTeam != null && awayTeam != null)
            {
                int id = matches.Count > 0 ? matches[^1].Id + 1 : 1;
                Match match = new Match(id, homeTeam, awayTeam);
                matches.Add(match);

                Console.WriteLine("\nPartida adicionada com sucesso!");
                SaveData();
            }
            else
            {
                Console.WriteLine("\nUm ou ambos os times não encontrados.");
            }
        }

        static void ListMatches()
        {
            Console.WriteLine("**********************************************");
            Console.WriteLine("     LISTA DE PARTIDAS   ");
            Console.WriteLine("**********************************************");

            if (matches.Count == 0)
            {
                Console.WriteLine("Nenhuma partida foi adicionada ainda.");
            }
            else
            {
                foreach (var match in matches)
                {
                    Console.WriteLine($"Partida ID: {match.Id} - {match.HomeTeam.Name} vs {match.AwayTeam.Name}");
                }
            }
        }


        static void UpdateMatch()
        {
            Console.Clear();
            Console.WriteLine("**********************************************   ");
            Console.WriteLine("     ATUALIZAR PARTIDA   ");
            Console.WriteLine("**********************************************   ");
            Console.Write("Digite o ID da partida a ser atualizada: ");
            int id = int.Parse(Console.ReadLine());

            var match = matches.Find(m => m.Id == id);

            if (match != null)
            {
                Console.Write("Digite o novo ID do time da casa: ");
                int newHomeTeamId = int.Parse(Console.ReadLine());
                var newHomeTeam = teams.Find(t => t.Id == newHomeTeamId);
                if (newHomeTeam != null) match.HomeTeam = newHomeTeam;

                Console.Write("Digite o novo ID do time visitante: ");
                int newAwayTeamId = int.Parse(Console.ReadLine());
                var newAwayTeam = teams.Find(t => t.Id == newAwayTeamId);
                if (newAwayTeam != null) match.AwayTeam = newAwayTeam;

                Console.WriteLine("\nPartida atualizada com sucesso!");
                SaveData();
            }
            else
            {
                Console.WriteLine("\nPartida não encontrada.");
            }
        }

        static void RemoveMatch()
        {
            Console.Clear();
            Console.WriteLine("**********************************************   ");
            Console.WriteLine("       REMOVER PARTIDA    ");
            Console.WriteLine("**********************************************   ");
            Console.Write("Digite o ID da partida a ser removida: ");
            int id = int.Parse(Console.ReadLine());

            var match = matches.Find(m => m.Id == id);

            if (match != null)
            {
                matches.Remove(match);
                Console.WriteLine("\nPartida removida com sucesso!");
                SaveData();
            }
            else
            {
                Console.WriteLine("\nPartida não encontrada.");
            }
        }

        static void AddResult()
        {
            Console.Clear();
            Console.WriteLine("**********************************************   ");
            Console.WriteLine("     ADICIONAR NOVO RESULTADO   ");
            Console.WriteLine("**********************************************   ");
            Console.Write("Digite o ID da partida: ");
            int matchId = int.Parse(Console.ReadLine());
            var match = matches.Find(m => m.Id == matchId);

            if (match != null)
            {
                Console.Write("Digite o placar do time da casa: ");
                int homeScore = int.Parse(Console.ReadLine());
                Console.Write("Digite o placar do time visitante: ");
                int awayScore = int.Parse(Console.ReadLine());

                Result result = new Result(match, homeScore, awayScore);
                results.Add(result);

                Console.WriteLine("\nResultado adicionado com sucesso!");
                SaveData();
            }
            else
            {
                Console.WriteLine("\nPartida não encontrada.");
            }
        }

        static void ListResults()
        {
            Console.Clear();
            Console.WriteLine("**********************************************   ");
            Console.WriteLine("==========      LISTA DE RESULTADOS   =========");
            Console.WriteLine("**********************************************   ");
            if (results.Count == 0)
            {
                Console.WriteLine("\nNenhum resultado cadastrado.");
            }
            else
            {
                foreach (var result in results)
                {
                    Console.WriteLine($"ID da Partida: {result.Match.Id} - {result.Match.HomeTeam.Name} {result.HomeScore} x {result.AwayScore} {result.Match.AwayTeam.Name}");
                }
            }
        }

        static void UpdateResult()
        {
            Console.Clear();
            Console.WriteLine("**********************************************   ");
            Console.WriteLine("==========  ATUALIZAR RESULTADO   ============");
            Console.WriteLine("**********************************************   ");
            Console.Write("Digite o ID da partida cujo resultado será atualizado: ");
            int matchId = int.Parse(Console.ReadLine());
            var result = results.Find(r => r.Match.Id == matchId);

            if (result != null)
            {
                Console.Write("Digite o novo placar do time da casa: ");
                result.HomeScore = int.Parse(Console.ReadLine());
                Console.Write("Digite o novo placar do time visitante: ");
                result.AwayScore = int.Parse(Console.ReadLine());

                Console.WriteLine("\nResultado atualizado com sucesso!");
                SaveData();
            }
            else
            {
                Console.WriteLine("\nResultado não encontrado.");
            }
        }

        static void RemoveResult()
        {
            Console.Clear();
            Console.WriteLine("**********************************************   ");
            Console.WriteLine("==========    REMOVER RESULTADO   ==============");
            Console.WriteLine("**********************************************   ");
            Console.Write("Digite o ID da partida cujo resultado será removido: ");
            int matchId = int.Parse(Console.ReadLine());
            var result = results.Find(r => r.Match.Id == matchId);

            if (result != null)
            {
                results.Remove(result);
                Console.WriteLine("\nResultado removido com sucesso!");
                SaveData();
            }
            else
            {
                Console.WriteLine("\nResultado não encontrado.");
            }
        }

        static void LoadData()
        {
            if (File.Exists(pathTeams))
            {
                var json = File.ReadAllText(pathTeams);
                teams = JsonSerializer.Deserialize<List<Team>>(json) ?? new List<Team>();
            }
            if (File.Exists(pathMatches))
            {
                var json = File.ReadAllText(pathMatches);
                matches = JsonSerializer.Deserialize<List<Match>>(json) ?? new List<Match>();
            }
            if (File.Exists(pathResults))
            {
                var json = File.ReadAllText(pathResults);
                results = JsonSerializer.Deserialize<List<Result>>(json) ?? new List<Result>();
            }
        }

        static void SaveData()
        {
            File.WriteAllText(pathTeams, JsonSerializer.Serialize(teams));
            File.WriteAllText(pathMatches, JsonSerializer.Serialize(matches));
            File.WriteAllText(pathResults, JsonSerializer.Serialize(results));
        }
    }

    class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Team(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    class Match
    {
        public int Id { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }

        public Match(int id, Team homeTeam, Team awayTeam)
        {
            Id = id;
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
        }
    }

    class Result
    {
        public Match Match { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }

        public Result(Match match, int homeScore, int awayScore)
        {
            Match = match;
            HomeScore = homeScore;
            AwayScore = awayScore;
        }
    }
}

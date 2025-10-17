using System;
namespace geradorsenhas
{
    class Program
    {
        private static Dictionary<String, String> armazenadorSenhasRedes = new Dictionary<String, String>(); // armazenar as senhas
        public static void Gerador()
        {
            Guid guid = Guid.NewGuid(); // gera um valor aleatório
            String senhaForte = guid.ToString().Substring(0, 8); // limita string para 8 caracteres

            Armazenador(senhaForte);
        }

        public static void Armazenador(String senhaForte)
        {
            Console.Write("Digite o site da senha: ");
            String redeSocial = Console.ReadLine();

            armazenadorSenhasRedes.Add(redeSocial, senhaForte);

            Console.WriteLine("Senha Cadastrada com Sucesso! volte para o menu");
            VoltarMenu();
        }

        public static void SenhasAtuais()
        {
            Console.WriteLine("rede | senha");

            foreach (KeyValuePair<String, String> parSenha in armazenadorSenhasRedes)
            {
                String rede = parSenha.Key;
                String senha = parSenha.Value;

                Console.WriteLine($"{rede} | {senha}");
            }
            VoltarMenu();
        }
        
        public static void VoltarMenu()
        {
            while (true)
            {
                Console.WriteLine("Digite 0 para voltar ao menu...");
                int voltarMenu = int.Parse(Console.ReadLine());
                if (voltarMenu == 0)
                {
                    Menu();
                    Console.Clear();
                }
                else
                {
                    continue;
                }
            }
        }
        public static void Menu()
        {
            while (true)
            {
                Console.WriteLine("=========================");
                Console.WriteLine("     GERADOR DE SENHAS   ");
                Console.WriteLine("=========================");

                Console.WriteLine("1 - Nova Senha");
                Console.WriteLine("2 - Senhas atuais");
                Console.WriteLine("3 - Sair");
                Console.Write("Escolha uma opção: ");
                int escolha = int.Parse(Console.ReadLine());

                switch (escolha)
                {
                    case 1:
                        Console.Clear();
                        Gerador(); // chama metodo gerador de senha
                        break;

                    case 2:
                        Console.Clear(); // limpa a tela do console
                        SenhasAtuais();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                }
            }


        }
        public static void Main(String[] args)
        {
            Menu(); // chama metodo menu
        }
    }
}
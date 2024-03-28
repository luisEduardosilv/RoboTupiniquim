namespace RoboTupiniquim.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int colunas, linhas;

            TamanhoMapa(out colunas, out linhas);

            Console.WriteLine("digite o x do robô");
            int roboX = Convert.ToInt32(Console.ReadLine());
            VerificaInput(colunas, roboX);

            Console.WriteLine("digite o y do robô");
            int roboY = Convert.ToInt32(Console.ReadLine());
            VerificaInput(linhas, roboY);


            Console.WriteLine("informe a direção do robô");
            char direcao = Convert.ToChar(Console.ReadLine().ToUpper());
            VerificaDirecao(direcao);

            string instrucoes = ColetandoCoordenadas();

            for (int i = 0; i < instrucoes.Length; i++)
            {
                if (instrucoes[i] == 'E')
                {
                    VirarEsquerda(ref direcao);
                }
                else if (instrucoes[i] == 'D')
                {
                    VirarDireita(ref direcao);
                }
                if (instrucoes[i] == 'M')
                {
                    Mover(ref direcao, ref roboX, ref roboY);
                }
                VerificaSeRoboEstaNoGrid(roboX, roboY, colunas, linhas);
            }
            ExibirResultado(roboX, roboY, direcao);
        }

        private static string ColetandoCoordenadas()
        {
            Console.WriteLine("informe os comando do robô:");
            string instrucoes = Console.ReadLine().ToUpper();
            char[] instrucoesArray = instrucoes.ToCharArray();
            return instrucoes;
        }

        private static void VerificaDirecao(char direcao)
        {
            if (direcao != 'N' && direcao != 'S' && direcao != 'L' && direcao != 'O')
            {
                Console.WriteLine("Erro: Direção inválida...");
            }
        }

        private static void TamanhoMapa(out int colunas, out int linhas)
        {
            Console.WriteLine("digite o tamanho de colunas");
            colunas = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("digite o tamanho de linhas");
            linhas = Convert.ToInt32(Console.ReadLine());
        }

        #region Verifica Valor Digitado
        private static void VerificaInput(int colunas, int roboX)
        {
            if (roboX > colunas || roboX < 0)
            {
                while (roboX > colunas || roboX < 0)
                {
                    Console.WriteLine("Erro: Limite de alcance...");
                    Console.WriteLine($"Digite um valor menorou igual à: {colunas}");
                    roboX = Convert.ToInt32(Console.ReadLine());
                }
            }
        }
        #endregion

        #region VirarEsquerda
        private static void VirarEsquerda(ref char direcao)
        {
            switch (direcao)
            {
                case 'N':
                    direcao = 'O';
                    break;
                case 'O':
                    direcao = 'S';
                    break;
                case 'S':
                    direcao = 'L';
                    break;
                case 'L':
                    direcao = 'N';
                    break;
            }

        }
        #endregion

        #region VirarDireita
        private static void VirarDireita(ref char direcao)
        {
            switch (direcao)
            {
                case 'N':
                    direcao = 'L';
                    break;
                case 'L':
                    direcao = 'S';
                    break;
                case 'S':
                    direcao = 'O';
                    break;
                case 'O':
                    direcao = 'N';
                    break;
            }
        }
        #endregion

        #region Mover
        private static void Mover(ref char direcao, ref int roboX, ref int roboY)
        {
            switch (direcao)
            {
                case 'N':
                    roboY++;
                    break;
                case 'L':
                    roboX++;
                    break;
                case 'S':
                    roboY--;
                    break;
                case 'O':
                    roboX--;
                    break;
            }
        }
        #endregion

        private static void VerificaSeRoboEstaNoGrid(int RoboX, int RoboY, int colunas, int linhas)
        {
            if (RoboX < 0)
            {
                Console.WriteLine("Erro: Limite de alcance...");
            }
            else if (RoboY < 0)
            {
                Console.WriteLine("Erro: Limite de alcance...");
            }
            else if (RoboX > colunas)
            {
                Console.WriteLine("Erro: Limite de alcance...");
            }
            else if (RoboY > linhas)
            {
                Console.WriteLine("Erro: Limite de alcance...");
            }
        }

        #region ExibirResultado
        private static void ExibirResultado(int roboX, int roboY, char direcao)
        {
            Console.WriteLine($"{roboX},{roboY} {direcao}");
            Console.ReadLine();
        }
        #endregion

    }
}
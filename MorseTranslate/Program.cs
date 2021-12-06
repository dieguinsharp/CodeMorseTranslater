using MorseTranslate.Translate;
using System;

namespace MorseTranslate
{
    class Program
    {
        private static readonly CodeMorse codeMorse = new CodeMorse();
        static void Main(string[] args)
        {
            string resp = "S";
            while(resp.Equals("S") || resp.Equals("s"))
            {
                Console.WriteLine("---- Painel Codigo Morse ----");
                Console.WriteLine("[1] - Codificar - [1]");
                Console.WriteLine("[2] - Decodificar - [2]");
                Console.Write("Escolha uma opção: ");
                int opc = Convert.ToInt32(Console.ReadLine());

                string text;
                switch (opc)
                {
                    case 1:

                        Console.Write("Informe o texto a se codificar: ");
                        text = Console.ReadLine();

                        Console.WriteLine("Codigo: " + codeMorse.Encode(text));

                        break;
                    case 2:

                        Console.Write("Informe o texto para decodificar: ");
                        text = Console.ReadLine();

                        Console.WriteLine("Codigo decodificado: " + codeMorse.Decode(text));

                        break;
                }

                Console.WriteLine("Usar o tradutor novamente? [S/N]");
                resp = Console.ReadLine();

                Console.Clear();
            }

            Console.WriteLine("Até mais XD");
        }
    }
}

using System.Text.RegularExpressions;

namespace oraiFeladat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. feladat");
            if (args.Length == 0 || args.Length % 2 == 0)
            {
                Console.Error.WriteLine("Hiba: Nem megfelelő számú argumentum.");
                Environment.Exit(1);
            }

            int[] szamok = new int[args.Length];
            for (int i = 0; i < args.Length; i++)
            {
                if (!int.TryParse(args[i], out szamok[i]))
                {
                    Console.Error.WriteLine("Hiba: Nem sikerült konvertálni az argumentumot egész számmá.");
                    Environment.Exit(1);
                }
            }
            int kozepso = szamok[szamok.Length / 2];

            int elsoSzomszed = szamok[szamok.Length / 2 - 1];
            int masodikSzomszed = szamok[szamok.Length / 2 + 1];

            if (szamok.Length == 1)
            {
                Console.Error.WriteLine("Hiba: Nem lehet kiszámolni a középső elemet egyetlen elem esetén.");
                Environment.Exit(1);
            }

            int osztas = Math.Max(elsoSzomszed, masodikSzomszed) / Math.Min(elsoSzomszed, masodikSzomszed);

            double hatvany = Math.Pow(kozepso, osztas);

            Console.WriteLine(hatvany);

            Console.WriteLine("2. feladat");

            string filePath = "szavak.txt";
            if (!File.Exists(filePath))
            {
                Console.Error.WriteLine("Hiba: A fájl nem létezik.");
                Environment.Exit(1);
            }

            string[] sorok = File.ReadAllLines(filePath);
            int negyneltobbszotaguk = 0;
            int legnagyobbszotagszam = 0;

            foreach (string sor in sorok)
            {
                int maganhangzok = Regex.Matches(sor.ToLower(), "[aeiou]").Count;

                if (maganhangzok > 4)
                {
                    negyneltobbszotaguk++;
                }
                if (maganhangzok > legnagyobbszotagszam)
                {
                    legnagyobbszotagszam = maganhangzok;
                }
            }

            Console.WriteLine("A fájlban {0} olyan szó található, amely több, mint négy szótagból áll.", negyneltobbszotaguk);
            Console.WriteLine("A legnagyobb szótagszám {0} ",legnagyobbszotagszam);

            Console.WriteLine("3.feladat");

            Random rnd = new Random(33);

            int[,] matrix = new int[6, 6];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    matrix[i, j] = rnd.Next(55, 156);
                }
            }

            Console.WriteLine("Mátrix:");
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

            int sum = 0;
            int count = 0;
            for (int i = 0; i < 6; i++)
            {
                sum += matrix[0, i];
                sum += matrix[5, i];
                count += 2;
            }
            for (int i = 1; i < 5; i++)
            {
                sum += matrix[i, 0];
                sum += matrix[i, 5];
                count += 2;
            }
            double avg = Convert.ToDouble(sum / count);

            Console.WriteLine("A széleken elhelyezkedő elemek átlaga: " + avg);

            Console.WriteLine("4.feladat");

            string inputFile = "kep.txt";
            string outputFile = "kekitett.txt";

            if (!File.Exists(inputFile))
            {
                Console.WriteLine("A bemeneti fájl nem létezik!");
                return;
            }

            string[] lines = File.ReadAllLines(inputFile);

            string[] modifiedLines = new string[50];
            for (int i = 0; i < 50; i++)
            {
                string[] rgb = lines[i].Split(';');

                int r = int.Parse(rgb[0]);
                int g = int.Parse(rgb[1]);
                int b = int.Parse(rgb[2]);

                if (b < 100)
                {
                    b += 20;
                }

                modifiedLines[i] = $"{r};{g};{b}";
            }

            File.WriteAllLines(outputFile, modifiedLines);

            Console.WriteLine("#Kész!");
        }
    }
    
}

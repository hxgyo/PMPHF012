namespace PMPHF012_IASJP5
{
    internal class Program
    {
        static string[] MegkeresendoSzavak(int n)
        {
            string[] szavak = new string[n];

            for (int i = 0; i < szavak.Length; i++)
            {
                szavak[i] = Console.ReadLine();
            }
            return szavak;
        }
        static char[,] Tablazat(int r, int c)
        {
            char[,] tablazat = new char[r, c];

            for (int i = 0; i < r; i++)
            {
                string sor = Console.ReadLine();
                for (int j = 0; j < c; j++)
                {
                    tablazat[i, j] = sor[j];
                }
            }
            return tablazat;
        }
        static int[] SorOszlop(string l)
        {
            int[] sorOszlop = new int[2];
            for (int i = 0; i < sorOszlop.Length; i++)
            {
                sorOszlop[i] = Convert.ToInt32(l.Split(' ')[i]);
            }
            return sorOszlop;
        }
        static int[] iranyVektorX = { -1, -1, -1, 0, 1, 1, 1, 0 };
        static int[] iranyVektorY = { -1, 0, 1, 1, 1, 0, -1, -1 };
        static bool Kereses(char[,] tablazat, string szo, int kezdoX, int kezdoY, int iranyX, int iranyY, bool[,] temp)
        {
            int r = tablazat.GetLength(0);
            int c = tablazat.GetLength(1);

            for (int i = 0; i < szo.Length; i++)
            {
                int x = kezdoX + i * iranyX;
                int y = kezdoY + i * iranyY;

                if (x < 0 || y < 0 || x >= r || y >= c || tablazat[x, y] != szo[i])
                {
                    return false;
                }
            }

            for (int i = 0; i < szo.Length; i++)
            {
                int x = kezdoX + i * iranyX;
                int y = kezdoY + i * iranyY;

                temp[x, y] = true;
            }

            return true;
        }
        static bool KeresesTablazat(char[,] tablazat, string szo, bool[,] temp)
        {
            int r = tablazat.GetLength(0);
            int c = tablazat.GetLength(1);

            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    for (int k = 0; k < iranyVektorX.Length; k++)
                    {
                        if (Kereses(tablazat, szo, i, j, iranyVektorX[k], iranyVektorY[k], temp))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        static void Torles(char[,] tablazat, bool[,] temp)
        {
            int r = tablazat.GetLength(0);
            int c = tablazat.GetLength(1);

            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    if (temp[i, j])
                    {
                        tablazat[i, j] = '\0';
                    }
                }
            }
        }
        static string TitkosUzenet(char[,] tablazat)
        {
            int r = tablazat.GetLength(0);
            int c = tablazat.GetLength(1);
            string uzenet = "";

            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    if (tablazat[i, j] != '\0')
                    {
                        uzenet += tablazat[i, j];
                    }
                }
            }
            return uzenet;
        }
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] keresendoSzavak = MegkeresendoSzavak(n);

            string sorOszlop = Console.ReadLine();
            int[] tablazatMerete = SorOszlop(sorOszlop);
            int r = tablazatMerete[0];
            int c = tablazatMerete[1];

            char[,] tablazat = Tablazat(r, c);
            bool[,] ideiglenesTablazat = new bool[r, c];

            for (int i = 0; i < keresendoSzavak.Length; i++)
            {
                KeresesTablazat(tablazat, keresendoSzavak[i], ideiglenesTablazat);
            }
            Torles(tablazat, ideiglenesTablazat);

            string titkosUzenet = TitkosUzenet(tablazat);

            Console.WriteLine(titkosUzenet);
        }
    }
}

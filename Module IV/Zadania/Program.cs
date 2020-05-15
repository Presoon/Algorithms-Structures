using System;
using System.Text;


namespace Zadania
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            const int textLength = 2000;
            const int patternLength = 2;
            char letter;

            StringBuilder strBuild = new StringBuilder();
            Random rnd = new Random();

            for (int j = 0; j < textLength; j++)
            {
                double r = rnd.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * r));
                letter = Convert.ToChar(shift + 65);
                strBuild.Append(letter);
            }

            var text = strBuild.ToString();
            strBuild.Clear();

            for (int j = 0; j < patternLength; j++)
            {
                double flt = rnd.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                strBuild.Append(letter);
            }

            var pattern = strBuild.ToString();

            Console.WriteLine("[#] Pattern: " + pattern);
            Console.WriteLine("[#] Generated text: " + text);

            Console.WriteLine("\n[#] Found patterns:");
            KnuthMorrisPratt(pattern, text);
            BoyerMoore(pattern, text);
            KarpaRabina(pattern, text);
            
            Console.ReadLine();
        }

        private static void KnuthMorrisPratt(string pat, string txt)
        {
            int patLength = pat.Length;
            int txtLength = txt.Length;

            var lps = new int[patLength];
            int j = 0;


            LPSArray(pat, patLength, lps);

            int i = 0;
            while (i < txtLength)
            {
                if (pat[j] == txt[i])
                {
                    j++;
                    i++;
                }
                if (j == patLength)
                {
                    Console.WriteLine($"[##] KPM pattern at index {i - j}");
                    j = lps[j - 1];
                }


                else if (i < txtLength && pat[j] != txt[i])
                {

                    if (j != 0)
                        j = lps[j - 1];
                    else
                        i += 1;
                }
            }
        }

        private static void LPSArray(string pat, int M, int[] lps)
        {
            int len = 0;
            int i = 1;
            lps[0] = 0;

            while (i < M)
            {
                if (pat[i] == pat[len])
                {
                    len++;
                    lps[i] = len;
                    i++;
                }
                else
                {
                    if (len != 0)
                    {
                        len = lps[len - 1];
                    }
                    else
                    {
                        lps[i] = len;
                        i++;
                    }
                }
            }
        }

        private static void BoyerMoore(string pat, string txt)
        {
            int patLength = pat.Length;
            int txtLength = txt.Length;


            for (int i = 0; i < txtLength; i++)
            {
                if (i + patLength >= txtLength) continue;
                if (pat == txt.Substring(i, patLength))
                {
                    Console.WriteLine($"[##] BoyerMoore pattern at index {i}");

                }
            }

        }

        private static void KarpaRabina(string pat, string txt)
        {

            int patLength = pat.Length;
            int txtLength = txt.Length;

            int i;
            int p = 0;
            int t = 0;
            
            const int d = 256;
            const int q = 101;

            int h = (int)Math.Pow(d, patLength - 1) % q;

            for (i = 0; i < patLength; i++)
            {
                p = (d * p + pat[i]) % q;
                t = (d * t + txt[i]) % q;
            }

            for (i = 0; i <= txtLength - patLength; i++)
            {
                if (p == t)
                {
                    int j;
                    for (j = 0; j < patLength; j++)
                    {
                        if (txt[i + j] != pat[j])
                            break;
                    }

                    if (j == patLength)
                        Console.WriteLine($"[##] KarpaRabina pattern at index {i}");
                }

                if (i >= txtLength - patLength) continue;
                t = (d * (t - txt[i] * h) + txt[i + patLength]) % q;
                if (t < 0)
                    t = (t + q);
            }

        }
    }
}

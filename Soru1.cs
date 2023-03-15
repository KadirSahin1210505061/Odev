using System;

class Program
{
    static void Main(string[] args)
    {
        int[] dizi = new int[10000];
        Random rastgeleNum = new Random();
        for (int i = 0; i < dizi.Length; i++)
        {
            dizi[i] = rastgeleNum.Next(0, 10000);
        }

        // Max algo
        DateTime maxIlk = DateTime.Now;
        int max = dizi[0];
        for (int i = 1; i < dizi.Length; i++)
        {
            if (dizi[i] > max)
            {
                max = dizi[i];
            }
        }
        DateTime maxSon = DateTime.Now;
        TimeSpan durationMax = maxSon - maxIlk;

        // BruteForce algo
        DateTime startBruteForce = DateTime.Now;
        int maxBruteForce = int.MinValue;
        for (int i = 0; i < dizi.Length; i++)
        {
            for (int j = i + 1; j < dizi.Length; j++)
            {
                if (dizi[i] > dizi[j])
                {
                    if (dizi[i] > maxBruteForce)
                    {
                        maxBruteForce = dizi[i];
                    }
                    break;
                }
                else
                {
                    if (dizi[j] > maxBruteForce)
                    {
                        maxBruteForce = dizi[j];
                    }
                }
            }
        }
        DateTime endBruteForce = DateTime.Now;
        TimeSpan durationBruteForce = endBruteForce - startBruteForce;


        Console.WriteLine("En Büyük Eleman: " + max);
        Console.WriteLine("Bulma Süresi: " + durationMax.TotalMilliseconds + " ms");

        Console.WriteLine("En Büyük Eleman (BruteForce): " + maxBruteForce);
        Console.WriteLine("BruteForce Bulma Süresi: " + durationBruteForce.TotalMilliseconds + " ms");
    }
}

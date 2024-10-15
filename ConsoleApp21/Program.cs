using System;
using System.Collections.Generic;

class Program
{
    public class Urun
    {
        public string isim; 
        public double kilo; 

        public Urun(string isim, double kilo)
        {
            this.isim = isim; // this.isim sınıfın alanını belirtir 
            this.kilo = kilo; 
        }
    }

    static void Main()
    {
        List<Urun> halUrunleri = new List<Urun>();
        string secim;
        double kilo, bakiye;

        Console.Write("Başlangıç bakiyenizi girin: ");
        bakiye = double.Parse(Console.ReadLine());

        while (true)
        {
            Console.Write("Meyve mi yoksa sebze mi almak istiyorsunuz? (m/s): ");
            secim = Console.ReadLine().ToLower();

            if (secim == "m") ListeleMeyveler();
            else if (secim == "s") ListeleSebzeler();
            else
            {
                Console.WriteLine("Geçersiz seçim! Lütfen 'm' veya 's' girin.");
                continue;
            }

            Console.Write("Hangi ürünü seçmek istersiniz? ");
            string urunIsmi = Console.ReadLine();

            Console.Write("Kaç kilo almak istersiniz? ");
            kilo = double.Parse(Console.ReadLine());

            double fiyat = 20 * kilo;

            if (fiyat > bakiye)
                Console.WriteLine("Yetersiz bakiye! Bu ürünü satın alamazsınız.");
            else
            {
                bakiye -= fiyat;
                UrunEkle(halUrunleri, urunIsmi, kilo);
                Console.WriteLine($"{kilo} kg {urunIsmi} alındı. Kalan bakiye: {bakiye} TL");
            }

        }

        while (true)
        {
            Console.Write("Meyve mi yoksa sebze mi satmak istersiniz? (m/s): ");
            secim = Console.ReadLine().ToLower();

            Console.WriteLine("Halden alınan ürünler:");
            UrunleriListele(halUrunleri);

            Console.Write("Hangi ürünü seçmek istersiniz? ");
            string urunIsmi = Console.ReadLine();

            Console.Write("Kaç kilo satmak istersiniz? ");
            kilo = double.Parse(Console.ReadLine());

            double fiyat = 20 * kilo;

            if (SatinAl(halUrunleri, urunIsmi, kilo))
            {
                bakiye += fiyat;
                Console.WriteLine($"{kilo} kg {urunIsmi} satıldı. Yeni bakiye: {bakiye} TL");
            }
            else
            {
                Console.WriteLine("Yetersiz ürün miktarı! Bu ürünü satamazsınız.");
            }

        }

        Console.WriteLine("\nAlınan ürünler:");
        UrunleriListele(halUrunleri);
    }

    static void UrunEkle(List<Urun> halUrunleri, string isim, double kilo)
    {
        foreach (var urun in halUrunleri)
        {
            if (urun.isim.ToLower() == isim.ToLower())
            {
                urun.kilo += kilo;
                return;
            }
        }
        halUrunleri.Add(new Urun(isim, kilo));
    }

    static bool SatinAl(List<Urun> halUrunleri, string isim, double kilo)
    {
        foreach (var urun in halUrunleri)
        {
            if (urun.isim.ToLower() == isim.ToLower() && urun.kilo >= kilo)
            {
                urun.kilo -= kilo;
                return true;
            }
        }
        return false;
    }

    static void UrunleriListele(List<Urun> halUrunleri)
    {
        if (halUrunleri.Count == 0) // listenin boş olup olmadığı kontrol ediliyor.
        {
            Console.WriteLine("Hiç ürün yok.");
            return;
        }

        foreach (var urun in halUrunleri)
        {
            Console.WriteLine($"{urun.isim} - {urun.kilo} kg");
        }
    }

    static void ListeleMeyveler()
    {
        Console.WriteLine("Meyveler:");
        Console.WriteLine("1. Elma");
        Console.WriteLine("2. Muz");
        Console.WriteLine("3. Portakal");
        Console.WriteLine("4. Üzüm");
        Console.WriteLine("5. Çilek");
    }

    static void ListeleSebzeler()
    {
        Console.WriteLine("Sebzeler:");
        Console.WriteLine("1. Domates");
        Console.WriteLine("2. Salatalık");
        Console.WriteLine("3. Patates");
        Console.WriteLine("4. Havuç");
        Console.WriteLine("5. Biber");
    }

    static bool DevamEt()
    {
        Console.Write("Başka bir arzunuz var mı? (E/H): ");
        char devam = Console.ReadKey().KeyChar;
        Console.WriteLine();
        return char.ToUpper(devam) == 'E';
    }
}

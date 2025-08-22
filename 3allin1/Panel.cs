using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _3allin1
{
    internal class Panel
    {
        private bool RepaetedWhile = true;
        string SelecetVeritabani;

        string[] SecilenVeritabani;
        private void MainScreen()
        {
            IslemeSistemi Islem;

            string input;
            string input2;
            string input3;
            FirstSelect();

            void FirstSelect()
            {
                Console.WriteLine("-*-*-*-*-*- Ana Sayfa -*-*-*-*-*-");
                Console.WriteLine("Lüften İşlem yapmak istediğiniz Veritabanı Seçiniz");
                // SADECE 3 TANE VERİTABANI 
                Console.WriteLine("1. Forum Veritabanı");
                Console.WriteLine("2. Fabrika Veritabanı");
                Console.WriteLine("3. Galeri Veritabanı");
                Console.WriteLine("4. Çıkış");

                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        SecilenVeritabani = BaglantiYol.ForuminTables;
                        SelecetVeritabani = "ForumVeritabani";
                        Islem = new IslemeSistemi("ForumVeritabani");
                        SecondSelect();
                        break;
                    case "2":
                        SecilenVeritabani = BaglantiYol.FabrikainTables;
                        SelecetVeritabani = "Fabrika_Veritabani";
                        Islem = new IslemeSistemi("Fabrika_Veritabani");
                        SecondSelect();
                        break;
                    case "3":
                        SecilenVeritabani = BaglantiYol.GaleriinTables;
                        SelecetVeritabani = "CarGaleriVeritabani";
                        Islem = new IslemeSistemi("CarGaleriVeritabani");
                        SecondSelect();
                        break;
                    case "4":
                        RepaetedWhile = false;
                        break;
                    default:
                        FirstSelect();
                        break;
                }
            }

            void SecondSelect()
            {
                Console.WriteLine("-*-*- " + input + ". Seçimi Yapıldı -*-*-");
                Console.WriteLine("");
                Console.WriteLine("-*-*-*- Veritabanında Tablo Seçimi -*-*-*-");
                for (int i = 0; i < SecilenVeritabani.Length; i++)
                {
                    if (SecilenVeritabani[i] == "null") { continue;}
                    Console.WriteLine((i + 1) + ". " + SecilenVeritabani[i]);
                }
                input2 = Console.ReadLine();
                switch (input2)
                {
                    case "1":
                        ThirdSelect();
                        break;
                    case "2":
                        if (SecilenVeritabani[1] == "null") {SecondSelect();}
                        ThirdSelect();
                        break;
                    case "3":
                        if (SecilenVeritabani[2] == "null") {SecondSelect();}
                        ThirdSelect();
                        break;
                    default:
                        SecondSelect();
                        break;
                }
            }


            void ThirdSelect()
            {
                Console.WriteLine("Seçildi.");
                Console.WriteLine("");
                Console.WriteLine("-*-*-* "+ input+" ve "+ SecilenVeritabani[Convert.ToInt32(input2)-1] + " Seçimi Yapıldı.");

                Console.WriteLine("Yapılacak İşlemleri Lütfen seçiniz.");
                Console.WriteLine("1. Listeleme");
                Console.WriteLine("2. Ekleme");
                Console.WriteLine("3. Silme");
                Console.WriteLine("4. Arama");

                input3 = Console.ReadLine();

                switch (input3)
                {
                    case "1":
                        string cmdl = BaglantiYol.CmderListele(SecilenVeritabani[Convert.ToInt32(input2) - 1]);
                        IslemeSistemi ListeleNew = new IslemeSistemi(SelecetVeritabani);
                        ListeleNew.Listele(cmdl);
                        break;
                    case "2":
                        string cmde = BaglantiYol.CmderEkleme(SecilenVeritabani[Convert.ToInt32(input2) - 1]);
                        IslemeSistemi EklemeNew = new IslemeSistemi(SelecetVeritabani);
                        EklemeNew.Ekleme(cmde);
                        break;
                    case "3":
                        string cmds = BaglantiYol.CmderSilme(SecilenVeritabani[Convert.ToInt32(input2) - 1]);
                        IslemeSistemi SilmeNew = new IslemeSistemi(SelecetVeritabani);
                        SilmeNew.Silme(cmds);
                        break;
                    case "4":
                        string cmda = BaglantiYol.CmderArama(SecilenVeritabani[Convert.ToInt32(input2) - 1]);
                        IslemeSistemi AramaNew = new IslemeSistemi(SelecetVeritabani);
                        AramaNew.Arama(cmda);
                        break;
                    default:
                        break;
                }

            }
        }


        





        public void Start()
        {
            while (RepaetedWhile)
            {
                MainScreen();
            }
        }

    }
}

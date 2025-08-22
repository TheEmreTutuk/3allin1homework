using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3allin1
{
    internal class BaglantiYol
    {

        public static string LocalYol(string Namespace)
        {
            string Datasource = "DESKTOP-6H4I8IJ\\SQLEXPRESS";
            return @"Data Source="+ Datasource + "; Initial Catalog="+ Namespace + "; Integrated Security=True";
        }

        // SADECE 3 TANE VERİTABANIYLA İŞLEM YAPILIR
        // BURADA TÜM DÜZELTMELER GİRDİLERİ VE ÇIKIŞLARI AYARLANAN YER
        // PANELLE İLİŞKİLİDİR.

        public static string[] ForuminTables = { "Forums", "Kategoris", "MEMBERS" };

        public static string[] FabrikainTables = { "Calisanlar", "Tedarik", "Nakliyat" };

        public static string[] GaleriinTables = { "ARABA","GALERI" ,"null"};

        //LİSTELEME CMD GİRDİSİ
        public static string CmderListele(string WhatTable)
        {
            if (WhatTable == "MEMBERS")
            {
                IslemeSistemi.countTypes = 3;
                IslemeSistemi.Types = new string[] { "int" ,"string","string"};
                IslemeSistemi.TypesName = new string[] { "ID" ,"Nick","Açıklama"};
                return "SELECT ID, Nick, ProfileDescription FROM MEMBERS";
            }
            else if (WhatTable == "Kategoris")
            {
                IslemeSistemi.countTypes = 3;
                IslemeSistemi.Types = new string[] { "int", "string", "string" };
                IslemeSistemi.TypesName = new string[] { "ID", "Ismi", "Açıklama" };
                return "SELECT Kategori_ID,Ismi,Description FROM Kategoris";
            }
            else if (WhatTable == "Forums")
            {
                IslemeSistemi.countTypes = 3;
                IslemeSistemi.Types = new string[] { "string","string", "string", "string" };
                IslemeSistemi.TypesName = new string[] { "Forum Numarası","Yazan Kişi", "Başlık", "Açıklama" };
                return "SELECT  F.Forum_ID,M.Nick,F.Title,F.Description FROM Forums AS F JOIN MEMBERS AS M ON M.ID = F.TypeMember_ID";
            }else if(WhatTable == "Calisanlar")
            {
                IslemeSistemi.countTypes = 5;
                IslemeSistemi.Types = new string[] { "string", "string", "string" ,"string","string"};
                IslemeSistemi.TypesName = new string[] { "Kimlik", "Isim", "Soyisim" ,"Şehir","Doğduğu Yer"};
                return "SELECT CalisanKimlik,Isim, Soyisim,Sehir,DogumYeri FROM Calisanlar";
            }
            else if (WhatTable == "Tedarik")
            {
                IslemeSistemi.countTypes = 3;
                IslemeSistemi.Types = new string[] { "int", "string", "string" };
                IslemeSistemi.TypesName = new string[] { "ID", "Tedarik ismi", "Adresi" };
                return "SELECT TedarikID,Isim,Adres FROM Tedarik";
            }
            else if (WhatTable == "Nakliyat")
            {
                IslemeSistemi.countTypes = 3;
                IslemeSistemi.Types = new string[] { "int", "string", "string" };
                IslemeSistemi.TypesName = new string[] { "ID", "Nakliyat ismi", "Adresi" };
                return "SELECT NakliyatID,Isim,Adres FROM Nakliyat";
            }
            else if (WhatTable == "ARABA")
            {
                IslemeSistemi.countTypes = 10;
                IslemeSistemi.Types = new string[] { "string", "string", "string" ,"int","string","string","long","string","string","decimal"};
                IslemeSistemi.TypesName = new string[] { "Plaka", "Motor No", "Şaşe No" ,"Yıl","Markası","Modeli","KM","Yakıt Tipi","Vites","Fiyati"};
                return "SELECT Plaka,MotorNosu,SaseNosu,Yili,Marka,Model,Kilometresi,YakitTipi,Vites,Fiyat FROM ARABA";
            }
            else if (WhatTable == "GALERI")
            {
                IslemeSistemi.countTypes = 3;
                IslemeSistemi.Types = new string[] { "int","string", "string", "string" };
                IslemeSistemi.TypesName = new string[] { "ID","Ismi", "Adresi", "Sahibi" };
                return "SELECT ID,Ismi,Adres,Sahibi FROM GALERI";
            }
            else
            {
                return "null";
            }
        }

        // EKLEME CMD GİRDİSİ
        public static string CmderEkleme(string WhatTable)
        {
            if (WhatTable == "MEMBERS")
            {
                IslemeSistemi.countadders = 5;
                IslemeSistemi.adders = new string[] { "string", "string","date","date","string" };
                IslemeSistemi.adderssinir = new int[] { 100, 15,0,0,0 };
                IslemeSistemi.addersexplain = new string[] { "Kullanıcı Nicki Belirleyin", "Yaşadığı Şehir","Doğum Tarihi","Kayıt Tarihi","Açıklaması" };
                return "INSERT INTO MEMBERS(Nick,Region,BirthDate,RegistryDate,ProfileDescription) VALUES(@0,@1,@2,@3,@4);";

            }
            else if (WhatTable == "Kategoris")
            {
                IslemeSistemi.countadders = 2;
                IslemeSistemi.adders = new string[] { "string", "string" };
                IslemeSistemi.adderssinir = new int[] { 20, 15 };
                IslemeSistemi.addersexplain = new string[] { "Kategori Ismi Belirleyin", "Açıklaması" };
                return "INSERT INTO Kategoris(Ismi,Description) VALUES(@0,@1);";
            }
            else if (WhatTable == "Forums")
            {
                IslemeSistemi.countadders = 5;
                IslemeSistemi.adders = new string[] { "string","int", "string","string","int" };
                IslemeSistemi.adderssinir = new int[] { 10,0, 60,0,0 };
                IslemeSistemi.addersexplain = new string[] { "Forum ID Numarası Giriniz (FORXXX)","Formu Yazan MEMBER ID numarası giriniz.", "Başlığı","Açıklaması","Formun Kategori ID numarası giriniz" };
                return "INSERT INTO Forums(Forum_ID,TypeMember_ID,Title,Description,Kategori_ID) VALUES(@0,@1,@2,@3,@4);";
            }
            else if (WhatTable == "Calisanlar")
            {
                IslemeSistemi.countadders = 5;
                IslemeSistemi.adders = new string[] { "string", "string", "string", "string", "string" };
                IslemeSistemi.adderssinir = new int[] { 11, 50, 50, 20, 30 };
                IslemeSistemi.addersexplain = new string[] { "Çalışan Kimliği Giriniz", "Ismi", "Soyismi", "Şehir", "Doğduğu Şehri" };
                return "INSERT INTO Calisanlar(CalisanKimlik,Isim,Soyisim,Sehir,DogumYeri) VALUES(@0,@1,@2,@3,@4);";
            }
            else if (WhatTable == "Tedarik")
            {
                IslemeSistemi.countadders = 2;
                IslemeSistemi.adders = new string[] { "string", "string" };
                IslemeSistemi.adderssinir = new int[] { 100, 100 };
                IslemeSistemi.addersexplain = new string[] { "Tedarikçinin Ismi Belirleyin ", "Adresi " };
                return "INSERT INTO Tedarik(Isim,Adres) VALUES(@0,@1);";
            }
            else if (WhatTable == "Nakliyat")
            {
                IslemeSistemi.countadders = 2;
                IslemeSistemi.adders = new string[] { "string", "string" };
                IslemeSistemi.adderssinir = new int[] { 100, 100 };
                IslemeSistemi.addersexplain = new string[] { "Nakliyatçının Ismi Belirleyin ", "Adresi " };
                return "INSERT INTO Nakliyat(Isim,Adres) VALUES(@0,@1);";
            }
            else if (WhatTable == "ARABA")
            {
                IslemeSistemi.countadders = 12;
                IslemeSistemi.adders = new string[] { "string", "string","string","int","string","string","bool","bool","long","string","string","decimal"};
                IslemeSistemi.adderssinir = new int[] { 8, 10,5,0 ,50,20,0,0,0,20,20,0};
                IslemeSistemi.addersexplain = new string[] { "Plaka (00XXX000)", "Motor Nosu","Şaşe Nosu","Yili","Markası (Audi,BMW,Fiat,Ford,Honda,Hyundai,Mecredes-Benz,Renault,Toyota,Volkswagen) \n Bu markalardan seçiniz","Modeli ","2. El mi?","Ağır Hasar Kaydı Var mı?","Kilometresi","Yakıt Tipi","Vitesi","Fiyati" };
                return "INSERT INTO ARABA(Plaka,MotorNosu,SaseNosu,Yili,Marka,Model,Is2inciEl,AgirHasarKaydi,Kilometresi,YakitTipi,Vites,Fiyat) VALUES(@0,@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11);";
            }
            else if (WhatTable == "GALERI")
            {
                IslemeSistemi.countadders = 3;
                IslemeSistemi.adders = new string[] { "string", "string","string" };
                IslemeSistemi.adderssinir = new int[] { 50, 100 ,50};
                IslemeSistemi.addersexplain = new string[] { "Galerinin Ismi", "Adresi ","Sahibi " };
                return "INSERT INTO GALERI(Ismi,Adres,Sahibi) VALUES(@0,@1,@2);";
            }
            else
            {
                return "null";
            }
        }

        // SİLME CMD GİRDİSİ
        public static string CmderSilme(string WhatTable)
        {
            if (WhatTable == "MEMBERS")
            {
                IslemeSistemi.deleteexplain = "Silmek İstediğiniz Üye ID numarasını giriniz.";
                IslemeSistemi.deleteType = "int";
                return "DELETE FROM MEMBERS WHERE ID = @dhere";
            }
            else if (WhatTable == "Kategoris")
            {
                IslemeSistemi.deleteexplain = "Silmek İstediğiniz Kategori ID numarasını giriniz.";
                IslemeSistemi.deleteType = "int";
                return "DELETE FROM Kategoris WHERE Kategori_ID = @dhere";
            }
            else if (WhatTable == "Forums")
            {
                IslemeSistemi.deleteexplain = "Silmek İstediğiniz Forum ID numarasını giriniz. (FORXXX)";
                IslemeSistemi.deleteType = "string";
                return "DELETE FROM Forums WHERE Forum_ID = @dhere";
            }
            else if (WhatTable == "Calisanlar")
            {
                IslemeSistemi.deleteexplain = "Silmek İstediğiniz Çalışan Kimlik numarasını giriniz. (11 Haneli)";
                IslemeSistemi.deleteType = "string";
                return "DELETE FROM Calisanlar WHERE CalisanKimlik = @dhere";
            }
            else if (WhatTable == "Tedarik")
            {
                IslemeSistemi.deleteexplain = "Silmek İstediğiniz Tedarik ID numarasını giriniz.";
                IslemeSistemi.deleteType = "int";
                return "DELETE FROM Tedarik WHERE TedarikID = @dhere";
            }
            else if (WhatTable == "Nakliyat")
            {
                IslemeSistemi.deleteexplain = "Silmek İstediğiniz Nakliyat ID numarasını giriniz.";
                IslemeSistemi.deleteType = "int";
                return "DELETE FROM Nakliyat WHERE NakliyatID =  @dhere";
            }
            else if (WhatTable == "ARABA")
            {
                IslemeSistemi.deleteexplain = "Silmek İstediğiniz Arabanın PLAKAsını giriniz. (00XXX000)";
                IslemeSistemi.deleteType = "string";
                return "DELETE FROM ARABA WHERE Plaka = @dhere";
            }
            else if (WhatTable == "GALERI")
            {
                IslemeSistemi.deleteexplain = "Silmek İstediğiniz Galeri ID numarasını giriniz.";
                IslemeSistemi.deleteType = "int";
                return "DELETE FROM GALERI WHERE ID = @dhere";
            }
            else
            {
                return "null";
            }
        }

        public static string CmderArama(string WhatTable)
        {
            if (WhatTable == "MEMBERS")
            {
                IslemeSistemi.countTypes = 3;
                IslemeSistemi.Types = new string[] { "int", "string", "string" };
                IslemeSistemi.TypesName = new string[] { "ID", "Nick", "Açıklama" };
                IslemeSistemi.findexplain = "Aramak istediğiniz Üye ID numarasını giriniz.";
                IslemeSistemi.findtype = "int";
                return "SELECT ID, Nick, ProfileDescription FROM MEMBERS WHERE ID = @fhere";
            }
            else if (WhatTable == "Kategoris")
            {
                IslemeSistemi.countTypes = 3;
                IslemeSistemi.Types = new string[] { "int", "string", "string" };
                IslemeSistemi.TypesName = new string[] { "ID", "Ismi", "Açıklama" };
                IslemeSistemi.findexplain = "Aramak istediğiniz Kategori ID numarasını giriniz.";
                IslemeSistemi.findtype = "int";
                return "SELECT Kategori_ID,Ismi,Description FROM Kategoris WHERE Kategori_ID = @fhere";
            }
            else if (WhatTable == "Forums")
            {
                IslemeSistemi.countTypes = 3;
                IslemeSistemi.Types = new string[] { "string", "string", "string", "string" };
                IslemeSistemi.TypesName = new string[] { "Forum Numarası", "Yazan Kişi", "Başlık", "Açıklama" };
                IslemeSistemi.findexplain = "Aramak istediğiniz Forum ID numarasını giriniz. (FORXXX)";
                IslemeSistemi.findtype = "string";
                return "SELECT  F.Forum_ID,M.Nick,F.Title,F.Description FROM Forums AS F JOIN MEMBERS AS M ON M.ID = F.TypeMember_ID WHERE F.Forum_ID = @fhere";
            }
            else if (WhatTable == "Calisanlar")
            {
                IslemeSistemi.countTypes = 5;
                IslemeSistemi.Types = new string[] { "string", "string", "string", "string", "string" };
                IslemeSistemi.TypesName = new string[] { "Kimlik", "Isim", "Soyisim", "Şehir", "Doğduğu Yer" };
                IslemeSistemi.findexplain = "Aramak istediğiniz Çalışan Kimlik numarasını giriniz. (11 Haneli)";
                IslemeSistemi.findtype = "string";
                return "SELECT CalisanKimlik,Isim, Soyisim,Sehir,DogumYeri FROM Calisanlar WHERE CalisanKimlik = @fhere";
            }
            else if (WhatTable == "Tedarik")
            {
                IslemeSistemi.countTypes = 3;
                IslemeSistemi.Types = new string[] { "int", "string", "string" };
                IslemeSistemi.TypesName = new string[] { "ID", "Tedarik ismi", "Adresi" };
                IslemeSistemi.findexplain = "Aramak istediğiniz Tedarik ID numarasını giriniz.";
                IslemeSistemi.findtype = "int";
                return "SELECT TedarikID,Isim,Adres FROM Tedarik WHERE TedarikID = @fhere";
            }
            else if (WhatTable == "Nakliyat")
            {
                IslemeSistemi.countTypes = 3;
                IslemeSistemi.Types = new string[] { "int", "string", "string" };
                IslemeSistemi.TypesName = new string[] { "ID", "Nakliyat ismi", "Adresi" };
                IslemeSistemi.findexplain = "Aramak istediğiniz Nakliyat ID numarasını giriniz.";
                IslemeSistemi.findtype = "int";
                return "SELECT NakliyatID,Isim,Adres FROM Nakliyat WHERE NakliyatID = @fhere";
            }
            else if (WhatTable == "ARABA")
            {
                IslemeSistemi.countTypes = 10;
                IslemeSistemi.Types = new string[] { "string", "string", "string", "int", "string", "string", "long", "string", "string", "decimal" };
                IslemeSistemi.TypesName = new string[] { "Plaka", "Motor No", "Şaşe No", "Yıl", "Markası", "Modeli", "KM", "Yakıt Tipi", "Vites", "Fiyati" };
                IslemeSistemi.findexplain = "Aramak istediğiniz Arabanın Plaka numarasını giriniz. (00XXX000)";
                IslemeSistemi.findtype = "string";
                return "SELECT Plaka,MotorNosu,SaseNosu,Yili,Marka,Model,Kilometresi,YakitTipi,Vites,Fiyat FROM ARABA WHERE Plaka = @fhere";
            }
            else if (WhatTable == "GALERI")
            {
                IslemeSistemi.countTypes = 3;
                IslemeSistemi.Types = new string[] { "int", "string", "string", "string" };
                IslemeSistemi.TypesName = new string[] { "ID", "Ismi", "Adresi", "Sahibi" };
                IslemeSistemi.findexplain = "Aramak istediğiniz Galeri ID numarasını giriniz.";
                IslemeSistemi.findtype = "int";
                return "SELECT ID,Ismi,Adres,Sahibi FROM GALERI WHERE ID = @fhere";
            }
            else
            {
                return "null";
            }
        }
    }
}

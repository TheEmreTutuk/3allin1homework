using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3allin1
{
    internal class IslemeSistemi
    {
        SqlConnection con;
        SqlCommand cmd;

        public IslemeSistemi(string namespac)
        {
            con = new SqlConnection(BaglantiYol.LocalYol(namespac));
            cmd = con.CreateCommand();
        }
        //listeleme değişkenleri
        public static int countTypes;
        public static string[] Types;
        public static string[] TypesName;
        //ekleme değişkenleri
        public static int countadders;
        public static string[] adders;
        public static int[] adderssinir;
        public static string[] addersexplain;
        //silme değişkenleri
        public static string deleteexplain;
        public static string deleteType;
        //arama değişkenleri
        public static string findexplain;
        public static string findtype;

        object TypeToSet(int Count,string TypeName,SqlDataReader read)
        {
            if (TypeName == "int")
            {
                return read.GetInt32(Count);
            }else if (TypeName == "string")
            {
                return read.GetString(Count);
            }else if (TypeName == "long")
            {
                return read.GetInt64(Count);
            }else if (TypeName == "decimal")
            {
                return read.GetDecimal(Count);
            }
            else
            {
                return null;
            }
        }

        public void Listele(string cmdText)
        {
            try
            {
                cmd.CommandText = cmdText;
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader Read = cmd.ExecuteReader();
                while (Read.Read())
                {
                    for (int i = 0; i < countTypes; i++)
                    {
                        object item = TypeToSet(i, Types[i], Read);
                        Console.WriteLine(TypesName[i] + ": " + item);
                    }
                    Console.WriteLine("");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                con.Close();
            }
        }


        string AddString(string Explain,int Sinir)
        {
            Console.WriteLine(Explain);
            string input = Console.ReadLine();

            if (String.IsNullOrEmpty(input))
            {
                Console.WriteLine("Boş Bırakılmaz");
                return AddString(Explain, Sinir);
            } else if(input.Length > Sinir && Sinir != 0)
            {
                Console.WriteLine("Sınır "+Sinir+ " Olmalı.");
                return AddString(Explain, Sinir);
            }
            else
            {
                return input;
            }
        }

        string AddDate(string Explain)
        {
            Console.WriteLine(Explain);
            Console.WriteLine("01.01.2000 Şeklinde Tarih Belirtin GÜN/AY/YIL");
            string input = Console.ReadLine();

            if (String.IsNullOrEmpty(input))
            {
                Console.WriteLine("Boş Bırakılmaz");
                return AddDate(Explain);
            }
            for (int i = 0; i < input.Length; i++)
            {
                if(input[i] == ' ')
                {
                    Console.WriteLine("Boşluk Bırakılmaz");
                    return AddDate(Explain);
                }
            }

            string[] split = input.Split('.');
            if (split.Length != 3)
            {
                Console.WriteLine("Hatalı Yerleşim");
                return AddDate(Explain);
            }
            try
            {
                int first = Convert.ToInt32(split[0]);
                int second = Convert.ToInt32(split[1]);
                int three = Convert.ToInt32(split[2]);

                if (first < 0 && first > 29 && second < 1 && second > 12 && three < 1970 && three > 2026)
                {
                    Console.WriteLine("Uygunsuz Yerleşim");
                    return AddDate(Explain);
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return AddDate(Explain);
            }
            Console.WriteLine(input);
            return input;
        }

        int AddInt(string Explain)
        {
            Console.WriteLine(Explain);
            Console.WriteLine("(SAYI BİÇİMDE YAZINIZ)");
            string input = Console.ReadLine() ;

            try
            {
                int convert = Convert.ToInt32(input);
                return convert;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("");
                Console.WriteLine("Hataya Karşıladı. Tekrar Deneyiniz");
                return AddInt(Explain);
            }
        }

        decimal AddDecimal(string Explain)
        {
            Console.WriteLine(Explain);
            Console.WriteLine("(SAYI BİÇİMDE YAZINIZ)");
            string input = Console.ReadLine();

            try
            {
                decimal convert = Convert.ToDecimal(input);
                return convert;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("");
                Console.WriteLine("Hataya Karşıladı. Tekrar Deneyiniz");
                return AddDecimal(Explain);
            }
        }

        long AddLong(string Explain)
        {
            Console.WriteLine(Explain);
            Console.WriteLine("(SAYI BİÇİMDE YAZINIZ)");
            string input = Console.ReadLine();

            try
            {
                long convert = Convert.ToInt64(input);
                return convert;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("");
                Console.WriteLine("Hataya Karşıladı. Tekrar Deneyiniz");
                return AddLong(Explain);
            }
        }

        bool AddBool(string Explain)
        {
            Console.WriteLine(Explain);
            Console.WriteLine("Evet ise e / Hayır ise h / Default h");
            string input = Console.ReadLine();

            switch (input)
            {
                case "e":
                    Console.WriteLine("Evet Seçimi Yapıldı");
                    return true;
                case "h":
                    Console.WriteLine("Hayır Seçimi Yapıldı.");
                    return false;
                default:
                    Console.WriteLine("Otomatik Olarak Hayır Ayarlandı.");
                    return false;
            }
        }

        object TypeToInput(string whatAdder,string explain,int sinir)
        {
            if(whatAdder == "string")
            {
                return AddString(explain, sinir);
            }else if(whatAdder == "int")
            {
                return AddInt(explain);
            }else if(whatAdder == "long")
            {
                return AddLong(explain);
            }else if(whatAdder == "date")
            {
                return AddDate(explain);
            }else if(whatAdder == "bool")
            {
                return AddBool(explain);
            }else if(whatAdder == "decimal")
            {
                return AddDecimal(explain);
            }
            else
            {
                return null;
            }
        }


        public void Ekleme(string cmdText)
        {
            try
            {
                cmd.CommandText = cmdText;
                cmd.Parameters.Clear();
                for (int i = 0; i < countadders; i++)
                {
                    object item = TypeToInput(adders[i], addersexplain[i], adderssinir[i]);
                    cmd.Parameters.AddWithValue("@" + i, item);
                }
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Ekleme İşlemi Başarılı");
            }catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Ekleme İşlemi Başarısız");
            }
            finally
            {
                con.Close();
            }
        }

        public void Silme(string cmdText)
        {
            try
            {
                cmd.CommandText = cmdText;
                cmd.Parameters.Clear();
                object item = TypeToInput(deleteType,deleteexplain,0);
                cmd.Parameters.AddWithValue("@dhere", item);
                con.Open() ;
                cmd.ExecuteNonQuery();
                Console.WriteLine("Silme İşlemi Başarılı");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Silme İşlemi Başarısız");
            }finally { con.Close(); }
        }

        public void Arama(string cmdText)
        {
            try
            {
                cmd.CommandText = cmdText;
                cmd.Parameters.Clear();
                object itemd = TypeToInput(findtype,findexplain,0);
                cmd.Parameters.AddWithValue("@fhere", itemd);
                con.Open();
                SqlDataReader Read = cmd.ExecuteReader();
                while (Read.Read())
                {
                    for (int i = 0; i < countTypes; i++)
                    {
                        object item = TypeToSet(i, Types[i], Read);
                        Console.WriteLine(TypesName[i] + ": " + item);
                    }
                    Console.WriteLine("");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Bulma İşlemi Başarısız");
            }
            finally { con.Close(); }
        }

        
    }
}

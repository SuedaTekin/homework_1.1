using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

class TcKimlik
{
    private string tcKimlikNo;

    public string TcKimlikNo
    {
        get { return tcKimlikNo; }
        set
        {
            if (IsValidTcKimlik(value))
            {
                tcKimlikNo = value;
            }
            else
            {
                throw new ArgumentException("Geçersiz TC Kimlik Numarası.");
            }
        }
    }

    private bool IsValidTcKimlik(string value)
    {
        // 1. TC kimlik numarası 11 karakter olmalı
        if (value.Length != 11)
            return false;

        // 2. Tüm karakterleri sayısal karakter olmalı
        foreach (char c in value)
        {
            if (!char.IsDigit(c))
                return false;
        }

        return true;
    }

    public string GetIlkBesKarakter()
    {
        return tcKimlikNo.Substring(0, 5);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            TcKimlik tcKimlik = new TcKimlik();
            Console.WriteLine("TC Kimlik Numarasını Girin:");
            string input = Console.ReadLine();
            tcKimlik.TcKimlikNo = input;

            Console.WriteLine($"TC Kimlik Numarasının ilk 5 karakteri: {tcKimlik.GetIlkBesKarakter()}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}


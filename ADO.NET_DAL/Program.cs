using ADO.NET_DAL.Models;
using ADO.NET_DAL.Repositories;
using System.Linq.Expressions;
using System.Reflection;

internal class Program
{
    
    public static void Main(string[] args)
    {
        RepositoryBase<Person> _personRepositoryBase = new();
        while (true)
        {
            Console.WriteLine("1. Kayıt Eklemek için        (a)\n" +
                                "2. Kayıt Listelemek için     (l)\n" +
                                "3. Kayır aramak için         (s)\n" +
                                "4. Çıkış                     (e)\n");
            Console.Write("Seçiminizi yapın: ");
            char select = Convert.ToChar(Console.ReadLine());
                switch (select)
            {
                case ('a'):
                    Console.Clear();
                    Console.Write("Adı daxil edin:");
                    string firstName = Console.ReadLine();
                    Console.Write("Soyadı daxil edin:");
                    string lastName = Console.ReadLine();
                    Console.Write("Phone daxil edin:");
                    string phone = Console.ReadLine();
                    Console.Write("Email daxil edin:");
                    string email = Console.ReadLine();

                    Person person = new()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Phone = phone,
                        Email = email
                    };
                    var result = _personRepositoryBase.Insert(person);
                    if (result) { Console.WriteLine("Kullanıcı eklendi"); Thread.Sleep(1000); }
                    else { Console.WriteLine("Kullanıcı eklenirken hata oldu."); Thread.Sleep(1000); };
                    break;
                case ('l'):
                    var list = _personRepositoryBase.GetAllDisConnected();
                    foreach (Person listItem in list)
                    {
                        foreach (PropertyInfo prop in listItem.GetType().GetProperties())
                        {
                            Console.WriteLine($"{prop.Name,-10} : {prop.GetValue(listItem)}");
                        }
                        Console.WriteLine($"\n{new String('_', 50)}");
                    }
                    Console.WriteLine("Kayıt silmek için    (d)\n" +
                                      "İşlem menüne dönmek işin (m)");
                    char choose2 = Convert.ToChar(Console.ReadLine());
                    if(choose2 == 'd')
                    {
                        Console.Write("Kullanıcı Id sini yazın : ");
                        int personId = Convert.ToInt32(Console.ReadLine());
                        _personRepositoryBase.Delete(personId);
                        Console.WriteLine("Kullanıcı silindi.");
                        Thread.Sleep(1000);
                        Console.Clear();
                    }
                    else if(choose2 == 'm')
                    {
                        Console.Clear();
                        break;
                    }
                    break;
                case ('s'):
                    Console.Write("Enter search: ");
                    string searchItem = Console.ReadLine();
                    var searchedList = _personRepositoryBase.Search(Person=> Person.FirstName == searchItem);
                    foreach (Person listItem in searchedList)
                    {
                        foreach (PropertyInfo prop in listItem.GetType().GetProperties())
                        {
                            Console.WriteLine($"{prop.Name,-10} : {prop.GetValue(listItem)}");
                        }
                        Console.WriteLine($"\n{new String('_', 50)}");
                    }
                    Console.WriteLine("\nÇıkmak için bir tuşa basın.");
                    Console.ReadLine();
                    break;
                case ('e'):
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Seçiminiz düzgün deyil.");
                    Thread.Sleep(900);
                    Console.Clear();
                    break;
            }
        }
    }
}





/*
 CREATE DATABASE PhoneBook;

USE PhoneBook;

CREATE TABLE People(
	Id int identity(1,1) PRIMARY KEY NOT NULL,
	FirstName nvarchar(50) NOT NULL,
	LastName nvarchar(100) NULL,
	Phone nvarchar(24),
	Email nvarchar(100)
)


INSERT INTO People VALUES ('Qudrat','Abidzada','+994(55) 664 21 43','abidzade.qudret@gmail.com')
 
 */
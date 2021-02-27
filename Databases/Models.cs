using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Modele bazy danych
/// </summary>
namespace FootballTeam.Databases
{
    /// <summary>
    /// Model adresów
    /// </summary>
    public class Address
    {
        public int Id { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string Number { get; set; }

        public string Country { get; set; }

    }
    /// <summary>
    ///  Model pilkarza
    /// </summary>
    public class Footballer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Weight { get; set; }

        public int Height { get; set; }
        [NotMapped]
        // zcalenie imienia i nazwiska 
        public string FullName => $"{FirstName} {LastName}";

        //'foreign key'
        public List<TransferHistory> TransferHistories { get; set; }

        public Footballer() { }

        // tworzenie gracza
        public Footballer(string firstName, string lastName, string nationality,
            DateTime dateOfBirth, int weight, int height)
        {
            FirstName = firstName;
            LastName = lastName;
            Nationality = nationality;
            DateOfBirth = dateOfBirth;
            Weight = weight;
            Height = height;
        }
    }
    /// <summary>
    ///  Model klubu
    /// </summary>
   
}

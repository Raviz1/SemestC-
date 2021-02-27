﻿using System;
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

}

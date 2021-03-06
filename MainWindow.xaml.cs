﻿
using FootballTeam.Databases;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

using System;



namespace FootballTeam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        Context dbContext;
        Footballer footballerToCreate = new Footballer();
        Sponsor sponsorToCreate = new Sponsor();

        public MainWindow(Context dbContext)
        {
            this.dbContext = dbContext;
            footballerToCreate = new Footballer();
            sponsorToCreate = new Sponsor();
            InitializeComponent();
            Inicjalizator.Initialize(dbContext);
            GetFootballers();
            GetSponsors();

            AddFootballerGrid.DataContext = footballerToCreate;
            AddSponsorGrid.DataContext = sponsorToCreate;
        }
        /// <summary>
        ///  Crud dla Graczy
        /// </summary>
        #region Footballers
        // Read
        private void GetFootballers()
        {
            FootballerDG.ItemsSource = dbContext.Footballers.ToList();
        }
        private void AddFootballer(object s, RoutedEventArgs e)
        {
            dbContext.Footballers.Add(footballerToCreate);
            dbContext.SaveChanges();
            GetFootballers();
            footballerToCreate = new Footballer();
            AddFootballerGrid.DataContext = footballerToCreate;
        }
        // Update
        Footballer selectedFootballer = new Footballer();
        private void UpdateFootballerForEdit(object s, RoutedEventArgs e)
        {
            selectedFootballer = (s as FrameworkElement).DataContext as Footballer;
            EditFootballerGrid.DataContext = selectedFootballer;
            AddFootballerGrid.Visibility = Visibility.Collapsed;
            EditFootballerGrid.Visibility = Visibility.Visible;
        }

        private void UpdateFootballer(object s, RoutedEventArgs e)
        {
            dbContext.Update(selectedFootballer);
            dbContext.SaveChanges();
            GetFootballers();
            AddFootballerGrid.Visibility = Visibility.Visible;
            EditFootballerGrid.Visibility = Visibility.Hidden;
        }
        // Delete
        private void DeleteFootballer(object s, RoutedEventArgs e)
        {
            var footballerToBeDeleted = (s as FrameworkElement).DataContext as Footballer;
            dbContext.Footballers.Remove(footballerToBeDeleted);
            dbContext.SaveChanges();
            GetFootballers();
        }
        // Anulowanie Zmiany
        private void CancelChanges(object s, RoutedEventArgs e)
        {
            AddFootballerGrid.Visibility = Visibility.Visible;
            EditFootballerGrid.Visibility = Visibility.Collapsed;
        }
        #endregion

        /// <summary>
        /// Crud dla Sponsorów
        /// </summary>
        #region Sponsors
        // Read
        private void GetSponsors()
        {
            SponsorDG.ItemsSource = dbContext.Sponsors.ToList();
        }
        // Create
        private void AddSponsor(object s, RoutedEventArgs e)
        {
            dbContext.Sponsors.Add(sponsorToCreate);
            dbContext.SaveChanges();
            GetSponsors();
            sponsorToCreate = new Sponsor();
            AddSponsorGrid.DataContext = sponsorToCreate;
        }
        // Update
        Sponsor selectedSponsor = new Sponsor();
        private void UpdateSponsorForEdit(object s, RoutedEventArgs e)
        {
            selectedSponsor = (s as FrameworkElement).DataContext as Sponsor;
            EditSponsorGrid.DataContext = selectedSponsor;
            AddSponsorGrid.Visibility = Visibility.Collapsed;
            EditSponsorGrid.Visibility = Visibility.Visible;
        }

        private void UpdateSponsor(object s, RoutedEventArgs e)
        {
            dbContext.Update(selectedSponsor);
            dbContext.SaveChanges();
            GetSponsors();
            AddSponsorGrid.Visibility = Visibility.Visible;
            EditSponsorGrid.Visibility = Visibility.Hidden;
        }
        //Deleted
        private void DeleteSponsor(object s, RoutedEventArgs e)
        {
            var sponsorToBeDeleted = (s as FrameworkElement).DataContext as Sponsor;
            dbContext.Sponsors.Remove(sponsorToBeDeleted);
            dbContext.SaveChanges();
            GetSponsors();
        }
        // Anulowanie zminany
        private void CancelSponsorChanges(object s, RoutedEventArgs e)
        {
            AddSponsorGrid.Visibility = Visibility.Visible;
            EditSponsorGrid.Visibility = Visibility.Collapsed;
        }
        #endregion
    }
}

﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using NotificationCentre.SideBar.Models;
using Presentation.Core;

namespace NotificationCentre.SideBar.ViewModels
{
    internal sealed class SideBarViewModel : INotifyPropertyChanged, ISideBarViewModel
    {
        private bool _isOpen;
        private ICommand _clearSearch;
        private ICommand _switchTheme;
        private string _searchString = string.Empty;

        public event PropertyChangedEventHandler PropertyChanged;

        public string SearchString
        {
            get { return _searchString; }
            set
            {
                if (_searchString == value)
                    return;

                _searchString = value;
                PropertyChanged.Raise(this);
            }
        }

        public ICommand ClearSearch
        {
            get { return _clearSearch; }
            set
            {
                if (_clearSearch == value)
                    return;

                _clearSearch = value;
                PropertyChanged.Raise(this);
            }
        }

        public ICommand SwitchTheme
        {
            get { return _switchTheme; }
            set
            {
                if (_switchTheme == value)
                    return;

                _switchTheme = value;
                PropertyChanged.Raise(this);
            }
        }

        public bool IsOpen
        {
            get { return _isOpen; }
            set
            {
                if (_isOpen == value)
                    return;

                _isOpen = value;
                PropertyChanged.Raise(this);
            }
        }

        public ObservableCollection<IAlertModel> Alerts { get; } = new ObservableCollection<IAlertModel>();
    }
}
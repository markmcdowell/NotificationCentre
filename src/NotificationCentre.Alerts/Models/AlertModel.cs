﻿using System.ComponentModel;
using System.Windows.Input;
using Presentation.Core;

namespace NotificationCentre.Alerts.Models
{
    internal sealed class AlertModel : INotifyPropertyChanged, IAlertModel
    {
        private string _id;
        private string _title;
        private string _content;
        private bool _hasAlert;
        private ICommand _timeout;
        private ICommand _dismiss;
        private ICommand _action;

        public AlertModel(ICommand timeout, ICommand dismiss, ICommand action)
        {
            _timeout = timeout;
            _dismiss = dismiss;
            _action = action;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool HasAlert
        {
            get { return _hasAlert; }
            set
            {
                if (_hasAlert == value)
                    return;

                _hasAlert = value;
                PropertyChanged.Raise(this);
            }
        }

        public string Id
        {
            get { return _id; }
            set
            {
                if (_id == value)
                    return;

                _id = value;
                PropertyChanged.Raise(this);
            }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                if (_title == value)
                    return;

                _title = value;
                PropertyChanged.Raise(this);
            }
        }

        public string Content
        {
            get { return _content; }
            set
            {
                if (_content == value)
                    return;

                _content = value;
                PropertyChanged.Raise(this);
            }
        }

        public ICommand Timeout
        {
            get { return _timeout; }
            set
            {
                if (_timeout == value)
                    return;

                _timeout = value;
                PropertyChanged.Raise(this);
            }
        }

        public ICommand Dismiss
        {
            get { return _dismiss; }
            set
            {
                if (_dismiss == value)
                    return;
                
                _dismiss = value;
                PropertyChanged.Raise(this);
            }
        }

        public ICommand Action
        {
            get { return _action; }
            set
            {
                if (_action == value)
                    return;

                _action = value;
                PropertyChanged.Raise(this);
            }
        }
    }
}
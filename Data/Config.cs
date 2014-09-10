﻿using System.Windows;

#region

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Xml.Serialization;
using LeagueSharp.Loader.Class;

#endregion

/*
    Copyright (C) 2014 LeagueSharp

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

/*
    Copyright (C) 2014 Nikita Bernthaler

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

namespace LeagueSharp.Loader.Data
{
    public static class Directories
    {
        public static readonly string RepositoryDir =
            System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "LeagueSharp", "Repositories") + "\\";

        public static readonly string AssembliesDir =
            System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assemblies") + "\\";

        public static readonly string LibrariesDir = System.IO.Path.Combine(AssembliesDir, "System") + "\\";

        public static readonly string LogsDir = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs") +
                                                "\\";
    }

    [ XmlType(AnonymousType = true) ]
    [ XmlRoot(Namespace = "", IsNullable = false) ]
    public class Config : INotifyPropertyChanged
    {
        private ObservableCollection<LeagueSharpAssembly> _installedAssemblies;
        private ObservableCollection<string> _knownRepositories;

        private ConfigSettings _settings;
        private bool _updateOnLoad = false;
        private bool _install = true;
        private bool _firstRun = true;

        public bool FirstRun
        {
            get
            {
                return _firstRun;
            }
            set
            {
                _firstRun = value;
                OnPropertyChanged("FirstRun");
            }
        }

        public bool Install
        {
            get
            {
                return _install;
            }
            set
            {
                _install = value;
                OnPropertyChanged("Install");
            }
        }

        public bool UpdateOnLoad
        {
            get { return _updateOnLoad; }
            set
            {
                _updateOnLoad = value;
                OnPropertyChanged("UpdateOnLoad");
            }
        }

        public string Username { get; set; }

        public string Password { get; set; }

        public ConfigSettings Settings
        {
            get { return _settings; }
            set
            {
                _settings = value;
                OnPropertyChanged("Settings");
            }
        }

        [ XmlArrayItem("InstalledAssemblies", IsNullable = true) ]
        public ObservableCollection<LeagueSharpAssembly> InstalledAssemblies
        {
            get { return _installedAssemblies; }
            set
            {
                _installedAssemblies = value;
                OnPropertyChanged("InstalledAssemblies");
            }
        }

        [ XmlArrayItem("KnownRepositories", IsNullable = true) ]
        public ObservableCollection<string> KnownRepositories
        {
            get { return _knownRepositories; }
            set
            {
                _knownRepositories = value;
                OnPropertyChanged("KnownRepositories");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }


    [ XmlType(AnonymousType = true) ]
    public class ConfigSettings : INotifyPropertyChanged
    {
        private ObservableCollection<GameSettings> _gameSettings;


        [ XmlArrayItem("GameSettings", IsNullable = true) ]
        public ObservableCollection<GameSettings> GameSettings
        {
            get { return _gameSettings; }
            set
            {
                _gameSettings = value;
                OnPropertyChanged("GameSettings");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class GameSettings : INotifyPropertyChanged
    {
        private string _name;
        private List<string> _posibleValues;
        private string _selectedValue;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public List<string> PosibleValues
        {
            get { return _posibleValues; }
            set
            {
                _posibleValues = value;
                OnPropertyChanged("PosibleValues");
            }
        }

        public string SelectedValue
        {
            get { return _selectedValue; }
            set
            {
                _selectedValue = value;
                OnPropertyChanged("SelectedValue");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
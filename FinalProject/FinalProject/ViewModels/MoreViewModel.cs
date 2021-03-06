﻿using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using Xamarin.Forms.Xaml;
using static FinalProject.Models.WeatherItemModel;

namespace FinalProject.ViewModels
{
    class MoreViewModel : BindableBase, INavigatedAware
    {
        INavigationService _navigationService;

        public DelegateCommand GoBackCommand { get; set; }

        private WeatherItem _weatherItem;
        public WeatherItem WeatherItem
        {
            get { return _weatherItem; }
            set { SetProperty(ref _weatherItem, value); }
        }

        public MoreViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            GoBackCommand = new DelegateCommand(GoBack);
        }

        private void GoBack()
        {
            _navigationService.GoBackAsync();
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("WeatherItemInfo"))
            {
                WeatherItem = (WeatherItem)parameters["WeatherItemInfo"];
            }
        }
    }
}

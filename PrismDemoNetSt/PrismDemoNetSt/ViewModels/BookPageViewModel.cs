using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using PrismDemoNetSt.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismDemoNetSt.ViewModels
{
	public class BookPageViewModel : ViewModelBase, INavigationAware
	{
        private readonly INavigationService _navigationService;
        private IPageDialogService _dialogService;

        private Book _book;
        public Book Book
        {
            get { return _book; }
            set { SetProperty(ref _book, value); }
        }

        public DelegateCommand ReadBookCommand { get; set; }

        public BookPageViewModel(INavigationService navigationService, IPageDialogService dialogService) 
            : base (navigationService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
            
            ReadBookCommand = new DelegateCommand(ShowAlert);
        }

        private async void ShowAlert()
        {
            // show alert with response
            var answer = await _dialogService.DisplayAlertAsync("Prism: DisplayAlertAsync", "Did you read this book?", "Yes", "No");
        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("book"))
                Book = (Book)parameters["book"];
        }
    }
}

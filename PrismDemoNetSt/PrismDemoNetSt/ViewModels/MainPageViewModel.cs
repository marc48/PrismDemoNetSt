using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.ObjectModel;
using PrismDemoNetSt.Models;
using PrismDemoNetSt.Services;

namespace PrismDemoNetSt.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        readonly INavigationService _navigationService;
        IBookService _bookService;

        private ObservableCollection<Book> _books = new ObservableCollection<Book>();
        public ObservableCollection<Book> Books
        {
            get { return _books; }
            set { SetProperty(ref _books, value); }
        }

        private Book _book;
        public Book Book
        {
            get { return _book; }
            set { SetProperty(ref _book, value); }
        }

        private string _maintext;
        public string MainText
        {
            get { return _maintext; }
            set { SetProperty(ref _maintext, value); }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        private int _year;
        public int Year
        {
            get { return _year; }
            set { SetProperty(ref _year, value); }
        }
        private string _firstname;
        public string FirstName
        {
            get { return _firstname; }
            set { SetProperty(ref _firstname, value); }
        }
        private string _author;
        public string Author
        {
            get { return _author; }
            set { SetProperty(ref _author, value); }
        }

        public DelegateCommand AddBookCommand { get; set; }
        public DelegateCommand LoadJsonCommand { get; set; }
        public DelegateCommand<Book> BookSelectedCommand => new DelegateCommand<Book>(OnBookSelectedCommandExecuted);

        private void AddBook()
        {
            _books.Add(new Book() { Title = "New Book", Year = 2018, Author = "Dolby", FirstName = "John" });
            MainText = "Book added...";
        }

        public MainPageViewModel(INavigationService navigationService, IBookService bookService) 
            : base (navigationService)
        {
            _navigationService = navigationService;
            _bookService = bookService;
            MainText = "Books loaded: OnNavigationTo";
            AddBookCommand = new DelegateCommand(AddBook);
            LoadJsonCommand = new DelegateCommand(LoadJsonBooks);
        }

        private async void LoadJsonBooks()
        {
            Books = new ObservableCollection<Book>(await _bookService.GetBooks());
            _books.Add(new Book() { Title = " Basic elements of narrative", Year = 2009, FirstName = "David", Author = "Herman" });
            MainText = "Books reloaded and one added...";
        }

        private async void OnBookSelectedCommandExecuted(Book book)
        {
            var p = new NavigationParameters();
            p.Add("book", book);

            await _navigationService.NavigateAsync("BookPage", p);
        }

        public async override void OnNavigatedTo(NavigationParameters parameters)
        {
            Books = new ObservableCollection<Book>(await _bookService.GetBooks());
        }
    }
}

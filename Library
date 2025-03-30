import 'dart:async';

abstract class LibraryItem {
  final int id;
  final String title;
  final int year;

  LibraryItem(this.id, this.title, this.year);

  String getInfo(); 
  bool isAvailable();
}

mixin Borrowable implements LibraryItem{
  bool isBorrowed = false;
  String? borrowedBy;
  DateTime? borrowedDate;

  Future<void> borrow(String userName) async {
    await Future.delayed(Duration(seconds: 1));
    if (isBorrowed) {
      throw Exception('Цей предмет вже позичено $borrowedBy з ${borrowedDate!.toLocal()}');
    }
    isBorrowed = true;
    borrowedBy = userName;
    borrowedDate = DateTime.now();
    print('$userName позичив(ла) "$this" на ${borrowedDate!.toLocal()}');
  }

  Future<void> returnItem() async {
    await Future.delayed(Duration(seconds: 1));
    if (!isBorrowed) {
      throw Exception('Цей предмет не позичений.');
    }
    isBorrowed = false;
    borrowedBy = null;
    borrowedDate = null;
    print('"$this" повернено до бібліотеки.');
  }
}

mixin Searchable implements LibraryItem{
  bool matchesQuery(String query) {
    return toString().toLowerCase().contains(query.toLowerCase());
  }
}

class Book extends LibraryItem with Borrowable, Searchable {
  final String author;
  final int pages;

  Book(int id, String title, int year, this.author, this.pages)
      : super(id, title, year);

  @override
  String getInfo() {
    return 'Book: $title, Author: $author, Year: $year, Pages: $pages, ID: $id';
  }

  @override
  bool isAvailable() => !isBorrowed;
}

class Magazine extends LibraryItem with Searchable {
  final int issueNumber;
  final String publisher;

  Magazine(int id, String title, int year, this.issueNumber, this.publisher)
      : super(id, title, year);

  @override
  String getInfo() {
    return 'Magazine: $title, Publisher: $publisher, Year: $year, Issue Number: $issueNumber, ID: $id';
  }

  @override
  bool isAvailable() => true; 
}

class DVD extends LibraryItem with Borrowable, Searchable {
  final String director;
  final double duration;

  DVD(int id, String title, int year, this.director, this.duration)
      : super(id, title, year);

  @override
  String getInfo() {
    return 'DVD: $title, Director: $director, Year: $year, Duration: $duration min, ID: $id';
  }

  @override
  bool isAvailable() => !isBorrowed;
}

class Library {
  final List<LibraryItem> _items = [];

  void addItem(LibraryItem item) {
    _items.add(item);
    print('${item.title} додано до бібліотеки.');
  }

  void deleteItem(int itemId) {
    _items.removeWhere((item) => item.id == itemId);
    print('Елемент ID: $itemId видалено.');
  }

  void clearLibrary() {
    _items.clear();
    print('Бібліотека очищена.');
  }

  void checkItems() {
    if (_items.isEmpty) {
      print('Бібліотека порожня.');
      return;
    }
    print('Список доступних елементів:');
    for (var item in _items) {
      print(item.getInfo());
    }
  }

  Future<List<LibraryItem>> search(String query) async {
    await Future.delayed(Duration(seconds: 2));
    return _items.where((item) => item is Searchable && item.matchesQuery(query)).toList();
  }

  Future<void> borrowItem(int itemId, String userName) async {
    var item = _items.firstWhere((item) => item.id == itemId, orElse: () => throw Exception('Елемент не знайдено.'));
    if (item is Magazine) {
      throw Exception('Журнали не можна позичати.');
    }
    if (item is Borrowable) {
      await item.borrow(userName);
    } else {
      throw Exception('Цей предмет не можна позичити.');
    }
  }

  Future<void> returnItem(int itemId) async {
    var item = _items.firstWhere((item) => item.id == itemId, orElse: () => throw Exception('Елемент не знайдено.'));
    if (item is Borrowable) {
      await item.returnItem();
    } else {
      throw Exception('Цей предмет не можна повернути.');
    }
  }
}

class LibraryReport {
  static void getOverallStatistics(List<LibraryItem> items) {
    int books = items.whereType<Book>().length;
    int magazines = items.whereType<Magazine>().length;
    int dvds = items.whereType<DVD>().length;
    double avgYear = items.isEmpty ? 0 : items.map((e) => e.year).reduce((a, b) => a + b) / items.length;

    print('--- Загальна статистика ---');
    print('Книг: $books');
    print('Журналів: $magazines');
    print('DVD: $dvds');
    print('Середній рік видання: ${avgYear.toStringAsFixed(2)}');
  }

  static void getBorrowedItems(List<LibraryItem> items) {
    var borrowedItems = items.where((item) => item is Borrowable && (item as Borrowable).isBorrowed).toList();
    if (borrowedItems.isEmpty) {
      print('Наразі немає позичених предметів.');
      return;
    }
    print('--- Позичені предмети ---');
    for (var item in borrowedItems) {
      print(item.getInfo());
    }
  }
}

void main() async {
  Library library = Library();

  var book1 = Book(1, 'The Great Gatsby', 1925, 'F. Scott Fitzgerald', 180);
  var book2 = Book(2, '1984', 1949, 'George Orwell', 328);
  var magazine1 = Magazine(3, 'National Geographic', 2021, 5, 'NatGeo');
  var dvd1 = DVD(4, 'Inception', 2010, 'Christopher Nolan', 148);

  library.addItem(book1);
  library.addItem(book2);
  library.addItem(magazine1);
  library.addItem(dvd1);

  library.checkItems();

  var foundItems = await library.search('1984');
  print('Знайдені елементи:');
  foundItems.forEach((item) => print(item.getInfo()));

  try {
    await library.borrowItem(1, 'Олена');
    await library.returnItem(1);
  } catch (e) {
    print('Помилка: $e');
  }

  LibraryReport.getOverallStatistics(library._items);
  LibraryReport.getBorrowedItems(library._items);
}

import 'dart:io';

void main() {
  stdout.write("Введіть текст: ");
  String text = stdin.readLineSync() ?? "";

  List<String> words = text.split(RegExp(r'\s+'));
  List<String> sentences = text.split(RegExp(r'[.!?]+'));

  sentences = sentences.map((s) => s.trim()).where((s) => s.isNotEmpty).toList();

  int wordCount = words.length;
  int sentenceCount = sentences.length;

  String longestWord = words.reduce((a, b) => a.length >= b.length ? a : b);

  Set<String> uniqueWords = words.map((word) => word.toLowerCase()).toSet();

  Map<String, int> wordFrequency = {};
  for (String word in words) {
    String cleanedWord = word.toLowerCase();
    wordFrequency[cleanedWord] = (wordFrequency[cleanedWord] ?? 0) + 1;
  }

  print("Кількість слів: $wordCount");
  print("Кількість речень: $sentenceCount");
  print("Найдовше слово: $longestWord");
  print("Унікальні слова: ${uniqueWords.length}");
  print("Частота використання слів:");
  wordFrequency.forEach((word, count) {
    print("$word: $count");
  });
}

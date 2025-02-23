import 'dart:math';

void main() {
  
  List<String> students = [
    "Анна", "Богдан", "Віктор", "Ольга", "Дмитро",
    "Микита", "Марія", "Михайло", "Іван", "Катерина"
  ];

  Random random = Random();
  Map<String, int> studentGrades = {
    for (var student in students) student: random.nextInt(12) + 1
  };

  List<int> grades = studentGrades.values.toList();

  double averageGrade = grades.reduce((a, b) => a + b) / grades.length;
  int maxGrade = grades.reduce((a, b) => a > b ? a : b);
  int minGrade = grades.reduce((a, b) => a < b ? a : b);

  Map<String, int> gradeCategories = {
    '10-12': 0,
    '7-9': 0,
    '4-6': 0,
    '1-3': 0,
  };

  for (int grade in grades) {
    if (grade >= 10) {
      gradeCategories['10-12'] = (gradeCategories['10-12'] ?? 0) + 1;
    } else if (grade >= 7) {
      gradeCategories['7-9'] = (gradeCategories['7-9'] ?? 0) + 1;
    } else if (grade >= 4) {
      gradeCategories['4-6'] = (gradeCategories['4-6'] ?? 0) + 1;
    } else {
      gradeCategories['1-3'] = (gradeCategories['1-3'] ?? 0) + 1;
    }
  }

  Set<String> excellentStudents = studentGrades.entries
      .where((entry) => entry.value >= 10)
      .map((entry) => entry.key)
      .toSet();

  print("Оцінки студентів:");
  studentGrades.forEach((student, grade) {
    print("$student: $grade");
  });
  print("Середній бал: ${averageGrade.toStringAsFixed(2)}");
  print("Максимальний бал: $maxGrade");
  print("Мінімальний бал: $minGrade");
  print("Розподіл оцінок по категоріях: $gradeCategories");
  print("Студенти-відмінники (оцінки 10 і більше): $excellentStudents");
}

using System;
using System.Collections.Generic;
using System.IO;
using SchoolGradingSystem.Models;
using SchoolGradingSystem.Exceptions;

namespace SchoolGradingSystem.Services
{
    public class StudentResultProcessor
    {
        public List<Student> ReadStudentsFromFile(string inputFilePath)
        {
            var students = new List<Student>();

            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(',');

                    if (parts.Length != 3)
                        throw new MissingFieldException($"Missing data in line: {line}");

                    if (!int.TryParse(parts[0], out int id))
                        throw new InvalidScoreFormatException($"Invalid ID format in line: {line}");

                    string fullName = parts[1].Trim();

                    if (!int.TryParse(parts[2], out int score))
                        throw new InvalidScoreFormatException($"Invalid score format in line: {line}");

                    students.Add(new Student(id, fullName, score));
                }
            }

            return students;
        }

        public void WriteReportToFile(List<Student> students, string outputFilePath)
        {
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (var student in students)
                {
                    writer.WriteLine($"{student.FullName} (ID: {student.Id}): Score = {student.Score}, Grade = {student.GetGrade()}");
                }
            }
        }
    }
}

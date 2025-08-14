﻿using System;
using System.Collections.Generic;
using System.IO;
using SchoolGradingSystem.Models;
using SchoolGradingSystem.Services;
using SchoolGradingSystem.Exceptions;

namespace SchoolGradingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var processor = new StudentResultProcessor();

            try
            {
                string inputFilePath = "students.txt";
                string outputFilePath = "report.txt";

                List<Student> students = processor.ReadStudentsFromFile(inputFilePath);
                processor.WriteReportToFile(students, outputFilePath);

                Console.WriteLine("Report generated successfully!");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (InvalidScoreFormatException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (MissingFieldException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
    }
}

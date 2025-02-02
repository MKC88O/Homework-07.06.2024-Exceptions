﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_07._06._2024_Exceptions
{
    class Group
    {
        private readonly List<Student> students;
        private string? nameOfGroup;
        private string? specializationOfGroup;
        private int numberOfCourse = 0;

        public Group() : this("PV312", "Software Development", 1) {}

        public Group(string? nameOfGroup, string? specializationOfGroup) : this(nameOfGroup, specializationOfGroup, 1) {}

        public Group(string? nameOfGroup, string? specializationOfGroup, int numberOfCourse)
        {
            SetNameOfGroup(nameOfGroup);
            SetSpecializationOfGroup(specializationOfGroup);
            SetNumberOfCourse(numberOfCourse);
            students = new();
        }
        public void SetNameOfGroup(string? nameOfGroup)
        {
            this.nameOfGroup = nameOfGroup;
        }

        public void SetSpecializationOfGroup(string? specializationOfGroup)
        {
            this.specializationOfGroup = specializationOfGroup;
        }

        public void SetNumberOfCourse(int numberOfCourse)
        {
            this.numberOfCourse = numberOfCourse;
        }

        public string? GetNameOfGroup()
        {
            return nameOfGroup;
        }

        public string? GetSpecializationOfGroup()
        {
            return specializationOfGroup;
        }

        public int GetNumberOfCourse()
        {
            return numberOfCourse;
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            students.Remove(student);
        }


        public void Print()
        {
            Console.WriteLine("\tGROUP:\n");
            Console.WriteLine(nameOfGroup + "\n" + specializationOfGroup);
            Console.WriteLine();
            Console.WriteLine("№" + "  Name:" + "\tLastname:\n");
            for (int i = 0; i < students.Count; i++)
            {
                var student = students[i];
                Console.WriteLine(i + 1 + "  " + student.GetName() + " \t" + student.GetLastName());
            }
        }

        public void StudentTransfer(Student student, Group newGroup)
        {
            RemoveStudent(student);
            newGroup.AddStudent(student);
            Console.WriteLine("Student " + student.GetName() + " " + student.GetLastName() + " was transferred to the group " + newGroup.GetNameOfGroup());
            Console.WriteLine();
        }

        public void EditingGroupData(string newName, string newSpecialization, int newNumber)
        {
            nameOfGroup = newName;
            specializationOfGroup = newSpecialization;
            numberOfCourse = newNumber;
        }

        public void RemoveMostUnderachieverStudent()
        {
            try
            {
                if (students.Count == 0)
                {
                    Console.WriteLine("Group is empty.");
                    return;
                }

                var MostUnderachieverStudent = students[0];
                foreach (var student in students)
                {
                    if (student.AverageRatings() < MostUnderachieverStudent.AverageRatings())
                    {
                        MostUnderachieverStudent = student;
                    }
                }

                students.Remove(MostUnderachieverStudent);
                Console.WriteLine("Student " + MostUnderachieverStudent.GetName() + " " + MostUnderachieverStudent.GetLastName() + " removed from group " + nameOfGroup);
                Console.WriteLine();
            }
            catch (Exception ex) 
            { 
                Console.WriteLine("Erroe: " + ex.Message);
            }
        }
    }
}

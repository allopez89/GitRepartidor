using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GitRepartidor{
    
    static class Program{
        
        static void Main(string[] args){
            studentsfile = "";
            topicsfile = "";

            if(args.Length == 2){
                studentsfile = $@"{args[0]}";
                topicsfile = $@"{args[1]}";
            }

            Console.WriteLine("How many groups? ");
            int groups = int.Parse(Console.ReadLine());
            string[] students = File.ReadAllLines(studentsfile);
            string[] topics = File.REadAllLines(topicsfile);

            if(students.Length != 0 && topics.Length > groups){
                List<string> randomStudents = students.ToList();
                randomStudents.RemoveAll(s => string.IsNullOrWhiteSpace(s));
                randomStudents.Shuffle();

                List<string> randomTopics = topics.ToList();
                randomTopics.RemoveAll(s => string.IsNullOrWhiteSpace(s));
                randomTopics.Suffle();

                int studentsxgroups = students.Length / groups;
                int remainingstudentes = students.Length % groups;
                int topicsxgroups = topics.Length / groups;
                int remainingtopics = topics.Length % groups;

                for(int i = 1; i <= gropus; i++){
                    
                    Console.WriteLine($"Group {i}: ");
                    for (int j = 0; j < studentsxgroups; j++){
                        Console.WriteLine($"    {j + 1}. {randomStudents[0]}");
                        randomStudents.RemoveAt(0);
                    }

                    if (remainingstudentes > 0){
                        Console.WriteLine($"    {studentsxgroups +1}. {randomStudents[0]}");
                        randomStudents.RemoveAt(0);
                        remainingstudentes--;
                    }

                    Console.WriteLine("         Topics: ");
                    for(int k = 0; k < topicsxgroups; k++;){
                        Console.WriteLine($"            {k + 1}. {randomTopics[0]}");
                        randomTopics.RemoveAt(0);
                    }

                    if(remainingtopics >0){
                        Console.WriteLine($"            {topicsxgroups + 1}. {randomTopics[0]}");
                        randomTopics.RemoveAt(0);
                        remainingtopics--;
                    }
                }
            }
            else{
                Console.WriteLine("The number of students or topics are not acceptable.");
            }
            Console.WriteLine("Press Enter to exit.");
            Console.ReadKey();
        }

        public static void Shuffle<T>(this IList<T> list){
            Random rng = new Random();
            int n = list.Count;
            while(n > 1){
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
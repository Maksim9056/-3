using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace КТ_3
{
    internal class Global
    {
        /// <summary>
        /// https://metanit.com/sharp/efcore/1.2.php
        /// </summary>
        public class ApplicationContext : DbContext
        {
            public DbSet<User> Users { get; set; } = null!;
            public ApplicationContext()
            {
                Database.EnsureCreated(); // гарантируем, что бд будет создание
            }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                // optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Testdb;Username=postgres;Password=1");


                optionsBuilder.UseSqlite("Data Source=helloapp.db");
            }
        }


        /// <summary>
        /// Создание базы данных
        /// </summary>
        public void CreateDataBase()
        {
            try
            {


                using (ApplicationContext db = new ApplicationContext())
                {

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        /// <summary>
        /// Регестрация пользователей
        /// </summary>
        /// <param name="user"></param>
        public void CreateUser(User user)
        {
            try
            {
                if (user.Age < 14)
                {
                    Exception exc = new Exception($"Регистрация запрещена для пользователей младше 14 лет Пользователь:{user.Name},Возраст:{user.Age}");
                    exc.HelpLink = "https://ithub.bulgakov.app/lessons/69696";
                    exc.Data.Add("Время возникновения", DateTime.Now);
                    exc.Data.Add("Причина", $"Регистрация запрещена для пользователей младше 14 лет{user.Name},{user.Age}");

                    throw exc;
                    
                }
                else
                {

                    using (ApplicationContext context = new ApplicationContext())
                    {
                        context.AddRange(user);
                        context.SaveChanges();
                        Console.WriteLine("Пользователей зарегистрировался", user.Name, user.Age);
                    }


                }
              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Выводит всех пользователей
        /// </summary>
        public void Select()
        {
            try
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    var users = context.Users.ToList();


                    for (int i = 0; i < users.Count(); i++)
                    {

                        Console.WriteLine($"Пользователь:{users[i].Name},Возраст:{users[i].Age}");
                        Console.WriteLine();
                    }
                }
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }

    }

        /// <summary>
        /// Класс пользователей
        /// </summary>
        public class User
        {
              /// <summary>
             /// Id пользователя
             /// </summary>
             public int Id { get; set; }

            /// <summary>
            /// Имя пользователя
           /// </summary>
           public string Name { get; set; }
             /// <summary>
            /// Имя пользователя
            /// </summary>
            public int Age { get; set; }
            public User() { }
             
             
            public User(int id, string name, int age)
            {
                Id = id;
                Name = name;
                Age = age;
            }
            public User(string name, int age)
            {
                Name = name;
                Age = age;
            }
        }
    }


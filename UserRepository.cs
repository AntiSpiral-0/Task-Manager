using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
namespace Management
{
    class UserRepository
    {
        private string user;
        private string password;

        public string User{
            get{return user;}
            set{user = value;}
        }
        public string Password{
            get{return password;}
            set{password = value ;}
        }
        public UserRepository(string user , string password)
        {
            User = user;
            Password = password;
        }

    }
    class UserInfo
    {
        
    }
    class Access
    {
        static List<UserRepository> users = new List<UserRepository>();
        static List<UserRepository> LoggedUsers = new List<UserRepository>();

        public void FillUsers()
        {
            Console.WriteLine("Please Choose Y if you're adding someone and N if you are finished");
            string choice = Console.ReadLine();
            while (choice.ToUpper() == "Y")
            {
                Console.WriteLine("Please Write your username here");
                string UN = Console.ReadLine();
                Console.WriteLine("Please Write a Password");
                string PW = Console.ReadLine();
                foreach (UserRepository userRepository in users)
                {
                    if(userRepository.User == UN)
                    {
                        Console.WriteLine("Apologies, this name is taken !");
                        break;
                    }
                    else
                    {
                        UserRepository user = new UserRepository(UN , PW);
                        users.Add(user);
                    }
                }
            }
        }
        public void Login()
        {
            Console.WriteLine("Welcome! Please write your username !");
            string Userinput1 = Console.ReadLine();
            Console.WriteLine("Please Write down your password");
            string userinput2 = Console.ReadLine();
            foreach(UserRepository us in users )
            {
                if((us.User == Userinput1)&& (us.Password == userinput2))
                {
                    UserRepository loggeduser = new UserRepository(Userinput1, userinput2);
                    Console.WriteLine($"Welcome {Userinput1} you are now logged in !");
                    LoggedUsers.Add(loggeduser);
                }
                else
                {   
                    Console.WriteLine("Apologies , your username doesn't exist in our database");
                    break;
                }
            } 
        }
        public void logout()
        {
            Console.WriteLine("Please write your password to log out");
            string pw = Console.ReadLine();
            foreach(UserRepository user in LoggedUsers)
            {
                if(user.Password == pw)
                {
                    Console.WriteLine($"You have successfully logged out {user.User}");
                    LoggedUsers.Remove(user);
                    break;
                }
                else
                {
                    Console.WriteLine("password is incorrect! try again.");
                }
            }
        }
    }
}

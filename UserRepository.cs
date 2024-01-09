using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
namespace Management
{
    class UserRepository
    {
        private string user;
        private string email;
        private int number;
        private string password;

        public string User
        {
            get { return user; }
            set { user = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public int Number
        {
            get { return number; }
            set { number = value; }
        }
        public UserRepository(string user, string password, string email, int number)
        {
            User = user;
            Password = password;
            Email = email;
            Number = number;
        }
        public static bool CheckEmail(string mail)
        {
            int atrep = 0;
            int pointrep = 0;
            for (int i = 0; i < mail.Length; i++)
            {
                if (mail[i] == '@')
                {
                    atrep = atrep + 1;
                }
                else if (mail[i] == '.')
                {
                    pointrep = pointrep + 1;
                }
            }
            if ((pointrep > 1 && atrep > 1) || (pointrep == 0 && atrep == 0))
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        public static bool CheckPassword(string password)
        {
            const int minimumPasswordLength = 8;

            try
            {
               
                if (password.Length < minimumPasswordLength)
                {
                    throw new ArgumentException("Password must be at least 8 characters long.");
                }

              
                bool hasUpperCase = false;
                foreach (char ch in password)
                {
                    if (char.IsUpper(ch))
                    {
                        hasUpperCase = true;
                        break;
                    }
                }
                if (!hasUpperCase)
                {
                    throw new ArgumentException("Password must contain at least one uppercase letter.");
                }

    
                bool hasLowerCase = false;
                foreach (char ch in password)
                {
                    if (char.IsLower(ch))
                    {
                        hasLowerCase = true;
                        break;
                    }
                }
                if (!hasLowerCase)
                {
                    throw new ArgumentException("Password must contain at least one lowercase letter.");
                }

                
                bool hasDigit = false;
                foreach (char ch in password)
                {
                    if (char.IsDigit(ch))
                    {
                        hasDigit = true;
                        break;
                    }
                }
                if (!hasDigit)
                {
                    throw new ArgumentException("Password must contain at least one digit.");
                }

                // Check for at least one special character
                bool hasSpecialChar = false;
                foreach (char ch in password)
                {
                    if (!char.IsLetterOrDigit(ch))
                    {
                        hasSpecialChar = true;
                        break;
                    }
                }
                if (!hasSpecialChar)
                {
                    throw new ArgumentException("Password must contain at least one special character.");
                }

                return true; 
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Invalid Password: {ex.Message}");
                return false;
            }
        }


    }
    class logged
    {
        private UserRepository user1;

        public UserRepository User1
        {
            get { return user1; }
            set { user1 = value; }
        }
        public logged(UserRepository user)
        {
            User1 = user;
        }
    }
    class Access
    {
        static List<UserRepository> users = new List<UserRepository>();
        static List<logged> LoggedUsers = new List<logged>();

        public void SignUp()
        {
            Console.WriteLine("Please Choose Y if you're adding someone and N if you are finished");
            string choice = Console.ReadLine();
            while (choice.ToUpper() == "Y")
            {
                Console.WriteLine("Please Write your username here");
                string UN = Console.ReadLine();
                Console.WriteLine("Please write your email");
                string EM = Console.ReadLine();
                Console.WriteLine("Please write your number");
                int NUM = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please Write a Password");
                string PW = Console.ReadLine();
                foreach (UserRepository userRepository in users)
                {
                    if (userRepository.User == UN)
                    {
                        Console.WriteLine("Apologies, this name is taken !");
                        break;
                    }
                    else if ((userRepository.Email == EM) || UserRepository.CheckEmail(EM))
                    {
                        Console.WriteLine("Apologies, this email is taken or not valid !");
                        break;
                    }
                    else if (userRepository.Number == NUM)
                    {
                        Console.WriteLine("Apologies, this number is taken !");
                        break;
                    }
                    else if (UserRepository.CheckPassword(PW))
                    {

                    }
                    else
                    {
                        UserRepository user = new UserRepository(UN, PW, EM, NUM);
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
            foreach (UserRepository us in users)
            {
                if ((us.User == Userinput1) && (us.Password == userinput2))
                {
                    logged loggeduser = new logged(us);
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
        public void Logout()
        {


            Console.WriteLine("Please write your username to log out");
            string us = Console.ReadLine();

            for (int i = 0; i < LoggedUsers.Count; i++)
            {
                if (LoggedUsers[i].User1.User == us)
                {
                    Console.WriteLine($"You have successfully logged out {LoggedUsers[i].User1.User}");
                    LoggedUsers.RemoveAt(i);
                    return;
                }
            }

            Console.WriteLine("Username is incorrect! Try again.");
        }
    }
}


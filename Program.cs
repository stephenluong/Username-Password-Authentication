using System;

namespace Username_and_Password_Verifier
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***********************");
            Console.WriteLine("* New Account Details *");
            Console.WriteLine("***********************\n");

            //string username = "user1";
            //string password = "P@ssword1";

            //UserAccount newAccount = new UserAccount();

            bool validInput = false;
            UserAccount newAccount = new UserAccount("temp", "Password1!", validInput);
            while (!validInput)
            {
                try
                {
                    Console.Write("Enter the username: ");
                    newAccount.Username = Console.ReadLine();
                    validInput = true;
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
            validInput = false;
            while (!validInput)
            {
                try
                {
                    Console.Write("Enter the password: ");
                    newAccount.Password = Console.ReadLine();
                    newAccount.IsValid = validInput;
                    validInput = true;
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
            Console.WriteLine("The following account information has been successfully created. \n\n" + newAccount);
            Console.ReadKey();
        }
    }
}
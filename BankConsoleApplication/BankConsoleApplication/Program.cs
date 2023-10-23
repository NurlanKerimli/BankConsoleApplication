using BankConsoleApplication.CustomExceptions;
using BankConsoleApplication.Interfaces;
using BankConsoleApplication.Models;
using System.Data;

namespace BankConsoleApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();

            while (true)
            {
                Console.WriteLine("Xoş gəlmisiniz!");
                Console.WriteLine("1. Yeni hesab yarat");
                Console.WriteLine("2. Pul yatır");
                Console.WriteLine("3. Pul çıxart");
                Console.WriteLine("4. Bütün hesabların siyahısı");
                Console.WriteLine("5. Hesablar arası pul köçürmə");
                Console.WriteLine("0. Çıxış");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        IAccount account = bank.CreateAccount();
                        Console.WriteLine($"Yeni hesab yaradıldı. Hesab ID: {account.AccountId}");
                        break;
                    case "2":
                        Console.Write("Hesab ID-ni daxil edin: ");
                        if (int.TryParse(Console.ReadLine(), out int depositAccountId))
                        {
                            Console.Write("Yatırılacaq məbləği daxil edin: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount))
                            {
                                try
                                {
                                    bank.DepositMoney(depositAccountId, depositAmount);
                                    Console.WriteLine("Əməliyyat uğurla tamamlandı.");
                                }
                                catch (AccountNotFoundException e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                catch (InvalidAmountException e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Yanlış məbləq daxil edildi.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Yanlış hesab ID daxil edildi.");
                        }
                        break;
                    case "3":
                        Console.Write("Hesab ID-ni daxil edin: ");
                        if (int.TryParse(Console.ReadLine(), out int withdrawAccountId))
                        {
                            Console.Write("Çıxarılacaq məbləği daxil edin: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount))
                            {
                                try
                                {
                                    bank.WithdrawMoney(withdrawAccountId, withdrawAmount);
                                    Console.WriteLine("Əməliyyat uğurla tamamlandı.");
                                }
                                catch (AccountNotFoundException e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                catch (InvalidAmountException e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                catch (InsufficientFundsException e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Yanlış məbləq daxil edildi.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Yanlış hesab ID daxil edildi.");
                        }
                        break;
                    case "4":
                        List<IAccount> allAccounts = bank.GetAllAccounts();
                        Console.WriteLine("Bütün hesabların siyahısı:");
                        foreach (IAccount acc in allAccounts)
                        {
                            Console.WriteLine($"Hesab ID: {acc.AccountId}, Balans: {acc.Balance}");
                        }
                        break;
                        
                    case "5":
                        Console.Write("Göndərən hesabın ID-sini daxil edin: ");
                        if (int.TryParse(Console.ReadLine(), out int fromAccountId))
                        {
                            Console.Write("Alan hesabın ID-sini daxil edin: ");
                            if (int.TryParse(Console.ReadLine(), out int toAccountId))
                            {
                                Console.Write("Köçürüləcək məbləği daxil edin: ");
                                if (decimal.TryParse(Console.ReadLine(), out decimal transferAmount))
                                {
                                    try
                                    {
                                        bank.TransferMoney(fromAccountId, toAccountId, transferAmount);
                                        Console.WriteLine("Əməliyyat uğurla tamamlandı.");
                                    }
                                    catch (AccountNotFoundException e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                    catch (InvalidAmountException e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                    catch (InsufficientFundsException e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Yanlış məbləq daxil edildi.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Yanlış alan hesab ID daxil edildi.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Yanlış göndərən hesab ID daxil edildi.");
                        }
                        break;
                    case "0":
                        Console.WriteLine("Proqram bağlanır. Təşəkkürlər!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Yanlış seçim. Zəhmət olmasa yenidən cəhd edin.");
                        break;
                }
            }
        }
    
    }
}
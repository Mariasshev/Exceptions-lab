using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exceptions_lab
{
    internal class CreditCard
    {
        private long id;
        private string fio;
        private int cvc;
        private string end_date;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Fio
        {
            get { return fio; }
            set { fio = value; }
        }

        public int Cvc
        {
            get { return cvc; }
            set { cvc = value; }
        }

        public string EndDate
        {
            get { return end_date; }
            set { end_date = value; }
        }

        public CreditCard(int id, string fio, int cvc, string end_date)
        {
            Id = id;
            Fio = fio;
            Cvc = cvc;
            EndDate = end_date;
        }

        public CreditCard()
        {
            Console.WriteLine("Add a new card! Please, add some information!");
        }

        public void addInf()
        {
            int attempts = 3;

            CheckId(attempts);
            CheckFio(attempts);
            CheckCVC(attempts);
            CheckDate(attempts);

        }

        private void CheckId(int attempts)
        {
            if(attempts == 0)
            {
                Console.WriteLine("Использовано максимальное кол-во попыток!");
                addInf();
            }
                
            else
            {
                int id_lenght = 0;
                try
                {
                    Console.WriteLine("Enter card number: ");
                    long checkId = long.Parse(Console.ReadLine());
                    string tempId = checkId.ToString();
                    id_lenght = tempId.Length;

                    if (Regex.IsMatch(tempId, @"[a-zA-Z]")) // проверка на наличие букв
                    {
                        throw new Exception("Данные содержат буквы!");
                    }
                    else if (Regex.IsMatch(tempId, @"[^a-zA-Z0-9]")) // проверка на спецсимволы
                    {
                        throw new Exception("Данные содержат специальные символы!");
                    }

                    if (id_lenght > 3 || id_lenght < 3)
                        throw new Exception("Incorrect id!");
                    else
                        this.Id = checkId;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine($"У вас осталось {attempts - 1} попыток.");
                    CheckId(--attempts);
                }
            }
        }

        private void CheckFio(int attempts)
        {
            if (attempts == 0)
            {
                Console.WriteLine("Использовано максимальное кол-во попыток!");
                addInf();
            }
            else
            {
                try
                {
                    Console.WriteLine("Enter fio: ");
                    string fio = Console.ReadLine();
                    int space = 0;


                    for (int i = 0; i < fio.Length; i++)
                    {
                        if (char.IsDigit(fio[i]))
                        {
                            throw new Exception("Вы использовали цифры!");
                        }
                        if (fio[i] == ' ')
                        {
                            space++;
                        }
                        if (space == 2 && i == fio.Length-1)
                        {
                            this.Fio = fio;
                        }
                        else if(space < 2 && i == fio.Length-1)
                        {
                            space = 0;
                            throw new Exception("Введена неполная информация!");
                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine($"У вас осталось {attempts - 1} попыток.");
                    CheckFio(--attempts);
                }
            }

        }

        private void CheckCVC(int attempts)
        {
            if (attempts == 0)
            {
                Console.WriteLine("Использовано максимальное кол-во попыток!");
                addInf();
            }

            else
            {
                int cvc_lenght = 0;
                try
                {
                    Console.WriteLine("Enter CVC number: ");
                    int checkCvc = int.Parse(Console.ReadLine());
                    string tempCVC = checkCvc.ToString();
                    cvc_lenght = tempCVC.Length;

                    if (Regex.IsMatch(tempCVC, @"[a-zA-Z]")) // проверка на наличие букв
                    {
                        throw new Exception("Данные содержат буквы!");
                    }
                    else if (Regex.IsMatch(tempCVC, @"[^a-zA-Z0-9]")) // проверка на спецсимволы
                    {
                        throw new Exception("Данные содержат специальные символы!");
                    }

                    if (cvc_lenght > 3 || cvc_lenght < 3)
                        throw new Exception("Incorrect id!");
                    
                    else
                        this.Cvc = checkCvc;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine($"У вас осталось {attempts - 1} попыток.");
                    CheckCVC(--attempts);
                }
            }
        }

        private void CheckDate(int attempts)
        {
            if (attempts == 0)
            {
                Console.WriteLine("Использовано максимальное кол-во попыток!");
                addInf();
            }

            else
            {
                try
                {
                    Console.WriteLine("Enter end date (use space to split numbers - 12 12 2024 ): ");
                    string checkDate = Console.ReadLine();
                    char[] dateArray = checkDate.ToCharArray();

                    if (Regex.IsMatch(checkDate, @"[a-zA-Z]")) // проверка на наличие букв
                    {
                        throw new Exception("Данные содержат буквы!");
                    }

                    if (checkDate.Length > 10 || checkDate.Length == 0)
                        throw new Exception("Incorrect date!");

                    else
                    {
                        int spaceCount = 0;
                        string month = "";
                        for (int i = 0; i < dateArray.Length; i++)
                        {
                            if (dateArray[i] == ' ')
                            {
                                spaceCount++;
                                if(spaceCount == 1)
                                {
                                    month += dateArray[i+1];
                                    month += dateArray[i+2];

                                    if(int.Parse(month) > 12 || int.Parse(month) < 1)
                                    {
                                        throw new Exception("Неверный месяц!");
                                    }
                                }
                                dateArray[i] = '/';
                            }
                            
                        }

                        this.EndDate = new string(dateArray);
                    }



                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine($"У вас осталось {attempts - 1} попыток.");
                    CheckDate(--attempts);
                }
            }
        }


        public void ShowInf()
        {
            Console.WriteLine("-------------------");
            Console.WriteLine($"Card number: {this.Id}");
            Console.WriteLine($"Person FIO: {this.Fio}");
            Console.WriteLine($"Card cvc: {this.Cvc}");
            Console.WriteLine($"Card end date: {this.EndDate}");
            Console.WriteLine("-------------------");
        }
    }


    internal class SolveTheEquation
    {
        private string equation;

        public string Equation
        {
            get { return equation; }
            set { equation = value; }
        }

        public SolveTheEquation() { 
            Console.WriteLine("Add an equation!"); 
        }

        public void CreateEquation()
        {
            try
            {
                Console.WriteLine("Write an eqaution (use only numbers and *): ");
                string checkEqual = Console.ReadLine();
                char[] chars = checkEqual.ToCharArray();

                if (Regex.IsMatch(checkEqual, @"[a-zA-Z]")) // проверка на наличие букв
                {
                    throw new Exception("Выражение содержит буквы!");
                }
                if (Regex.IsMatch(checkEqual, @"[^a-zA-Z0-9*\s]"))
                {
                    Console.WriteLine("Выражение содержит недопустимые символы!");
                }
                
                for (int i = 0; i < chars.Length; i++)
                {
                    if (chars[i] == ' ')
                    {
                        throw new Exception("Выражение содержит пробелы!");
                    }
                    if (chars[i] == '.' || chars[i] == ',')
                    {
                        throw new Exception("Выражение содержит дробные числа!");
                    }
                }

                this.Equation = checkEqual;
                int count = 0;
                for(int i = 0; i < chars.Length; i++)
                {
                    if (chars[i] == '*')
                    {
                        count++;
                    }
                }
                int[] num = new int[count+1];
                string tempNum = "";
                int index = 0;

                for (int i = 0; i < chars.Length; i++)
                {
                    if (chars[i] != '*')
                    {
                        tempNum += chars[i];
                        //Console.WriteLine($"tempNum: {tempNum}");
                    }
                    else
                    {
                        num[index] = int.Parse(tempNum);
                        tempNum = "";
                        index++;
                    }
                }
                if (tempNum != null) //проверка + добавление последнего числа в массив
                {
                    num[index] = int.Parse(tempNum);
                }

                int result = 0;
                for(int i = 0; i < num.Length; i++)
                {
                    if (i == 0)
                    {
                        result = num[i];
                    }
                    else
                    {
                        result = result* num[i];
                    }
                }

                Console.WriteLine($"Result: {this.Equation} = {result}");

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}

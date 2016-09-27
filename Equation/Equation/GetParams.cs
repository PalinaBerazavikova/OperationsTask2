using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equation
{
    class GetParams
    {
        public void Start()
        {
            this.Menu();
        }


        public double ReadParamA()
        {
            bool isAGoodA;
            double a;
            do
            {
                Console.WriteLine("Введите коэффициент а (число не равное нулю):");
                isAGoodA = this.IsAGoodParam(Console.ReadLine(), out a);
            } while ((!isAGoodA) || (a == 0));
            return a;
        }

        public double ReadParam()
        {
            double param;
            do
            {
                Console.WriteLine("Введите коэффициет:");

            } while (!this.IsAGoodParam(Console.ReadLine(), out param));
            return param;
        }

        public bool IsAGoodParam(string param, out double doubParam)
        {
            return double.TryParse(param.Replace(",", "."), out doubParam);
        }

        public void Menu()
        {
            string choice = string.Empty;
            do
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("Введите 1 для решения квадратного уравнения (a * x^2 + b * x + c = 0)");
                Console.WriteLine("Введите 2 для решения линейного уравнения (a * x + b = 0)");
                choice = Console.ReadLine();
            } while ((!choice.Equals("1")) && (!choice.Equals("2")));
            switch (choice)
            {
                case "1":
                    {
                        double a, b, c;
                        Console.WriteLine("Вы выбрали квадратное уравнение (a * x^2 + b * x + c = 0)");
                        a = this.ReadParamA();
                        b = this.ReadParam();
                        c = this.ReadParam();
                        Console.WriteLine($"Ваше квадратное уравнение {a:F} * x^2 + {b:F} * x + {c:F} = 0");
                        Quadr quadr = new Quadr(a, b, c);
                        double[] result = quadr.ToFindResult();
                        if (quadr.D < 0)
                        {
                            Console.WriteLine("Дискриминант меньше нуля, решений нет.");
                        }
                        else
                        {
                            if (quadr.D == 0)
                            {
                                Console.WriteLine($"Дискриминант равен нулю, решение: x1 = x2 = {result[0]:F}.");
                            }
                            else
                            {
                                if (quadr.D > 0)
                                {
                                    Console.WriteLine($"Дискриминант больше нуля, решение: x1 = {result[0]:F} x2 = {result[1]:F}.");
                                }
                            }
                        }
                        break;
                    }
                case "2":
                    {
                        double a, b;
                        Console.WriteLine("Вы выбрали линейное уравнение (a * x + b = 0)");
                        a = this.ReadParamA();
                        b = this.ReadParam();
                        Console.WriteLine($"Ваше линейное уравнение {a:F} * x + {b:F} = 0");
                        Linear linear = new Linear(a, b);
                        Console.WriteLine($"Ответ: {linear.ToFindResult():F}");
                        break;
                    }
            }
        }
    }
}


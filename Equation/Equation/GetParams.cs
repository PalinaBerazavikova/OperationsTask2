using Library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equation
{
    class GetParams
    {
        public const string EnterA = "Введите коэффициент а (число не равное нулю):";
        public const string EnterParam = "Введите коэффициет:";
        public const string Coma = ",";
        public const string Dot = ".";
        public const string First = "1";
        public const string Second = "2";
        public const string DiscSubZero = "Дискриминант меньше нуля, решений нет.";
        public const string YouChooseLinear = "Вы выбрали линейное уравнение (a * x + b = 0)";
        public const string YouChooseQuadr = "Вы выбрали квадратное уравнение (a * x^2 + b * x + c = 0)";
        public const string MenuStr = "Меню:\nВведите 1 для решения квадратного уравнения (a * x^2 + b * x + c = 0)\nВведите 2 для решения линейного уравнения (a * x + b = 0)";

        public static void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            w.WriteLine("  :");
            w.WriteLine("  :{0}", logMessage);
            w.WriteLine("-------------------------------");
        }
        public static void SendToLog(string s)
        {
            using (StreamWriter w = File.AppendText("log.txt"))
            {
                Log(s, w);
            }
            
        }
        public static void DumpLog()
        {
            using (StreamReader r = File.OpenText("log.txt"))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
            
        }
        public double ReadParamA()
        {
            bool isAGoodA;
            string input;
            double a;
            do
            {
                Console.WriteLine(EnterA);
                input = Console.ReadLine();
                isAGoodA = this.IsAGoodParam(input, out a);
                SendToLog($"Пользователь ввел коэффициент {input}");
            } while ((!isAGoodA) || (a == 0));
            return a;
        }

        public double ReadParam()
        {

            double param;
            string input;
            do
            {
                Console.WriteLine(EnterParam);
                input = Console.ReadLine();
                SendToLog($"Пользователь ввел коэффициент {input}");

            } while (!this.IsAGoodParam(input, out param));
            return param;
        }

        public bool IsAGoodParam(string param, out double doubParam)
        {
            return double.TryParse(param.Replace(Coma, Dot), out doubParam);
        }

        public string GetResult()
        {
            string choice = string.Empty;
            do
            {
                Console.WriteLine(MenuStr);
                choice = Console.ReadLine();
            } while ((!choice.Equals(First)) && (!choice.Equals(Second)));
            switch (choice)
            {
                case First:
                    {
                        double a, b, c;
                        Console.WriteLine(YouChooseQuadr);
                        a = this.ReadParamA();
                        b = this.ReadParam();
                        c = this.ReadParam();
                        Console.WriteLine($"Ваше квадратное уравнение {a:F} * x^2 + {b:F} * x + {c:F} = 0");
                        SendToLog($"{a:F} * x^2 + {b:F} * x + {c:F} = 0");
                        Quadr quadr = new Quadr(a, b, c);
                        double[] result = quadr.ToFindResult();
                        if (quadr.D < 0)
                        {
                            SendToLog(DiscSubZero);
                            return DiscSubZero;
                        }
                        else
                        {
                            if (quadr.D == 0)
                            {
                                SendToLog($"x1 = x2 = {result[0]:F}.");
                                return $"Дискриминант равен нулю, решение: x1 = x2 = {result[0]:F}.";
                                
                            }
                            else
                            {
                                if (quadr.D > 0)
                                {
                                    SendToLog($"x1 = {result[0]:F} x2 = {result[1]:F}.");
                                    return $"Дискриминант больше нуля, решение: x1 = {result[0]:F} x2 = {result[1]:F}.";
                                }
                            }
                        }
                        break;
                    }
                case Second:
                    {
                        double a, b, result;
                        Console.WriteLine(YouChooseLinear);
                        a = this.ReadParamA();
                        b = this.ReadParam();
                        SendToLog($"{a:F} * x + {b:F} = 0");
                        Console.WriteLine($"Ваше линейное уравнение {a:F} * x + {b:F} = 0");
                        Linear linear = new Linear(a, b);
                        result = linear.ToFindResult();
                        SendToLog($"{result:F}");
                        return $"Ответ: {result:F}";
                        break;
                    }
            }
            return "";
        }
    }
}


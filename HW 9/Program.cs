using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace HW_9
{
    class Program
    {
        static void Main(string[] args)
        {


            string name;
            bool end = true;
            do
            {
                name = Console.ReadLine();
                try
                {
                    switch (name)
                    {
                        case "Help":
                            Console.WriteLine("List -Выводит список файлов в каталоге\nDel-Удаление файла по имени\nCrea-Создание файла\nCopy-Копирование файла\nInfo-Показывает информацию о файле");
                            Console.WriteLine("");
                            break;

                        case "List":
                            List<string> q = new List<string>();
                            Console.WriteLine("Введите путь каталога");
                            string p = Console.ReadLine();
                            int s = 0;
                            DirectoryInfo dir = new DirectoryInfo(p);

                            foreach (var item in dir.GetDirectories())
                            {
                                q.Add(item.Name);
                                s++;
                            }

                            foreach (var item in dir.GetFiles())
                            {
                                q.Add(item.Name);
                                s++;
                            }
                            bool flag = true;
                            while (flag)
                            {
                                flag = false;
                                for (int k = 0; k < s - 1; ++k)
                                    if (q[k].CompareTo(q[k + 1]) > 0)
                                    {
                                        string buf = q[k];
                                        q[k] = q[k + 1];
                                        q[k + 1] = buf;
                                        flag = true;
                                    }
                            }
                            for (int k = 0; k < s; ++k)
                                Console.WriteLine("{0} ", q[k]);
                            Console.ReadKey();
                            Console.Clear();
                            break;


                        case "Info":

                            Console.WriteLine("Введите путь и имя файла, о котором хотите узнать информацию");
                            string path = Console.ReadLine();
                            FileInfo fileInf = new FileInfo(path);
                            if (fileInf.Exists)
                            {
                                Console.WriteLine("Имя файла: {0}", fileInf.Name);
                                Console.WriteLine("Время создания: {0}", fileInf.CreationTime);
                                Console.WriteLine("Размер: {0} байт", fileInf.Length);
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                            

                        case "Del":
                            string DeleteThis;
                            string pyt;
                            Console.WriteLine("Введите имя файла");
                            DeleteThis = Console.ReadLine();
                            Console.WriteLine("Введите путь по которому расположен файл");
                            pyt = Console.ReadLine();
                            string[] Files = Directory.GetFiles(pyt);

                            foreach (string file in Files)
                            {
                                if (file.ToUpper().Contains(DeleteThis.ToUpper()))
                                {
                                    File.Delete(file);
                                    Console.WriteLine($"Файл {DeleteThis} успешно удален");
                                }
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case "Crea":

                            string pyt2;
                            Console.WriteLine("Введите путь куда создать и имя файла");
                            pyt2 = Console.ReadLine();
                            File.Create(pyt2);
                            Console.WriteLine($"Файл успешно создан");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case "Copy":
                            Console.WriteLine("Введите путь копируемого файла");
                            string pathToFile = Console.ReadLine();
                            Console.WriteLine("Введите путь куда копировать файл");
                            string pathToFile1 = Console.ReadLine();
                            File.Copy(pathToFile, pathToFile1, true);
                            Console.WriteLine("Копия файла успешно выполнена");
                            break;
                        case "Exit":
                            end = false;
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        default:
                            Console.WriteLine("Введена не правильная команда");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("Что-то пошло не так, введите команду заново");
                    Console.ReadKey();
                    Console.Clear();
                }

            } while (end != false);
        }
    }
}

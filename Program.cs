using System;
using System.IO;
using System.Text;
using Microsoft.VisualBasic;

namespace ADS_4
{
    class Program
    {
        static unsafe void Main()
        {
            DLL lst = GetList();
            DLL newLst = GetNewList(lst);
            ListToFile(newLst);
        }

        static void GenerateFile()
        {
            Console.Write("Enter the amount of numbers: ");
            int n = Int32.Parse(Console.ReadLine());
            using (StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + @"\txt.txt", false, Encoding.Default))
            {
                sw.WriteLine(n);
                Random rand = new Random();
                for (int i = 0; i < n; i++)
                {
                    sw.Write($"{rand.NextDouble()*50:N3} ");
                }
                sw.WriteLine();
            }
        }

        static unsafe DLL GetList()
        {
            DLL lst = new DLL();
            using (StreamReader sr = new StreamReader(Environment.CurrentDirectory + @"\txt.txt", System.Text.Encoding.Default))
            {
                string[] slices = sr.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                foreach (string s in slices) lst.PushBack(Double.Parse(s));
            }
            return lst; 
        }

        static unsafe DLL GetNewList(DLL inpList)
        {
            DLL.Node* item = inpList.First;
            double lastValue = inpList.Last->Value;
            DLL nLst = new DLL();
            for (int i = 0; i < inpList.get_size() - 2; i++)
            {
                nLst.PushBack(item->Value-lastValue);
                item = item->Next;
            }
            nLst.PushBack(item->Value-lastValue);
            return nLst;
        }
        static unsafe void ListToFile(DLL newList)
        {
            DLL.Node* node = newList.First;
            using (StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + @"\new.txt", false, Encoding.Default))
            {
                Console.WriteLine(newList.get_size());
                for (int i = 0; i < newList.get_size(); i++)
                {
                    sw.Write($"{node->Value} ");
                    Console.Write($"{node->Value} ");
                    node = node->Next;
                }
            }
        } 
    }
}
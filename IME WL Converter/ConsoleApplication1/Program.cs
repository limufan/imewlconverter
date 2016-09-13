using Studyzy.IMEWLConverter.IME;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            List<string> lines = File.ReadLines(@"C:\Users\Administrator\Desktop\qq地区.txt").ToList();
            foreach(string line in lines)
            {
                string[] lineSplit = line.Split('=');
                string hanziValue =  lineSplit[0];
                string pinyinValue =  lineSplit[1];

                for (int i = 0; i < hanziValue.Length; i++ )
                {
                    char hanzi =hanziValue[i];
                    string pinyin = pinyinValue.Split(',')[i];
                    if(!dic.ContainsKey(hanzi.ToString()))
                    {
                        dic.Add(hanzi.ToString(), pinyin);
                    }
                }
            }

            lines = dic.Select(d =>  d.Key + "=" + d.Value + ";").ToList();

            File.WriteAllLines(@"C:\Users\Administrator\Desktop\qq地区字库.txt", lines);
        }
    }
}

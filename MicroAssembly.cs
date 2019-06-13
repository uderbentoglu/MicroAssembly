using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static void Main(string[] args)
    {
        string[] inputs = Console.ReadLine().Split(' ');
        Console.Error.WriteLine(string.Join(" ", inputs));
        int a = int.Parse(inputs[0]);
        int b = int.Parse(inputs[1]);
        int c = int.Parse(inputs[2]);
        int d = int.Parse(inputs[3]);

        Dictionary<string, int> registers = new Dictionary<string, int>();
        registers["a"] = a;
        registers["b"] = b;
        registers["c"] = c;
        registers["d"] = d;

        int n = int.Parse(Console.ReadLine());
        List<string> instructions = new List<string>();
        for (int i = 0; i < n; i++)
        {
            string instruction = Console.ReadLine();
            Console.Error.WriteLine(instruction);
            instructions.Add(instruction);
        }

        for (int i = 0; i < instructions.Count; i++)
        {
            string cmd = instructions[i].Split(' ')[0];
            if (cmd == "MOV")
            {
                string register = instructions[i].Split(' ')[1];
                string value = instructions[i].Split(' ')[2];
                int target = registers.ContainsKey(value) ? registers[value] : int.Parse(value);
                registers[register] = target;
            }

            else if (cmd == "ADD")
            {
                string register = instructions[i].Split(' ')[1];
                string val1 = instructions[i].Split(' ')[2];
                string val2 = instructions[i].Split(' ')[3];
                registers[register] = (registers.ContainsKey(val1) ? registers[val1] : int.Parse(val1)) + (registers.ContainsKey(val2) ? registers[val2] : int.Parse(val2));
            }

            else if (cmd == "SUB")
            {
                string register = instructions[i].Split(' ')[1];
                string val1 = instructions[i].Split(' ')[2];
                string val2 = instructions[i].Split(' ')[3];
                registers[register] = (registers.ContainsKey(val1) ? registers[val1] : int.Parse(val1)) - (registers.ContainsKey(val2) ? registers[val2] : int.Parse(val2));
            }

            else if (cmd == "JNE")
            {
                string val1 = instructions[i].Split(' ')[2];
                string val2 = instructions[i].Split(' ')[3];
                int cond1 = registers.ContainsKey(val1) ? registers[val1] : int.Parse(val1);
                int cond2 = registers.ContainsKey(val2) ? registers[val2] : int.Parse(val2);
                if (cond1 != cond2)
                {
                    i = int.Parse(instructions[i].Split(' ')[1]) - 1;
                }
            }
        }

        Console.WriteLine(registers["a"] + " " + registers["b"] + " " + registers["c"] + " " + registers["d"]);
    }
}

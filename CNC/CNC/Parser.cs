using System;
using System.Collections.Generic;
using System.Text;

namespace CNC
{
    class Parser
    {
        double? prevF = null, prevX = null;
        double y1, y2, f1, f2, f3, f4;
        public Parser(double y1, double y2, double f1, double f2, double f3, double f4)
        {
            this.y1 = y1;
            this.y2 = y2;
            this.f1 = f1;
            this.f2 = f2;
            this.f3 = f3;
            this.f4 = f4;
        }

        public string AddF(string line)
        {
            line = line.Replace('f', 'F').Replace('y', 'Y').Replace('x', 'X');
            
            int indexX = line.IndexOf('X');
            int indexY = line.IndexOf('Y');
            int indexF = line.IndexOf('F');
            

            if (indexF != -1)
            {
                int numberDidgits = 1;
                try
                {
                    while (line[indexF + numberDidgits] == '0' || line[indexF + numberDidgits] == '1' ||
                        line[indexF + numberDidgits] == '2' || line[indexF + numberDidgits] == '3' ||
                        line[indexF + numberDidgits] == '4' || line[indexF + numberDidgits] == '5' ||
                        line[indexF + numberDidgits] == '6' || line[indexF + numberDidgits] == '7' ||
                        line[indexF + numberDidgits] == '8' || line[indexF + numberDidgits] == '9' ||
                        line[indexF + numberDidgits] == '-' || line[indexF + numberDidgits] == ',' ||
                        line[indexF + numberDidgits] == '.')
                    {
                        numberDidgits++;
                    }
                }
                catch (IndexOutOfRangeException) { };
                double number = double.Parse(line.Substring(indexF + 1, numberDidgits - 1).Replace(',', '.'));
                line = line.Replace($"{'F'}{line.Substring(indexF + 1, numberDidgits - 1)}", "");
            }


            if (indexX != -1)
            {
                
                
                if (prevX == null)
                {
                    prevX = stringNumberToDidgit(indexX, line);
                    prevF = f1;
                    return line + $"F{f1}";

                }
                if (stringNumberToDidgit(indexX, line) - prevX < 0)
                {
                    double tempX = stringNumberToDidgit(indexX, line);
                    if (prevF != f4)
                    {
                        line += $"F{f4}";
                    }
                    prevF = f4;
                    prevX = tempX;
                    return line;
                }
                else
                {
                    indexY = line.IndexOf('Y');
                    if (indexY == -1)
                    {
                        prevX = stringNumberToDidgit(indexX, line);
                        return line;
                    }
                    double numberY = stringNumberToDidgit(indexY, line);
                    if (numberY > y1)
                    {
                        if(prevF != f1)
                        {
                            line += $"F{f1}";
                            prevF = f1;
                        }
                        prevX = stringNumberToDidgit(indexX, line);
                        return line;                        
                    }
                    else if (numberY > y2 && numberY <= y1)
                    {
                        if (prevF != f2)
                        {
                            line += $"F{f2}";
                            prevF = f2;
                        }
                        prevX = stringNumberToDidgit(indexX, line);

                        return line;
                    }
                    else if (numberY <= y2)
                    {
                        if (prevF != f3)
                        {
                            line += $"F{f3}";
                            prevF = f3;
                        }
                        prevX = stringNumberToDidgit(indexX, line);
                        return line;
                    }
                }
            }
            return line;
        }

        double stringNumberToDidgit(int index, string line)
        {
            int numberDidgits = 1;
            try
            {
                while (line[index + numberDidgits] == '0' || line[index + numberDidgits] == '1' ||
                    line[index + numberDidgits] == '2' || line[index + numberDidgits] == '3' ||
                    line[index + numberDidgits] == '4' || line[index + numberDidgits] == '5' ||
                    line[index + numberDidgits] == '6' || line[index + numberDidgits] == '7' ||
                    line[index + numberDidgits] == '8' || line[index + numberDidgits] == '9' ||
                    line[index + numberDidgits] == '-' || line[index + numberDidgits] == ',' ||
                    line[index + numberDidgits] == '.')
                {
                    numberDidgits++;
                }
            }
            catch (IndexOutOfRangeException) { };
            double number = double.Parse(line.Substring(index + 1, numberDidgits - 1).Replace(',', '.'));
            return number;
        }
    }
}

using System;
using System.Collections.Generic;

namespace RangeProgram
{
    public class Range
    {
        public string Input { get; set; }
        public int InferiorLimit { get; set; }
        public int SuperiorLimit { get; set; }
        public List<int> IncludedValues { get; set; } = new List<int>();
        public Range(string input)
        {
            Input = input;

            string clear = input.Replace("[", "").Replace("]", "").Replace("(", "").Replace(")", "");
            string[] values = clear.Split(",");

            InferiorLimit = Int16.Parse(values[0]);
            SuperiorLimit = Int16.Parse(values[1]);

            if (Input[0] == '[')
            {
                IncludedValues.Add(InferiorLimit);
            }
            else
            {
                IncludedValues.Add(InferiorLimit + 1);
            }

            if (Input[Input.Length - 1] == ']')
            {
                IncludedValues.Add(SuperiorLimit);
            }
            else
            {
                InferiorLimit -= 1;
                IncludedValues.Add(SuperiorLimit - 1);
            }

        }

        public List<int> EndPoints()
        {
            return IncludedValues;
        }

        public int[] GetAllPoints()
        {
            int rangeSize = IncludedValues[1] - IncludedValues[0] + 1;
            int[] allPoints = new int[rangeSize];

            for (int i = 0; i < rangeSize; i++)
            {
                allPoints[i] = IncludedValues[0] + i;
            }

            return allPoints;
        }

        public bool Contains(int number)
        {
            int output = 0;

            foreach (var item in GetAllPoints())
            {
                if (item == number)
                {
                    output += 1;
                }
                else
                {
                    output += 0;
                }
            }

            if (output == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool NotContains(int number)
        {
            return !Contains(number);
        }

        public bool ContainsRange(Range range)
        {
            if (range.IncludedValues[0] >= IncludedValues[0] && range.IncludedValues[1] <= IncludedValues[1])
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool NotContainsRange(Range range)
        {
            return !ContainsRange(range);
        }

        public bool Overlaps(Range range)
        {
            if (range.IncludedValues[0] >= IncludedValues[0] && range.IncludedValues[0] <= IncludedValues[1])
            {
                return true;
            }
            else if(range.IncludedValues[1] <= IncludedValues[1] && range.IncludedValues[1] >= IncludedValues[0])
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool NotOverlaps(Range range)
        {
            return !Overlaps(range);
        }

        public bool Equals(Range range)
        {
            if (range.IncludedValues[0] == this.IncludedValues[0])
            {
                if (range.IncludedValues[1] == this.IncludedValues[1])
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool NotEquals(Range range)
        {
            return !Equals(range);
        }
    }
}

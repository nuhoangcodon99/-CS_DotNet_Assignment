// See https://aka.ms/new-console-template for more information

namespace NPL.Practice.T01.Problem01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] chartInput = { 1, 1, 2, 3 }; // Initialize
            decimal[] result = DrawCircleChart(chartInput);
            foreach (var item in result)
            {
                Console.Write($"{item} ");
            }
        }

        private static decimal[] DrawCircleChart(int[] chartInput)
        {
            decimal[] drawCircleChart = new decimal[chartInput.Length];
            long sumChart = 0; // sum 
            foreach (int item in chartInput)
            {
                sumChart += item; // add item in charInput
            }

            for (int i = 0; i < chartInput.Length; i++)
            {
                drawCircleChart[i] = Math.Round((decimal)((double)chartInput[i] / (double)sumChart)*100,2);
                // Calculate percentage values and round them
            }

            return drawCircleChart;
        }
    }
}

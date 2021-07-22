using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generation
{
    class Program
    {
		static int[,] nextGeneration(int[,] universe, int expectedGen, int[,] outputGeneration)
		{
			if (expectedGen != 1)
			{
				nextGeneration(universe, expectedGen - 1, outputGeneration);
			}
			else
			{
				for (int i = 1; i < 24; i++)
				{
					for (int j = 1; j < 24; j++)
					{
						int sumOfAllBesides = 0;

						for (int k = -1; k <= 1; k++)
						{
							for (int l = -1; l <= 1; l++)
							{
								if (!(k == 0 && l == 0))
								{
									sumOfAllBesides += universe[i + k, j + l];
								}
							}
						}

						if ((universe[i, j] == 1) && (sumOfAllBesides < 2))
						{
							outputGeneration[i, j] = 0;
						}
						else if ((universe[i, j] == 1) && (sumOfAllBesides > 3))
						{
							outputGeneration[i, j] = 0;
						}
						else if ((universe[i, j] == 0) && (sumOfAllBesides == 3))
						{
							outputGeneration[i, j] = 1;
						}
						else
							outputGeneration[i, j] = universe[i, j];
					}
				}
			}
			return outputGeneration;
		}
		static void Main(string[] args)
        {
			int[,] universe = new int[25, 25];

			Console.WriteLine("Which Generation are  we expecting? Please enter the number");
			int expectedGen = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("no. of live cells being provided? Please enter the number");
			int numLive = Convert.ToInt32(Console.ReadLine());

			Console.WriteLine("Please enter the Live cells position, in x & y format");

			int ypos, xpos;
			for (int i = 0; i < numLive; i++)
			{
				Console.WriteLine("Please enter the x-coordinate of {0} Live Cell", i + 1);
				xpos = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine("Please enter the y-coordinate of {0} Live Cell", i + 1);
				ypos = Convert.ToInt32(Console.ReadLine());

				universe[xpos, ypos] = 1;
			}

			int[,] outputGeneration = new int[25, 25];
			int[,] output = nextGeneration(universe, expectedGen, outputGeneration);

			for (int i = 0; i < 25; i++)
			{
				for (int j = 0; j < 25; j++)
				{
					if (output[i, j] == 1)
					{
						Console.Write("({0}, {1})\t", i, j);
					}
				}
			}

			Console.ReadKey();
		}
    }
}

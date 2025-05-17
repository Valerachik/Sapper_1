using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Initialization_Methods
{
    private Sapper sapper;
    public Initialization_Methods(Sapper s)
    {
        sapper = s;
    }
    public void field_bombs(int[,] sum)
    {
        Random rnd = new Random();
        int g = 0;
        while (g < sapper.Bombs)
        {
            int i = rnd.Next(0, sum.GetLength(0));
            int j = rnd.Next(0, sum.GetLength(1));
            if (sum[i, j] != 9)
            {
                sum[i, j] = 9;
                g++;
            }
        }

        for (int i = 0; i < sum.GetLength(0); i++)
        {
            for (int j = 0; j < sum.GetLength(1); j++)
            {
                if (sum[i, j] == 9)
                {
                    check(sum, i + 1, j);
                    check(sum, i - 1, j);
                    check(sum, i, j + 1);
                    check(sum, i, j - 1);
                    check(sum, i + 1, j - 1);
                    check(sum, i - 1, j + 1);
                    check(sum, i + 1, j + 1);
                    check(sum, i - 1, j - 1);
                }
            }
        }


    }
    public void check(int[,] sum, int i, int j)
    {
        if (i >= 0 && j >= 0 && i < sum.GetLength(0) && j < sum.GetLength(1) && sum[i, j] != 9)
        {
            sum[i, j] += 1;
        }
    }
}


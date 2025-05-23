

class InitializationMethods
{
    private Sapper sapper;

    public InitializationMethods(Sapper s)
    {
        sapper = s;
    }

    public void FillBombs(int[,] sum)
    {
        Random rnd = new Random();
        int g = 0;
        while (g < sapper.Bombs)
        {
            int i = rnd.Next(0, sum.GetLength(0));
            int j = rnd.Next(0, sum.GetLength(1));
            if (sum[i, j] != Sapper.Bomb)
            {
                sum[i, j] = Sapper.Bomb;
                g++;
            }
        }

        for (int i = 0; i < sum.GetLength(0); i++)
        {
            for (int j = 0; j < sum.GetLength(1); j++)
            {
                if (sum[i, j] == Sapper.Bomb)
                {
                    CheckNeighboringCell(sum, i + 1, j);
                    CheckNeighboringCell(sum, i - 1, j);
                    CheckNeighboringCell(sum, i, j + 1);
                    CheckNeighboringCell(sum, i, j - 1);
                    CheckNeighboringCell(sum, i + 1, j - 1);
                    CheckNeighboringCell(sum, i - 1, j + 1);
                    CheckNeighboringCell(sum, i + 1, j + 1);
                    CheckNeighboringCell(sum, i - 1, j - 1);
                }
            }
        }


    }

    public void CheckNeighboringCell(int[,] sum, int i, int j)
    {
        if (i >= 0 && j >= 0 && i < sum.GetLength(0) && j < sum.GetLength(1) && sum[i, j] != Sapper.Bomb)
        {
            sum[i, j] += 1;
        }
    }
}


using System.Drawing;

internal class Turn : ICloneable
{
    public int[,] matrix;

    public Turn(int[,] matrix)
    {
        this.matrix = matrix;
    }

    internal int Width { get { return matrix.GetLength(0); } }
    internal int Height { get { return matrix.GetLength(1); } }

    public object Clone()
    {
        int[,] clone = new int[Width, Height];
        for (int x=0; x<Width; x++)
        {
            for (int y=0; y<Height; y++)
            {
                clone[x,y] = matrix[x, y];
            }
        }
        return new Turn(clone);
    }

    internal void UpdateColor(int color)
    {
        if (color == 0) return;

        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                if (matrix[x, y] > 0) matrix[x, y] = color;
            }
        }
    }
}
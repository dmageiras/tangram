using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tangram
{
    internal static class TileExtensions
    {
        public static Tile[] getCopyExceptOfElementAt(this Tile[] shapes, int deleteAt)
        {
            Tile[] copy = new Tile[shapes.Length - 1];
            
            for (int i = 0; i < deleteAt; i++)
            {
                copy[i] = shapes[i];
            }

            for (int i = deleteAt + 1; i < shapes.Length; i++)
            {
                copy[i - 1] = shapes[i];
            }

            return copy;
        }
    }
}

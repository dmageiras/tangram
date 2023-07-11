using System.Drawing;

internal class Factory
{

    internal static Tile[] CreateShapePrototypes()
    {
        int i = 0;

        // square, 1 varation
        i++;
        var s_square = new Tile(
                        "square", 

            new Turn[] {
                new Turn( new int[2, 2] { 
                    { i, i }, 
                    { i, i } 
                }) }
        );

        // line, 2 variations
        i++;
        var s_line = new Tile(
                        "line", 
            new Turn[] {
                new Turn( new int[4, 1] {
                    { i },
                    { i },
                    { i },
                    { i }
                }) ,

                new Turn( new int[1, 4] {
                    { i, i, i, i }
                }) ,
            }
        );

        // L, 4 variations
        i++;
        var s_lamda = new Tile(
                        "lamda" , 
            new Turn[] {
                new Turn( new int[3, 2] {
                    { i, 0 },
                    { i, 0 },
                    { i, i },
                }) ,

                new Turn( new int[3, 2] {
                    { i, i },
                    { i, 0 },
                    { i, 0 },
                }) ,

                new Turn( new int[2, 3] {
                    { i, 0, 0 },
                    { i, i, i },
                }) ,

                new Turn( new int[2, 3] {
                    { i, i, i },
                    { i, 0, 0 },
                }) ,
            }
        );

        // S, 4 variations
        i++;
        var s_sigma = new Tile(
                        "sigma" , 
            new Turn[] {
                new Turn( new int[3, 2] {
                    { i, 0 },
                    { i, i },
                    { 0, i },
                }) ,

                new Turn( new int[3, 2] {
                    { 0, i },
                    { i, i },
                    { i, 0 },
                }) ,

                new Turn( new int[2, 3] {
                    { i, i, 0 },
                    { 0, i, i },
                }) ,

                new Turn( new int[2, 3] {
                    { 0, i, i },
                    { i, i, 0 },
                }) ,
            } 
        );

        // T, 3 variations
        i++;
        var s_taf = new Tile(
                        "taf" , 
            new Turn[] {
                new Turn( new int[3, 2] {
                    { i, 0 },
                    { i, i },
                    { i, 0 },
                }) ,

                new Turn( new int[2, 3] {
                    { i, i, i },
                    { 0, i, 0 },
                }) ,

                new Turn( new int[2, 3] {
                    { 0, i, 0 },
                    { i, i, i },
                }) ,
            }
        );

        /*        i++;
                var s_black = (Tile)s_taf.Clone();
                s_black.updateColor(i);
                s_black.Name = "black";
        */

        i++;
        var s_black1 = new Tile(
                        "black1",
            new Turn[] {
                new Turn( new int[2, 1] {
                    { i },
                    { i },
                }) ,

                new Turn( new int[1, 2] {
                    { i, i }
                }) ,
            }
        );

        i++;
        var s_black2 = new Tile(
                        "black2",
            new Turn[] {
                new Turn( new int[2, 1] {
                    { i },
                    { i },
                }) ,

                new Turn( new int[1, 2] {
                    { i, i }
                }) ,
            }
        );

        return new Tile[] { s_square, s_line, s_lamda, s_taf, s_sigma , s_black1, s_black2 } ;
    }
}
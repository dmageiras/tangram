using tangram;

var shapes = Factory.CreateShapePrototypes();
var board = new Board(6, 4);
board.Solve(shapes);
foreach (Board solution in Board.solutions)
{
    solution.Print();
}

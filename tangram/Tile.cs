internal class Tile : ICloneable
{ 
    public Turn[] Turns;

    public string Name = string.Empty;

    public Tile(string name, Turn[] turns) 
    {
        this.Name = name;
        this.Turns = turns;
    }

    public object Clone()
    {
        Turn[] clones = new Turn[Turns.Length];

        for (int i = 0; i < clones.Length; i++)
        {
            clones[i] = (Turn)Turns[i].Clone();
        }

        return new Tile(this.Name, clones);
    }

    public void updateColor(int color)
    {
        foreach (var variation in this.Turns)
        {
            variation.UpdateColor(color);
        }
    }
}
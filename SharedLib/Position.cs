namespace SharedLib;
public class Position
{
    public int Row { get; private set; }
    public int Column { get; private set; }
    public Position(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public Position MoveUp()
    { 
        Row--;
        return this;
    }

    public Position MoveDown()
    {
        Row++;
        return this;
    } 
    
    public Position MoveLeft()
    { 
        Column--;
        return this;
    }

    public Position MoveRight()
    { 
        Column++;
        return this;
    }
}
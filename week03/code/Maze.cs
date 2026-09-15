namespace week03;

public class Maze
{
    private readonly Dictionary<(int, int), bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<(int, int), bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    /// <summary>
    /// Problem 4: Move Left
    /// </summary>
    public void MoveLeft()
    {
        if (_mazeMap.TryGetValue((_currX, _currY), out var status) && status[0])
        {
            _currX--;
        }
        else
        {
            Console.WriteLine("Can't go that way!");
        }
    }

    /// <summary>
    /// Problem 4: Move Right
    /// </summary>
    public void MoveRight()
    {
        if (_mazeMap.TryGetValue((_currX, _currY), out var status) && status[1])
        {
            _currX++;
        }
        else
        {
            Console.WriteLine("Can't go that way!");
        }
    }

    /// <summary>
    /// Problem 4: Move Up
    /// </summary>
    public void MoveUp()
    {
        if (_mazeMap.TryGetValue((_currX, _currY), out var status) && status[2])
        {
            _currY--;
        }
        else
        {
            Console.WriteLine("Can't go that way!");
        }
    }

    /// <summary>
    /// Problem 4: Move Down
    /// </summary>
    public void MoveDown()
    {
        if (_mazeMap.TryGetValue((_currX, _currY), out var status) && status[3])
        {
            _currY++;
        }
        else
        {
            Console.WriteLine("Can't go that way!");
        }
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}

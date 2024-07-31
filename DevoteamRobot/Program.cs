using System;

class RobotController
{
    static void Main (string[] args)
    {
        try
        {

            // Parse input room size
            Console.WriteLine ("Enter the room dimensions (width height)");
            string [] roomSize = Console.ReadLine ().Trim ().Split (' ');

            // Checks if the format is correct and, if it is, assigns the values
            if (roomSize.Length != 2 || !int.TryParse (roomSize [0], out int width) || !int.TryParse (roomSize [1], out int depth))
            {
                throw new FormatException ("Room dimensions format is not correct. Please enter two integers separated by one space.");
            }

            // Parse input robot starting position and direction
            Console.WriteLine ("Enter the initial position and direction of the robot (x y D)");
            string [] initialPosition = Console.ReadLine ().Trim ().Split (' ');

            if (initialPosition.Length != 3 || !int.TryParse (initialPosition [0], out int startX) || !int.TryParse (initialPosition [1], out int startY) || initialPosition [2].Length != 1)
            {
                throw new FormatException ("Initial robot position format is not correct. Please enter two integers and a single character separated by one space each.");
            }

            if (startX < 0 || startX >= width || startY < 0 || startY >= depth)
            {
                throw new FormatException ("Initial robot position is not inside the room's bounds.");
            }

            char startDirection = initialPosition [2] [0];

            if (startDirection != 'N' && startDirection != 'E' && startDirection != 'S' && startDirection != 'W')
            {
                throw new FormatException ("Initial direction format is not correct. Please enter one of 'N', 'E', 'S', 'W'.");
            }

            // Parse input commands
            Console.WriteLine ("Enter the commands");
            string commands = Console.ReadLine ().Trim ();

            foreach (char command in commands)
            {
                if (command != 'L' && command != 'R' && command != 'F')
                {
                    throw new FormatException ("Commands' format is not correct. Please enter a string containing only 'L', 'R', 'F'.");
                }
            }

            Robot robot = new Robot (width, depth, startX, startY, startDirection);

            robot.ExecuteCommands (commands);
            robot.OutputReport ();

        }
        catch (Exception ex) 
        {
            Console.WriteLine (ex.Message);
        }
    }
}
public class Robot
{
    private int m_roomWidth = default;
    private int m_roomDepth = default;
    private int m_xPos = default;
    private int m_yPos = default;

    private char m_direction = default;


    public Robot (int width, int depth, int startX, int startY, char startDirection)
    {
        m_roomWidth = width;
        m_roomDepth = depth;
        m_xPos = startX;
        m_yPos = startY;
        m_direction = startDirection;
    }

    public void ExecuteCommands (string commands)
    {
        foreach (char command in commands)
        {
            switch (command)
            {
                case 'L':
                    TurnLeft ();
                    break;
                case 'R':
                    TurnRight ();
                    break;
                case 'F':
                    WalkForward ();
                    break;
            }
        }
    }

    private void TurnLeft ()
    {
        switch (m_direction)
        {
            case 'N':
                m_direction = 'W';
                break;
            case 'W':
                m_direction = 'S';
                break;
            case 'S':
                m_direction = 'E';
                break;
            case 'E':
                m_direction = 'N';
                break;
        }
    }

    private void TurnRight ()
    {
        switch (m_direction)
        {
            case 'N':
                m_direction = 'E';
                break;
            case 'E':
                m_direction = 'S';
                break;
            case 'S':
                m_direction = 'W';
                break;
            case 'W':
                m_direction = 'N';
                break;
        }
    }

    private void WalkForward ()
    {
        switch (m_direction)
        {
            case 'N':
                m_yPos++;
                break;
            case 'E':
                m_xPos++;
                break;
            case 'S':
                m_yPos--;
                break;
            case 'W':
                m_xPos--;
                break;
        }

        // Check if the robot got off the room
        if (m_xPos < 0 || m_xPos >= m_roomWidth || m_yPos < 0 || m_yPos >= m_roomDepth)
        {
            throw new InvalidOperationException ("The robot tried to walk out of the room!");
        }

    }



    public void OutputReport ()
    {
        Console.WriteLine ("Report: " + m_xPos + " " + m_yPos + " " + m_direction);
    }
}
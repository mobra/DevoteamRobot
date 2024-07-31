using System;

class RobotController
{
    static void Main (string[] args)
    {
        try
        {
       
            //Parse input text
            string [] roomSize = Console.ReadLine ().Trim ().Split (' ');
            int width = int.Parse (roomSize [0]);
            int depth = int.Parse (roomSize [1]);

            string [] initialPosition = Console.ReadLine ().Trim ().Split (' ');
            int startX = int.Parse (initialPosition [0]);
            int startY = int.Parse (initialPosition [1]);

            char startDirection = initialPosition [2] [0];
            string commands = Console.ReadLine ().Trim ();

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
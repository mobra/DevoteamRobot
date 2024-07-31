using System;

class RobotController
{

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
                    //WalkForward ();
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



}
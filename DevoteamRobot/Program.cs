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
    }
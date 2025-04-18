using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle6
{
    public class Coordinates
    {
        private int CoordinateX;
        private int CoordinateY;
        public Coordinates()
        {
                
        }
        public Coordinates(int coordinateX, int coordinateY)
        {
                CoordinateX = coordinateX;
                CoordinateY = coordinateY;
        }
        public int GetCoordinateX()
        {
            return CoordinateX;
        }
        public int GetCoordinateY()
        {
            return CoordinateY;
        }
     
        public void SetCoordinateX(int coordinateX)
        {
            CoordinateY = coordinateX;
        }
        public void SetCoordinateY(int coordinateY)
        {
            CoordinateY = coordinateY;
        }
    }
}

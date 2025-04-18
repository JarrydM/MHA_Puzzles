using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle6
{
    public class Guard
    {
        private Coordinates Coordinates;
        private int NumberOfUniqueLocations;
        private List<Coordinates> Locations;
        private Movement movement;
        public Guard()
        {
            movement = Movement.UP;
            Locations = new List<Coordinates>();

        }
        public void SetCoordinates(Coordinates coordinates)
        {
            Coordinates = coordinates;
        }
        public Coordinates GetCoordinates()
        {
            return Coordinates;
        }
        public int GetMovement()
        {
            return (int) movement;
        }
        public void SetLocations(Coordinates coordinate)
        {
            foreach (var l in Locations)
            {
                if(l.GetCoordinateY()== coordinate.GetCoordinateY() && l.GetCoordinateX()== coordinate.GetCoordinateX())
                {
                    return;
                }
            }
            Locations.Add(coordinate);
            SetNumberOfUniqueLocations();
        }
        private void SetNumberOfUniqueLocations()
        {
            NumberOfUniqueLocations++;
        }
       
        public int GetNumberOfUniqueLocations() 
        { 
            return NumberOfUniqueLocations;
        }
     
        public void SwitchMovement()
        {
            switch (movement)
            {
                case Movement.UP:
                    movement = Movement.LEFT;
                break;

                case Movement.LEFT:
                    movement = Movement.DOWN;
                break;

                case Movement.DOWN: 
                        movement = Movement.RIGHT;
                break;

                case Movement.RIGHT:
                    movement = Movement.UP;
                break;
            }
        }
        enum Movement
        {
            UP,
            DOWN,
            LEFT,
            RIGHT
        }
    }
}

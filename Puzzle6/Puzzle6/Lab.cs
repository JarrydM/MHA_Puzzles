using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle6
{
    public class Lab
    {

        private Guard Guard;
        
        private char[,] labOffice;

        public Lab(Guard guard)
        {
            Guard = guard;
        }

        public int GetTheUniqueNumberOfLocations(string labLayout)
        {
            CheckSteps(labLayout);
            MoveGuard();
            return Guard.GetNumberOfUniqueLocations();
        }
        private void CheckSteps(string labLayout)
        {
            var splitLab = labLayout.Split("\r\n");
            labOffice = new char[splitLab.Length,splitLab[0].Length];
            for (int i = 0; i < splitLab.Length; i++)
            {
                for(int j = 0; j < splitLab[i].Length; j++)
                {
                    labOffice[i,j] =splitLab[i][j];
                    if (labOffice[i,j]=='^')
                    {
                        Coordinates coordinates = new Coordinates();
                        coordinates.SetCoordinateX(i);
                        coordinates.SetCoordinateY(j);
                        Guard.SetCoordinates(coordinates);
                    }
                }
            }
        }
        private void MoveGuard()
        {
            Coordinates GuardCoordinates = Guard.GetCoordinates();
            int GuardX = Guard.GetCoordinates().GetCoordinateX();
            int GuardY = Guard.GetCoordinates().GetCoordinateY();
           
            while (CheckIfGuardIsInLab())
            {
                if (Guard.GetMovement() == 0)
                {
                    if (labOffice[GuardX + 1, GuardY] == '#')
                    {
                        Guard.SwitchMovement();
                    }
                    else
                    {
                        GuardX++;
                        GuardCoordinates.SetCoordinateX((GuardX));
                        Guard.SetCoordinates(GuardCoordinates);
                        StoreLocations(GuardCoordinates);
                    }
                }
                else if (Guard.GetMovement() == 1)
                {
                    if (labOffice[GuardX - 1, GuardY] == '#')
                    {
                        Guard.SwitchMovement();
                    }
                    else
                    {
                        GuardX--;
                        GuardCoordinates.SetCoordinateX((GuardX));
                        Guard.SetCoordinates(GuardCoordinates);
                        StoreLocations(GuardCoordinates);
                    }
                }
                else if (Guard.GetMovement() == 2)
                {
                    if (labOffice[GuardX, GuardY + 1] == '#')
                    {
                        Guard.SwitchMovement();
                    }
                    else
                    {
                        GuardY++;
                        GuardCoordinates.SetCoordinateY((GuardY));
                        Guard.SetCoordinates(GuardCoordinates);
                        StoreLocations(GuardCoordinates);
                    }
                }
                else if (Guard.GetMovement() == 3)
                {
                    if (labOffice[GuardX, GuardY - 1] == '#')
                    {
                        Guard.SwitchMovement();
                    }
                    else
                    {
                        GuardY--;
                        GuardCoordinates.SetCoordinateY((GuardX));
                        Guard.SetCoordinates(GuardCoordinates);
                        StoreLocations(GuardCoordinates);
                    }

                }
            }
            
        }
        private void StoreLocations(Coordinates coordinates)
        {
            Guard.SetLocations(coordinates);
        }
        private bool CheckIfGuardIsInLab()
        {
            Coordinates coordinates= Guard.GetCoordinates();
            if(Guard.GetCoordinates().GetCoordinateX() > labOffice.GetLength(0) || Guard.GetCoordinates().GetCoordinateX() < 0 || Guard.GetCoordinates().GetCoordinateY() > labOffice.GetLength(1)|| Guard.GetCoordinates().GetCoordinateY() < 0)
            {
                return false;
            }
            return true;
        }

    }
}

using Puzzle6;

Guard Guard = new Guard();
Lab lab = new Lab(Guard);
string labLayout = "....#.....\r\n.........#\r\n..........\r\n..#.......\r\n.......#..\r\n..........\r\n.#..^.....\r\n........#.\r\n#.........\r\n......#...";
Console.WriteLine(lab.GetTheUniqueNumberOfLocations(labLayout));
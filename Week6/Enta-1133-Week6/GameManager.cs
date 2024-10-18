using System;
namespace Enta_1133_Week6
{
	public class GameManager
	{
		private Map gameMap;

		public GameManager()
		{
            Console.WriteLine("GameManger Constructor Start!");
            gameMap = new Map();
            Console.WriteLine("GameManger Constructor End!");

            Random rand = new Random();

            int playerPos = rand.Next(0, gameMap.MapSize);
            RoomBase current = gameMap.RoomByIndex(playerPos);

            // example moving north, setting the current room from current.North
            /*
            if (inputDir == 0 )
            {
                if (current.North != null)
                {
                    current = current.North;
                }
            }
            */
        }

        public void StartGame()
		{
            // Intro
            Console.WriteLine("Hello, World!");


            Console.ReadLine();
        }
	}
}


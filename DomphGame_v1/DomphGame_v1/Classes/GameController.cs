using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomphGame_v1.Classes
{
    /// <summary>
    /// main game controller
    /// </summary>
    class GameController
    {
        public int IdGame { get; }      //id of current game
        List<MiniGame> gamelist;        //list of all minigames
        SaveGame savegame;              //for saving/reading game id
        Screensaver story;              //game story (comics)

        public GameController()
        {
            savegame = new SaveGame();
            GetCurrentGame();

            story = new Screensaver(IdGame);
            FillGameList();
        }

        //filling gamelist with all minigames
        private void FillGameList()
        {
            //todo: fill list
        }

        //reading id from file
        public void GetCurrentGame()
        {
            //to do: read id using savegame
            //IdGame = savegame.Read();
        }

        //saving current game id
        public void SaveCurrentGame()
        {
            //to do: save id using savegame
            //savegame.Save(IdGame);
        }

        public void ShowStory()
        {
            //todo: 
        }

    }
}

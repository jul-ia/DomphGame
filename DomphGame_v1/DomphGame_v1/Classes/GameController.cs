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
        public int IdGame { get; private set; }      //id of current game
        List<MiniGame> gamelist;        //list of all minigames
        SaveGame savegame;              //for saving/reading game id
        Screensaver story;              //game story (comics)

        public GameController()
        {
            savegame = new SaveGame();
            GetCurrentGame();

            //story = new Screensaver(IdGame);
            IdGame = 0;
            FillGameList();
        }

        //filling gamelist with all minigames
        private void FillGameList()
        {
            //todo: fill list
            gamelist = new List<MiniGame>();

            //test
            AddFirstGame_test();
        }

        //test
        public void AddFirstGame_test()
        {
            TestMiniGame test = new TestMiniGame();
            gamelist.Add(test);
        }
        //test

        public void StartGame(System.Windows.Controls.Canvas canvas, System.Windows.Controls.Button button)
        {
            //todo: Show story: show comics

            gamelist[IdGame].FillCanvas(canvas);
            gamelist[IdGame].Restart(button);
        }

        //current minigame rules
        public string GetRules()
        {
            return gamelist[IdGame].GetRules();
        }

        //check if minigame was passed
        public bool GameCheck()
        {
            return gamelist[IdGame].EndCheck();
        }

        //continuing game
        public bool Continue(System.Windows.Controls.Canvas canvas, System.Windows.Controls.Button button)
        {
            if (IdGame < gamelist.Count - 1)
            {
                IdGame++;
                StartGame(canvas, button);
                return true;
            }
            return false;
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
            savegame.SetId(IdGame);
        }

        //show comics for certain minigame
        public void ShowStory()
        {
            //todo: show story using story
        }

    }
}

using System;


namespace DomphGame_v1.MiniGames
{
    /// <summary>
    /// Abstract class for all minigames
    /// </summary>
    public abstract class MiniGame
    {
        public int IdGame { get; private set; }
        protected bool IsPassed { get; set; }

        //method for filling window canvas
        public virtual void FillCanvas() {}

        //game start/restart
        public virtual void Restart(System.Windows.Controls.Canvas canvas, System.Windows.Controls.Button continueButton) { }

        //rules how to play certain game
        public virtual string GetRules()
        {
            return "DomphGame\nEnjoy our game!";
        }

        //check if game is passed
        public bool EndCheck()
        {
            return IsPassed;
        }
    }
}

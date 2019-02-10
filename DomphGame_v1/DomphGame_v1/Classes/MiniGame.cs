using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomphGame_v1.Classes
{
    /// <summary>
    /// Abstract class for all minigames
    /// </summary>
    public abstract class MiniGame
    {
        public int IdGame { get; private set; }
        protected bool IsPassed { get; set; }

        //method for filling window canvas
        public virtual void FillCanvas(System.Windows.Controls.Canvas canvas) {}

        //game start/restart
        public virtual void Restart() { }

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

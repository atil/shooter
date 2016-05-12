using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Shooter
{
	public class SessionModel : ModelBase
	{
        private int _score;
        public int Score
        {
            get
            {
                return _score;
            }

            set
            {
                _score = value;
                NotifyPropertyChange("Score", _score);
            }
        }

        private int _lives;
        public int Lives
        {
            get { return _lives; }
            set
            {
                _lives = value;
                NotifyPropertyChange("Lives", _lives);
            }
        }

        public PlayerShip PlayerShip { get; set; }

        public List<BotShip> BotShips { get; set; }

    }
}
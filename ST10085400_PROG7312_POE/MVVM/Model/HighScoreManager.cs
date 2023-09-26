using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10085400_PROG7312_POE.MVVM.Model
{
    public class HighScoreManager
    {
        private static HighScoreManager instance;
        private int highScore = 0;

        // Private constructor to prevent multiple instances
        private HighScoreManager() 
        {

        }

        public static HighScoreManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HighScoreManager();
                }
                return instance;
            }
        }

        public int HighScore
        {
            get { return highScore; }
            set
            {
                if (value > highScore)
                {
                    highScore = value;
                }
            }
        }
    }
}

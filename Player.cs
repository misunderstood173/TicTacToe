using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Player
    {
        int score;
        string sign;
        Type type;

        public int Score
        {
            get
            {
                return score;
            }
        }
        internal void setScore(int score)
        {
            if (score < 0) score = 0;
            this.score = score;
        }

        public string Sign
        {
            get
            {
                return sign;
            }
        }

        internal Type Type
        {
            get
            {
                return type;
            }
        }

        public Player(Type playerType = Type.noValue, String sign = "")
        {   
            score = 0;
            type = playerType;
            this.sign = sign;
        }
    }
}

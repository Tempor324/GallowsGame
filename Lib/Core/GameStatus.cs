using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GallowsGame.Lib.Core
{
    public enum GameStatus
    {
        Lose,
        Win,
        //GameIsNull, //нужно как-то грамотно испльзовать. Постоянные проверки в методах - плохая практика
        Default
    }
}

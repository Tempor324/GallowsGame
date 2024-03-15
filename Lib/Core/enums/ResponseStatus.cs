using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GallowsGame.Lib.Core
{
    public enum ResponseStatus
    {
        InvalidInput,
        CharIsUsed,
        PlayerMistake,
        CorrectInput,
        Lose,
        Win
    }
}

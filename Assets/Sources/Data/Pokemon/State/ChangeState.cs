﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace PokemonBattele
{
    /// <summary>
    /// 状态变化
    /// </summary>
    public enum ChangeStateEnumForPokemon
    {
        Confusion,
        畏缩
    }
    /// <summary>
    /// 状态变化
    /// </summary>
    abstract class ChangeState:PokemonState
    {
    }

    


}

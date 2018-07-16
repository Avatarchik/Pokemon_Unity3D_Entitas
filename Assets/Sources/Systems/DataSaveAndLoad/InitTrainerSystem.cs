﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System.IO;
using PokemonBattelePokemon;
using Newtonsoft.Json;
using System;

public class InitTrainerSystem : IInitializeSystem
{
    readonly GameContext context;
    public InitTrainerSystem(Contexts contexts)
    {

        context = contexts.game;
    }
    public void Initialize()
    {
        string json = null;
        if (File.Exists(ResourceController.Instance.TrainerDataPath.ToString()))
        {
            json = File.ReadAllText(ResourceController.Instance.TrainerDataPath.ToString());
        }

        Trainer trainer = ScriptableObject.CreateInstance<Trainer>();
        if (json != null)
        {
            trainer = JsonConvert.DeserializeObject<Trainer>(json);
        }
        if (null == trainer|| null == trainer.pokemons|| 0 == trainer.pokemons.Count )
        {
            //如果没有精灵，就给一只皮卡丘和小火龙
            Pokemon Pikaqiu = PokemonFactory.BuildPokemon(25);

            Pokemon Charmander = PokemonFactory.BuildPokemon(4);
            trainer.pokemons = new List<Pokemon>() { Pikaqiu, Charmander };

        }
        else
        {
            foreach (Pokemon pokemon in trainer.pokemons)
                new BattlePokemonData(pokemon);
        }

        context.ReplacePlayerData(trainer);

    }


}


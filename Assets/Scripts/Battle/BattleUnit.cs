using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class BattleUnit : MonoBehaviour
{
    [SerializeField]PokemonBase _base;
    [SerializeField] int _level;
    [SerializeField] bool isPlayer;
    public Pokemon Pokemon {get; set;}
    public void SetUpPokemon()
    {
        Pokemon = new Pokemon(_base, _level);

        if(isPlayer)
        {
            GetComponent<Image>().sprite = Pokemon.Base.BackSprite;
        }else{
            GetComponent<Image>().sprite = Pokemon.Base.FrontSprite;
        }
    }
}

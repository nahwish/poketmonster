using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    [SerializeField] Text pokemonName;
    [SerializeField] Text pokemonLevel;
    [SerializeField] HealthBar healthBar;
    [SerializeField] Text pokemonHealth;

    public void SetPokemonData(Pokemon pokemon)
    {
        pokemonName.text = pokemon.Base.Name;
        pokemonLevel.text = $"Lv {pokemon.Level}";
        healthBar.SetHP(pokemon.HP/pokemon.MaxHP);
        pokemonHealth.text = $"{pokemon.HP}/{pokemon.MaxHP}";
    }
}

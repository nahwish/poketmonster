using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField] BattleUnit playerUnit;
    [SerializeField] BattleHUD playerHUD;
    [SerializeField] BattleHUD enemyHUD;
    [SerializeField] BattleUnit enemyUnit;


    public void Start()
    {
        SetupBattle();
    }
    public void SetupBattle()
    {
        playerUnit.SetUpPokemon();
        playerHUD.SetPokemonData(playerUnit.Pokemon);

        enemyUnit.SetUpPokemon();
        enemyHUD.SetPokemonData(enemyUnit.Pokemon);
    }
}

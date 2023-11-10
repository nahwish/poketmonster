using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BattleStates
{
    StartBattle,
    PlayerSelectAction,
    PlayerMove,
    EnemyMove,
    Busy
}





public class BattleManager : MonoBehaviour
{
    [SerializeField] BattleUnit playerUnit;
    [SerializeField] BattleHUD playerHUD;
    [SerializeField] BattleHUD enemyHUD;
    [SerializeField] BattleUnit enemyUnit;
    [SerializeField] BattleDialogBox battleDialogBox;
    public BattleStates state;


    public void Start()
    {
        StartCoroutine(SetupBattle());
    }
    public IEnumerator SetupBattle()
    {
        state = BattleStates.StartBattle;
        playerUnit.SetUpPokemon();
        playerHUD.SetPokemonData(playerUnit.Pokemon);

        battleDialogBox.SetPokemonMovement(playerUnit.Pokemon.Moves);

        enemyUnit.SetUpPokemon();
        enemyHUD.SetPokemonData(enemyUnit.Pokemon);

        yield return battleDialogBox.SetDialog($"Un {enemyUnit.Pokemon.Base.Name} salvaje apareció");
        yield return new WaitForSeconds(1.0f);

        if (enemyUnit.Pokemon.Speed > playerUnit.Pokemon.Speed)
        {
            StartCoroutine(battleDialogBox.SetDialog("El enemigo acata primero"));
            enemyAction();
        }
        else
        {
            PlayerAction();

        }

    }
    void PlayerMovement()
    {
        state = BattleStates.PlayerMove;

        battleDialogBox.ToggleDialogText(false);
        battleDialogBox.ToggleActions(false);
        battleDialogBox.ToggleMovement(true);
        currentSelectedMovement = 0;
    }
    void enemyAction()
    {

    }
    void PlayerAction()
    {
        state = BattleStates.PlayerSelectAction;
        StartCoroutine(battleDialogBox.SetDialog("Selecciona una acción"));
        battleDialogBox.ToggleDialogText(true);
        battleDialogBox.ToggleMovement(false);
        battleDialogBox.ToggleActions(true);
        currentSelectedAction = 0;
        battleDialogBox.SelectAction(currentSelectedAction);
    }

    private void Update()
    {
        timeSinceLastClick += Time.deltaTime;
        if (state == BattleStates.PlayerSelectAction)
        {
            HandlePlayerActionSelection();
        }else if(state === BattleStates.PlayerMove){
                HandlePlayerMovementSelection();
        }
    }
    private int currentSelectedAction;
    private float timeSinceLastClick;
    public float timeBetweenClick = 1.0f;

    void HandlePlayerActionSelection()
    {
        if (timeSinceLastClick < timeBetweenClick)
        {
            return;
        }
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            timeSinceLastClick = 0;
            if (currentSelectedAction == 0)
            {
                currentSelectedAction++;
            }
            else if (currentSelectedAction == 1)
            {
                currentSelectedAction--;
            }
            battleDialogBox.SelectAction(currentSelectedAction);
        }

        if (Input.GetAxis("Submit") != 0)
        {
            timeSinceLastClick = 0;
            if (currentSelectedAction == 0)
            {
                PlayerMovement();
            }
            else if (currentSelectedAction == 1)
            {
                //huir
            }
        }
    }
    private int currentSelectedMovement;
    void HandlePlayerMovementSelection()
    {
        if(timeSinceLastClick < timeBetweenClicks)
        {
            return;
        }
        if(input.GetAxisRaw("Vertical") != 0)
        {
            currentSelectedMovement = (currentSelectedMovement + 2) % 4;
        }else if(Input.GetAxisRaw("Horizontal") !=0)
        {

        }
    }
}

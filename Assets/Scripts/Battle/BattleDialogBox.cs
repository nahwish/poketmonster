using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleDialogBox : MonoBehaviour
{
    [SerializeField] Text dialogText;
    [SerializeField] GameObject actionSelect;
    [SerializeField] GameObject movementSelect;
    [SerializeField] GameObject MovementDesc;

    [SerializeField] List<Text> actionText;
    [SerializeField] List<Text> movementText;

    [SerializeField] Text ppText;
    [SerializeField] Text typeText;
    public float charactersPerSEcond = 10.0f;
    [SerializeField] Color selectedColor = Color.blue;


    public IEnumerator SetDialog(string message)
    {
        dialogText.text = "";

        foreach (var character in message)
        {
            dialogText.text += character;
            yield return new WaitForSeconds(1 / charactersPerSEcond);
        }
    }

    public void ToggleDialogText(bool activated)
    {
        dialogText.enabled = activated;
    }

    public void ToggleActions(bool activated)
    {
        actionSelect.SetActive(activated);
    }

    public void ToggleMovement(bool activated)
    {
        movementSelect.SetActive(activated);
        MovementDesc.SetActive(activated);
    }
    public void SelectAction(int selectedAction)
    {
        for (int i = 0; i < actionText.Count; i++)
        {
            if(i == selectedAction)
            {
                actionText[i].color = selectedColor;
            }else{
                actionText[i].color = Color.black;
            }
        }
    }

    public void SetPokemonMovement(List<Move> moves)
    {
        for (int  i = 0;   i < movementText.Count;  i++)
        {
            if(i < moves.Count)
            {
                movementText[i].text = moves[i].Base.name;
            }else{
                movementText[i].text = "- Empty";
            }
        }
    }
}

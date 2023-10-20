using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] GameObject healthBar;
    // void Start()
    // {
    //     healthBar.transform.localScale = new Vector3(0.5f,1.0f);
    // }

    //actualiza la barra de vida a partir del vLOR NORMALIZADO DE LA MISMA
    public void SetHP(float normalizerValue)
    {
        healthBar.transform.localScale = new Vector3(normalizerValue, 1.0f);


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextFaseDebug : MonoBehaviour
{
    public TMP_Text textFase;
    public GameObject enemy;

    // Update is called once per frame
    void Update()
    {
        if(enemy.GetComponent<EnemyPhasesController>().isPhase1Active){
            textFase.text="Fase 1";
        }
                if(enemy.GetComponent<EnemyPhasesController>().isPhase2Active){
            textFase.text="Fase 2";
        }
                if(enemy.GetComponent<EnemyPhasesController>().isPhase3Active){
            textFase.text="Fase 3";
        }

    }
}

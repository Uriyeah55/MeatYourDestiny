using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;

public class DialogSetUp : MonoBehaviour
{
    public GameObject dialogPanel, vegPortrait, meatPortrait, enemy, player;
    public TMP_Text clickContinue, dialegText;
    public LocalizeStringEvent textDialog;  // Use LocalizeStringEvent instead of TMP_Text for localization
    public bool dialogueOnCourse;
    public UbhObjectPool pool;

    public FightCourse fightCourseScript;

    public int dialogState = -1;  // To keep track of the current dialog state
    int Xposicio = -2;
    int yposicio = -1;

    void Start()
    {
        pool = GameObject.Find("Pool").GetComponent<UbhObjectPool>();
        fightCourseScript = GetComponent<FightCourse>();

        SwitchDialog();
    }

    void Update()
    {
        Debug.Log("dialeg state: " + dialogState);
        // Detect mouse click anywhere on the screen
        if (Input.GetMouseButtonDown(0))  // 0 = left mouse button
        {
            if (dialogueOnCourse)
            {
                SwitchDialog();
            }
        }
    }

    // Method to switch dialogues
    public void SwitchDialog()
    {
        dialogState++;  // Move to the next dialog state

        switch (dialogState)
        {
            case 0:
                player.SetActive(false);
                player.transform.position = new Vector3(Xposicio, yposicio, 0);
                dialogPanel.SetActive(true);
                vegPortrait.SetActive(false);
                meatPortrait.SetActive(true);
                SetLocalizedText("dialog_0");
                break;

            case 1:
                dialogPanel.SetActive(true);
                vegPortrait.SetActive(true);
                meatPortrait.SetActive(false);
                SetLocalizedText("dialog_1");
                break;

            case 2:
                dialogPanel.SetActive(true);
                vegPortrait.SetActive(true);
                meatPortrait.SetActive(false);
                SetLocalizedText("dialog_2");
                break;

            case 3:
                player.SetActive(false);

                dialogPanel.SetActive(true);
                vegPortrait.SetActive(false);
                meatPortrait.SetActive(true);
                SetLocalizedText("dialog_3");
                break;

            case 4:
                // FASE 1
                player.SetActive(true);
                hidePortraitsAndPanel();
                changeEnemyPhase(1);
                allowPlayerShootAndMovement();
                clickContinue.enabled = true;
                dialogueOnCourse = false;
                break;

            case 5:
                
                player.SetActive(false);

                clickContinue.enabled = false;
                enemy.GetComponent<UbhShotCtrl>().StopShotRoutineAndPlayingShot();
                pool.ReleaseAllBullet();
                dialogPanel.SetActive(true);
                vegPortrait.SetActive(false);
                meatPortrait.SetActive(true);
                SetLocalizedText("dialog_5");
                break;

            case 6:
                vegPortrait.SetActive(false);
                meatPortrait.SetActive(true);
                SetLocalizedText("dialog_6");
                break;

            case 7:
                vegPortrait.SetActive(false);
                meatPortrait.SetActive(true);
                SetLocalizedText("dialog_7");
                break;

            case 8:
                // FASE 2
                player.SetActive(true);

                player.transform.position = new Vector3(Xposicio, yposicio, 0);
                hidePortraitsAndPanel();
                changeEnemyPhase(2);
                allowPlayerShootAndMovement();
                dialogueOnCourse = false;
                break;

            case 9:
            changeEnemyPhase(0);
            enemy.GetComponent<UbhShotCtrl>().StopShotRoutineAndPlayingShot();
            pool.ReleaseAllBullet();
            player.SetActive(false);
            dialogPanel.SetActive(true);
            vegPortrait.SetActive(false);
            meatPortrait.SetActive(true);
            SetLocalizedText("dialog_9");
            break;

            case 10:
                dialogPanel.SetActive(true);
                vegPortrait.SetActive(false);
                meatPortrait.SetActive(true);
                SetLocalizedText("dialog_10");
                break;

            case 11:
                // FASE 3
                hidePortraitsAndPanel();
                allowPlayerShootAndMovement();
                changeEnemyPhase(3);
                dialogueOnCourse = false;
                break;

            case 12:
                player.SetActive(false);
                pool.ReleaseAllBullet();
                changeEnemyPhase(0);
                enemy.GetComponent<UbhShotCtrl>().StopShotRoutineAndPlayingShot();
                dialogPanel.SetActive(true);
                vegPortrait.SetActive(false);
                meatPortrait.SetActive(true);
                SetLocalizedText("dialog_11");
                break;

            case 13:
                dialogPanel.SetActive(true);
                vegPortrait.SetActive(false);
                meatPortrait.SetActive(true);
                SetLocalizedText("dialog_12");
                break;

            case 14:
                SceneManager.LoadScene("score");
                break;
        }
    }

    void SetLocalizedText(string key)
    {
        textDialog.StringReference.SetReference("Test", key);
    }

    void hidePortraitsAndPanel()
    {
        dialogPanel.SetActive(false);
        vegPortrait.SetActive(false);
        meatPortrait.SetActive(false);
    }

void allowPlayerShootAndMovement()
{
    PlayerLimitations playerLimitations = GetComponent<PlayerLimitations>();
    if (playerLimitations != null)
    {
        playerLimitations.enablePlayerMovement();
        playerLimitations.enablePlayerShooting();
    }
    else
    {
        Debug.LogError("PlayerLimitations component is missing on " + gameObject.name);
    }
}


    void disablePlayerShootAndMovement()
    {
        GetComponent<PlayerMovement>().DisableMovement();
        GetComponent<PlayerLimitations>().disablePlayerShooting();
    }

    void changeEnemyPhase(int idPhase)
    {
        switch (idPhase)
        {
            case 0:
                enemy.GetComponent<EnemyPhasesController>().isPhase1Active = false;
                enemy.GetComponent<EnemyPhasesController>().isPhase2Active = false;
                enemy.GetComponent<EnemyPhasesController>().isPhase3Active = false;
                break;
            case 1:
                enemy.GetComponent<EnemyPhasesController>().isPhase1Active = true;
                enemy.GetComponent<EnemyPhasesController>().isPhase2Active = false;
                enemy.GetComponent<EnemyPhasesController>().isPhase3Active = false;
                break;
            case 2:
                enemy.GetComponent<EnemyPhasesController>().isPhase1Active = false;
                enemy.GetComponent<EnemyPhasesController>().isPhase2Active = true;
                enemy.GetComponent<EnemyPhasesController>().isPhase3Active = false;
                break;
            case 3:
                enemy.GetComponent<EnemyPhasesController>().isPhase1Active = false;
                enemy.GetComponent<EnemyPhasesController>().isPhase2Active = false;
                enemy.GetComponent<EnemyPhasesController>().isPhase3Active = true;
                break;
        }
    }
}

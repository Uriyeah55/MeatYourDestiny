using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShowHideLanguagePanel : MonoBehaviour
{
    public GameObject langPanel,mainPanel,difficultyPanel;

    public void showLangPanel()
    {
        langPanel.SetActive(true);
       mainPanel.SetActive(false);
       difficultyPanel.SetActive(false);
    }
    public void hideLangPanel()
    {
        mainPanel.SetActive(true);
        langPanel.SetActive(false);
        difficultyPanel.SetActive(false);
    }
    public void showDifficultyPanel()
    {
        mainPanel.SetActive(false);
        langPanel.SetActive(false);
        difficultyPanel.SetActive(true);
    }
    public void showMainPanel()
    {
        mainPanel.SetActive(true);
        langPanel.SetActive(false);
        difficultyPanel.SetActive(false);
    }

}

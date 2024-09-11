using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShowHideLanguagePanel : MonoBehaviour
{
    public GameObject langPanel,mainPanel,difficultyPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void showLangPanel(){
        langPanel.SetActive(true);
       mainPanel.SetActive(false);
       difficultyPanel.SetActive(false);
    }
        public void hideLangPanel(){
        mainPanel.SetActive(true);
        langPanel.SetActive(false);
       difficultyPanel.SetActive(false);
    }
            public void showDifficultyPanel(){
              //  img1.SetActive(false);
        mainPanel.SetActive(false);
        langPanel.SetActive(false);
       difficultyPanel.SetActive(true);
    }
        public void showMainPanel(){
        mainPanel.SetActive(true);
        langPanel.SetActive(false);
       difficultyPanel.SetActive(false);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;  


public class LanguagesHover : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    public GameObject catSprite,engSprite,SpanishSprite,ChineseSprite;
    public int buttonToShow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        public void OnPointerEnter(PointerEventData eventData)
    {
        switch (buttonToShow){
        case 1:
        catSprite.SetActive(true);
        engSprite.SetActive(false);
        SpanishSprite.SetActive(false);
        ChineseSprite.SetActive(false);
        break;
        case 2:
        catSprite.SetActive(false);
        engSprite.SetActive(true);
        SpanishSprite.SetActive(false);
        ChineseSprite.SetActive(false);
        break;
        case 3:
        catSprite.SetActive(false);
        engSprite.SetActive(false);
        SpanishSprite.SetActive(true);
        ChineseSprite.SetActive(false);
        break;
        case 4:
        catSprite.SetActive(false);
        engSprite.SetActive(false);
        SpanishSprite.SetActive(false);
        ChineseSprite.SetActive(true);
        break;
        }
  

    }
        public void hitAllLangSprites()
        {
        catSprite.SetActive(false);
        engSprite.SetActive(false);
        SpanishSprite.SetActive(false);
        ChineseSprite.SetActive(false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        catSprite.SetActive(false);
        engSprite.SetActive(false);
        SpanishSprite.SetActive(false);
        ChineseSprite.SetActive(false);
    }
        public void quitapp(){
        Application.Quit();
    }
}

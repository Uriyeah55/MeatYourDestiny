using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class SetStartLanguage : MonoBehaviour
{
    public string languageToSet;
    private static bool localHasBeenSet=false;

    void Start(){
        if(!localHasBeenSet)
        {
        Locale targetLocale = LocalizationSettings.AvailableLocales.GetLocale(languageToSet);
        LocalizationSettings.SelectedLocale = targetLocale;
        Debug.Log("Language INITIALLY changed to: " + languageToSet);
        localHasBeenSet=true;
        }


    }
}

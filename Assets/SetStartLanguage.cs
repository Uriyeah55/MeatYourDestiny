using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class SetStartLanguage : MonoBehaviour
{
    public string languageToSet;

    void Start(){
        Locale targetLocale = LocalizationSettings.AvailableLocales.GetLocale(languageToSet);
        LocalizationSettings.SelectedLocale = targetLocale;
        Debug.Log("Language INITIALLY changed to: " + languageToSet);

    }
        public void SetLanguage(string localeCode)
    {
        Locale targetLocale = LocalizationSettings.AvailableLocales.GetLocale(localeCode);
        
        if (targetLocale != null)
        {
            LocalizationSettings.SelectedLocale = targetLocale;
            Debug.Log("Language changed to: " + localeCode);
        }
        else
        {
            Debug.LogWarning("Locale not found: " + localeCode);
        }
    }
}

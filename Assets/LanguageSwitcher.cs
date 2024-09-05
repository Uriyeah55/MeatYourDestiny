using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class LanguageSwitcher : MonoBehaviour
{

    void Start()
    {
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneTranlatable : MonoBehaviour {
    public List<Text> listTextTranslate;

    // Use this for initialization
    void Start() {
        foreach (Text item in listTextTranslate) {
            string texto = LocaleManager.GetInstance().TranslateStr(item.text.Trim());
            item.text = texto;
        }
    }
}

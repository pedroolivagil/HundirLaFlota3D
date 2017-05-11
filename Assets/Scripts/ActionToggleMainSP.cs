using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ActionToggleMainSP : MonoBehaviour {

    public Text descriptionLevel;
    private ToggleGame toggleGame;

    private void Start() {
        toggleGame = GetComponent<ToggleGame>();
        ChangeTextDescriptionLevel();
    }

    public void ChangeTextDescriptionLevel() {
        string descriptText = null;
        switch (toggleGame.idToggle) {
            case "easy":
                descriptText = "DESCRIPT_EASY";
                break;
            case "middle":
                descriptText = "DESCRIPT_MIDDLE";
                break;
            case "hard":
                descriptText = "DESCRIPT_HARD";
                break;
            case "extreme":
                descriptText = "DESCRIPT_EXTREME";
                break;
        }
        string[] values = { "3" };
        descriptionLevel.text = LocaleManager.GetInstance().TranslateStr(descriptText) + "\n\n" + LocaleManager.GetInstance().TranslateStr("DESCRIPT_BASE", values);
    }

}

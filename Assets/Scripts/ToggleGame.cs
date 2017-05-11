using UnityEngine;
using UnityEngine.UI;

public class ToggleGame : MonoBehaviour {

    public string idToggle;
    public Graphic secondGraphic;
    private Toggle toggle;
    private Color c;

    private void Start() {
        toggle = GetComponent<Toggle>();
        c = secondGraphic.color;
        ChangeValue();
    }

    public void ChangeValue() {
        if (toggle.isOn) {
            c.a = 1;
            secondGraphic.color = c;
        } else {
            c.a = 0;
            secondGraphic.color = c;
        }
    }
}

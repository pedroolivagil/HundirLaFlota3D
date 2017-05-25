using UnityEngine;

public class MainSinglePlayerScreen : MonoBehaviour {

    public Canvas canvas;
    public GameObject layoutLogin;

    private void FixedUpdate() {
        Controllers.GetInstance().HideFloatingLayouts();
    }

    public void NavigateToMainMenuScene() {
        GameManager.ChangeScreen(GameScenes.MainMenuScene);
    }

    public void CloseLayout(string id) {
        Controllers.GetInstance().HideFloatingLayouts(id);
    }

    public void StartGame() {
        GameObject instance = Instantiate(layoutLogin);
        instance.GetComponent<RectTransform>().SetParent(canvas.GetComponent<Transform>(), false);
    }

}

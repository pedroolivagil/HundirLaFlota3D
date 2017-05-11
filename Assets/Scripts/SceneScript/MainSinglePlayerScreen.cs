using UnityEngine;
using UnityEngine.UI;

public class MainSinglePlayerScreen : MonoBehaviour {

    public Text textMessages;
    public InputField user;
    public InputField pass;

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
        Controllers.GetInstance().ShowFloatingLayouts("login");
    }

    public void Login() {
        textMessages.text = "conectando...";
        user.interactable = false;
        pass.interactable = false;
        ExceptionGame result = DB.GetInstance().LoginUser(user.text, pass.text);
        if (result.code != ExceptionGame.ResponseCode.CODE_200) {
            textMessages.text = result.message;
            user.interactable = true;
            pass.interactable = true;
        } else {
            Controllers.GetInstance().HideFloatingLayouts();
        }
    }
}

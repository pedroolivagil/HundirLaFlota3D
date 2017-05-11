using LitJson;
using System.Collections;
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
        DB.GetInstance().LoginUser(user.text, pass.text);
        JsonData response = DB.GetInstance().GetResponse();
        ExceptionGame.ResponseCode code = DB.GetInstance().ResponseCode(response);
        
        string message;
        if (code != ExceptionGame.ResponseCode.CODE_200) {
            if (code == ExceptionGame.ResponseCode.CODE_404) {
                Debug.Log("Conection Fail");
                message = LocaleManager.GetInstance().TranslateStr("ERROR_USER_NOT_EXIST");
            } else {
                Debug.Log("FAIL TO CONNECT SERVER");
                message = LocaleManager.GetInstance().TranslateStr("ERROR_UNABLE_TO_CONNECT_SERVER");
            }
            user.interactable = true;
            pass.interactable = true;
        } else {
            message = LocaleManager.GetInstance().TranslateStr("ERROR_USER_EXIST");
            Controllers.GetInstance().HideFloatingLayouts();
        }
        textMessages.text = message;
    }
}

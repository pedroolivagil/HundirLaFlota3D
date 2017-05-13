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
        StartCoroutine(DB.GetInstance().LoginUser(user.text, pass.text));
    }

    public void Login() {
        StartCoroutine(DB.GetInstance().LoginUser(user.text, pass.text));
        if (DB.GetInstance().GetResponseText() != null) {
            textMessages.text = LocaleManager.GetInstance().TranslateStr("CONNECTING_SERVER");
            user.interactable = false;
            pass.interactable = false;
            Debug.Log("aqui entra");
            JsonData response = DB.GetInstance().JSONResponse();
            ExceptionGame.ResponseCode code = ExceptionGame.Parse((int)response[DB.RESPONSE_LABEL]);
            string message;
            if (code != ExceptionGame.ResponseCode.CODE_200) {
                user.interactable = true;
                //user.text = null;
                pass.interactable = true;
                pass.text = null;
                if (code == ExceptionGame.ResponseCode.CODE_404) {
                    Debug.Log("Conection Fail");
                    message = LocaleManager.GetInstance().TranslateStr("ERROR_USER_NOT_EXIST");
                } else {
                    Debug.Log("FAIL TO CONNECT SERVER");
                    message = LocaleManager.GetInstance().TranslateStr("ERROR_UNABLE_TO_CONNECT_SERVER");
                }
            } else {
                message = LocaleManager.GetInstance().TranslateStr("INFO_USER_EXIST");
                Controllers.GetInstance().HideFloatingLayouts();
            }
            Debug.Log("MSJ: " + message);
            textMessages.text = message;
        }
        DB.GetInstance().CloseDB();
    }
}

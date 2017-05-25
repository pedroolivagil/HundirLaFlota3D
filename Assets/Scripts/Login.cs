using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour {

    public Text textMessages;
    public InputField user;
    public InputField pass;

    public void CloseLayout() {
        Destroy(gameObject, .1f);
    }

    public void LoginUser() {
        StartCoroutine(DB.GetInstance().LoginUser(user.text, pass.text));
        if (user.text != null && pass.text != null) {
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
                    StartCoroutine(StartSP());
                }
                Debug.Log("MSJ: " + message);
                textMessages.text = message;
            }
            DB.GetInstance().CloseDB();
        }
    }

    public IEnumerator StartSP() {
        yield return new WaitForSeconds(2);
        GameManager.ChangeScreen(GameScenes.GameSP, true);
    }
}

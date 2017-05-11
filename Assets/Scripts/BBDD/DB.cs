using System.Collections;
using UnityEngine;
using LitJson;

public class DB : MonoBehaviour {

    public string url_host = "http://localhost/testHundirFlota3D";
    public string url_login = "/www/login.php";

    private static DB instance = null;
    WWW con;

    public static DB GetInstance() {
        init();
        return instance;
    }

    public static void init() {
        if (instance == null) {
            instance = GameObject.FindObjectOfType<DB>();
        }
    }

    void Awake() {
        init();
        DontDestroyOnLoad(this.gameObject);
    }

    private JsonData ParseResponse(string response) {
        return JsonMapper.ToObject(response);
    }

    private int ResponseCode(JsonData response) {
        return (int)response["response"];
    }

    private IEnumerator Connection(WWWForm data) {
        con = new WWW(url_host + url_login, data);
        yield return con;
    }

    private IEnumerator WhileWWW(WWW con) {
        while (!con.isDone) {
            yield return new WaitForSeconds(1);
        }
    }

    public ExceptionGame LoginUser(string user, string pass) {
        WWWForm data = new WWWForm();
        data.AddField("user", user);
        data.AddField("pass", pass);
        StartCoroutine(Connection(data));
        if (con.isDone) {
            JsonData response = ParseResponse(con.text);
            int code = ResponseCode(response);
            if (code == 200) {
                Debug.Log("User Ok");
                return new ExceptionGame(ExceptionGame.ResponseCode.CODE_200, LocaleManager.GetInstance().TranslateStr("ERROR_USER_EXIST"));
            } else if (code == 404) {
                Debug.Log("User Fail");
                return new ExceptionGame(ExceptionGame.ResponseCode.CODE_404, LocaleManager.GetInstance().TranslateStr("ERROR_USER_NOT_EXIST"));
            } else {
                Debug.Log("FAIL TO CONNECT SERVER");
                return new ExceptionGame(ExceptionGame.ResponseCode.CODE_400, LocaleManager.GetInstance().TranslateStr("ERROR_UNABLE_TO_CONNECT_SERVER"));
            }
        }
        return new ExceptionGame(ExceptionGame.ResponseCode.CODE_100, LocaleManager.GetInstance().TranslateStr("ERROR_TIMEOUT"));
    }
}

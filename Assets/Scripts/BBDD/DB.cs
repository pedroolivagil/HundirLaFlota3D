using System.Collections;
using UnityEngine;
using LitJson;

public class DB : MonoBehaviour {

    public string url_host = "http://localhost/testHundirFlota3D";
    public string url_login = "/www/login.php";

    private static DB instance = null;
    private WWW con;
    private JsonData response;

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

    private IEnumerator Connection(WWWForm data) {
        con = new WWW(url_host + url_login, data);
        yield return con;
        Response();
    }

    private void Response() {
        if (con.isDone) {
            this.response = ParseResponse(con.text);
        }
    }

    public ExceptionGame.ResponseCode ResponseCode(JsonData responseLocal) {
        ExceptionGame.ResponseCode result = ExceptionGame.ResponseCode.CODE_000;
        Debug.Log(responseLocal["response"]);
        if (responseLocal["response"] != null) {
            switch ((int)responseLocal["response"]) {
                case 200:
                    result = ExceptionGame.ResponseCode.CODE_200;
                    break;
                case 400:
                    result = ExceptionGame.ResponseCode.CODE_400;
                    break;
                case 404:
                    result = ExceptionGame.ResponseCode.CODE_404;
                    break;
            }
        }
        return result;
    }

    public JsonData GetResponse() {
        return response;
    }

    public IEnumerator LoginUser(string user, string pass) {
        WWWForm data = new WWWForm();
        data.AddField("user", user);
        data.AddField("pass", pass);
        yield return StartCoroutine(Connection(data));
    }
}

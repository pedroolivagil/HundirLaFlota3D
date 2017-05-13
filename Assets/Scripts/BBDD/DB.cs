using System.Collections;
using UnityEngine;
using LitJson;

public class DB : MonoBehaviour {

    public static string RESPONSE_LABEL = "response";

    public string url_host = "http://localhost/HundirLaFlota3DServer";
    public string url_login = "/www/login.php";

    private static DB instance = null;
    private string responseText;

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

    private IEnumerator Connection(WWWForm data) {
        WWW con = new WWW(url_host + url_login, data);
        yield return con;
        responseText = con.text;
    }

    public JsonData JSONResponse() {
        return JsonMapper.ToObject(responseText);
    }

    public string GetResponseText() {
        return responseText;
    }

    public IEnumerator LoginUser(string user, string pass) {
        WWWForm data = new WWWForm();
        data.AddField("user", user);
        data.AddField("pass", pass);
        yield return StartCoroutine(Connection(data));
    }

    public void CloseDB() {
        responseText = null;
    }
}

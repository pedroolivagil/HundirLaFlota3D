using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static readonly int SINGLE_PLAYER = 0;
    public static readonly int MULTI_PLAYER = 1;

    public List<Text> listaTextoFadeOut;
    public float timeToFade = .05f;
    private static int gameMode;

    // Use this for initialization
    void Start() {
        StartCoroutine(SecuencialFadeInText());
        StartCoroutine(SecuencialFadeOutText());
        DontDestroyOnLoad(gameObject);
    }

    public IEnumerator SecuencialFadeOutText() {
        yield return new WaitForSeconds(2f);
        if (listaTextoFadeOut.Capacity > 0) {
            foreach (Text objText in listaTextoFadeOut) {
                Color c = objText.color;
                while (c.a > 0) {
                    c.a -= timeToFade * 2;
                    objText.color = c;
                    Debug.Log("Object txt change color: " + c.a);
                    yield return new WaitForSeconds(timeToFade);
                }
            }
        }
        StopCoroutine(SecuencialFadeOutText());
    }

    public IEnumerator SecuencialFadeInText() {
        yield return new WaitForSeconds(.3f);
        if (listaTextoFadeOut.Capacity > 0) {
            foreach (Text objText in listaTextoFadeOut) {
                Color c = objText.color;
                while (c.a < 1) {
                    c.a += timeToFade * 2;
                    objText.color = c;
                    Debug.Log("Object txt change color: " + c.a);
                    yield return new WaitForSeconds(timeToFade);
                }
            }
        }
        StopCoroutine(SecuencialFadeInText());
    }

    public static IEnumerator ExitGame() {
        Debug.Log("Exiting...");
        yield return new WaitForSeconds(3.5f);
        Debug.Log("Exited");
        Application.Quit();
    }

    public static void ChangeScreen(string screen) {
        SceneManager.LoadScene(screen, LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    public static void ChangeScreen(int screen) {
        SceneManager.LoadScene(screen, LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    public static void Reload() {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    public static int GetGameMode() {
        return GameManager.gameMode;
    }

    public static void SetGameMode(int gameMode) {
        GameManager.gameMode = gameMode;
    }

}

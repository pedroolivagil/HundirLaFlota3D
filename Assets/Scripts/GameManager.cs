using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static readonly int SINGLE_PLAYER = 0;
    public static readonly int MULTI_PLAYER = 1;
    public int screenWidth = 1920;
    public int screenHeigth = 1080;
    public List<Text> listaTextoFadeOut;
    public float timeToFade = .05f;
    private static int gameMode;
    private static List<Resolution> listResolution;

    // Use this for initialization
    void Start() {
        StartCoroutine(SecuencialFadeInText());
        StartCoroutine(SecuencialFadeOutText());
        DontDestroyOnLoad(gameObject);
        listResolution = new List<Resolution>();
        foreach (Resolution res in Screen.resolutions) {
            if (!listResolution.Contains(res)) {
                listResolution.Add(res);
                if (res.width.Equals(screenWidth) && res.height.Equals(screenHeigth)) {
                    SetResolutionGame(res);
                }
            }
        }
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

    public List<Resolution> GetListResolution() {
        return listResolution;
    }

    public void SetResolutionGame(Resolution resolution) {
        Debug.Log("Resolution has been changed: " + resolution.width + "x" + resolution.height);
        Screen.SetResolution(resolution.width, resolution.height, true, resolution.refreshRate);
        Screen.fullScreen = true;
    }

    public void ToogleFullScreen() {
        Screen.fullScreen = !Screen.fullScreen;
    }
}

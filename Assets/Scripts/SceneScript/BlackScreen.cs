using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BlackScreen : MonoBehaviour {

    public Slider sliderLoader;
    public Text textStatus;
    private AsyncOperation loadScene;
    public static string navigateScene;
    
    void Start() {
        sliderLoader.value = 0;
        if (textStatus) {
            textStatus.text = "0%";
        }
        //loadScene = SceneManager.LoadSceneAsync(GameScenes.StarterSinglePlayer, LoadSceneMode.Single);
        loadScene = SceneManager.LoadSceneAsync(navigateScene, LoadSceneMode.Single);
    }

    void Update() {
        PreLoadScene();
    }

    private void PreLoadScene() {
        if (sliderLoader.value <= 100) {
            Debug.Log("Preload scene progress: " + loadScene.progress * 100);
            sliderLoader.value = loadScene.progress * 100;
            if (textStatus) {
                textStatus.text = loadScene.progress * 100 + "%";
            }
        }
    }

    public static void SetNavigateScene(string navigateScene) {
        BlackScreen.navigateScene = navigateScene;
    }
}

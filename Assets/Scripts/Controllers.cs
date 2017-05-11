using UnityEngine;

public class Controllers {

    public static readonly string TAG_FLOATING_LAYOUT = "FloatingLayout";
    private static Controllers instance = null;

    public static Controllers GetInstance() {
        init();
        return instance;
    }

    public static void init() {
        if (instance == null) {
            instance = new Controllers();
        }
    }

    void Awake() {
        init();
    }

    public void HideFloatingLayouts() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            GameObject[] layouts = GameObject.FindGameObjectsWithTag(TAG_FLOATING_LAYOUT);
            foreach (GameObject layout in layouts) {
                layout.transform.localScale = new Vector3(0,0,0);
            }
        }
    }

    public void HideFloatingLayouts(string id) {
        Debug.Log("Close Layout");
        GameObject[] layouts = GameObject.FindGameObjectsWithTag(TAG_FLOATING_LAYOUT);
        foreach (GameObject layout in layouts) {
            Debug.Log("L: " + layout.GetComponent<Identificador>().GetIdLayout() + "; ID: " + id);
            if (layout.GetComponent<Identificador>().GetIdLayout().Equals(id)) {
                layout.transform.localScale = new Vector3(0, 0, 0);
            }
        }
    }

    public void ShowFloatingLayouts(string id) {
        Debug.Log("Open Layout");
        GameObject[] layouts = GameObject.FindGameObjectsWithTag(TAG_FLOATING_LAYOUT);
        Debug.Log(layouts.ToString());
        foreach (GameObject layout in layouts) {
            Debug.Log("L: "+ layout.GetComponent<Identificador>().GetIdLayout() + "; ID: "+id);
            if (layout.GetComponent<Identificador>().GetIdLayout().Equals(id)) {
                layout.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }

}

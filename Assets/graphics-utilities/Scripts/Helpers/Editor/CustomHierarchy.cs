using UnityEditor;
using UnityEngine;

[InitializeOnLoad]

public class CustomHierarchy : EditorWindow
{
    private static bool useCustomHierarchy = false;
    private static bool showLayers = true;
    private static bool showToggle = true;
    private static Color activeColor = new Color(0f, 0.4f, 0f, 1f);
    private static Color inActiveColor = new Color(0f, 0.4f, 0f, 0.5f);
    private static Color prefabActiveColor = new Color(0f, 0.3f, 1f, 1f);
    private static Color prefabInactiveColor = new Color(0f, 0.3f, 1f, 0.5f);
    private static float offset = 0;
    private static GUIStyle layerStyle;
    private static string labelString = "";

    private static EditorWindow w;

    static CustomHierarchy()
    {
        EditorApplication.hierarchyWindowItemOnGUI += HierarchyWindowItemOnGUI;
        layerStyle = new GUIStyle();
        layerStyle.fontSize = 10;
        layerStyle.fixedWidth = 76;
        layerStyle.clipping = TextClipping.Clip;
        layerStyle.normal.textColor = activeColor;
    }

    private static void HierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
    {
        if (!useCustomHierarchy)
            return;
        GameObject go = (GameObject)EditorUtility.InstanceIDToObject(instanceID);
        if (go != null)
        {
            if (go.activeInHierarchy)
                if (PrefabUtility.GetPrefabType(go) == PrefabType.PrefabInstance)
                {
                    layerStyle.normal.textColor = prefabActiveColor;
                    layerStyle.fontStyle = FontStyle.Bold;
                }
                else
                {
                    layerStyle.normal.textColor = activeColor;
                    layerStyle.fontStyle = FontStyle.Normal;
                }
            else
                if (PrefabUtility.GetPrefabType(go) == PrefabType.PrefabInstance)
            {
                layerStyle.normal.textColor = prefabInactiveColor;
                layerStyle.fontStyle = FontStyle.Bold;
            }
            else
            {
                layerStyle.normal.textColor = inActiveColor;
                layerStyle.fontStyle = FontStyle.Normal;
            }

            Rect rect = new Rect(selectionRect);
            offset = selectionRect.width + selectionRect.x - 16;

            if (showToggle)
            {
                rect.x = offset;
                bool toggleStatus = GUI.Toggle(rect, go.activeSelf, "");
                go.SetActive(toggleStatus);
            }

            if (showLayers)
            {
                labelString = "";
                Canvas canvas = go.GetComponent<Canvas>();
                Renderer renderer = go.GetComponent<Renderer>();
                if (renderer != null)
                    labelString = renderer.sortingOrder + " " + renderer.sortingLayerName;
                if (canvas != null)
                    labelString = canvas.sortingOrder + " " + canvas.sortingLayerName;
                if (showToggle)
                    rect.x = offset - 80;
                else
                    rect.x = offset - 62;
                rect.width = 120;
                GUI.Label(rect, labelString, layerStyle);
            }
        }
    }

    [MenuItem("Edit/CustomHierarchy Settings", false, 2000)]
    public static void ShowSettingsWindow()
    {
        LoadSettings();
        var window = GetWindow(typeof(CustomHierarchy));
        Vector2 midScreen = new Vector2(Screen.currentResolution.width * 0.5f, Screen.currentResolution.height * 0.5f);
        window.position = new Rect(midScreen.x - 100, midScreen.y - 67, 200, 134);
        window.Show();
    }

    void OnGUI()
    {
        useCustomHierarchy = EditorGUILayout.Toggle("Use CustomHierarchy?", useCustomHierarchy);
        showToggle = EditorGUILayout.Toggle("Show toggle?", showToggle);
        showLayers = EditorGUILayout.Toggle("Show layers info?", showLayers);

        activeColor = EditorGUILayout.ColorField("Normal color", activeColor);
        inActiveColor = activeColor;
        inActiveColor.a = 0.5f;

        prefabActiveColor = EditorGUILayout.ColorField("Prefab color", prefabActiveColor);
        prefabInactiveColor = prefabActiveColor;
        prefabInactiveColor.a = 0.5f;

        if (GUILayout.Button("Reset settings"))
            ResetSettings();
        if (GUILayout.Button("Save settings"))
            SaveSettings();
    }

    static void SaveSettings()
    {
        PlayerPrefs.SetInt("useCustomHierarchy", useCustomHierarchy ? 1 : 0);
        PlayerPrefs.SetInt("CHshowToggle", showToggle ? 1 : 0);
        PlayerPrefs.SetInt("CHshowLayers", showLayers ? 1 : 0);

        PlayerPrefs.SetFloat("activeColorR", activeColor.r);
        PlayerPrefs.SetFloat("activeColorG", activeColor.g);
        PlayerPrefs.SetFloat("activeColorB", activeColor.b);

        PlayerPrefs.SetFloat("prefabActiveColorR", prefabActiveColor.r);
        PlayerPrefs.SetFloat("prefabActiveColorG", prefabActiveColor.g);
        PlayerPrefs.SetFloat("prefabActiveColorB", prefabActiveColor.b);

        PlayerPrefs.Save();

        Debug.Log("CustomHierarchy config saved...");
    }

    [InitializeOnLoadMethod]
    static void LoadSettings()
    {
        if (PlayerPrefs.HasKey("useCustomHierarchy"))
            useCustomHierarchy = PlayerPrefs.GetInt("useCustomHierarchy") == 1;
        if (PlayerPrefs.HasKey("CHshowToggle"))
            showToggle = PlayerPrefs.GetInt("CHshowToggle") == 1;
        if (PlayerPrefs.HasKey("CHshowLayers"))
            showLayers = PlayerPrefs.GetInt("CHshowLayers") == 1;

        if (PlayerPrefs.HasKey("activeColorR"))
        {
            activeColor = new Color(PlayerPrefs.GetFloat("activeColorR"), PlayerPrefs.GetFloat("activeColorG"), PlayerPrefs.GetFloat("activeColorB"), 1);
            inActiveColor = activeColor;
            inActiveColor.a = 0.5f;
        }

        if (PlayerPrefs.HasKey("prefabActiveColorR"))
        {
            prefabActiveColor = new Color(PlayerPrefs.GetFloat("prefabActiveColorR"), PlayerPrefs.GetFloat("prefabActiveColorG"), PlayerPrefs.GetFloat("prefabActiveColorB"), 1);
            prefabInactiveColor = prefabActiveColor;
            prefabInactiveColor.a = 0.5f;
        }

        Debug.Log("CustomHierarchy config loaded...");
    }

    void ResetSettings()
    {
        useCustomHierarchy = true;
        showLayers = true;
        showToggle = true;
        activeColor = new Color(0f, 0.4f, 0f, 1f);
        inActiveColor = new Color(0f, 0.4f, 0f, 0.5f);
        prefabActiveColor = new Color(0f, 0.3f, 1f, 1f);
        prefabInactiveColor = new Color(0f, 0.3f, 1f, 0.5f);
        SaveSettings();
    }

    void OnDestroy()
    {
        SaveSettings();
    }
}
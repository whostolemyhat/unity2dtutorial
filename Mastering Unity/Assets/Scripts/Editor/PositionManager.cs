using UnityEditor;
using UnityEngine;

public class PositionManager : MonoBehaviour {
    // define a menu item in the editor
    [MenuItem("Assets/Create/PositionManager")]
    public static void CreateAsset() {
        ScriptingObjects positionManager = ScriptableObject.CreateInstance<ScriptingObjects>();

        // create asset
        AssetDatabase.CreateAsset(positionManager, "Assets/newPositionManager.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();
        Selection.activeObject = positionManager;
    }

    public static PositionManager ReadPositions(string Name) {
        string path = "/";
        object o = Resources.Load(path + Name);
        PositionManager retrievedPositions = (PositionManager) o;

        return retrievedPositions;
    }
}
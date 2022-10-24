using System.Linq;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using System.Collections.Generic;

public class AssetsEditor : EditorWindow
{
    string bundleName = "New Bundle"; // string of a choosen bundle name
    public GameObject obj = null; // a gameobject for the sprites

    [MenuItem("Window/Assets Editor")]  //The location and the name of the Editor Window
    public static void ShowWindow()
    {

        GetWindow<AssetsEditor>(); // make the window visible on the menu

    }



    void OnInspectorUpdate()
    {

    }


    private void OnGUI()
    {
        GUILayout.Label("Assets Bundle Maker:", EditorStyles.boldLabel); // Top Text

        //Code For input Sprites
        GUILayout.Label("Set X symbol:");
        EditorGUILayout.ObjectField(obj, typeof(Sprite), false, GUILayout.Height(EditorGUIUtility.singleLineHeight));
        GUILayout.Label("Set O symbol:");
        EditorGUILayout.ObjectField(obj, typeof(Sprite), false, GUILayout.Height(EditorGUIUtility.singleLineHeight));
        GUILayout.Label("Set Background:");
        EditorGUILayout.ObjectField(obj, typeof(Sprite), false, GUILayout.Height(EditorGUIUtility.singleLineHeight));



        bundleName = EditorGUILayout.TextField("Asset Bundle Name:", bundleName); // Text Field for the name of the bundle


        if (GUILayout.Button("Build Asset Bundle")) // a button
        {
            Debug.Log("Build Is Set");

            BuildPipeline.BuildAssetBundles("Assets/Streaming Assets", BuildAssetBundleOptions.None, BuildTarget.Android);

        }


    }

    

}

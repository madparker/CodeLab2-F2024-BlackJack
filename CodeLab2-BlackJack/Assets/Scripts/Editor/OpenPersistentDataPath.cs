

using UnityEditor;
using UnityEngine;

public class OpenPersistentDataPath
{
    [MenuItem("Tools/Open Persistent Data Path")]
    public static void Open()
    {
        //if mac os
#if UNITY_EDITOR_OSX
        EditorUtility.RevealInFinder(Application.persistentDataPath);
#endif
        
#if UNITY_EDITOR_WIN
        System.Diagnostics.Process.Start("explorer.exe", Application.persistentDataPath.Replace("/", "\\"));
#endif
        
        
    }
}
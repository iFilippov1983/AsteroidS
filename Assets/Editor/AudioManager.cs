using Assets.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AudioManager
{
    [MenuItem("Tools/����� ��������")]
    private static void MenuOption()
    {
        EditorWindow.GetWindow(typeof(AudioManagerWindow), false, "����� ��������");
    }
}

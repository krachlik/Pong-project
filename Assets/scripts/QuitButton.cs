using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public void CloseApplication()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
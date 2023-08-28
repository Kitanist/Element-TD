using UnityEngine.SceneManagement;
using UnityEngine;

public class TheScene : MonoBehaviour
{
    public void SceneLoaderTheScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}

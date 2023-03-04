using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagment : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

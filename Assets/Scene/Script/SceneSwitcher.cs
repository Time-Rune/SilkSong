using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{

    string s;
    public void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    float stimes;

    float ntimes;
    private void Start()
    {
        stimes = Time.time;
    }
    private void Update()
    {
        ntimes = Time.time;
        if (ntimes - stimes >= 3)
        {
            SwitchScene("MainMenu");
        }
    }
}

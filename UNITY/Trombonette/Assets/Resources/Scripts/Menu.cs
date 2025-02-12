using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public TextMeshProUGUI textHighScore;

    private void Start()
    {
        textHighScore.text = PlayerPrefs.GetInt("highScore").ToString();
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuiApp()
    {
        Application.Quit();
    }

}

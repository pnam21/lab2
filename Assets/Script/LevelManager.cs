using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    [SerializeField] float delay =3f;
    ScoreKeeper scoreKeeper;
    private void Awake()
    {
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
    }
    public void LoadStage1()
    {
            scoreKeeper.ResetScore();

        StartCoroutine(WaitAndLoad("Level1", 1));
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadBegin()
    {
        StartCoroutine(WaitAndLoad("Level1", 1));
    }


    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}

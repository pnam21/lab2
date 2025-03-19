using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Rendering;

public class ScoreKeeper : MonoBehaviour
{
    int score;
    static ScoreKeeper instance;
    LevelManager levelManager;
    private void Awake()
    {
        ManageSingleton();
        SceneManager.sceneLoaded += OnSceneLoaded; 
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; 
    }


    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        levelManager = FindFirstObjectByType<LevelManager>(); 
        Debug.Log($"LevelManager reassigned in scene: {scene.name}");
    }
    public void ModifyScore(int value)
    {
        Debug.Log($"Adding Score: {value}");
        score += value;
        score = Mathf.Clamp(score, 0, int.MaxValue);
    }
    void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public int GetScore()
    {
        return score;
    }

    public void ResetScore()
    {
        Debug.Log("ResetScore() dc goi!");
        score = 0;
        
    }
}

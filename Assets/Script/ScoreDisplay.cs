using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ScoreDisplay : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject scorePoint;
    [SerializeField] Transform scorePointParent;
    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
    }

    void Update()
    {
        scoreText.text = scoreKeeper.GetScore() < 0 ? scoreKeeper.GetScore().ToString() : scoreKeeper.GetScore().ToString("");
    }
    public void ShowPoint(int score)
    {
        GameObject point = Instantiate(scorePoint, scorePointParent.position, Quaternion.identity);
        point.transform.SetParent(scorePointParent, true);

        TextMeshProUGUI pointText = point.GetComponentInChildren<TextMeshProUGUI>();
        if (pointText != null)
        {
            if (score < 0)
            {
                pointText.color = Color.red;
                pointText.text = score.ToString();
            }
            else
            {
                pointText.text = "+" + score.ToString();
            }
        }

        StartCoroutine(FadeAndMove(point));
    }

    IEnumerator FadeAndMove(GameObject point)
    {
        float duration = 1f;
        float elapsed = 0f;
        Vector3 startPosition = point.transform.position;
        Vector3 targetPosition = startPosition + Vector3.up * 50f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;

            point.transform.position = Vector3.Lerp(startPosition, targetPosition, t);

            yield return null;
        }

        Destroy(point);
    }
}

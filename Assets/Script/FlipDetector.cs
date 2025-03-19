using UnityEngine;

public class FlipDetector : MonoBehaviour
{
    [SerializeField] private float baseFlipScore = 100f; 
    private float lastRotationZ;
    private float accumulatedRotation = 0f;
    private int flipCount = 0;
    private bool isAirborne = false;
    [SerializeField] AudioClip audioClip;
    private ScoreKeeper scoreKeeper;
    private ScoreDisplay scoreDisplay;
    private Rigidbody2D rb;

    private void Awake()
    {
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
        scoreDisplay = FindFirstObjectByType<ScoreDisplay>();
        rb = GetComponent<Rigidbody2D>(); 
    }

    private void Update()
    {
        DetectAirborneState(); 

        float currentRotationZ = transform.eulerAngles.z;
        float rotationDifference = Mathf.DeltaAngle(lastRotationZ, currentRotationZ);

        if (isAirborne)
        {
            accumulatedRotation += rotationDifference;

            if (Mathf.Abs(accumulatedRotation) >= 180f)
            {
                flipCount++; 
                float scoreToAdd = baseFlipScore + 50f * (flipCount - 1);
                scoreKeeper.ModifyScore(Mathf.RoundToInt(scoreToAdd));
                scoreDisplay.ShowPoint(Mathf.RoundToInt(scoreToAdd));
                GetComponent<AudioSource>().PlayOneShot(audioClip);
                accumulatedRotation = 0f; 
            }
        }

        lastRotationZ = currentRotationZ;
    }

    private void DetectAirborneState()
    {
        isAirborne = Mathf.Abs(rb.linearVelocity.y) > 0.5f;

        if (!isAirborne)
        {
            accumulatedRotation = 0f;
            flipCount = 0;
        }
    }
}

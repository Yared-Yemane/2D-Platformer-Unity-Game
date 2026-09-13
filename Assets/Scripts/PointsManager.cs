using UnityEngine;
using TMPro;

public class PointsManager : MonoBehaviour
{

    public static PointsManager Instance;
    [SerializeField] private TMP_Text pointsText;
    private int points = 0;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        pointsText.text = "Points: " + points;
    }

    public void IncreasePoints(int amount)
    {
        points += amount;
        pointsText.text = "Points: " + points;
    }

    public void ResetScore()
    {
        points = 0;
        pointsText.text = "Points: " + points;
    }
}

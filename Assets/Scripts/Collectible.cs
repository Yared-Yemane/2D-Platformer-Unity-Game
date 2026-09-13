using UnityEngine;

public class Collectible : MonoBehaviour
{

    [SerializeField] private int pointsToAdd;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.GetComponent<PlayerController>())
        {
            //Debug.Log("Cherry touched");
            PointsManager.Instance.IncreasePoints(pointsToAdd);
            SoundManager.Instance.PlayCollectibleSound();
            Destroy(gameObject);
       }
    }
}   

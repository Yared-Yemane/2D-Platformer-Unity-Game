using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrophyManager : MonoBehaviour
{

    [SerializeField] private GameObject winParticles;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>()) {
            Instantiate(winParticles, transform.position, Quaternion.identity);

            StartCoroutine(WinRoutine());
        }
    }

    private IEnumerator WinRoutine()
    {
        yield return new WaitForSeconds(2f);

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
}

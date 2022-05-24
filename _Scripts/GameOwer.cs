using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOwer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<PlayerController>(out PlayerController player))
        {
            Debug.Log("Game Ower!");
            SceneManager.LoadScene("SampleScene");
        }
    }
}

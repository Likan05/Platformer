using UnityEngine;

public class FruitTaken : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerController>(out PlayerController player))
            Destroy(gameObject);     
    }
}

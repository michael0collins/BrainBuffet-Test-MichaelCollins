using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] GameObject _healthParticlePrefab;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            collision.GetComponent<PlayerController>().OnTriggeredCollectable();

            Destroy(gameObject);
        }
    }
}

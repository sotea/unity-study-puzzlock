using UnityEngine;

public class Lock : MonoBehaviour
{
    [SerializeField] GameObject effect;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string keyColor = collision.gameObject.name.Replace("Key", "");
        string lockColor = gameObject.name.Replace("Lock", "");

        if (keyColor == lockColor)
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}

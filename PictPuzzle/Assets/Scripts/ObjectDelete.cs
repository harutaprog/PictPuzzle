using UnityEngine;

public class ObjectDelete : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Abyss")
        {
            Destroy(this.gameObject);
        }
    }
}

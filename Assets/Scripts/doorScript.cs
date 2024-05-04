using UnityEngine.SceneManagement;
using UnityEngine;

public class doorScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadSceneAsync(2);
        }
    }
}

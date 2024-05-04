using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptEnd : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(LoadNextSceneAfterDelay(15f));
    }

    IEnumerator LoadNextSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadSceneAsync(0);
    }
}

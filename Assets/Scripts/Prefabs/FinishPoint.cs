using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    public float x = 0f, y = 0f;
    public string sceneName;
    public GameObject player;

    private static float newX = 0f, newY = 0f;

    private void Awake()
    {
        if (newX != 0f || newY != 0f)
        {
            player.transform.position = new Vector3(newX, newY, 0f);
            newX = 0f;
            newY = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            SceneManager.LoadSceneAsync(sceneName);
            newX = x;
            newY = y;
        }
    }
}

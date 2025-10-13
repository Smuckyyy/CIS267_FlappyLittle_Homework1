using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public GameObject deathScreen;

    private bool isDead = false;

    void Update()
    {
        if (isDead) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody.linearVelocity = Vector2.up * flapStrength;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe") || collision.gameObject.CompareTag("Ground"))
        {
            Die();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.gameObject.CompareTag("ScoreZone"))
    {
        FindFirstObjectByType<ScoreManager>().AddPoint();
    }
}

    void Die()
    {
        if (isDead) return;
        Debug.Log("Player Died");
        isDead = true;

        myRigidbody.simulated = false;

        if (GameOverManager.instance != null)
        {
            GameOverManager.instance.ShowGameOver();
            return;
        }

        Time.timeScale = 0f;
        if (deathScreen != null)
            deathScreen.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
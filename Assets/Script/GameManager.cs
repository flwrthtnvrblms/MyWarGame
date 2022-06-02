using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TankMovement movement;
    public float levelRestartDelay = 2f;
    public float playAgainDeleay = 10f;

    public GameObject tankExplosion;
    public AudioClip tankExplosionAudio;

    public void EndGame(){
        movement.enabled = false;
        Debug.Log("Game Over!");
        Invoke("RestartLevel", levelRestartDelay);
    }

    public void GameWin(){
        movement.enabled = false;
        Debug.Log("You win!");
        Invoke("RestartLevel", playAgainDeleay);
    }

    void RestartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

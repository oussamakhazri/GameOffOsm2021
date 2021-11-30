using UnityEngine;
using UnityEngine.SceneManagement;




public class End : MonoBehaviour
{
    public float delay = 2.0f;
    public Animator transitionanim;
    public GameManager gameManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")

            transitionanim.SetTrigger("End");
        FindObjectOfType<AudioManager>().Play("Ending SFX");

        Invoke("LevelLoad", delay);
    }
    public void LevelLoad()
    {
        {
            gameManager.LoadNextLevel();
        }
    }
}









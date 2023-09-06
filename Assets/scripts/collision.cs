using UnityEngine;

public class collision : MonoBehaviour{

    public movement pmovement;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "Obstacle")
        {
            pmovement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    public float jumpForce = 5f;
    // Start is called before the first frame update
    void Start(){

    }

    // Update is called once per frame
    void Update(){
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("."))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey(","))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();

        }
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LevelPlayerController : MonoBehaviour
{

    [SerializeField] float speed = 0;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public GameObject LevelBtn;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        LevelBtn.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {

        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;

    }

    void checkEnd()
    {
        if (GameObject.FindGameObjectsWithTag("PickUp").Length == 0)
            LevelBtn.SetActive(true);
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    IEnumerator Fall()
    {

        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);


    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("PickUp"))
        {

            other.gameObject.SetActive(false);
            checkEnd();


        }
        else
             if (other.gameObject.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
                  if (other.gameObject.CompareTag("danger"))
        {
            StartCoroutine("Fall");

        }




    }


}

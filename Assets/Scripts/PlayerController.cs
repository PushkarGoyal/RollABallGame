using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;
using mine;

public class PlayerController : MonoBehaviour
{
    public int level;
    public float speed = 0;
    private Rigidbody rb;
    private int count;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI levelText;
    public GameObject winTextObject;
    private float movementX;
    private float movementY;
    public GameObject SceneBtn;
    private bool Isbool = false;
    private bool touch = false;
    [SerializeField] private FixedJoystick joystick;
    public AudioClip pickMusic;
    public AudioSource PickSource;
    private AudioSource ObstacleSource;






    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
        SceneBtn.SetActive(false);
        levelText.text = "Level " + level;
        PickSource.Stop();
        if (GameObject.Find("ObstacleParent") != null)
            ObstacleSource = GameObject.Find("ObstacleParent").GetComponent<AudioSource>();

        if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            joystick.gameObject.SetActive(false);
        }
        else
             if (Application.platform == RuntimePlatform.Android)
        {
            joystick.gameObject.SetActive(true);
        }

    }

    void OnMove(InputValue movementValue)
    {

        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;

    }



    void PauseGame()
    {


        if (!Isbool)
        {

            Time.timeScale = 0;
            Isbool = true;
        }

        else
        {

            Time.timeScale = 1;
            Isbool = false;
        }


    }

    bool end()
    {
        if ((GameObject.FindGameObjectsWithTag("Success").Length == 0) && (GameObject.FindGameObjectsWithTag("Normal").Length == 0) && (GameObject.FindGameObjectsWithTag("PickUp").Length == 0))
            return true;
        else
            return false;
    }

    void SetCountText()

    {
        PickSource.clip = pickMusic;
        PickSource.Play();
        countText.text = "Score : " + count.ToString();
        if (end())
        {
            winTextObject.SetActive(true);
            SceneBtn.SetActive(true);
            Time.timeScale = 0;


        }
    }

    void checkEnd()
    {
        if (GameObject.FindGameObjectsWithTag("PickUp").Length == 0)
        {
            SceneBtn.SetActive(true);


        }
    }

    void FixedUpdate()
    {



        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        Vector3 movement1 = new Vector3(joystick.Horizontal, 0.0f, joystick.Vertical);
        rb.AddForce(movement * speed);
        rb.AddForce(movement1 * speed);




    }

    IEnumerator Fall()
    {

        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);


    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            PauseGame();
        if (touch)
            JumpTo();
        if (checkFall() && SceneManager.GetActiveScene().buildIndex != 6)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (SceneManager.GetActiveScene().buildIndex == 6 && transform.position.y < -8f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
            BackToMenu();

    }


    void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }


    void JumpTo()
    {
        if (GameObject.FindGameObjectsWithTag("PickUp").Length == 1)
        {

            Vector3 end = GameObject.Find("Destination").transform.position;
            transform.position = Vector3.Slerp(transform.position, end, 10.1f * Time.deltaTime);

        }
    }

    Pick getInstance(string name)
    {
        if (name.Equals("Success"))
            return new Success();
        else
             if (name.Equals("Danger"))
            return new Danger();
        else
            return new Normal();

    }

    bool checkFall()
    {
        if (transform.position.y < -3f)
            return true;
        else
            return false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Last"))
        {

            touch = true;

        }
    }



    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("PickUp"))
        {

            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
            checkEnd();

        }

        else
             if (other.gameObject.CompareTag("Obstacle"))
        {
            if (ObstacleSource != null)
                ObstacleSource.Play();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
                  if (other.gameObject.CompareTag("danger"))
        {
            StartCoroutine("Fall");

        }

        else
        {
            other.gameObject.SetActive(false);
            checkCube obj = new checkCube();
            obj.call(getInstance(other.gameObject.tag));
            if (Pick.score != 0)
            {
                count += Pick.score;
                SetCountText();

            }
            else
            {
                count = Pick.score;
                SetCountText();
            }

        }




    }

}

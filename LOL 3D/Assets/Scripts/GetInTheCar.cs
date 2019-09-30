using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.CharacterController;
using UnityStandardAssets.Vehicles.Car;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GetInTheCar : MonoBehaviour
{
    public GameObject charizard;

    public GameObject shield;
    public float shieldTime;
    private bool isShielded = false;
    public Text timer;
    public Text winnerLoser;
    public Text scoreDisplay;
    private int score;
    private bool hasLost;
    private string timeplayed;
    public float airSpeed;
    public float fallSpeed;


    private void Start()
    {
        shield.SetActive(false);
    }
    private void Update()
    {
        if (!hasLost)
        {
            timeplayed = Time.timeSinceLevelLoad.ToString("00 : 00");
            timer.text = timeplayed;
        }


        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            winnerLoser.text = "";
        }

        if (Input.GetKeyDown(KeyCode.F) && !isShielded)
            StartCoroutine("Shield");

        if (Input.GetKeyUp(KeyCode.A))
            Fire();


        if (!GetComponent<vThirdPersonController>().isGrounded)
        {
            if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.S))
                GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * airSpeed * Time.deltaTime, ForceMode.Impulse);
        }

        if (!GetComponent<vThirdPersonController>().isGrounded)
            if (Input.GetKey(KeyCode.R))
                GetComponent<Rigidbody>().AddRelativeForce(Vector3.down * fallSpeed * Time.deltaTime, ForceMode.Impulse);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !isShielded)
        {
            gameObject.transform.parent = collision.gameObject.transform;
            gameObject.GetComponent<vThirdPersonController>().enabled = false;
            // gameObject.GetComponent<vThirdPersonInput>().enabled = false;
            gameObject.GetComponent<Animator>().enabled = false;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Discrete;
            GameObject.Find("Mesh_LOD").SetActive(false);
            LOLFUCKINGNOOB();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sanic")
        {
            score++;
            scoreDisplay.text = score + "/8";
            if (score == 8)
                Win();
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "DeadZone")
            LOLFUCKINGNOOB();
    }

    private IEnumerator Shield()
    {
        isShielded = true;
        shield.SetActive(true);
        yield return new WaitForSeconds(shieldTime);
        shield.SetActive(false);
        isShielded = false;
    }

    private void Fire()
    {
        GameObject projectile = Instantiate(charizard, gameObject.transform.position, gameObject.transform.rotation);
        projectile.transform.Rotate(90, 0, 0);
    }

    private void LOLFUCKINGNOOB()
    {
        hasLost = true;
        winnerLoser.text = "GIT GUD, NOOBLORD";
    }

    private void Win()
    {
        hasLost = true;
        winnerLoser.text = "What the fuck ?";
    }
}

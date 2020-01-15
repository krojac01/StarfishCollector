using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class TurtleController : MonoBehaviour
{

    // Public Variables
    public float moveSpeed = 1.0f;
    public float turnSpeed = 1.0f;

    public Text starfishText;
    private int starfishTotal;      // Set in the Start method
    //readonly string winnerText = "You Win!";

    public Text winText;
    readonly string starPH = "Starfish Left:";

    

    public AudioClip collectSound;
    public AudioSource audioPlayer;
    public float myVolume = 1.0f;



    // Use this for initialization, Runs Once
    void Start()
    {
        print("Hello World");
        GameObject[] starfishArray; 
         starfishArray = GameObject.FindGameObjectsWithTag("Star");
        starfishTotal = starfishArray.Length;
        starfishText.text = starPH + starfishTotal;

        winText.text = string.Empty;             // Empty when game starts

        audioPlayer = this.GetComponent<AudioSource>();


    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.position =
            this.transform.position +
            this.transform.localRotation * Vector3.forward * moveSpeed;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.localRotation =
            Quaternion.Euler(0, -turnSpeed, 0) *        // Rotates on the Y axis
            this.transform.localRotation;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.localRotation =
            Quaternion.Euler(0, turnSpeed, 0) *         // turnSpeed is positive on R
            this.transform.localRotation;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Star")
        {
            Destroy(col.gameObject);
            starfishTotal -= 1;
            starfishText.text = starPH + starfishTotal;
            if (starfishTotal == 0)
            {
                winText.text = "You Win";
            }
            audioPlayer.PlayOneShot(collectSound, myVolume);


        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    public float jumpForce;
    public float horizontalVelocity;
    private int count;
    public Text countText;
    public Text winText;
    public Text loseText;

    void SetCountText()
    {
        countText.text = " Coin : " + count.ToString();
    }

    void Start()
    {
        if (Physics.gravity.y > 0)
        {
            Physics.gravity *= -1;
        }
        count = 0;
        SetCountText();
        winText.text = "";
        loseText.text = "";
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Physics.gravity *= -1;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            count = count + 10;
            SetCountText();
        }
        if (other.gameObject.CompareTag("Trap"))
        {
            gameObject.SetActive(false);
            count = count;
            SetCountText();
            loseText.text = " YOU LOSE\nPress R to restart";
        }
        if (other.gameObject.CompareTag("End"))
        {
            other.gameObject.SetActive(false);
            count = count;
            SetCountText();
            winText.text = " YOU WIN!\nPress R to restart ";
        }
    }

   void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump"))
            print("horizontalVelocity : " + horizontalVelocity + "; Time.deltaTime : " + Time.deltaTime + " >>x : " + horizontalVelocity * Time.deltaTime);
            this.GetComponent<Rigidbody>().velocity = new Vector3(horizontalVelocity * Time.deltaTime, this.GetComponent<Rigidbody>().velocity.y, this.GetComponent<Rigidbody>().velocity.z);
    }
}
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
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

    void SetCountText()
    {
        countText.text = " Point : " + count.ToString();
    }

    void Start()
    {
        count = 0;
        SetCountText();
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpForce, 0));
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
        }
    }

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump"))
            print("horizontalVelocity : " + horizontalVelocity + "; Time.deltaTime : " + Time.deltaTime + " >>x : " + horizontalVelocity * Time.deltaTime);
            this.GetComponent<Rigidbody>().velocity = new Vector3(horizontalVelocity * Time.deltaTime, this.GetComponent<Rigidbody>().velocity.y, this.GetComponent<Rigidbody>().velocity.z);
    }
}
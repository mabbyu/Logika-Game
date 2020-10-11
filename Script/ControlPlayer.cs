using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class ControlPlayer : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public double count;
    public Text countText;
    public Text winText;
    public Text loseText;

    void SetCountText()
    {
        countText.text = " Point : " + count.ToString();
        if (count >= 32)
        {
            winText.text = " YOU WIN! ";
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        loseText.text = "";
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up Gold"))
        {
            other.gameObject.SetActive(false);
            count = count + 10;
            SetCountText();
        }
        if (other.gameObject.CompareTag("Pick Up Silver"))
        {
            other.gameObject.SetActive(false);
            count = count + 8;
            SetCountText();
        }
        if (other.gameObject.CompareTag("Pick Up Bronze"))
        {
            other.gameObject.SetActive(false);
            count = count + 2;
            SetCountText();
        }
        if (other.gameObject.CompareTag("Pick Up Zonk"))
        {
            gameObject.SetActive(false);
            count = count;
            SetCountText();
            loseText.text = " YOU LOSE! ";
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }
}

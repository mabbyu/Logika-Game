using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class ControlPlayer : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    private double count;
    public Text countText;

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
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

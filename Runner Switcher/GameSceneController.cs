using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneController : MonoBehaviour
{

    public PlayerController player;
    public GameObject[] blockPrefab;
    public Camera gameCamera;
    public Text gameText;
    private float blockPointer = -10;
    private float safeMargin = 20;
    private bool isGameOver;

    void Start()
    {

    }

    void Update()
    {
        while (player != null && blockPointer < player.transform.position.x + safeMargin)
        {
             int blockIndex = Random.Range(0, blockPrefab.Length);
             if (blockPointer < 20)
                 blockIndex = 0;
             GameObject blockObject = GameObject.Instantiate<GameObject>(blockPrefab[blockIndex]);
             blockObject.transform.SetParent(this.transform);
             BlockController block = blockObject.GetComponent<BlockController>();
             blockObject.transform.position = new Vector3(blockPointer + block.size / 2, 0, 0);
             blockPointer += block.size;
        }
        if (player != null)
        {
            gameCamera.transform.position = new Vector3(player.transform.position.x, gameCamera.transform.position.y, gameCamera.transform.position.z);
            gameText.text = " Score : " + Mathf.Floor(player.transform.position.x);
        }
        else
        {
            if(!isGameOver)
            {
                isGameOver = true;
                gameText.text += "\nPress R to restart";
            }
        }
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneController : MonoBehaviour
{

    public PlayerController player;
    public Camera gameCamera;

    void Start()
    {
        
    }

    void Update()
    {
        gameCamera.transform.position = new Vector3(player.transform.position.x, gameCamera.transform.position.y, gameCamera.transform.position.z);
    }
}

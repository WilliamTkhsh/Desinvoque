using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winGame : MonoBehaviour
{

    void Start()
    {
        // Disable Enemy
        GameObject.Find("Enemy").SetActive(false);
    }

}

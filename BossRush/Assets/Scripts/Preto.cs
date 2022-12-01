using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preto : MonoBehaviour
{
    public static SpriteRenderer sp;
    [SerializeField] private GameObject red;
    PlayerMovement script;
    [SerializeField] private GameObject lose;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        sp = red.GetComponent<SpriteRenderer>();
        script = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(script.gameLost);
        if (script.gameLost)
        {
            red.SetActive(true);
            Clareia();
            //Debug.Log(sp.color);
        }
    }
    void Clareia()
    {
        if (sp.color == new Color(0f,0f,0f,1f))
        {
            lose.SetActive(true);
        } else
        {
            sp.color -= new Color(0.01f, 0, 0, 0);
        }
        
    }
    void Escurece()
    {
        sp.color += new Color(0, 0, 0, 0.02f);
    }
}

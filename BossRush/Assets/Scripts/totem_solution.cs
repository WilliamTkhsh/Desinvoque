using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class totem_solution : MonoBehaviour
{
    public int total_totems = 12;
    [SerializeField] private GameObject win;
    public int current_active = 1;
    private bool solved = false;

    private void FixedUpdate()
    {
        if (!solved && current_active == total_totems + 1)
        {
            totemSolved();
        }
    }

    public void enemySpeedup()
    {
        
    }

    public bool activateNextTotem(int id)
    {
        if (id <= current_active)
        {
            current_active += 1;
            return true;
        }
        return false;
    }

    private void totemSolved()
    {
        Debug.Log("Totens solucionados, fim do jogo");
        solved = true;
        win.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class totem : MonoBehaviour
{
    public int totem_id = 1;
    [SerializeField] private totem_solution solution;
    private bool closeEnough = false;

    private void FixedUpdate() {
        //Checar acionamento
        if (closeEnough && Input.GetKeyDown(KeyCode.E)) 
        {
            bool totem_active = solution.activateNextTotem(totem_id);
            if(totem_active){
                Debug.Log("Totem Ativo com Sucesso");
            }
            else{
                Debug.Log("Totem não pode ser ativado");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") closeEnough = true;
        else closeEnough = false;
        return;
    }

    private void OnCollisionExit2D(Collision2D collision) {
        closeEnough = false;
        return;
    }
}

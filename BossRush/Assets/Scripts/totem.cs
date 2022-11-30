using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class totem : MonoBehaviour
{
    public int totem_id = 1;
    public Sprite totemAction;
    public AudioClip totemSuccessAudio, totemFailAudio, monsterCry;
    [SerializeField] private totem_solution solution;
    public float repellDistance = 10.0f;
    private bool active = false;
    private bool closeEnough = false;
    private AudioSource audioSource;

    private void Start() {
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    private void FixedUpdate() {
        //Checar acionamento
        if (!active && closeEnough && Input.GetKeyDown(KeyCode.E)) 
        {
            bool totem_active = solution.activateNextTotem(totem_id);
            if(totem_active){
                Debug.Log("Totem Ativo com Sucesso");
                this.gameObject.GetComponent<SpriteRenderer>().sprite = totemAction;
                audioSource.clip = totemSuccessAudio;
                active = true;
                repellEnemy();
            }
            else{
                Debug.Log("Totem não pode ser ativado");
                audioSource.clip = totemFailAudio;
            }

            audioSource.Play();
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

    private void repellEnemy() {
        GameObject _enemy = GameObject.Find("Enemy");
        Vector3 enemyPos = _enemy.GetComponent<Transform>().transform.position;
        Vector3 totemPos = this.gameObject.GetComponent<Transform>().transform.position;
        // Teleport Monster
        _enemy.GetComponent<Transform>().transform.position = Vector3.MoveTowards(enemyPos, totemPos, -repellDistance);
        // Monster Cry
        _enemy.GetComponent<AudioSource>().clip = monsterCry;
        _enemy.GetComponent<AudioSource>().Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
    public GameObject shell2Prefab;
    private Transform fireposition2;
    public TankMovement tank;

    public float shellSpeed = 60;
    public float ShotDelay = 1f;

    public AudioClip ShotAudio;
    private AudioSource fireAudio;

    protected bool idle = true;
    protected int cooldown = 75;
    protected int timer = 0;
    protected int shotCount = 0;
    
    void Start () {
        fireposition2 = transform.Find("FirePosition");
    }

    void FixedUpdate() {
        fireAudio = this.GetComponent<AudioSource>();
        if (tank != null){
            if (transform.position.z - tank.transform.position.z <= 75f && transform.position.z - tank.transform.position.z > -50f){
                idle = false;
            } else{
                idle = true;
            }
            if(timer == 0 && !idle){
                fireAudio.volume = 0.8f;
                fireAudio.Play();
                AudioSource.PlayClipAtPoint(ShotAudio, transform.position);
                GameObject go2 = GameObject.Instantiate(shell2Prefab, fireposition2.position, fireposition2.rotation) as GameObject;
                go2.GetComponent<Rigidbody>().velocity = go2.transform.forward * shellSpeed;
                timer = cooldown;
            }
        }

        if(timer > 0f) {
            timer -= 1;
        } 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAttack : MonoBehaviour {
    public GameObject shellPrefab;
    private Transform fireposition;
    public float shellSpeed = 75;
    public KeyCode firekey = KeyCode.Space;

    public AudioClip ShotAudio;
    private AudioSource fireAudio;
    public AudioClip ReloadAudio;
    private AudioSource reloading;

    protected int cooldown = 130;
    protected int timer = 0;
	
	void Start () {
        fireposition = transform.Find("FirePosition");
	}
	
	void Update () {
        fireAudio = this.GetComponent<AudioSource>();
        reloading = this.GetComponent<AudioSource>();
        if (Input.GetKeyDown(firekey) && timer == 0)
        {
            fireAudio.volume = 1.0f;
            fireAudio.Play();
            AudioSource.PlayClipAtPoint(ShotAudio, transform.position);
            GameObject go = GameObject.Instantiate(shellPrefab, fireposition.position, fireposition.rotation) as GameObject;
            go.GetComponent<Rigidbody>().velocity = go.transform.forward * shellSpeed;
            timer = cooldown;
            reloading.volume = 1f;
            reloading.Play();
            AudioSource.PlayClipAtPoint(ReloadAudio, transform.position);
        }
	}

    void FixedUpdate() {
        if(timer > 0f) {
            timer -= 1;
        }
    }
}

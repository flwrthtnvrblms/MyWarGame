using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellEnemy : MonoBehaviour {

    public GameObject shellExplosionPrefab;
    public AudioClip shellExplosionAudio;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag != "Enemy"){
            if (collider.tag == "Tank")
            {
                collider.SendMessage("TakeDamage");
            }

            AudioSource.PlayClipAtPoint(shellExplosionAudio, transform.position);
            GameObject.Instantiate(shellExplosionPrefab, transform.position, transform.rotation);
            GameObject.Destroy(this.gameObject);  
        }
    }
}

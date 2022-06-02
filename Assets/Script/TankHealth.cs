using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHealth : MonoBehaviour {

    public float damage = 0f;
    public float hp = 1f;

    public HealthBar Health;

    public GameObject tankExplosion;
    public AudioClip tankExplosionAudio;

    float Add_Damage(){
        damage += 0.2f;
        Invoke("Reduce_Damage", 1);
        return damage;
    }

    float Reduce_Damage(){
        damage -= 0.2f;
        return damage;
    }

    void TakeDamage(){
        if (hp <= 0) return;
        damage = Add_Damage();
        hp = hp - damage;
        Health.SetHealthBarValue(hp);
        if (hp < 0.1)
        {
            AudioSource.PlayClipAtPoint(tankExplosionAudio, transform.position);
            GameObject.Instantiate(tankExplosion, transform.position + Vector3.up, transform.rotation);
            GameObject.Destroy(this.gameObject);
        }
    }

    void Сrashed(){
        hp = 0;
        Health.SetHealthBarValue(hp);
        if (hp == 0)
        {
            AudioSource.PlayClipAtPoint(tankExplosionAudio, transform.position);
            GameObject.Instantiate(tankExplosion, transform.position + Vector3.up, transform.rotation);
            GameObject.Destroy(this.gameObject);
        }
    }

    void DestroyEnemy(){
        AudioSource.PlayClipAtPoint(tankExplosionAudio, transform.position);
        GameObject.Instantiate(tankExplosion, transform.position + Vector3.up, transform.rotation);
        GameObject.Destroy(this.gameObject);
    }
}

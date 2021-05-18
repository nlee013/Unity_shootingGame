using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public float attackAmount = 20.0f;
    public AudioClip swordClip;
    AudioSource swordAudio;

    // Start is called before the first frame update
    void Start()
    {
        swordAudio = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Monster")
        {
            BulletSpawner bulletmonster = other.GetComponent<BulletSpawner>();

            if(bulletmonster != null)
            {
                bulletmonster.GetDamage(attackAmount);
            }

            swordAudio.PlayOneShot(swordClip);
        }
        else if(other.tag == "Monster2")
        {
            MonsterCtrl alien = other.GetComponent<MonsterCtrl>();
            
            if(alien != null)
            {
                alien.GetDamage(attackAmount);
            }

            swordAudio.PlayOneShot(swordClip);
        }
    }
}

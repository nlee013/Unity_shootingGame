using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class SimpleShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;
    public Transform barrelLocation;
    public Transform casingExitlocation;

    public float shotPower = 100f;

    public bool isGrab = false;

    public AudioClip fireClip;
    AudioSource fireAudio;

    public HandState currentGrab;

    // Start is called before the first frame update
    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;

        fireAudio = GetComponent<AudioSource>()
;    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonDown("Fire1"))
        //{
        //    GetComponent<Animator>().SetTrigger("Fire");
        //}
    }

    public void grabGun()
    {
        isGrab = true;
    }

    public void dropGun()
    {
        isGrab = false;
    }
    public void Shoot()
    {
        if (isGrab == true)
        {
            GameObject tempFlash;
            Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
            tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

            fireAudio.PlayOneShot(fireClip);
        }
    }
    void CasingRelease()
    {
        GameObject casing;
        casing = Instantiate(casingPrefab, casingExitlocation.position, casingExitlocation.rotation) as GameObject;
        casing.GetComponent<Rigidbody>().AddExplosionForce(550f, (casingExitlocation.position - casingExitlocation.right * 0.3f - casingExitlocation.up * 0.6f), 1f);
        casing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(10f, 1000f)), ForceMode.Impulse);
    }

    public void SetGraspState(HandState state)
    {
        currentGrab = state;
    }

    public void SetGraspNONE()
    {
       
        if (!GetComponent<XRGrabInteractable>().isSelected)
            currentGrab = HandState.NONE;
    }

    public void SetGraspLEFT()
    {
        currentGrab = HandState.LEFT;
    }

    public void SetGraspRIGHT()
    {
        currentGrab = HandState.RIGHT;
    }
}

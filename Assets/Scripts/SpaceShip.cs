using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpaceShip : MonoBehaviour
{
    public AudioClip sonido;
    [SerializeField] private Text scoreboardText;
    [SerializeField] private float velocidad = 15;
    public GameObject shot;
    Vector2 shotPos;
    public float fireRate = 0.5f;
    float nextFire = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        transform.Translate(horizontal * velocidad * Time.deltaTime, 0, 0);
        
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            fire();
            GetComponent<AudioSource>().Play();
        }

    }
    void fire()
    {
        shotPos = transform.position;
        shotPos += new Vector2(0f, 0.40f);
        Instantiate(shot, shotPos, Quaternion.identity);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        scoreboardText.text = "Hit!";
    }
}

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
    public float fireRate = 0.5f;
    [SerializeField] private Transform prefabShot;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        transform.Translate(horizontal * velocidad * Time.deltaTime, 0, 0);
        
        if (Input.GetButtonDown("Fire1"))
        {

            Instantiate(prefabShot, transform.position, Quaternion.identity);

            GetComponent<AudioSource>().Play();
        }

    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        scoreboardText.text = "Hit!";
    }
}

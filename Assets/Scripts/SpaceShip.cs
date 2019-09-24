using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
public class SpaceShip : MonoBehaviour
{
    public AudioClip sonido;
    [SerializeField] private Text scoreboardText;
    [SerializeField] private float velocidad = 30;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if ((transform.position.x >= -5) && (transform.position.x <= 5))
        {
            transform.Translate(horizontal * velocidad * Time.deltaTime, 0, 0);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            GetComponent<AudioSource>().Play();
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        scoreboardText.text = "Hit!";
    }
}

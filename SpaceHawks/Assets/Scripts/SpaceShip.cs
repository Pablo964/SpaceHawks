using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    [SerializeField]private float velocidad = 30;
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if ((transform.position.x >= -5) && (transform.position.x <= 5))
        {
            transform.Translate(horizontal * velocidad * Time.deltaTime, 0, 0);
        }
    }
}

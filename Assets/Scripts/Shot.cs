using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{

    [SerializeField] private float shotSpeed = 20000;
    [SerializeField] private Transform prefabExplosion;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity =
                new Vector2(0, shotSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.y > 5)
        {
            Destroy(gameObject);

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            Instantiate(
                prefabExplosion, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(prefabExplosion.gameObject, 1f);
            Destroy(gameObject);
        }
    }
}

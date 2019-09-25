using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    private float velY = 5f;
    private float velX = 0f;
    Rigidbody2D rb;
    [SerializeField] private float shotSpeed = 8000;
    [SerializeField] private Transform prefabExplosion;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity =
                new Vector3(0, shotSpeed*Time.deltaTime, 0);
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

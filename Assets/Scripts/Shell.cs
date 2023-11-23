using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    private TankData td;
    public GameObject fxFactory;
    // Start is called before the first frame update
    private void Awake()
    {
        td = GameObject.Find("Tank").GetComponent<TankData>();
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject fx = Instantiate(fxFactory);
        fx.transform.position = transform.position;
        Destroy(gameObject);
        if (collision.collider.tag == "Enemy")
        {
            Chicken chicken = collision.collider.GetComponent<Chicken>();
            chicken.GetDamage(td.damage);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMove : MonoBehaviour
{
    private TankData td;
    Rigidbody rigid;
    [SerializeField]
    private float rotateSpeed;
    private float saveTime;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>(); 
        td = GetComponent<TankData>();
    }
    private void Start()
    {
        
    }

    void Update()
    {
       
    }
    void Move()
    {
        float input = Input.GetAxis("Vertical");
        Vector3 moveDistance = input * transform.forward * td.speed * Time.deltaTime;

        rigid.MovePosition(rigid.position + moveDistance);

    }
    void Rotate()
    {
        float input = Input.GetAxis("Horizontal");

        float turn = input * rotateSpeed * Time.deltaTime;

        rigid.rotation = rigid.rotation * Quaternion.Euler(0f, turn, 0f);
    }
    void FixedUpdate()
    {
        Move();
        Rotate();
    }
}

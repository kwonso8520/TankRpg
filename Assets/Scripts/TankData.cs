using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankData : MonoBehaviour
{
    public float tankHp;
    public float range;
    public float damage;
    public float speed;
    public float exp;
    public float maxExp;
    public int level = 1;
    // Start is called before the first frame update
    void Start()
    {
        maxExp = 500;
        level = 1;
        tankHp = 100f;
        range = 20f;
        damage = 5f;
        speed = 5f;
    }
}

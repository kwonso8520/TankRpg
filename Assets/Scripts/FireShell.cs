using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShell : MonoBehaviour
{
    private TankData td;
    [SerializeField]
    private GameObject shellPrefab;
    [SerializeField]
    private Transform muzzlePos;
    // Start is called before the first frame update
    void Start()
    { 
        td = GetComponent<TankData>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject shell = Instantiate(shellPrefab);
            shell.transform.position = muzzlePos.position;
            Rigidbody shellRigid = shell.GetComponent<Rigidbody>();
            shellRigid.AddForce(muzzlePos.transform.forward * td.range, ForceMode.Impulse);
        }
    }
}

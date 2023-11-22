using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    TankData td;
    RaycastHit hit;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private float enemySpeed;
    private bool isMoving;
    private bool isAction;
    [SerializeField]
    private float moveTime;
    [SerializeField]
    private float waitTime;
    private float currentTime;
    private Vector3 direction;
    public LayerMask construct;
    private float enemyHp;
    public float expValue = 50f;
    private UiManager uiManager;

    private void Start()
    {
        uiManager = GameObject.Find("UiManager").GetComponent<UiManager>();    
        td = GameObject.Find("Tank").GetComponent<TankData>();
        if (!PlayerPrefs.HasKey("exp"))
        {
            PlayerPrefs.SetFloat("exp", td.exp);
        }
        else
        {
            td.exp = PlayerPrefs.GetFloat("exp");
        }
        uiManager.expTxt.text = string.Format("{0} / {1}", td.exp, td.maxExp);
        enemyHp = 20;
        currentTime = waitTime;
        isAction = true;
    }
    private void Update()
    {
        if (enemyHp <= 0)
        {
            Die();
        }
        Move();
        ElapsedTime();
        checkFrontWall();
    }
    private void Move()
    {
        if (isMoving)
        {
            transform.position += transform.forward * enemySpeed * Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(direction), Time.deltaTime * 5);
        }
    }
    private void ElapsedTime()
    {
        if (isAction)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                ResetMove();
            }
        }
    }
    private void checkFrontWall()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, distance, construct))
        {
            transform.forward = transform.forward * -1;
            Move();
        }
    }
    private void ResetMove()
    {
        isMoving = false;
        isAction = true;
        direction.Set(0f, Random.Range(0f, 360f), 0f);
        RandomAction();
    }
    private void RandomAction()
    {

        int _random = Random.Range(0, 2);

        if (_random == 0)
        {
            Wait();
        }
        else
        {
            TryMove();
        }

    }
    private void Wait()
    {
        currentTime = waitTime;
    }
    private void TryMove()
    {
        isMoving = true;
        currentTime = moveTime;
    }
    private void Die()
    {
        td.exp += expValue;
        PlayerPrefs.SetFloat("exp", td.exp);
        uiManager.expTxt.text = string.Format("{0} / {1}", td.exp, td.maxExp);
        Destroy(gameObject);
    }
    public void GetDamage(float damage)
    {
        enemyHp -= damage;
    }
}
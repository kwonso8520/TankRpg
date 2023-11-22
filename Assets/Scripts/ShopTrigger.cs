using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject shopPanel;
    public bool isShowing = false;
    [SerializeField]
    private UiManager uiManager;
    TankData td;
    public Text skillText;
    // Start is called before the first frame update
    void Start()
    {
        td = GameObject.Find("Tank").GetComponent<TankData>();
        skillText.text = string.Format("SkillPoint : {0}", uiManager.skillPoint);
        if (!PlayerPrefs.HasKey("speed"))
        {
            PlayerPrefs.SetFloat("speed", td.speed);
        }
        else
        {
            td.speed = PlayerPrefs.GetFloat("speed");
        }
        if (!PlayerPrefs.HasKey("damage"))
        {
            PlayerPrefs.SetFloat("damage", td.damage);
        }
        else 
        {
            td.damage = PlayerPrefs.GetFloat("damage");
        }
        if ((!PlayerPrefs.HasKey("range")))
        {
            PlayerPrefs.SetFloat("range", td.range);
        }
        else
        {
            td.range = PlayerPrefs.GetFloat("range");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            ExitShop();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ShowShop();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            ExitShop();
        }
    }
    private void ShowShop()
    {
        skillText.text = string.Format("SkillPoint : {0}", uiManager.skillPoint);
        isShowing = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        shopPanel.SetActive(true);
    }
    private void ExitShop()
    {
        isShowing = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        shopPanel.SetActive(false);
        PlayerPrefs.SetFloat("speed", td.speed);
        PlayerPrefs.SetFloat("damage", td.damage);
        PlayerPrefs.SetFloat("range", td.range);
    }
}

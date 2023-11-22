using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Slider expbar;
    public Text expTxt;
    TankData td;
    public Text levelTxt;
    [SerializeField]
    Camera camera;
    public Transform lvPos;
    public int skillPoint = 3;
    // Start is called before the first frame update
    void Start()
    {
        td = GameObject.Find("Tank").GetComponent<TankData>();
        expTxt.text = string.Format("{0} / {1}", td.exp, td.maxExp);
        if (!PlayerPrefs.HasKey("maxExp"))
        {
            PlayerPrefs.SetFloat("maxExp", td.maxExp);
        }
        else
        {
            td.maxExp = PlayerPrefs.GetFloat("maxExp");
        }
        if (!PlayerPrefs.HasKey("level"))
        {
            PlayerPrefs.SetInt("level", td.level);
        }
        else
        {
            td.level = PlayerPrefs.GetInt("level");
            levelTxt.text = PlayerPrefs.GetInt("level").ToString();
        }
        if (!PlayerPrefs.HasKey("skillPoint"))
        {
            PlayerPrefs.GetInt("skillPoint", skillPoint);
        }
        else
        {
            skillPoint = PlayerPrefs.GetInt("skillPoint");
        }
        expbar.maxValue = td.maxExp;
    }

    // Update is called once per frame
    void Update()
    {
        levelTxt.transform.position = camera.WorldToScreenPoint(lvPos.position + new Vector3(0, 0, 0));
        SetExp();
        SetLevel();
        if (expbar.value >= expbar.maxValue)
        {
            skillPoint++;
            td.level++;
            td.maxExp *= td.level;
            expbar.maxValue = td.maxExp;
            td.exp = 0;
            expTxt.text = string.Format("{0} / {1}", td.exp, td.maxExp);
            PlayerPrefs.SetFloat("maxExp", td.maxExp);
            PlayerPrefs.SetInt("level", td.level);
            PlayerPrefs.SetInt("skillPoint", skillPoint);
        }
    }
  
    private void SetExp()
    {
        expbar.value = td.exp;
    }
    private void SetLevel()
    {
        levelTxt.text = string.Format("Lv : {0}", td.level);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateManager : MonoBehaviour
{
    [SerializeField]
    UiManager uiManager;
    [SerializeField]
    TankData td;
    public Text skillText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DamageUpdate()
    {
        if(uiManager.skillPoint > 0)
        {
            uiManager.skillPoint--;
            td.damage += 20;
            skillText.text = string.Format("SkillPoint : {0}", uiManager.skillPoint);
            PlayerPrefs.SetInt("skillPoint", uiManager.skillPoint);
        }
    }
    public void SpeedUpdate()
    {
        if (uiManager.skillPoint > 0)
        {
            uiManager.skillPoint--;
            td.speed += 1.5f;
            skillText.text = string.Format("SkillPoint : {0}", uiManager.skillPoint);
            PlayerPrefs.SetInt("skillPoint", uiManager.skillPoint);
        }
    }
    public void RangeUpdate()
    {
        if (uiManager.skillPoint > 0)
        {
            uiManager.skillPoint--;
            td.range += 10f;
            skillText.text = string.Format("SkillPoint : {0}", uiManager.skillPoint);
            PlayerPrefs.SetInt("skillPoint", uiManager.skillPoint);
        }
    }
}
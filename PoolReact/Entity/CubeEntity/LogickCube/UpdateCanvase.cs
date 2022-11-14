using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UpdateCanvase : MonoBehaviour
{
    [SerializeField] 
    private Image _healBar;
    private float _multiplierHp;
    
    [SerializeField] 
    private Text _CountKill;

    public void MaxHeal(float maxHeal)
    {
        _multiplierHp = 1f / maxHeal;
        _healBar.fillAmount = 1;
    }
   
    public void UpdateHealBar(float heal)
    {
        _healBar.fillAmount = _multiplierHp * heal;
    }
    
    public void UpdateCountCill(int count)
    {
        _CountKill.text = count.ToString();
    }

}

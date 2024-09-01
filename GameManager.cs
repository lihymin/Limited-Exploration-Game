using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Slider weaponSlider;
    public Slider expSlider;
    public Text expText;
    public GameObject enemy;
    public GameObject player;
    Enemy enemyLogic;
    public int playerExp;

    void Awake()
    {
        enemyLogic = enemy.GetComponent<Enemy>();
    }
    public void isAttack()
    {
        Player playerLogic = player.GetComponent<Player>();
        float fillPerFrame = playerLogic.attackResetTime / 20;
        weaponSlider.value += fillPerFrame;
        if (weaponSlider.value >= 1) {
            weaponSlider.value = 0;
        }

        else if (weaponSlider.value < 1) {
            Invoke("isAttack", fillPerFrame);
        }
    }

    public void ExpUp()
    {
        float totalExp = enemyLogic.curExp / playerExp;
        expSlider.value = totalExp;
    }
}

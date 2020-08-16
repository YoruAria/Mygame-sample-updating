using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Value : MonoBehaviour
{
    public int money; //金钱
    public int health; //生命
    public int damage; //伤害
    public int defend; //防御
    public int bag; //库存
    public int talk; //话术
    public int luck; //幸运
    public int fake; //欺骗
    public int reliability; //诚信
    public int vigilant; //警惕
    public int prestige; //声望
    public int gameTime; //游戏时间
    public int round; //回合
    void Start()
    {
        money = 20;
        health = 100;
    }
    void OnGUI()
    {
        GUILayout.TextField(money.ToString());
        GUILayout.TextField(health.ToString());
    }
}

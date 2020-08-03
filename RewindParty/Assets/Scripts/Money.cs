using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    private long money;

    [SerializeField] private GameObject loseMoneyGameObject;

    private Text text;
    private void Start()
    {
        text = GetComponent<Text>();
    }

    public void AddMoney(int moneyToAdd)
    {
        money += moneyToAdd;

        UpdateText();
    }

    public void LoseMoney(int moneyToLose)
    {
        moneyToLose -= moneyToLose;

        UpdateText();

        loseMoneyGameObject = Instantiate(loseMoneyGameObject, transform.parent);

        loseMoneyGameObject.GetComponent<Text>().text = "-" + moneyToLose + "$";
    }
    
    public long GetMoney()
    {
        return money;
    }

    private void UpdateText()
    {
        text.text = money.ToString() + "$";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FuelTank : MonoBehaviour
{
    [SerializeField][Min(0)] private float initFuel = 200;
    [SerializeField][Min(0)] private float expenseInSecond = 1f;

    public int CurentFuel => (int)curentFuel;

    public UnityEvent OnFuelRanOut;

    private float curentFuel;
    private bool isExpense = false;
    private float expenseInFixed;

    public void AddFuel(int fuel)
    {
        curentFuel += fuel;
    }

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        curentFuel = initFuel;
        isExpense = true;
        expenseInFixed = expenseInSecond * Time.fixedDeltaTime;
    }

    private void FixedUpdate()
    {
        if (isExpense)
        {
            curentFuel -= expenseInFixed;
            print(curentFuel);
            if (curentFuel <= 0)
            {
                OnFuelRanOut?.Invoke();
                isExpense = false;
            }
        }
    }
}

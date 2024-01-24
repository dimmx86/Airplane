using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ViewFuelTank : MonoBehaviour
{
    [SerializeField] private FuelTank fuelTank;
    [SerializeField] private TMPro.TMP_Text text;

    private int curentFuel;

    private void FixedUpdate()
    {
        if (fuelTank.CurentFuel != curentFuel)
        {
            curentFuel = fuelTank.CurentFuel;
            text.text = curentFuel.ToString();
        }
    }
}

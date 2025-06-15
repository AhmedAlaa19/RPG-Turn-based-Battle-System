using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class MakeButton : MonoBehaviour
{
public static UnityEvent melee = new UnityEvent();
    public static UnityEvent ranged = new UnityEvent();
    public static UnityEvent heal = new UnityEvent();

    void Awake()
    {
        Button button = GetComponent<Button>();
        string buttonName = gameObject.name;

        button.onClick.AddListener(() => 
        {
            if(buttonName == "MeleeBtn") melee.Invoke();
            else if(buttonName == "RangedBtn") ranged.Invoke();
            else heal.Invoke();
        });
    }
     
}


 
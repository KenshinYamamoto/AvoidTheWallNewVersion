using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleController : MonoBehaviour
{
    [SerializeField] Toggle toggle;

    [SerializeField] Text text;

    public void Push()
    {
        text.text = toggle.isOn ? "ON" : "OFF";
    }
}

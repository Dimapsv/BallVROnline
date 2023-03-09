using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Test : MonoBehaviour
{
    [SerializeField] private Button button;
    public Button button1;
    public Text text;

    public void TestText()
    {
        text.text = "Hello World";
    }
}

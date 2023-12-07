using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour
{
    public GameObject gameObject;
    // Start is called before the first frame update
    void Start()
    {
        //this.GetComponent<Image>().color = new Color(255, 255, 255, 255);
        //this.GetComponent<Image>().color = gameObject.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Image>().color = gameObject.GetComponent<Image>().color;
    }
}

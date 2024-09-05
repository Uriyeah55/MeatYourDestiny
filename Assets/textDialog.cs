using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class textDialog : MonoBehaviour
{
        public TMP_Text textdialog;
    public GameObject enemy,manager;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    textdialog.text="Dialeg: " + manager.GetComponent<DialogSetUp>().dialogState.ToString();
    }
}

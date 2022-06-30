using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RUSNButtonSwitch : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    IInteractable interactable;
    private float x;
    private float z;
    private bool rotateX;

    void Start()
    {
        x = -52.0f;

        rotateX = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
    DB dB = new DB();
    
    public void Interact()
    {
        string objectName = gameObject.name;
        
        if (rotateX == true)
        {
            x += 90;
            Debug.Log("RUSN interact off");
            Toggle toggle1 = Interact().gameObject.GetComponent<Toggle1>();
            Toggle toggle2 = Interact().gameObject.GetComponent<Toggle2>();
            var datatime = DateTime.Now;
            if (objectName == "RUSNButton4")
            {
                string[] values = new string[] { 1, 1, 3, 4, "CS", DateTime.Now, "Выбрать " + objectName};
                dB.InsertValues("'Фактические действия'", values);
                string[] values = new string[] {1, 1, 4, null, "CI", DateTime.Now, "Отключить " + objectName};
                dB.InsertValues("'Фактические действия'", values);
                toggle1.isOn = true;
            }
                
            else if (objectName == "RUSNButton5")
            {
                string[] values = new string[] { 1, 1, 3, 5, "CS", DateTime.Now, "Выбрать " + objectName};
                dB.InsertValues("'Фактические действия'", values);
                string[] values = new string[] {1, 1, 5, null, "CI", DateTime.Now, "Отключить " + objectName};
                dB.InsertValues("'Фактические действия'", values);
                toggle2.isOn = true;
                
            }
            else
            {
                string[] values = new string[] { 1, 1, 3, null, "CS", DateTime.Now, "Выбрать " + objectName};
                dB.InsertValues("'Фактические действия'", values);
                string[] values = new string[] {1, 1, null, null, "CI", DateTime.Now, "Отключить " + objectName};
                dB.InsertValues("'Фактические действия'", values);
            
            }
                
           
            if (x > 38.0f)
            {
                x = -52.0f;
                Debug.Log("RUSN interact on");
                if (objectName == "RUSNButton4")
                {
                    string[] values = new string[] { 1, 1, 3, 4, "CS", DateTime.Now, "Выбрать " + objectName};
                    dB.InsertValues("'Фактические действия'", values);
                    string[] values = new string[] {1, 1, 4, null, "CI", DateTime.Now, "Включить" + objectName};
                    dB.InsertValues("'Фактические действия'", values);
          
                }
                else if (objectName == "RUSNButton5")
                {
                    string[] values = new string[] { 1, 1, 3, 5, "CS", DateTime.Now, "Выбрать " + objectName};
                    dB.InsertValues("'Фактические действия'", values);
                    string[] values = new string[] {1, 1, 5, null, "CI", DateTime.Now, "Включить" + objectName};
                    dB.InsertValues("'Фактические действия'", values);
                    
                }
                else
                {
                    string[] values = new string[] { 1, 1, 3, null, "CS", DateTime.Now, "Выбрать " + objectName};
                    dB.InsertValues("'Фактические действия'", values);
                    string[] values = new string[] {1, 1, null, null, "CI", DateTime.Now, "Включить" + objectName};
                    dB.InsertValues("'Фактические действия'", values);

                }
                

            }
            HighLight();
            transform.localRotation = Quaternion.Euler(x, 0, 0);
        }
    }
    public void GetMessage()
    {
        string objectName = gameObject.name;
        Text message = objectName.GetComponent<Text>();
        if (Interact().objectName == "RUSNButton4")
        {
            message.Clear();
        }
        else if (Interact().objectName == "RUSNButton5")
        {
            message.Clear();
        }
        else
        {
            
            if (GetCheckList().toggle1.isOn && GetCheckList().toggle2.isOn)
            {
                message.text = "Действие выполнено не верно, завершите работу в комнате РУСН";
            }
            else if (GetCheckList().toggle1.isOn && GetCheckList().toggle2.isOn == false)
            {
                message.text = "Действие выполнено не верно, переведите переключатель 1АВ12 в отключенное положение";
            }
            else if (GetCheckList().toggle1.isOn == false)
            {
                message.text = "Действие выполнено не верно, переведите переключатель 1АВ6 в отключенное положение";
            }

        }
    }
    public void GetCheckList()
    {
        string objectName = gameObject.name;
        
        if (rotateX == true)
        {
            x += 90;
            Debug.Log("RUSN interact off");
            Toggle toggle1 = objectName.GetComponent<Toggle1>();
            Toggle toggle2 = objectName.GetComponent<Toggle2>();
            var datatime = DateTime.Now;
            if (objectName == "RUSNButton4")
            {
                
                toggle1.isOn = true;
            }
                
            else if (objectName == "RUSNButton5")
            {
                
                toggle2.isOn = true;
                
            }
        }
        
    }
    public void HighLight()
    {
        outline = GetComponent<Outline>();

        void OnMouseEnter()
        {
            if (gameObject.Name == "RUSNButton4")
            {
                outline.outlioneWidth = 5;
                outline.outlineColor = "Green";
            }
            else if (gameObject.Name == "RUSNButton5" )
            {
                outline.outlioneWidth = 5;
                outline.outlineColor = "Green";
            }
            else
            {
                outline.outlioneWidth = 5;
                outline.outlineColor = "Red";
            }

        }

        void OnMouseExit()
        {
            outline.outlineWidth = 0;
        }

    }

        

}

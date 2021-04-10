using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuUI : MonoBehaviour
{
    [SerializeField] private Button _button = null;
    [SerializeField] private GameObject _holder = null;
    public void OnButtonPress()
    {
        _holder.SetActive(true);
        this.transform.parent.gameObject.SetActive(false);
        Debug.Log("SNCF");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Updates : MonoBehaviour
{
    public void OnClickUpdates()
    {
        GameObject.Find("Main Camera/Console/Canvas/Roll/UpdateField").SetActive(true);

    }
    public void OnClickCmd()
    {
        GameObject.Find("Main Camera/Console/Canvas/Roll/UpdateField").SetActive(false);
    }

}

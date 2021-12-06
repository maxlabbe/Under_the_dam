using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpamController : MonoBehaviour
{
    public static TileSpamController instance { get; private set; }
    public Tile tmpReference;
    private void Awake()
    {
        instance = this;
    }

    //Call this method with OnClick() event of action confirmation button
    public void DisableActionAccept()
    {
        tmpReference.acceptAction = false;
        tmpReference.UpdateColorBalance();
    }
    
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    #region Properties
    public event Action OnKeyDamage;
    public event Action OnKeyHeal;
    public event Action OnKeyPoints;
    public event Action OnKeyAddLevel;
    #endregion

    #region Fields
    #endregion

    #region Unity Callbacks
    // Start is called before the first frame update
    void Start()
    {
        OnKeyDamage?.Invoke();
        OnKeyHeal?.Invoke();
        OnKeyPoints?.Invoke();
        OnKeyAddLevel?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {

    }
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    #endregion

}


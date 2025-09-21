using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolo : MonoBehaviour
{
#region Properties
#endregion

#region Fields
#endregion
 
#region Unity Callbacks
// Start is called before the first frame update
void Start()
{
       
}

// Update is called once per frame
void Update()
{
        
}
#endregion
 
#region Public Methods
    //Detectar si "ball" ha colisionado con "bolo"
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Debug.Log("Has dado al bolo!!");
            Destroy(gameObject);
        }
    }
    #endregion

    #region Private Methods
    #endregion
}


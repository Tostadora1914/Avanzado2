using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
#region Properties
//Lista para almacenar cubos
public List<GameObject> Inventory =  new List<GameObject>();
[NonSerialized] private int _itemsInInventory = 0;

#endregion 

#region Fields
[SerializeField] private GameObject _collectableItem;
[SerializeField] private GameObject _spawner;
#endregion
 
#region Unity Callbacks
// Start is called before the first frame update
void Start()
{
        //Inicialización de la Corrutina
        float repeatRate = UnityEngine.Random.Range(1f, 3f);
        StartCoroutine(Drop(repeatRate));
}

    //Corrutina
IEnumerator Drop(float waitTime)
{
    while(true)
    {
        yield return new WaitForSeconds(waitTime);
        Instantiate();
    }
}

// Update is called once per frame
void Update()
{
        DetectObject();
        IntroduceToList();    
}
#endregion
 
#region Public Methods
#endregion

#region Private Methods

    private void Instantiate()
    {
        Instantiate(_collectableItem, _spawner.transform.position, Quaternion.identity);
    }
    private void DetectObject()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Collectable")) 
            {
                //Cambiar el color a rojo
                hit.collider.GetComponent<MeshRenderer>().material.color = Color.red;
            }
        }
    }
    private void IntroduceToList()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Collectable"))
                {
                    Inventory.Add(_collectableItem);
                    _itemsInInventory++;
                    Destroy(hit.collider.gameObject);
                    Debug.Log("Has recogido un cubo!!");
                    Debug.Log("Tienes : " + _itemsInInventory + " cubos en tu inventario");
                }
            }
        }
    }
#endregion
}


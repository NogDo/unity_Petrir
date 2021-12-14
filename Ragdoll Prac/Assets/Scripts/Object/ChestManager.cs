using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestManager : MonoBehaviour
{
    public List<Sprite> list_Material;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            other.gameObject.SetActive(false);
            list_Material.Add(other.gameObject.GetComponent<ObjectManager>().sprite_ObjectImage);
        }
    }

    public List<Sprite> GetMaterialList()
    {
        return list_Material;
    }
}

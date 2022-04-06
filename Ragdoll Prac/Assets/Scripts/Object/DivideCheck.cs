using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivideCheck : MonoBehaviour
{
    public DivideObject divideObject1;
    public DivideObject divideObject2;

    public GameObject objDivideObject1;
    public GameObject objDivideObject2;
    public GameObject objMap;

    public ChestManager chestManager;

    void Update()
    {
        if(divideObject1.GetIsKnifeEnter() && divideObject2.GetIsKnifeEnter())
        {
            Debug.Log("오브젝트 자르기 확인");
            objDivideObject1.gameObject.transform.parent = objMap.transform;
            objDivideObject2.gameObject.transform.parent = objMap.transform;
            Destroy(objDivideObject1.GetComponent<FixedJoint>());
            divideObject1.gameObject.SetActive(false);
            divideObject2.gameObject.SetActive(false);
            chestManager.CutChocoloateTrue();
            gameObject.SetActive(false);
        }
    }
}

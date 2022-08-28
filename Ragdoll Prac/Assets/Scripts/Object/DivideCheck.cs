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
    public ObjectManager objectManager;

    void Update()
    {
        switch (objectManager.ingredient)
        {
            case Ingredient.Chocolate:
                if (divideObject1.GetIsKnifeEnter() && divideObject2.GetIsKnifeEnter())
                {
                    Debug.Log("초콜렛 자르기 확인");
                    objDivideObject1.gameObject.transform.parent = objMap.transform;
                    objDivideObject2.gameObject.transform.parent = objMap.transform;
                    Destroy(objDivideObject1.GetComponent<FixedJoint>());
                    divideObject1.gameObject.SetActive(false);
                    divideObject2.gameObject.SetActive(false);
                    chestManager.CutChocoloateTrue();
                    gameObject.SetActive(false);
                }
                break;

            case Ingredient.Strawberry:
                if (divideObject1.GetIsKnifeEnter())
                {
                    Debug.Log("딸기 자르기 확인");
                    if (objMap == null)
                    {
                        objDivideObject1.gameObject.transform.parent = null;
                        objDivideObject2.gameObject.transform.parent = null;
                    }
                    else
                    {
                        objDivideObject1.gameObject.transform.parent = objMap.transform;
                        objDivideObject2.gameObject.transform.parent = objMap.transform;
                    }
                    objDivideObject1.gameObject.SetActive(true);
                    objDivideObject2.gameObject.SetActive(true);
                    chestManager.CutStrawberryTrue();
                    transform.parent.gameObject.SetActive(false);
                }
                break;

            case Ingredient.Kiwi:
                if (divideObject1.GetIsKnifeEnter())
                {
                    Debug.Log("키위 자르기 확인");
                    if (objMap == null)
                    {
                        objDivideObject1.gameObject.transform.parent = null;
                        objDivideObject2.gameObject.transform.parent = null;
                    }
                    else
                    {
                        objDivideObject1.gameObject.transform.parent = objMap.transform;
                        objDivideObject2.gameObject.transform.parent = objMap.transform;
                    }
                    objDivideObject1.gameObject.SetActive(true);
                    objDivideObject2.gameObject.SetActive(true);
                    chestManager.CutKiwiTrue();
                    transform.parent.gameObject.SetActive(false);
                }
                break;

            case Ingredient.Banana:
                if (divideObject1.GetIsKnifeEnter())
                {
                    Debug.Log("바나나 자르기 확인");
                    if (objMap == null)
                    {
                        objDivideObject1.gameObject.transform.parent = null;
                        objDivideObject2.gameObject.transform.parent = null;
                    }
                    else
                    {
                        objDivideObject1.gameObject.transform.parent = objMap.transform;
                        objDivideObject2.gameObject.transform.parent = objMap.transform;
                    }
                    objDivideObject1.gameObject.SetActive(true);
                    objDivideObject2.gameObject.SetActive(true);

                    transform.parent.gameObject.SetActive(false);
                }
                break;
        }

    }
}

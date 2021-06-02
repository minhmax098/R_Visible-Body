// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.EventSystems;
// using System.Linq; //


// public static class Helper2
// {
//     // Start is called before the first frame update
//     // void Start()
//     // {
        
//     // }

//     // Update is called once per frame
//     // void Update()
//     // {
        
//     // }
//     // GetObjectOnTouchByTag: chạm vào đối tượng bằng thẻ 
//     public static GameObject GetObjectOnTouchByTag(Vector3 position, string objectTag)
//     {
//         PointerEventData eventData = new PointerEventData(EventSystem.current); //
//         eventData.position = new Vector2(position.x, position.y); //
//         List<RaycastResult> results = new List<RaycastResult>();
//         EventSystem.current.RaycastAll(eventData, results); 
//         foreach(RaycastResult result in results)
//         {
//             if(result.gameObject.tag == objectTag)
//             {
//                 return result.gameObject; 
//             }
//         }
//         return null; 
//     }

//     //GetObjectInSpaceOnTouchByTag: lấy đối tượng trong không gian bằng cách chạm bằng thẻ tag
//     public static GameObject GetObjectInSpaceOnTouchByTag(Vector3 position, string objectTag)
//     {
//         Ray ray = Camera.main.ScreenPointToRay(position);
//         RaycastHit[] raycastHits; 
//         raycastHits = Physics.RaycastAll(ray); 
//         foreach (RaycastHit hit in raycastHits)
//         {
//             if(hit.collider.tag == objectTag)
//             {
//                 return hit.collider.gameObject; 

//             }
//         }
//     }

//     // IsTouchOnCurrentOrgan: kiểm tra xem có đang chạm vào cơ quan hiện tại hay không ?
//     public static bool IsTouchOnCurrentOrgan(Vector3 position)
//     {
//         Ray ray = Camera.main.ScreenPointToRay(position);
//         RaycastHit[] raycastHits;
//         raycastHits = Physics.RaycastAll(ray);
//         foreach(RaycastHit hit in raycastHits)
//         {
//             if(hit.collider.gameObject == AROrganManager.Instance.GetCurrentOrganObject())
//             {
//                 return true;
//             }
//         }
        
//         return false; 
//     }

//     // GetChildObjectInSpaceOnTouchByTag: lấy đối tượng con trong không gian bằng cách chạm bằng thẻ
//     public static GameObject GetChildObjectInSpaceOnTouchByTag(Vector3 position, string objectTag)
//     {
//         Ray ray = Camera.main.ScreenPointToRay(position);
//         RaycastHit[] raycastHits; //
//         raycastHits = Physics.RaycastAll(ray); //
//         foreach (RaycastHit hit in raycastHits)
//         {
//             if(hit.collider.transform.root.tag == objectTag && hit.collider.tag != objectTag)
//             {
//                 return hit.collider.gameObject; 
//             }
//         }

//         return null; 
//     }

//     // MoveObject: di chuyển đối tượng
//     public static IEnumerator MoveObject(GameObject moveObject, Vector3 targetPosition)
//     {
//         // float timeSinceStarted = 0f; 
//         // raycastHits = Physics.SphereAll(pointerPosition, castingRadius, Vector3.forward); 
//         // foreach(RaycastHit hit in raycastHits)
//         // {
//         //     if(hit.collider.transform.root.tag == objecttag && hit.collider.tag != objectTag)
//         //     {
//         //         return hit.collider.gameObject; 
//         //     }
            
//         // }
//         // return null;
//         float timeSinceStarted = 0f; 
//         while(true)
//         {
//             timeSinceStarted += Time.deltaTime; 
//             moveObject.transform.position = Vector3.Lerp(moveObject.transform.position, targetPosition, timeSinceStarted); 
//             if(moveObject.transform.position == targetPosition)
//             {
//                 yield break; 
//             }
//             yield return null; 
//         }
//     }

//     // GetObjectOnPointerByTag: Lấy đối tượng trên con trỏ theo thẻ tag
//     public static GameObject GetObjectOnPointerByTag(Vector3 pointerPosition, float castingRadius, string objectTag)
//     {
//         RaycastHit[] raycastHits; 
//         raycastHits = Physics.SphereCastAll(pointerPosition, castingRadius, Vector3.forward); //
//         foreach(RaycastHit hit in raycastHits)
//         {
//             if(hit.collider.transform.root.tag == objectTag && hit.collider.tag != objectTag)
//             {
//                 return hit.collider.gameObject; 
//             }
           
//         }
//         return null; 
//     }

//     // GetPointerPosition: lấy vị trí con trỏ
//     public static GameObject GetPointerPosition(TrackingInfo trackingInfo)
//     {
//         Vector3 currentPosition = trackingInfo.bounding_box.top_left + new Vector3(trackingInfo.bounding_box.width / 3.6f, -trackingInfo.bounding_box.height / 21f,0);
//         return ManoUtils.Instance.CalculateNewPostion(currentPosition, trackingInfo.depth_estimation); 

//     }

//     // FindObject: Tìm đối tượng 
//     public static GameObject FindObject (this GameObject parent, string name)
//     {
//         Transform[] trs = parent.GetComponentInChildren<Transform>(true); //
//         foreach (Transform t in trs)
//         {
//             if(t.name == name)
//                 return t.gameObject;
//         }
//         return null; 
//     }

//     public static List<Organ> fakeDataSubOgran() {
//         List<Organ> data = new List<Organ>();
//         data.Add(new Organ(3, "Axial", 1, "Paragraphs are the building blocks", 1, 0));
//         data.Add(new Organ(4, "Appendicular", 1, "Paragraphs are the building blocks", 1, 0));
//         data.Add(new Organ(5, "Skull", 1, "Paragraphs are the building blocks", 1, 0));
//         data.Add(new Organ(6, "Vertebral Colum", 1, "Paragraphs are the building blocks", 1, 0));
//         data.Add(new Organ(7, "Thoracic Cage", 1, "Paragraphs are the building blocks", 1, 0));
//         data.Add(new Organ(7, "Upper Limbs", 1, "Paragraphs are the building blocks", 1, 0)); 
//         data.Add(new Organ(7, "Shoulder gridles", 1, "Paragraphs are the building blocks", 1, 0));
//         data.Add(new Organ(7, "Lower Limbs", 1, "Paragraphs are the building blocks", 1, 0));
//         data.Add(new Organ(7, "Pelvic Girdlle", 1, "Paragraphs are the building blocks", 1, 0));
//         return data;
//     }
// }

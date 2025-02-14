using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerObject : MonoBehaviour
{
    public void UpdateChildrenPositions(Vector3 parentNewPosition){
        MovableObject[] movableObjects = GetComponentsInChildren<MovableObject>();
        // GameObject gameObject = new GameObject();
        // gameObject.transform.rotation = transform.parent.transform.rotation;
        // gameObject.transform.localScale = transform.parent.transform.localScale;
        // gameObject.transform.position = parentNewPosition;

        foreach(MovableObject movableObject in movableObjects){
            Debug.LogError("Provo a riposizionare: " + movableObject.name);
            Debug.LogError("newpos: " + transform.TransformPoint(movableObject.transform.localPosition) + " old:" + movableObject.transform.position);
            movableObject.UpdatePosition(transform.TransformPoint(movableObject.transform.localPosition));
        }
    }

    public void ReleaseSelectionOnSelectedChildren(PhoneRepresentation playerSelecting){
        MovableObject[] movableObjects = GetComponentsInChildren<MovableObject>();
        foreach(MovableObject movableObject in movableObjects){
            if(movableObject.isSelectedBy == playerSelecting)
                movableObject.ReleaseSelection();
        }
    }

    public void TrySelectChildren(PhoneRepresentation playerSelecting){
        MovableObject[] movableObjects = GetComponentsInChildren<MovableObject>();
        foreach(MovableObject movableObject in movableObjects){
            //if(movableObject.selected == false)
            Debug.LogError("Provo a selezionare: " + movableObject.name);
                movableObject.TrySelectObject(playerSelecting);
        }
    }
}

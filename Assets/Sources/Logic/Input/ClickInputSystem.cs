
using System;
using Entitas;
using UnityEngine;

public class ClickInputSystem : IExecuteSystem
{
    public void Execute()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                var gameObject = hit.transform.gameObject;
                var entityLink = gameObject.GetEntityLink();

                if(entityLink == null) { return; }

                var entity = entityLink.LinkedEntity;
                Debug.Log(entity);

                entityLink.Unlink();

                entity.Destroy();
                GameObject.Destroy(gameObject);
            }
        }
    }
}

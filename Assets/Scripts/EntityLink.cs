using UnityEngine;
using Entitas;
using System;

public class EntityLink : MonoBehaviour
{

    public Entity LinkedEntity { get; private set; }

    public void Link(Entity entity)
    {
        if (LinkedEntity != null)
        {
            throw new Exception("EntityLink is already linked to " + LinkedEntity + "!");
        }

        LinkedEntity = entity;
        LinkedEntity.Retain(this);
    }

    public void Unlink()
    {
        if (LinkedEntity == null)
        {
            throw new Exception("EntityLink is already unlinked!");
        }
        
        LinkedEntity.Release(this);
        LinkedEntity = null;
    }
}

public static class EntityLinkExtension
{

    public static EntityLink GetEntityLink(this GameObject gameObject)
    {
        return gameObject.GetComponent<EntityLink>();
    }

    public static EntityLink Link(this GameObject gameObject, Entity entity)
    {
        var link = gameObject.GetEntityLink();
        if (link == null)
        {
            link = gameObject.AddComponent<EntityLink>();
        }

        link.Link(entity);
        return link;
    }

    public static void Unlink(this GameObject gameObject)
    {
        gameObject.GetEntityLink().Unlink();
    }
}
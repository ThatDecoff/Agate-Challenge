using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Game.Challenge6
{
    public class ObjectPool<TClass>
    {
        private Func<TClass> createNewObject;

        private List<TClass> objects = new List<TClass>();

        private List<TClass> usedObject = new List<TClass>();

        public ObjectPool(Func<TClass> function)
        {
            createNewObject = function;
        }

        public TClass GetObject()
        {
            if(objects.Count == 0)
            {
                TClass newObj = createNewObject.Invoke();
                objects.Add(newObj);
            }

            TClass result = objects[0];
            objects.Remove(result);
            usedObject.Add(result);
            return result;
        }

        public void FreeObject(TClass obj)
        {
            objects.Add(obj);
            usedObject.Remove(obj);
        }

        private TClass CreateNew()
        {
            return createNewObject.Invoke();
        }
    }
}

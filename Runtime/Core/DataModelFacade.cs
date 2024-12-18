using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace LK.SimpleFramework
{
    public class DataModelFacade : DataModelFacadeBase
    {
        protected override T GetDataModel<T>()
        {
            T res = InstanceCollector.Instance.GetInstance<T>(() => Activator.CreateInstance<T>());

#if UNITY_ASSERTIONS
            Assert.IsNotNull(res);
#endif

            return res;
        }
    }
}

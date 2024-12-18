using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace LK.SimpleFramework
{
    /// <summary>
    /// 业务逻辑外观基类
    /// </summary>
    public class BusinessFacade : BusinessFacadeBase
    {
        protected override T GetBusiness<T>() where T : class
        {
            T res = InstanceCollector.Instance.GetInstance<T>(()=> Activator.CreateInstance<T>());

#if UNITY_ASSERTIONS
            Assert.IsNotNull(res);
#endif

            return res;
        }
    }
}

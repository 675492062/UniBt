﻿using UnityEngine;

namespace UniBt
{
    public sealed class RuntimeTask
    {
        public Task parent;
        public string methodName;
        public System.Func<System.IDisposable> taskFunc;
        public MonoBehaviour comp;

        private System.IDisposable _disposable;

        public RuntimeTask(Task parent, string methodName)
        {
            this.parent = parent;
            this.methodName = methodName;
        }

        public void Start()
        {
            if (parent.isCoroutine)
            {
                comp.StopCoroutine(methodName);
                comp.StartCoroutine(methodName);
            }
            else
            {
                if (_disposable != null)
                    _disposable.Dispose();
                _disposable = taskFunc();
            }
        }

        public void Finish()
        {
            if (parent.isCoroutine)
                comp.StopCoroutine(methodName);
            else if (_disposable != null)
                _disposable.Dispose();
        }
    }
}

using UnityEngine;

namespace Code
{
    #region MyRegion

    public class A
    {
        // public A(int t)
        // {
        //     Debug.LogError(nameof(A));
        // }

        public virtual void NameMethod()
        {
            Debug.LogError(nameof(A)); 
        }
    }
    
    public class B : A
    {
        // public B(int t) : base(t)
        // {
        //     Debug.LogError(nameof(B));
        // }

        // public override void NameMethod()
        // {
        //     base.NameMethod();
        //     Debug.LogError(nameof(B));
        // }

        public new void NameMethod()
        {
            Debug.LogError(nameof(B));
        }
    }

    #endregion

    public abstract class First
    {
        public abstract void NameMethod();
    }

    public sealed class Second : First
    {
        // public sealed override string ToString()
        // {
        //     return base.ToString();
        // }
        
        public override void NameMethod()
        {
        }
    }
}

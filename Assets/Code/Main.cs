using UnityEngine;

namespace Code
{
    public sealed class Main : MonoBehaviour
    {
        private void Start()
        {
            A a = new A();
            a.NameMethod();
            
            A ab = new B();
            ab.NameMethod();
            
            B b = new B();
            b.NameMethod();
            //First first = new First();
            //First second = new Second();
            // B bad = new A();
            // List<A> list = new List<A>();
            // list.Add(new A());
            // list.Add(new B());
            //
            // foreach (A c in list)
            // {
            //     c.NameMethod();
            // }
            // IEnumerable<A> test = new List<B>();
            // IComparer<B> comparer = new A();
        }
    }
}

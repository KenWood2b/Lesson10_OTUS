using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Code
{
    public sealed class Sample : MonoBehaviour
    {
        private void Start()
        {
            IEnumerable<string> stringEnumerable = new StringEnumerable(new[] { "Hello", "World", "!" });
            
            //StartCoroutine(TestRoutine());
        }

        private IEnumerator TestRoutine()
        {
            Debug.Log(0);
            
            yield return new WaitForSeconds(1);
            
            Debug.Log(1);

            StartCoroutine(SecondRoutine());
            
            yield return new WaitForSeconds(1);
            
            Debug.Log(2);
            
            yield return new WaitForSeconds(1);
            
            Debug.Log(3);
        }

        private IEnumerator SecondRoutine()
        {
            Debug.Log("+0");

            yield return new WaitForSeconds(1);
            
            Debug.Log("+1");
            
            yield return new WaitForSeconds(1);
            
            Debug.Log("+2");
        }
    }
}
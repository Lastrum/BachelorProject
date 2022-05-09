using System.Collections;
using UnityEngine;

namespace Player
{
    public abstract class State 
    {
        public virtual IEnumerator Start()
        {
            yield break;
        }
    }
}

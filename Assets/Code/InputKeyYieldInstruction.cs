using UnityEngine;

namespace Code
{
    public sealed class InputKeyYieldInstruction : CustomYieldInstruction
    {
        public override bool keepWaiting => !Input.GetKey(_keyCode);

        private readonly KeyCode _keyCode;

        public InputKeyYieldInstruction(KeyCode keyCode)
        {
            _keyCode = keyCode;
        }
    }
}
using UnityEngine;

namespace Cnoom.UnityTool.MaterialUtils
{
    public class RenderScroll : AMaterialScroll
    {

        protected override Material GetMaterial()
        {
            return GetComponent<Renderer>().material;
        }
    }
}
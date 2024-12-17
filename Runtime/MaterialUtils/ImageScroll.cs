using UnityEngine;
using UnityEngine.UI;

namespace Cnoom.UnityTool.MaterialUtils
{
    public class ImageScroll : AMaterialScroll
    {

        protected override Material GetMaterial()
        {
            return GetComponent<Image>().material;
        }
    }
}
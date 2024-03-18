using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectHighlightScript : MonoBehaviour
{
    public Shader defaultShader;
    public Shader highlightedShader;
    //public Shader highlightedShader2;

    // when hover over an object, change to the highlighted shader
    public void OnFirstHoverEntered(HoverEnterEventArgs args)
    {
        var renderer = args.interactableObject.transform.GetComponent<Renderer>();
        renderer.material.shader = highlightedShader;
    }

    //public void OnFirstHoverEntered2(HoverEnterEventArgs args)
    //{
    //    var renderer = args.interactableObject.transform.GetComponent<Renderer>();
    //    renderer.material.shader = highlightedShader2;
    //}

    // when stopped hovering over an object, change to the regular shader
    public void OnLastHoverExited(HoverExitEventArgs args)
    {
        if (!args.interactableObject.isHovered)
        {
            var renderer = args.interactableObject.transform.GetComponent<Renderer>();
            renderer.material.shader = defaultShader;
        }
    }

    // when selected an object, change to the highlighted shader
    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        var renderer = args.interactableObject.transform.GetComponent<Renderer>();
        renderer.material.shader = highlightedShader;
    }

    //public void OnSelectEntered2(SelectEnterEventArgs args)
    //{
    //    var renderer = args.interactableObject.transform.GetComponent<Renderer>();
    //    renderer.material.shader = highlightedShader2;
    //}

    // when stopped selecting an object, change to the normal shader
    public void OnSelectExited(SelectExitEventArgs args)
    {
        if (!args.interactableObject.isSelected)
        {
            var renderer = args.interactableObject.transform.GetComponent<Renderer>();
            renderer.material.shader = defaultShader;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour
{
    public Button castleButton;
    public Button forestButton;
    public Button montainButton;

    public void GetAction()
    {
        if (SelectorOptionPause.castle)
        {
            var click = castleButton.onClick;
            click.Invoke();
        }
        else if (SelectorOptionPause.forest)
        {
            var click = forestButton.onClick;
            click.Invoke();
        }
        else if (SelectorOptionPause.montain)
        {
            var click = montainButton.onClick;
            click.Invoke();
        }
    }
}

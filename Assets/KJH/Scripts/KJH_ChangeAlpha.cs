using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KJH_ChangeAlpha : MonoBehaviour
{
    Color color = new Color(1, 1, 1, 0);
    Color targetColor = new Color(1, 1, 1, 0.3f);

    public IEnumerator IeChangeAlpha()
    {
        Transform tr_image = transform.GetChild(KJH_DrawConstellation.instance.coIndex);
        SpriteRenderer sprite = tr_image.GetComponent<SpriteRenderer>();

        tr_image.forward = Vector3.zero - tr_image.position;
        color = sprite.color;

        while(color.a <= 0.25f)
        {
            color = Color.Lerp(color, targetColor, Time.deltaTime * 0.4f);
            sprite.color = color;
            Debug.Log("alpha : " + color.a);
            yield return null;
        }
        sprite.color = targetColor;
        color.a = 0f;
        StarGuide.Instance.guideState = StarGuide.GuideState.state5;
    }
}

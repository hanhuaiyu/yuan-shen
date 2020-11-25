using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    /*public static IEnumerator loadPicture(string absPath, Action<Sprite> callback)
    {
        WWW www = new WWW(absPath);
        yield return www;
        if (string.IsNullOrEmpty(www.error))
        {
            Sprite sprite = CreateSprite(www.texture);

            if (callback != null)
            {
                callback(sprite);
            }
        }
        else
        {
            Debug.Log(www.error);
        }
    }

    /// <summary>
    /// 创建精灵图片
    /// </summary>
    /// <param name="texture"></param>
    /// <returns></returns>
    public static Sprite CreateSprite(Texture2D texture)
    {
        if (!texture)
        {
            return null;
        }
        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

        2、设置图片给image

    public void LoadPicture(string bgpath)
        {
            if (string.IsNullOrEmpty(bgpath))
            {
                return;
            }
            string absPath = "file:///" + bgpath;
            StartCoroutine(FileUtils.loadPicture(absPath, sprite =>
            {
                img_Background.GetComponent<Image>().sprite = sprite;

            }));
        }

        /// <summary>
        ///3、使用滑轮  根据鼠标位置 设置背景板的背景大小
        /// </summary>
        public void SetImageSize(Transform transform)
        {
            float value = 0;
            value = controller.inputControl.MouseScrollWheel;
            if (value == 0)
            {
                return;
            }
            SetMouseChangeForImage(transform, value > 0 ? stepValue : -stepValue);
        }

        /// <summary>
        /// 4、通过鼠标控制缩放比例
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="value"></param>
        void SetMouseChangeForImage(Transform transform, int value)
        {
            float delX = Input.mousePosition.x - transform.position.x;
            float delY = Input.mousePosition.y - transform.position.y;

            float scaleX = delX / transform.GetComponent<RectTransform>().rect.width / transform.localScale.x;
            float scaleY = delY / transform.GetComponent<RectTransform>().rect.height / transform.localScale.y;

            transform.GetComponent<RectTransform>().localScale += Vector3.one * 0.1f * value;
            nowVector3 = transform.GetComponent<RectTransform>().localScale;
            if (nowVector3.x < 0.1f)
            {
                transform.GetComponent<RectTransform>().localScale = Vector3.one * 0.1f;
            }
            if (nowVector3.x > 3f)
            {
                transform.GetComponent<RectTransform>().localScale = Vector3.one * 3f;
            }
            transform.GetComponent<RectTransform>().pivot += new Vector2(scaleX, scaleY);
            transform.GetComponent<RectTransform>().anchoredPosition3D += new Vector3(delX, delY, 0);
        }

    }*/
}

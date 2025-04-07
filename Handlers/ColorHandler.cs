using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using TMPro;
using UnityEngine;
using WhoIsTalking;
using static WhoIsThatMonke.PublicVariablesGatherHere;

namespace WhoIsThatMonke.Handlers
{
    internal class ColorHandler : MonoBehaviour
    {
        public NameTagHandler nameTagHandler;
        public GameObject fpTag, tpTag, firstPersonNameTag, thirdPersonNameTag;
        public Renderer fpTextRenderer, fpColorRenderer, tpColorRenderer;
        public TextMeshPro fpColorText, tpColorText;
        public Shader uiShader = Shader.Find("UI/Default");

        void Start()
        {
            if (firstPersonNameTag == null || thirdPersonNameTag == null)
            {
                CreateColorTags();
            }
        }

        private string GetColorCode(VRRig rig)
        {
            var color = rig.playerColor;
            int r = Mathf.RoundToInt(color.r * 9);
            int g = Mathf.RoundToInt(color.g * 9);
            int b = Mathf.RoundToInt(color.b * 9);
            return $"{r}, {g}, {b}";
        }

        public void CreateColorTags()
        {
            if (firstPersonNameTag == null)
            {
                Transform tmpchild0 = transform.FindChildRecursive("First Person NameTag");
                firstPersonNameTag = tmpchild0.FindChildRecursive("NameTag").gameObject;

                fpTag = GameObject.CreatePrimitive(PrimitiveType.Quad);
                fpTag.name = "FP Color Holder";
                fpTag.transform.SetParent(firstPersonNameTag.transform);
                fpTag.transform.localPosition = new Vector3(0f, 4f, 0f);
                fpTag.transform.localScale = Vector3.one;
                fpTag.transform.localRotation = Quaternion.Euler(0, 180, 0);
                fpTag.layer = firstPersonNameTag.layer;

                Destroy(fpTag.GetComponent<Collider>());

                fpColorRenderer = fpTag.GetComponent<Renderer>();
                fpColorRenderer.material = new Material(uiShader);

                fpColorText = fpTag.AddComponent<TextMeshPro>();
                fpColorText.alignment = TextAlignmentOptions.Center;
                fpColorText.transform.rotation = Quaternion.Euler(0, 180, 0);
                fpColorText.font = nameTagHandler.rig.playerText1.font;
                fpColorText.fontSize = 7;
                fpColorText.text = GetColorCode(nameTagHandler.rig);
                fpColorText.color = nameTagHandler.rig.mainSkin.material.color;
            }

            if (thirdPersonNameTag == null)
            {
                Transform tmpchild1 = transform.FindChildRecursive("Third Person NameTag");
                thirdPersonNameTag = tmpchild1.FindChildRecursive("NameTag").gameObject;

                tpTag = GameObject.CreatePrimitive(PrimitiveType.Quad);
                tpTag.name = "TP Color Holder";
                tpTag.transform.SetParent(thirdPersonNameTag.transform);
                tpTag.transform.localPosition = new Vector3(0f, 4f, 0f);
                tpTag.transform.localScale = Vector3.one;
                tpTag.transform.localRotation = Quaternion.Euler(0, 180, 0);
                tpTag.layer = thirdPersonNameTag.layer;

                Destroy(tpTag.GetComponent<Collider>());

                tpColorRenderer = tpTag.GetComponent<Renderer>();
                tpColorRenderer.material = new Material(uiShader);

                tpColorText = tpTag.AddComponent<TextMeshPro>();
                tpColorText.alignment = TextAlignmentOptions.Center;
                tpColorText.transform.rotation = Quaternion.Euler(0, 180, 0);
                tpColorText.font = nameTagHandler.rig.playerText1.font;
                tpColorText.fontSize = 7;
                tpColorText.text = GetColorCode(nameTagHandler.rig);
                tpColorText.color = nameTagHandler.rig.mainSkin.material.color;
            }
            UpdateColorPatchThingy();
        }

        void UpdateColorPatchThingy()
        {
            if (fpColorText != null)
            {
                fpColorText.text = GetColorCode(nameTagHandler.rig);
            }

            if (tpColorText != null)
            {
                tpColorText.text = GetColorCode(nameTagHandler.rig);
            }
        }

        void FixedUpdate()
        {
            if (nameTagHandler != null)
            {
                if (fpColorText.text != GetColorCode(nameTagHandler.rig))
                {
                    fpColorText.text = GetColorCode(nameTagHandler.rig);

                }
                if (tpColorText.text != GetColorCode(nameTagHandler.rig))
                {
                    tpColorText.text = GetColorCode(nameTagHandler.rig);
                }

                if (fpTextRenderer == null)
                {
                    fpTextRenderer = fpTag.transform.parent.GetComponent<Renderer>();
                }
                if (fpColorRenderer == null)
                {
                    fpColorRenderer = fpColorText.GetComponent<Renderer>();
                }
                if (tpColorRenderer == null)
                {
                    tpColorRenderer = tpColorText.GetComponent<Renderer>();
                }
                if (isColorCodeEnabled)
                {
                    tpColorRenderer.forceRenderingOff = false;
                    fpColorRenderer.forceRenderingOff = fpTextRenderer.forceRenderingOff;
                }
                else
                {
                    fpColorRenderer.forceRenderingOff = true;
                    tpColorRenderer.forceRenderingOff = true;
                }
                if (!isVelocityEnabled && !isFPSEnabled)
                {
                    fpTag.transform.localPosition = new Vector3(0f, 2f, 0f);
                    tpTag.transform.localPosition = new Vector3(0f, 2f, 0f);
                }
                else if (!isFPSEnabled)
                {
                    fpTag.transform.localPosition = new Vector3(0f, 3f, 0f);
                    tpTag.transform.localPosition = new Vector3(0f, 3f, 0f);
                }
                else if (!isVelocityEnabled)
                {
                    fpTag.transform.localPosition = new Vector3(0f, 3f, 0f);
                    tpTag.transform.localPosition = new Vector3(0f, 3f, 0f);
                }
                else
                {
                    fpTag.transform.localPosition = new Vector3(0f, 4f, 0f);
                    tpTag.transform.localPosition = new Vector3(0f, 4f, 0f);
                }

                fpColorText.color = nameTagHandler.rig.playerColor;
                tpColorText.color = nameTagHandler.rig.playerColor;

                if (nameTagHandler.rig.mainSkin.material.color != nameTagHandler.rig.playerColor)
                {
                    nameTagHandler.rig.mainSkin.material.color = nameTagHandler.rig.playerColor;
                }
            }
        }
    }
}
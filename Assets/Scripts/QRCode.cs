﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using ZXing;
using ZXing.QrCode;

public class QRCode : MonoBehaviour
{


    public string QRInput;

    private bool QRActivated;

    private void Start()
    {
        QRActivated = false;
    }

    void OnGUI()
    {

        if (QRActivated)
        {
            Texture2D myQR = generateQR(QRInput);
            if (GUI.Button(new Rect(300, 300, 256, 256), myQR, GUIStyle.none)) { }
        }
    }


    private static Color32[] Encode(string textForEncoding, int width, int height)
    {
        var writer = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                Height = height,
                Width = width
            }
        };
        return writer.Write(textForEncoding);
    }

    public Texture2D generateQR(string text)
    {
        var encoded = new Texture2D(256, 256);
        var color32 = Encode(text, encoded.width, encoded.height);
        encoded.SetPixels32(color32);
        encoded.Apply();
        return encoded;
    }

    private void OnMouseDown()
    {
        QRActivated = !QRActivated;
    }

}

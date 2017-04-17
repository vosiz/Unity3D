using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Colors {

    //public static Color info_text = colorFloat(0xff, 0xc5, 0x2b, 0xff);
    public static Color info_text = colorFloat(0xFFC52BFF);
    public static Color info_text_neg = colorFloat(0xFF0000FF);


    /* Byte channel value to float*/
    public static Color colorFloat(int r, int g, int b, int a) {

        float red_channel;
        float green_channel;
        float blue_channel;
        float alpha_channel;

        red_channel = (float)r / 255.0f;
        green_channel = (float)g / 255.0f;
        blue_channel = (float)b / 255.0f;
        alpha_channel = (float)a / 255.0f;

        return new Color(red_channel, green_channel, blue_channel, alpha_channel);
    }


    /* Unsigned integer to floats*/
    public static Color colorFloat(uint rgba) {

        float red_channel;
        float green_channel;
        float blue_channel;
        float alpha_channel;

        red_channel = (float)((rgba&0xff000000) >> 24) / 255.0f;
        green_channel = (float)((rgba & 0xff0000) >> 16) / 255.0f;
        blue_channel = (float)((rgba & 0xff00) >> 8) / 255.0f;
        alpha_channel = (float)((rgba & 0xff) >> 0) / 255.0f;

        return new Color(red_channel, green_channel, blue_channel, alpha_channel);
    }

}

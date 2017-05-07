using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public static class Errors {

    public static void Unimplemented(string text = "") {

        Warning(System.Reflection.MethodBase.GetCurrentMethod().Name + "Uniplemented functionionality");
    }

    public static void Warning(string text = "") {

        Debug.Log("[Warn] " + System.Reflection.MethodBase.GetCurrentMethod().Name + ":" +  text);
        throw new Exception(text);
    }

    public static void Error(string text = "") {

        Debug.Log("[Error] " + System.Reflection.MethodBase.GetCurrentMethod().Name + ":" + text);
        throw new Exception(text);
    }

    public static void FatalError(string text = "") {

        Debug.Log("[Fatal] " + System.Reflection.MethodBase.GetCurrentMethod().Name + ":" + text);
        
        FatalErrorHandler();
    }

    public static void FatalErrorHandler(string text = "") {

        // unimplemented yet
        throw new Exception(text);
    }

}

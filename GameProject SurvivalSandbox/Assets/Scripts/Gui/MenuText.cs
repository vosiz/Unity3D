using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class MenuText {

    private const int header_index  = 0;
    private const int title_index   = 1;
    private const int text_index    = 2;


    static public string GetHeader(string scenario_text) {

        if (scenario_text == null) Errors.Error("Cannot get header (null)");

        return string.Concat(TextUtilities.GetRowsFromString(scenario_text, header_index, 1));
    }

    static public string GetTitle(string scenario_text) {

        if (scenario_text == null) Errors.Error("Cannot get title (null)");

        return string.Concat(TextUtilities.GetRowsFromString(scenario_text, title_index, 1));
    }

    static public string GetText(string scenario_text) {

        if (scenario_text == null) Errors.Error("Cannot get text (null)");

        return string.Concat(TextUtilities.GetRowsFromString(scenario_text, text_index));
    }
}

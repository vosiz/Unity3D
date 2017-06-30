using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class TextUtilities {


    // Get row count 
    static public int GetRowCount(string text) {

        int count = 0;

        text.Replace("\r", "");

        foreach (char c in text) {

            if (c == '\n') count++;
        }

        return count;
    }

    // Get rows from index till end
    static public string[] GetRowsFromString(string text, int row_index) {

        return GetRowsFromString(text, row_index, GetRowCount(text) - row_index);
    }

    // Get cetain count from index
    static public string[] GetRowsFromString(string text, int row_index, int row_count) {

        string[] lines;
        int rows_total;
        int end_index;
        string[] output_lines;

        if (text == null) Errors.Error("Null text");
        if (row_index < 0) Errors.Error("Row index < 0");
        if (row_count <= 0) Errors.Error("Row count <= 0");

        rows_total = GetRowCount(text);
        end_index = row_count + row_index -1;

        if (end_index > rows_total) Errors.Error("Number of wanted rows are too high! "+ end_index + " ending index of " + rows_total);

        // split lines
        lines = text.Replace("\r", "").Split('\n');

        output_lines = new string[row_count];
        for(int i = 0; i < row_count; i++) {

            output_lines[i] = lines[row_index + i];
        }

        return output_lines;
    }

    // Edit given noun when more than 1
    static public string CorrectSuffix(string noun) {

        string output = noun;

        if(noun.EndsWith("s")) {

            output += "es";
        }

        if (noun.EndsWith("us")) {

            output.Substring(output.Length - 2);
            output += "si";
        }

        return output;
    }

    // Trims "(Clone)"
    static public string TrimClone(string str) {

        return str.Replace("(Clone)", "");
    }
}

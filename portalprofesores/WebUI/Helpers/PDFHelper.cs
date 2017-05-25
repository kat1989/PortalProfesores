using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using iTextSharp.text.pdf;

namespace WebUI.Helpers
{
    public class PDFHelper
    {
        public static Dictionary<string, string> GetFormFieldNames(string pdfPath)
        {
            var reader = new PdfReader(pdfPath);
            var fields = reader.AcroFields.Fields.Cast<DictionaryEntry>().ToDictionary(entry => entry.Key.ToString(), entry => string.Empty);
            reader.Close();

            return fields;
        }

        public static byte[] GeneratePDF(string pdfPath, Dictionary<string, string> formFieldMap)
        {
            var output = new MemoryStream();
            var reader = new PdfReader(pdfPath);
            var stamper = new PdfStamper(reader, output);
           
            var formFields = stamper.AcroFields;

            foreach (var fieldName in formFieldMap.Keys)
                formFields.SetField(fieldName, formFieldMap[fieldName]);

            stamper.FormFlattening = true;
             string Printer = "";
            if (Printer == null || Printer == "")
            {
                stamper.JavaScript = "var pp = getPrintParams();pp.interactive = pp.constants.interactionLevel.automatic;pp.printerName = getPrintParams().printerName;print(pp);\r";
               
            }
            else
            {
                stamper.JavaScript = "var pp = getPrintParams();pp.interactive = pp.constants.interactionLevel.automatic;pp.printerName = " + Printer + ";print(pp);\r";
               
            }
            stamper.Close();
            reader.Close();

            return output.ToArray();
        }

        // See http://stackoverflow.com/questions/4491156/get-the-export-value-of-a-checkbox-using-itextsharp/
        public static string GetExportValue(AcroFields.Item item)
        {
            var valueDict = item.GetValue(0);
            var appearanceDict = valueDict.GetAsDict(PdfName.AP);

            if (appearanceDict != null)
            {
                var normalAppearances = appearanceDict.GetAsDict(PdfName.N);
                // /D is for the "down" appearances.

                // if there are normal appearances, one key will be "Off", and the other
                // will be the export value... there should only be two.
                if (normalAppearances != null)
                {
                    foreach (var curKey in normalAppearances.Keys)
                        if (!PdfName.OFF.Equals(curKey))
                            return curKey.ToString().Substring(1); // string will have a leading '/' character, so remove it!
                }
            }

            // if that doesn't work, there might be an /AS key, whose value is a name with 
            // the export value, again with a leading '/', so remove it!
            var curVal = valueDict.GetAsName(PdfName.AS);
            if (curVal != null)
                return curVal.ToString().Substring(1);
            else
                return string.Empty;
        }

        public static void ReturnPDF(byte[] contents)
        {
            ReturnPDF(contents, null);
        }

        public static void ReturnPDF(byte[] contents, string attachmentFilename)
        {
            var response = HttpContext.Current.Response;

            if (!string.IsNullOrEmpty(attachmentFilename))
                response.AddHeader("Content-Disposition", "inline; filename=" + attachmentFilename);

            response.ContentType = "application/pdf";
            response.BinaryWrite(contents);
            response.End();
           
        }
    }
}
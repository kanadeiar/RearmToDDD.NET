using RearmCSharp1L1T1.Questionnaire.DataAccessLayer.Codes;

namespace RearmCSharp1L1T1.Questionnaire.DataAccessLayer.Data;

public class VariantsSource
{
    public IEnumerable<(string, FormatEntryCode)> GetVariants()
    {
        yield return ("Склеивание", FormatEntryCode.GluedLine);
        yield return ("Форматирование", FormatEntryCode.Formatted);
        yield return ("Интерполяция", FormatEntryCode.Interpolated);
    }
}
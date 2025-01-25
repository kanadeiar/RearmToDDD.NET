using RearmCSharp1L1T1.Questionnaire.UsefulLogicLayer.QuestionnaireModule;

namespace RearmCSharp1L1T1.Questionnaire.DataAccessLayer.Data;

public class VariantsSource
{
    public IEnumerable<(string, FormatCode)> GetVariants()
    {
        yield return ("Склеивание", FormatCode.GluedLine);
        yield return ("Форматирование", FormatCode.Formatted);
        yield return ("Интерполяция", FormatCode.Interpolated);
    }
}
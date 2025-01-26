using RearmCSharp1L1T1.Questionnaire.DataAccessLayer.Codes;

namespace RearmCSharp1L1T1.Questionnaire.UsefulLogicLayer.QuestionnaireModule.FormattingCodes;

public record FormatCode
{
    public static FormatCode Create(FormatEntryCode code)
    {
        return code switch
        {
            FormatEntryCode.GluedLine => new GluedLineCode(),
            FormatEntryCode.Formatted => new FormattedCode(),
            FormatEntryCode.Interpolated => new InterpolatedCode(),
            _ => new FormatCode(),
        };
    }

    public virtual string FormattedText((string surName, string name, int age, int height, int weight) values) => string.Empty;
}
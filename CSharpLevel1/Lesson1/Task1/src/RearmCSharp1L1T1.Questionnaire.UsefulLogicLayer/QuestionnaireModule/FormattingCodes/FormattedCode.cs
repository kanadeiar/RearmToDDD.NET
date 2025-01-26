namespace RearmCSharp1L1T1.Questionnaire.UsefulLogicLayer.QuestionnaireModule.FormattingCodes;

public record FormattedCode : FormatCode
{
    public override string FormattedText((string surName, string name, int age, int height, int weight) values) =>
        string.Format("Formatted {0} {1} {2} лет {3} см {4} кг", values.surName, values.name, values.age, values.height, values.weight);
}
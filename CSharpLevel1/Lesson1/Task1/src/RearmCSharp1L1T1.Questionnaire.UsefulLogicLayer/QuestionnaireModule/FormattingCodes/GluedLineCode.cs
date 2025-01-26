namespace RearmCSharp1L1T1.Questionnaire.UsefulLogicLayer.QuestionnaireModule.FormattingCodes;

public record GluedLineCode : FormatCode
{
    public override string FormattedText((string surName, string name, int age, int height, int weight) values) =>
        values.Item1 + " " + values.Item2 + " " + values.Item3 + " лет " + values.Item4 + " см " + values.Item5 + " кг";
}
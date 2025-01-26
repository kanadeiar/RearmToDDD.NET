namespace RearmCSharp1L1T1.Questionnaire.UsefulLogicLayer.QuestionnaireModule.FormattingCodes;

public record InterpolatedCode : FormatCode
{
    public override string FormattedText((string surName, string name, int age, int height, int weight) values) =>
        $"{values.surName} {values.name} {values.age} лет {values.height} см {values.weight} кг";
}
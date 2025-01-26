using System.Runtime.CompilerServices;
using RearmCSharp1L1T1.Questionnaire.UsefulLogicLayer.QuestionnaireModule.FormattingCodes;

[assembly: InternalsVisibleTo("RearmCSharp1L1T1.Questionnaire.Tests.EndToEnd")]
namespace RearmCSharp1L1T1.Questionnaire.UsefulLogicLayer.QuestionnaireModule;

public class QuestionnaireBase(string surName, string name, int age, int height, int weight)
{
    public string GetFormattedText(FormatCode code) => code.FormattedText(deconstruct());

    internal (string, string, int, int, int) deconstruct() => (surName, name, age, height, weight);
}


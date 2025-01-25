using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RearmCSharp1L1T1.Questionnaire.Tests.EndToEnd")]
namespace RearmCSharp1L1T1.Questionnaire.UsefulLogicLayer.QuestionnaireModule;

public class QuestionnaireBase(string surName, string name, int age, int height, int weight)
{
    public string GetFormattedText(FormatCode code)
    {
        var result = code switch
        {
            FormatCode.GluedLine => surName + " " + name + " " + age + " лет " + height + " см " + weight + " кг",
            FormatCode.Formatted => string.Format("Formatted {0} {1} {2} лет {3} см {4} кг", surName, name, age, height, weight),
            FormatCode.Interpolated => $"{surName} {name} {age} лет {height} см {weight} кг",
            _ => "",
        };

        return result;
    }

    internal (string, string, int, int, int) deconstruct() => (surName, name, age, height, weight);
}


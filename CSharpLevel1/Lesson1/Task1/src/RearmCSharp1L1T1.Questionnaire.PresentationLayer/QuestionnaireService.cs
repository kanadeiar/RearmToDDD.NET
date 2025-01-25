using System.Runtime.CompilerServices;
using Kanadeiar.Common;
using RearmCSharp1L1T1.Questionnaire.DataAccessLayer.Data;
using RearmCSharp1L1T1.Questionnaire.UsefulLogicLayer.QuestionnaireModule;

[assembly: InternalsVisibleTo("RearmCSharp1L1T1.Questionnaire.Tests.EndToEnd")]
namespace RearmCSharp1L1T1.Questionnaire.PresentationLayer;

public class QuestionnaireService
{
    public QuestionnaireBase InputFromConsole()
    {
        var surName = ConsoleHelper.ReadLineFromConsole("Введите фамилию")!;
        var name = ConsoleHelper.ReadLineFromConsole("Введите имя")!;
        var age = ConsoleHelper.ReadNumberFromConsole<int>("Введите возраст");
        var height = ConsoleHelper.ReadNumberFromConsole<int>("Введите рост");
        var weight = ConsoleHelper.ReadNumberFromConsole<int>("Введите вес");

        return new QuestionnaireBase(surName, name, age, height, weight);
    }

    public void PrintToConsole(QuestionnaireBase questionnaire)
    {
        var variants = new VariantsSource();

        foreach (var each in variants.GetVariants())
        {
            var text = questionnaire.GetFormattedText(each.Item2);

            ConsoleHelper.PrintValueWithMessage(each.Item1, text);
        }
    }
}
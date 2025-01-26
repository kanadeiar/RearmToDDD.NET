using System.Runtime.CompilerServices;
using Kanadeiar.Common;
using RearmCSharp1L1T1.Questionnaire.DataAccessLayer.Data;
using RearmCSharp1L1T1.Questionnaire.UsefulLogicLayer.QuestionnaireModule;

[assembly: InternalsVisibleTo("RearmCSharp1L1T1.Questionnaire.Tests.EndToEnd")]
namespace RearmCSharp1L1T1.Questionnaire.PresentationLayer;

public class QuestionnaireService
{
    public Some<QuestionnaireBase> InputFromConsole()
    {
        try
        {
            var surName = ConsoleHelper.ReadLineFromConsole("Введите фамилию")!;
            var name = ConsoleHelper.ReadLineFromConsole("Введите имя")!;
            var age = ConsoleHelper.ReadNumberFromConsole<int>("Введите возраст");
            var height = ConsoleHelper.ReadNumberFromConsole<int>("Введите рост");
            var weight = ConsoleHelper.ReadNumberFromConsole<int>("Введите вес");

            var result = new QuestionnaireBase(surName, name, age, height, weight);

            return Option.Some(result);
        }
        catch (Exception e)
        {
            return Option.None<QuestionnaireBase>("Не удалось получить анкету с консоли. Ошибка: " + e);
        }
    }

    public Some PrintToConsole(QuestionnaireBase questionnaire)
    {
        try
        {
            var variants = new VariantsSource();

            foreach (var each in variants.GetVariants())
            {
                var text = questionnaire.GetFormattedText(each.Item2);

                ConsoleHelper.PrintValueWithMessage(each.Item1, text);
            }

            return Option.Some();
        }
        catch (Exception e)
        {
            return Option.None("Не удалось распечатать результаты в консоли. Ошибка: " + e);
        }
    }
}
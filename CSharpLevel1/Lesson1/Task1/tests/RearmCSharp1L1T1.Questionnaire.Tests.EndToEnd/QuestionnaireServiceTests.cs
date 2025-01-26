﻿using FluentAssertions;
using Kanadeiar.Common;
using Kanadeiar.Tests;
using Moq;
using RearmCSharp1L1T1.Questionnaire.PresentationLayer;
using RearmCSharp1L1T1.Questionnaire.PresentationLayer.Abstractions;
using RearmCSharp1L1T1.Questionnaire.UsefulLogicLayer.QuestionnaireModule;

namespace RearmCSharp1L1T1.Questionnaire.Tests.EndToEnd;

public class QuestionnaireServiceTests
{
    [Theory]
    [AutoMoqData]
    public void TestInputFromConsole(Mock<IConsole> mock, string surName, string name, int age, int height, int weight)
    {
        mock.SetupSequence(x => x.ReadLine())
            .Returns(surName).Returns(name).Returns(age.ToString).Returns(height.ToString).Returns(weight.ToString);
        ConsoleHelper.console = mock.Object;
        var sut = new QuestionnaireService();

        var actual = sut.InputFromConsole()
            .TryGetValue(x => throw new ApplicationException());

        var values = actual.deconstruct();
        values.Item1.Should().Be(surName);
        values.Item2.Should().Be(name);
        values.Item3.Should().Be(age);
        values.Item4.Should().Be(height);
        values.Item5.Should().Be(weight);
    }

    [Theory]
    [AutoMoqData]
    public void TestInputFromConsole_WhenError(Mock<IConsole> mock)
    {
        mock.Setup(x => x.ReadLine())
            .Returns(() => throw new IOException());
        ConsoleHelper.console = mock.Object;
        var sut = new QuestionnaireService();

        var actual = sut.InputFromConsole();

        actual.Should().BeOfType<None<QuestionnaireBase>>();
    }

    [Theory]
    [AutoMoqData]
    public void TestPrintToConsole(Mock<IConsole> mock, QuestionnaireBase questionnaire)
    {
        var expecteds = questionnaire.deconstruct();
        ConsoleHelper.console = mock.Object;
        var sut = new QuestionnaireService();

        var actual = sut.PrintToConsole(questionnaire);
        
        actual.Should().BeOfType<Some>();
        mock.Verify(x => x.WriteLine("Склеивание:"));
        mock.Verify(x => x.WriteLine("Форматирование:"));
        mock.Verify(x => x.WriteLine("Интерполяция:"));
        mock.Verify(x => x.WriteLine($"{expecteds.Item1} {expecteds.Item2} {expecteds.Item3} лет {expecteds.Item4} см {expecteds.Item5} кг"));
    }

    [Theory]
    [AutoMoqData]
    public void TestPrintToConsole_WhenError(Mock<IConsole> mock, QuestionnaireBase questionnaire)
    {
        mock.Setup(x => x.WriteLine(It.IsAny<string>()))
            .Throws(new IOException());
        ConsoleHelper.console = mock.Object;
        var sut = new QuestionnaireService();

        var actual = sut.PrintToConsole(questionnaire);

        actual.Should().BeOfType<None>();
    }
}
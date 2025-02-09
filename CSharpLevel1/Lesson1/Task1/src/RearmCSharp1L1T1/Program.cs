﻿using RearmCSharp1L1T1.Questionnaire.PresentationLayer;

ConsoleHelper.PrintHeader( "Задача № 1. Написать программу «Анкета».", "RearmToDDD.NET, C# Уровень 1, Лекция 1.");

var service = new QuestionnaireService();

var questionnaire = service.InputFromConsole()
    .Throw(none => new ApplicationException(none.Message));

service.PrintToConsole(questionnaire)
    .Throw(none => new ApplicationException(none.Message));

ConsoleHelper.PrintFooter();
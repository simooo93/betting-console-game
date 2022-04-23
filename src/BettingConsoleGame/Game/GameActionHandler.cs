﻿using BettingConsoleGame.Application.Actions;
using BettingConsoleGame.Application.Actions.ExitAction;
using BettingConsoleGame.Domain.Entities;
using BettingConsoleGame.Domain.ValueObjects;
using BettingConsoleGame.InputHandlers;
using BettingConsoleGame.OutputHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettingConsoleGame.Game;

public class GameActionHandler
{
    private readonly IActionReader actionReader;
    private readonly IActionResultOutputter actionResultOutputter;

    public GameActionHandler(IActionReader actionReader, IActionResultOutputter actionResultOutputter)
    {
        this.actionReader = actionReader;
        this.actionResultOutputter = actionResultOutputter;
    }

    public Result<IActionResult> Execute(Wallet wallet)
    {
        var actionParseResult = actionReader.GetNextAction();

        if (actionParseResult.Failed)
        {
            actionResultOutputter.OutputError(actionParseResult.Errors);
            return Result<IActionResult>.Fail(actionParseResult.Errors);
        }

        var action = actionParseResult.Value;
        var result = action.Execute(wallet);

        actionResultOutputter.Output(result);

        return result;
    }
}

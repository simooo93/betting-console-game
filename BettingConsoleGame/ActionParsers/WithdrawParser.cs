﻿using BettingConsoleGame.Application.Action.Interfaces;
using BettingConsoleGame.Application.Action.Types;

namespace BettingConsoleGame.ActionParsers;

public class WithdrawParser : ActionWithAmountParser
{
    public override IAction Parse(string[] actionParameters)
    {
        return new WithdrawAction(ParseAmount(actionParameters));
    }
}

﻿using BettingConsoleGame.Domain.ValueObjects;

namespace BettingConsoleGame.Application.Actions.Interfaces;

public interface IActionFactory
{
    IAction CreateBetAction(Money bet);

    IAction CreateDepositAction(Money deposit);

    IAction CreateWithdrawAction(Money withdraw);

    IAction CreateExitAction();
}

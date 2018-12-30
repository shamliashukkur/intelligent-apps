﻿using ContosoHelpdeskChatBot.Dialogs;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ContosoHelpdeskChatBot.Bots
{
    public class ContosoBot : IBot
    {
        private readonly DialogSet dialogs;

        public ContosoBot(BotAccessors botAccessors)
        {
            var dialogState = botAccessors.DialogStateAccessor;

            // compose dialogs
            dialogs = new DialogSet(dialogState);
                    
            dialogs.Add(MainDialog.Instance);
            dialogs.Add(new ChoicePrompt("choicePrompt"));

            BotAccessors = botAccessors;
        }

        public BotAccessors BotAccessors { get; }

        public async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (turnContext.Activity.Type == ActivityTypes.Message)
            {
                //initialize state if necessary
                //var state = await BotAccessors.ContosoBotStateStateAccessor.GetAsync(turnContext, () => new ContosoBotState(), cancellationToken);

                turnContext.TurnState.Add("BotAccessors", BotAccessors);

                var dialogCtx = await dialogs.CreateContextAsync(turnContext, cancellationToken);

                if (dialogCtx.ActiveDialog == null)
                {
                     await dialogCtx.BeginDialogAsync(MainDialog.Id, cancellationToken);
                }
                else
                {
                    await dialogCtx.ContinueDialogAsync(cancellationToken);
                }
                await BotAccessors.ConversationState.SaveChangesAsync(turnContext, false, cancellationToken);
            }
        }
    }
}

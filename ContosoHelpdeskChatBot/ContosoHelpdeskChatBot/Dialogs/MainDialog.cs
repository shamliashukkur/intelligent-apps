using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoHelpdeskChatBot.Dialogs
{
    public class MainDialog : WaterfallDialog
    {
        public MainDialog(string dialogId, IEnumerable<WaterfallStep> steps = null) : base(dialogId, steps)
        {
            AddStep(async (stepContext, cancellationToken) =>
            {
                return await stepContext.PromptAsync("choicePrompt",
                    new PromptOptions
                    {
                        Prompt = stepContext.Context.Activity.CreateReply("Welcome to **Contoso Helpdesk Chat Bot**.\n\nI am designed to use with mobile email app, make sure your replies do not contain signatures. \n\nFollowing is what I can help you with:"),
                        Choices = new[] { new Choice { Value = "Install Application" }, new Choice { Value = "Reset Password" }, new Choice { Value = "Request Local Admin" } }.ToList()
                    });
            });

            AddStep(async (stepContext, cancellationToken) =>
            {
                var response = (stepContext.Result as FoundChoice)?.Value;

                if (response == "Install Application")
                {
                    await stepContext.Context.SendActivityAsync("You want to install an application");
                }

                if (response == "Reset Password")
                {
                    await stepContext.Context.SendActivityAsync("You want to reset your password");
                }

                if (response == "Request Local Admin")
                {
                    await stepContext.Context.SendActivityAsync("You want to request local admin access!");
                }
                return await stepContext.NextAsync();
            });

            AddStep(async (stepContext, cancellationToken) => { return await stepContext.ReplaceDialogAsync(Id); });
        }

        public static string Id => "mainDialog";

        public static MainDialog Instance { get; } = new MainDialog(Id);

    }




}

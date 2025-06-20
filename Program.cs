using Microsoft.Toolkit.Uwp.Notifications;
using System;

/// <summary>
/// A .NET console application to display toast notifications.
/// </summary>
public class Program
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    /// <param name="args">Command-line arguments.</param>
    public static void Main(string[] args)
    {
        Console.WriteLine("/-------\\");
        Console.WriteLine("|Toaster|");
        Console.WriteLine("\\-------/");

        // --- Custom notification from arguments ---
        if (args.Length >= 2)
        {
            // Expecting title and content only.
            string title = args[0];
            string content = args[1];

            Console.WriteLine("\nShowing custom notification from arguments...");
            ShowCustomNotification(title, content);
            Console.WriteLine("Custom notification sent.");
        }
        else
        {
            Console.WriteLine("\nShowing the example notification...");
            ShowExampleNotification();
            Console.WriteLine("Example notification sent.");
            Console.WriteLine("\nTo send a custom notification, provide arguments:");
            Console.WriteLine("Usage: Toaster.exe \"Your Title\" \"Your content message.\"");
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    /// <summary>
    /// Shows the hardcoded example toast notification.
    /// </summary>
    private static void ShowExampleNotification()
    {
        try
        {
            new ToastContentBuilder()
                .AddArgument("action", "viewConversation")
                .AddArgument("conversationId", 9813)
                .AddText("Toaster")
                .AddText("Your toast is ready!")
                .Show();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error showing example notification: {ex.Message}");
        }
    }

    /// <summary>
    /// Shows a toast notification with custom content provided by the user.
    /// </summary>
    /// <param name="title">The title of the notification.</param>
    /// <param name="content">The main body text of the notification.</param>
    private static void ShowCustomNotification(string title, string content)
    {
        try
        {
            var toastBuilder = new ToastContentBuilder()
                .AddArgument("action", "viewDetails")
                .AddText(title)
                .AddText(content);

            toastBuilder.Show();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }
}

using System;
using System.Collections.Generic;

namespace Assi2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<PostProxy> Posts = new List<PostProxy>();

            PostProxy p1 = new PostProxy();
            Posts.Add(p1);

            PostProxy p2 = new PostProxy();
            Posts.Add(p2);

            PostProxy p3 = new PostProxy();
            Posts.Add(p3);

            Console.WriteLine("Welcome to the Social Network!\nEnter a command to get started, or 'help' to see a list of commands:");
            string command = Console.ReadLine() ?? "";

            while(command != "quit") {
                string[] commandArgs = command.Split(":");
                int postNum = -1;
                if(commandArgs.Length > 1) {
                    try {
                        postNum = int.Parse(commandArgs[1]);
                    } catch(FormatException) {
                        Console.WriteLine("Error: Invalid post number specified!");
                    }

                    if(postNum < 0 || postNum > Posts.Count) {
                        Console.WriteLine("Error: Invalid post number specified!");
                        break;
                    }
                }

                switch(commandArgs[0]) {
                    case "help":
                        Console.WriteLine("help\t\t\tDisplay this menu");
                        Console.WriteLine("new\t\t\tCreate a new post.");
                        Console.WriteLine("list\t\t\tList all posts.");
                        Console.WriteLine("download:[id]\t\tDownload a post.");
                        Console.WriteLine("settitle:[id]:[title]\tSet a post's title.");
                        Console.WriteLine("setbody:[id]:[body]\tSet a post's body.");
                        Console.WriteLine("view:[id]\t\tView a post.");
                        Console.WriteLine("quit\t\t\tQuit the application");
                        break;
                    case "new":
                        // Create a new proxy post and add it to the list
                        Posts.Add(new PostProxy());
                        Console.WriteLine("New post created.");
                        break;
                    case "list":
                        // List all posts with their status
                        for (int i = 0; i < Posts.Count; i++)
                        {
                            Console.WriteLine($"Post {i + 1}: {(Posts[i].IsDownloaded() ? "Downloaded" : "Not Downloaded")}");
                        }
                        break;
                    case "download":
                        // Simulate downloading a post
                        if (commandArgs.Length > 1 && postNum >= 0 && postNum < Posts.Count)
                        {
                            Posts[postNum].Download("Sample Title", "Sample Body");
                            Console.WriteLine($"Post {postNum + 1} downloaded.");
                        }
                        break;
                    case "settitle":
                        // Set title of a post
                        if (commandArgs.Length > 2 && postNum >= 0 && postNum < Posts.Count)
                        {
                            Posts[postNum].GetPost().Title = commandArgs[2];
                            Console.WriteLine($"Post {postNum + 1} title updated.");
                        }
                        break;
                    case "setbody":
                        // Set body of a post
                        if (commandArgs.Length > 2 && postNum >= 0 && postNum < Posts.Count)
                        {
                            Posts[postNum].GetPost().Body = commandArgs[2];
                            Console.WriteLine($"Post {postNum + 1} body updated.");
                        }
                        break;
                    case "view":
                        // View a specific post
                        if (postNum >= 0 && postNum < Posts.Count)
                        {
                            Posts[postNum].Print();
                        }
                        break;
                    default:
                        if (command != "")
                        {
                            Console.WriteLine("Invalid command.");
                        }
                        break;
                }

                command = Console.ReadLine() ?? "";
            }
        }
    }
}

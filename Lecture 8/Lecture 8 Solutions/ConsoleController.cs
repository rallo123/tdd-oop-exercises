﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_8_Solutions
{
    public class ConsoleController
    {
        Dictionary<string, Action<string>> _commands = new Dictionary<string, Action<string>>()
        {
            ["echo"] = (text) => Console.WriteLine(text),
            ["reverse"] = (text) =>
            {
                char[] charArray = text.ToCharArray();
                Array.Reverse(charArray);
                Console.WriteLine(charArray);
            },
            ["greet"] = (name) => Console.WriteLine($"Hello {name}")
        };

        public void HandleInput(string input)
        {
            if (input == null)
                throw new ArgumentNullException();

            string[] commandParts = parseCommand(input);

            if (commandParts[0] == null)
            {
                Console.WriteLine("Please provide a command");
            }
            else if (!_commands.ContainsKey(commandParts[0].ToLower()))
            {
                Console.WriteLine($"Command {commandParts[0]} not found");
            }
            else if (commandParts[1] == null)
            {
                Console.WriteLine("Please provide a command argument");
            }
            else _commands[commandParts[0].ToLower()].Invoke(commandParts[1]);
        }

        public void AddCommand(string name, Action<string> action)
        {
            if (_commands.ContainsKey(name.ToLower()))
                throw new ArgumentException();
            _commands.Add(name.ToLower(), action);
        }

        public void RemoveCommand(string name)
        {
            _commands.Remove(name.ToLower());
        }

        private string[] parseCommand(string rawCommand)
        {
            string command;
            string arg;
            string[] commandParts = rawCommand.Split(' ', 2);

            command = !string.IsNullOrEmpty(rawCommand) ? commandParts[0] : null;
            arg = commandParts.Length > 1 ? commandParts[1] : null;

            return new[] { command, arg };
        }
    }
}
